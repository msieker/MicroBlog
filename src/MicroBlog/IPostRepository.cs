using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Dropbox.Api;
using Dropbox.Api.Files;

using Microsoft.Extensions.Options;

using NLog;

namespace MicroBlog
{
    public interface IPostRepository
    {
        Task Refresh();
        Post GetBySlug(string slug);
        Post GetDraftBySlug(string slug);

        IList<string> Categories();

        IList<Post> AllPosts { get; }
        IList<Post> Drafts { get; }

        Task<byte[]> GetMedia(string path);
    }

    public abstract class PostRepositoryBase : IPostRepository
    {
        public abstract IList<Post> AllPosts { get; }
        public abstract IList<Post> Drafts { get; }

        public abstract Task Refresh();

        public Post GetBySlug(string slug)
        {
            return AllPosts.FirstOrDefault(s => s.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));
        }

        public Post GetDraftBySlug(string slug)
        {
            return Drafts.FirstOrDefault(s => s.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));
        }

        public abstract Task<byte[]> GetMedia(string path);

        public IList<string> Categories()
        {
            return AllPosts.Select(c => c.Category).Distinct().OrderBy(c => c).ToList();
        }
    }

    public class DropboxPostRepository : PostRepositoryBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly ConcurrentDictionary<string, Post> _posts;
        private readonly DropboxClient _client;
        private string _cursor;

        public DropboxPostRepository(IOptions<DropboxSettings> dropboxSettings)
        {
            _posts = new ConcurrentDictionary<string, Post>();
            _client = new DropboxClient(dropboxSettings.Value.AccessToken);
        }

        public async Task<bool> LoadPosts()
        {
            Logger.Info($"Loading all files from Dropbox");
            var files = await _client.Files.ListFolderAsync("/posts");
            _cursor = files.Cursor;
            foreach (var entry in files.Entries)
            {
                if (!entry.IsFile || !entry.Name.EndsWith(".md", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                Logger.Info($"Processing {entry.PathLower}");
                var post = await MakePostFromEntry(entry);
                _posts[post.File] = post;
            }

            return true;
        }

        private async Task<Post> MakePostFromEntry(Metadata entry)
        {
            var metadata = entry.AsFile;
            var response = await _client.Files.DownloadAsync(metadata.PathLower);
            var content = await response.GetContentAsStringAsync();
            return new Post(metadata.PathLower, content, metadata.ServerModified);
        }

        public override IList<Post> Drafts
        {
            get
            {
                return _posts.Values.Where(p => p.IsDraft).OrderByDescending(p => p.Date).ToList();
            }
        }

        public override async Task Refresh()
        {
            if (string.IsNullOrEmpty(_cursor))
            {
                await LoadPosts();
                return;
            }
            Logger.Info($"Checking for updates");
            var changes = await _client.Files.ListFolderContinueAsync(_cursor);
            foreach (var entry in changes.Entries)
            {
                if (!entry.PathLower.EndsWith(".md", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (entry.IsDeleted)
                {
                    Logger.Info($"Deleting {entry.PathLower}");
                    Post removedPost;
                    _posts.TryRemove(entry.PathLower, out removedPost);
                }
                else if (entry.IsFile)
                {
                    Logger.Info($"Processing {entry.PathLower}");
                    var post = await MakePostFromEntry(entry);
                    _posts[post.File] = post;
                }
            }
            _cursor = changes.Cursor;
        }

        public override async Task<byte[]> GetMedia(string path)
        {
            try
            {
                var file = await _client.Files.DownloadAsync("/media/" + path);
                var contents = await file.GetContentAsByteArrayAsync();
                return contents;
            }
            catch (ApiException<DownloadError> ex)
            {
                Logger.Error(ex, "Exception from Dropbox when getting media");
                return null;
            }
        }

        public override IList<Post> AllPosts
        {
            get
            {
                return _posts.Values.Where(p => !p.IsDraft).OrderByDescending(p => p.Date).ToList();
            }
        }

    }
    public class LocalPostRepository : PostRepositoryBase
    {
        private readonly Settings _settings;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly ConcurrentDictionary<string, Post> _posts;

        public LocalPostRepository(IOptions<Settings> settings)
        {
            _settings = settings.Value;
            Logger.Info("Using Local source for posts");
            _posts = new ConcurrentDictionary<string, Post>();
            ScanPosts();

            var rootPath = Path.Combine(_settings.ContentPath, "Posts");
            var watcher = new FileSystemWatcher(rootPath);


            watcher.IncludeSubdirectories = true;
            watcher.Deleted += (sender, args) =>
            {
                Logger.Info($"File deleted: {args.FullPath}");
                Post oldPost;
                _posts.TryRemove(args.FullPath, out oldPost);
            };

            watcher.Created += (sender, args) =>
            {
                Logger.Info($"File created: {args.FullPath}");
            };

            watcher.Changed += (sender, args) =>
            {
                Logger.Info($"File changed: {args.FullPath}");
                var content = File.ReadAllText(args.FullPath);
                _posts[args.FullPath] = new Post(args.FullPath, content, File.GetCreationTime(args.FullPath));
            };

            watcher.EnableRaisingEvents = true;
            Logger.Info($"Watching for changes: {rootPath}");
        }

        private void ScanPosts()
        {
            var rootPath = Path.Combine(_settings.ContentPath, "Posts");
            Logger.Info("Looking for posts in {0}", rootPath);
            foreach (var f in Directory.GetFiles(rootPath))
            {
                var content = File.ReadAllText(f);
                _posts[f] = new Post(f, content, File.GetCreationTime(f));
            }
        }

        public override IList<Post> Drafts { get { return _posts.Values.Where(p => p.IsDraft).OrderByDescending(p => p.Date).ToList(); } }

        public override Task Refresh()
        {
            _posts.Clear();
            ScanPosts();
            return Task.CompletedTask;
        }

        public override async Task<byte[]> GetMedia(string path)
        {
            try
            {
                using (var ms = new MemoryStream())
                using (var f = File.Open(Path.Combine(_settings.ContentPath, "media", path), FileMode.Open, FileAccess.Read))
                {
                    await f.CopyToAsync(ms);
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Error reading media {path}");
                return null;
            }
        }

        public override IList<Post> AllPosts { get { return _posts.Values.Where(p => !p.IsDraft).OrderByDescending(p => p.Date).ToList(); } }

    }
}

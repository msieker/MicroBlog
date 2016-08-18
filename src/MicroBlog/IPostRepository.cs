using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Dropbox.Api;

using Microsoft.Extensions.Options;

using NLog;

namespace MicroBlog
{
    public interface IPostRepository
    {
        Post GetBySlug(string slug);
        Post GetDraftBySlug(string slug);

        IEnumerable<string> Categories();

        IEnumerable<Post> AllPosts { get; }
        IEnumerable<Post> Drafts { get; }

        Stream GetMedia(string path);
    }

    public abstract class PostRepositoryBase : IPostRepository
    {
        public abstract IEnumerable<Post> AllPosts { get; }
        public abstract IEnumerable<Post> Drafts { get; }

        public Post GetBySlug(string slug)
        {
            return AllPosts.FirstOrDefault(s => s.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));
        }

        public Post GetDraftBySlug(string slug)
        {
            return Drafts.FirstOrDefault(s => s.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));
        }

        public abstract Stream GetMedia(string path);

        public IEnumerable<string> Categories()
        {
            return AllPosts.Select(c => c.Category).Distinct().OrderBy(c => c);
        }
    }

    public class DropboxPostRepository : PostRepositoryBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly ConcurrentBag<Post> _posts;
        private readonly DropboxClient _client;

        public DropboxPostRepository(IOptions<DropboxSettings> dropboxSettings)
        {
            _posts = new ConcurrentBag<Post>();
            _client = new DropboxClient(dropboxSettings.Value.AccessToken);
        }

        public async Task<bool> LoadPosts()
        {
            var files = await _client.Files.ListFolderAsync("/posts");

            foreach (var entry in files.Entries)
            {
                if (!entry.IsFile || !entry.Name.EndsWith(".md", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                var metadata = entry.AsFile;
                var response = await _client.Files.DownloadAsync(metadata.PathLower);
                var content = await response.GetContentAsStringAsync();
                var post = new Post(metadata.Name, content, metadata.ServerModified);
                _posts.Add(post);
            }

            return true;
        }

        public override IEnumerable<Post> Drafts
        {
            get
            {
                return _posts.Where(p => p.IsDraft).OrderByDescending(p => p.Date);
            }
        }

        public override Stream GetMedia(string path)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Post> AllPosts
        {
            get
            {
                return _posts.Where(p => !p.IsDraft).OrderByDescending(p => p.Date);
            }
        }

    }
    public class LocalPostRepository : PostRepositoryBase
    {
        private readonly Settings _settings;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly new ConcurrentDictionary<string, Post> _posts;

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

        public override IEnumerable<Post> Drafts { get { return _posts.Values.Where(p => p.IsDraft).OrderByDescending(p => p.Date); } }

        public override Stream GetMedia(string path)
        {
            try
            {
                return File.Open(Path.Combine(_settings.ContentPath,"media", path), FileMode.Open, FileAccess.Read);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Error reading media {path}");
                return null;
            }
        }

        public override IEnumerable<Post> AllPosts { get { return _posts.Values.Where(p => !p.IsDraft).OrderByDescending(p => p.Date); } }

    }
}

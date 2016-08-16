using System;
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
        Post GetByFileName(string fileName);

        IEnumerable<string> Categories();
        IEnumerable<Post> AllPosts { get; }

        void AddOrUpdatePost(Post post);
    }

    public class DropboxPostRepository : IPostRepository
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IList<Post> _posts;
        private DropboxSettings _dropboxSettings;
        private DropboxClient _client;

        public DropboxPostRepository(IOptions<DropboxSettings> dropboxSettings)
        {
            _posts = new List<Post>();
            _dropboxSettings = dropboxSettings.Value;
            _client = new DropboxClient(_dropboxSettings.AccessToken);
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

        public Post GetBySlug(string slug)
        {
            return AllPosts.FirstOrDefault(s => s.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));
        }

        public Post GetDraftBySlug(string slug)
        {
            throw new NotImplementedException();
        }

        public Post GetByFileName(string fileName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> Categories()
        {
            return _posts.Select(c => c.Category).Distinct().OrderBy(c => c);
        }

        public IEnumerable<Post> AllPosts { get { return _posts.Where(p => !p.IsDraft).OrderByDescending(p => p.Date); } }
        public void AddOrUpdatePost(Post post)
        {
            throw new NotImplementedException();
        }
    }
    public class LocalPostRepository : IPostRepository
    {
        private readonly Settings _settings;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IList<Post> _posts;

        public LocalPostRepository(IOptions<Settings> settings)
        {
            _settings = settings.Value;
            Logger.Info("Using Local source for posts");
            _posts = new List<Post>();
            ScanPosts();
        }

        private void ScanPosts()
        {
            Logger.Info("Looking for posts in {0}", Path.Combine(_settings.ContentPath, "Posts"));
            foreach (var f in Directory.GetFiles(Path.Combine(_settings.ContentPath, "Posts")))
            {
                var content = File.ReadAllText(f);
                _posts.Add(new Post(f, content, File.GetCreationTime(f)));
            }
        }

        public IEnumerable<string> Categories()
        {
            return _posts.Select(c => c.Category).Distinct().OrderBy(c => c);
        }

        public Post GetBySlug(string slug)
        {
            return AllPosts.FirstOrDefault(s => s.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));
        }

        public Post GetDraftBySlug(string slug)
        {
            throw new NotImplementedException();
        }

        public Post GetByFileName(string fileName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> AllPosts { get { return _posts.OrderByDescending(p => p.Date); } }

        public void AddOrUpdatePost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}

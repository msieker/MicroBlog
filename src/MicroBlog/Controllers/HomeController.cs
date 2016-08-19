using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace MicroBlog.Controllers
{
    public class PostListModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
    }
    public class HomeController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly IPostRepository _postRepository;
        private readonly Settings _settings;
        public HomeController(IPostRepository postRepository, IOptions<Settings> settings, IMemoryCache cache)
        {
            _postRepository = postRepository;
            _cache = cache;
            _settings = settings.Value;
        }

        [Route("webhook")]
        public async Task<IActionResult> Webhook(string challenge)
        {
            if (!string.IsNullOrEmpty(challenge))
            {
                return Content(challenge);
            }
            else
            {
                Task.Run(() => _postRepository.Refresh());
                return NoContent();
            }
        }

        [Route("media/{*mediaPath}")]
        public async Task<IActionResult> Media(string mediaPath)
        {
            byte[] content;
            if (!_cache.TryGetValue("media-" + mediaPath, out content))
            {
                content = await _postRepository.GetMedia(mediaPath);
                if (content == null)
                {
                    return NotFound();
                }
                _cache.Set("media-" + mediaPath, content);
            }
            string contentType;
            new FileExtensionContentTypeProvider().TryGetContentType(mediaPath, out contentType);
            var mimeType = contentType ?? "application/octet-stream";
            return File(content, mimeType);
        }

        [Route("drafts")]
        [Route("drafts/page/{pageNum}")]
        public IActionResult Drafts(int? pageNum)
        {
            var posts = _postRepository.Drafts;
            var model = MakeModelFromPosts(null, pageNum, posts);
            return View("Index", model);
        }

        [Route("")]
        [Route("page/{pageNum}")]
        [Route("category/{category}")]
        [Route("category/{category}/{pageNum}")]
        public IActionResult Index(string category, int? pageNum)
        {
            var posts = _postRepository.AllPosts;
            var model = MakeModelFromPosts(category, pageNum, posts);
            return View(model);
        }

        private PostListModel MakeModelFromPosts(string category, int? pageNum, IList<Post> posts)
        {
            var model = new PostListModel();
            var postCount = posts.Count();
            model.PageCount = (int)Math.Ceiling(postCount / (float)_settings.PageSize);
            model.CurrentPage = pageNum ?? 1;

            model.HasPreviousPage = model.CurrentPage > 1;
            model.HasNextPage = model.CurrentPage < model.PageCount;

            if (!string.IsNullOrEmpty(category))
            {
                posts = posts.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (pageNum.HasValue)
            {
                posts = posts.Skip((pageNum.Value - 1) * _settings.PageSize).ToList();
            }

            model.Posts = posts.Take(_settings.PageSize).ToList();
            return model;
        }
    }
}

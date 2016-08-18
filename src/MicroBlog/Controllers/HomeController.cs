using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace MicroBlog.Controllers
{
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

        [Route("media/{*mediaPath}")]
        public IActionResult Media(string mediaPath)
        {
            byte[] content;
            if (!_cache.TryGetValue("media-" + mediaPath, out content))
            {
                using(var stream =  _postRepository.GetMedia(mediaPath))
                using (MemoryStream ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    content = ms.ToArray();
                }                
                
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
            if (pageNum.HasValue)
            {
                posts = posts.Skip(pageNum.Value * _settings.PageSize);
            }

            posts = posts.Take(_settings.PageSize);
            return View("Index", posts);
        }

        [Route("")]
        [Route("page/{pageNum}")]
        [Route("category/{category}")]
        [Route("category/{category}/{pageNum}")]
        public IActionResult Index(string category, int? pageNum)
        {
            var posts = _postRepository.AllPosts;

            if (!string.IsNullOrEmpty(category))
            {
                posts = posts.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
            }

            if (pageNum.HasValue)
            {
                posts = posts.Skip(pageNum.Value * _settings.PageSize);
            }

            posts = posts.Take(_settings.PageSize);
            return View(posts);
        }
    }
}

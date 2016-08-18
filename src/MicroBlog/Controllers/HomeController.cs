using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MicroBlog.Controllers
{    
    public class HomeController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly Settings _settings;
        public HomeController(IPostRepository postRepository, IOptions<Settings> settings)
        {
            _postRepository = postRepository;
            _settings = settings.Value;
        }

        [Route("")]
        [Route("page/{pageNum}")]
        [Route("{category}")]
        [Route("{category}/{pageNum}")]
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroBlog.Controllers
{
    [Route("post")]
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [Route("{slug}")]
        public IActionResult ViewPost(string slug)
        {
            var post = _postRepository.GetBySlug(slug);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
    }
}

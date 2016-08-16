using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MicroBlog.Controllers
{    
    public class HomeController : Controller
    {
        private readonly IPostRepository _postRepository;
        
        public HomeController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

 
        public IActionResult Index()
        {
            return View(_postRepository.AllPosts);
        }
    }
}

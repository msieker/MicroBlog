using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace MicroBlog.Components
{
    public class PostViewComponentModel
    {
        public Post Post { get; set; }
        public bool ShowComments { get; set; }
    }
    public class PostViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Post post, bool showComments)
        {
            return View(new PostViewComponentModel
            {
                Post = post,
                ShowComments = showComments
            });
        }
    }
}

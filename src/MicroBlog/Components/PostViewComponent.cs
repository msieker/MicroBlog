using System;
using Markdig;
using Markdig.Renderers;
using Markdig.Renderers.Html.Inlines;
using Markdig.Syntax.Inlines;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MicroBlog.Components
{
    public class PostViewComponentModel
    {
        public Post Post { get; set; }
        public string Content { get; set; }
        public bool ShowComments { get; set; }
    }

    public class MediaLinkExtension : IMarkdownExtension
    {
        private readonly Func<string, string> _urlResolver;

        public MediaLinkExtension(Func<string, string> urlResolver)
        {
            _urlResolver = urlResolver;
        }
        public void Setup(MarkdownPipelineBuilder pipeline)
        {

        }

        public void Setup(IMarkdownRenderer renderer)
        {
            var htmlRenderer = renderer as HtmlRenderer;
            if (htmlRenderer != null)
            {
                var inlineRenderer = htmlRenderer.ObjectRenderers.FindExact<LinkInlineRenderer>();
                if (inlineRenderer != null)
                {
                    inlineRenderer.TryWriters.Remove(TryMediaLinkRenderer);
                    inlineRenderer.TryWriters.Add(TryMediaLinkRenderer);
                }
            }
        }

        private bool TryMediaLinkRenderer(HtmlRenderer renderer, LinkInline linkInline)
        {
            if (linkInline.IsImage && linkInline.Url.StartsWith("{media}", StringComparison.OrdinalIgnoreCase))
            {
                var newUrl = _urlResolver(linkInline.Url.Substring(7));
                renderer.Write($"<img src=\"{newUrl}\" title=\"{linkInline.Title}\" />");
                return true;
            }
            //if (linkInline.Url.StartsWith("{slug}", StringComparison.OrdinalIgnoreCase))
            //{
            //    var newUrl = _urlResolver(linkInline.Url.Substring(6));
            //    renderer.Write($"<a href=\"{newUrl}\">");
            //    renderer.WriteChildren(linkInline);
            //    renderer.Write("</a>");
            //    return true;
            //}
            return false;
        }
    }

    public class SlugLinkExtension : IMarkdownExtension
    {
        private readonly Func<string, string> _urlResolver;

        public SlugLinkExtension(Func<string, string> urlResolver)
        {
            _urlResolver = urlResolver;
        }
        public void Setup(MarkdownPipelineBuilder pipeline)
        {

        }

        public void Setup(IMarkdownRenderer renderer)
        {
            var htmlRenderer = renderer as HtmlRenderer;
            if (htmlRenderer != null)
            {
                var inlineRenderer = htmlRenderer.ObjectRenderers.FindExact<LinkInlineRenderer>();
                if (inlineRenderer != null)
                {
                    inlineRenderer.TryWriters.Remove(TrySlugLinkRenderer);
                    inlineRenderer.TryWriters.Add(TrySlugLinkRenderer);
                }
            }
        }

        private bool TrySlugLinkRenderer(HtmlRenderer renderer, LinkInline linkInline)
        {
            if (linkInline.Url.StartsWith("{slug}", StringComparison.OrdinalIgnoreCase))
            {
                var newUrl = _urlResolver(linkInline.Url.Substring(6));
                renderer.Write($"<a href=\"{newUrl}\">");
                renderer.WriteChildren(linkInline);
                renderer.Write("</a>");
                return true;
            }
            return false;
        }
    }

    public class PostViewComponent : ViewComponent
    {
        private readonly IMemoryCache _cache;

        public PostViewComponent(IMemoryCache cache)
        {
            _cache = cache;
        }

        public IViewComponentResult Invoke(Post post, bool showComments)
        {
            string postHtml;

            if (!_cache.TryGetValue("post-" + post.Hash, out postHtml))
            {
                var pipelineBuilder = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions();

                var slugResolver = new SlugLinkExtension(s => Url.Action("ViewPost", "Post", new { slug = s }));
                var mediaResolver = new MediaLinkExtension(s => Url.Action("Media", "Home") + s);
                pipelineBuilder.Extensions.AddIfNotAlready(slugResolver);
                pipelineBuilder.Extensions.AddIfNotAlready(mediaResolver);
                var pipeline = pipelineBuilder.Build();
                postHtml = Markdown.ToHtml(post.Markdown, pipeline);

                _cache.Set("post-" + post.Hash, postHtml);
            }
            return View(new PostViewComponentModel
            {
                Post = post,
                Content = postHtml,
                ShowComments = showComments
            });
        }
    }
}

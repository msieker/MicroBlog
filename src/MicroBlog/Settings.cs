using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroBlog
{
    public enum PostSource
    {
        Local,
        Dropbox
    }

    public class DropboxSettings
    {
        public string AccessToken { get; set; }
        public string AppKey { get; set; }
        public string AppSecret { get; set; }
    }

    public class Settings
    {
        public string ContentPath { get; set; }
        public PostSource PostSource { get; set; }
        public int PageSize { get; set; }
        public string BlogTitle { get; set; }
        public string DisqusShortName { get; set; }
    }
}

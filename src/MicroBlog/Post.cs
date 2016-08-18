using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

using Markdig;

using NLog;

namespace MicroBlog
{
    public class Post
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public Post(string file, string content, DateTime modified)
        {
            Metadata = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            Logger.Info($"Loading post from {file}");
            File = file;
            Slug = Path.GetFileNameWithoutExtension(file);
            ProcessContent(content);
            LoadMetadata(modified);
        }

        private void ProcessContent(string content)
        {
            var reader = new StringReader(content);
            while (true)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrEmpty(line.Trim()))
                {
                    break;
                }
                var valueSep = line.IndexOf(":");
                if (valueSep > 0)
                {
                    var key = line.Substring(0, valueSep).Trim();
                    var value = line.Substring(valueSep + 1).Trim();
                    Logger.Info($"Found metadata: {key}: {value}");
                    Metadata[key] = value;
                }
            }
            Markdown = reader.ReadToEnd();
        }

        private void LoadMetadata(DateTime modified)
        {
            string value;
            Title = Metadata.TryGetValue("title", out value) ? value : File;
            Category = Metadata.TryGetValue("category", out value) ? value : "";
            var dateStr = Metadata.TryGetValue("Date", out value) ? value : "";
            if (!string.IsNullOrEmpty(dateStr))
            {
                Date = DateTimeOffset.Parse(dateStr);
            }
            else
            {
                Date = modified;
            }
            IsDraft = (Metadata.TryGetValue("Status", out value) ? value : "").Equals("draft", StringComparison.OrdinalIgnoreCase);
        }

        public Dictionary<string, string> Metadata { get; private set; }
        public string File { get; private set; }
        public string Slug { get; private set; }
        public string Title { get; private set; }
        public string Category { get; private set; }
        public DateTimeOffset Date { get; private set; }
        public bool IsDraft { get; private set; }
        public string Markdown { get; private set; }       

        private string _hash;
        public string Hash
        {
            get
            {
                if (string.IsNullOrEmpty(_hash))
                {
                    var sb = new StringBuilder();
                    sb.Append(File)
                        .Append(Slug)
                        .Append(Title)
                        .Append(Category)
                        .Append(Date)
                        .Append(IsDraft)
                        .Append(Markdown);

                    using (var sha = SHA256.Create())
                    {
                        var hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(sb.ToString()));
                        _hash = Convert.ToBase64String(hashBytes);

                    }
                }
                return _hash;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedditCats.Models
{
    public class RedditPost
    {
        public string Author { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
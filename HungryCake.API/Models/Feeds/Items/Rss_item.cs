using System;

namespace HungryCake.API.Models
{
    public class Rss_item : Feed_item
    {
        public string Content { get; set; }
        public DateTime Posted { get; set; }
    }
}
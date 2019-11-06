using System;

namespace HungryCake.API.Models
{
    public class Html_item : Feed_item
    {
        public string Content { get; set; }
        public DateTime? Posted { get; set; }
    }
}
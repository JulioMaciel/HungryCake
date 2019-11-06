using System;

namespace HungryCake.API.Models
{
    public class Twitter_item : Feed_item
    {
        public int Likes { get; set; }
        public int Comments { get; set; }
        public int Retweets { get; set; }
        public DateTime Posted { get; set; }
    }
}
using System;

namespace HungryCake.API.Models
{
    public class Reddit_item : Feed_item
    {
        public DateTime Posted { get; set; }
        public int Upvotes { get; set; }
        public int AvgUpvotes { get; set; }
        public int Comments { get; set; }        
    }
}
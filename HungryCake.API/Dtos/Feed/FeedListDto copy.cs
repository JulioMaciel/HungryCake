using System;
using System.Collections.Generic;

namespace HungryCake.API.Dtos
{
    public class FeedListDto
    {
        public string Id { get; set; }
        public string FeedName { get; set; }
        public string UrlSite { get; set; }
        public string Topic { get; set; }
    }
}
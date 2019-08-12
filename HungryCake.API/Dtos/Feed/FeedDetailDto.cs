using System;
using System.Collections.Generic;

namespace HungryCake.API.Dtos
{
    public class FeedDetailDto
    {
        public int Id { get; set; }
        public string FeedName { get; set; }
        public string UrlSite { get; set; }
        public string UrlFeed { get; set; }
        public string Topic { get; set; }
        public string Language { get; set; }
        public bool isWorking { get; set; }
    }
}
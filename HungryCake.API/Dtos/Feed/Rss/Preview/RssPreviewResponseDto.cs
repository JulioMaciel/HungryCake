using System.Collections.Generic;
using HungryCake.API.Controllers;
using HungryCake.API.Helpers;

namespace HungryCake.API.Dtos.Feed
{
    public class RssPreviewResponseDto
    {
        public IEnumerable<NewsItem> FeedList { get; set; }
    }
}
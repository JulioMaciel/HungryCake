using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HungryCake.API.Models
{
    public class FeedRss : Feed
    {
        public string Name { get; set; }
        public string UrlRss { get; set; }
        public string UrlSite { get; set; }
        public string Description { get; set; }
        public bool HasPayWall { get; set; }
        public IEnumerable<ColumnRss> ColumnsRss { get; set; }
    }
}
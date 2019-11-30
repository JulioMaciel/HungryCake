using System.Collections.Generic;

namespace HungryCake.API.Models
{
    public class FeedRegex : Feed
    {
        public string Name { get; set; }
        public string UrlSite { get; set; }
        public string Description { get; set; }
        public bool LoadedLastTime { get; set; }
        public bool HasPayWall { get; set; }
        public string PatternTitle { get; set; }
        public string PatternLink { get; set; }
        public IEnumerable<ColumnRegex> ColumnsRegex { get; set; }
    }
}
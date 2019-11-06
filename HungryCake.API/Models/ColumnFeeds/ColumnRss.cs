using HungryCake.API.Helpers;

namespace HungryCake.API.Models
{
    public class ColumnRss : ColumnParent
    {
        public FeedRss FeedRss { get; set; }
        public int FeedRssId { get; set; }
    }
}
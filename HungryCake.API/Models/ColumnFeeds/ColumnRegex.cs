using HungryCake.API.Helpers;

namespace HungryCake.API.Models
{
    public class ColumnRegex : ColumnParent
    {
        public FeedRegex FeedRegex { get; set; }
        public int FeedRegexId { get; set; }
    }
}
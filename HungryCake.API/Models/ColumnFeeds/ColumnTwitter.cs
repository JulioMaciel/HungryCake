using HungryCake.API.Helpers;

namespace HungryCake.API.Models
{
    public class ColumnTwitter : ColumnParent
    {
        public FeedTwitter FeedTwitter { get; set; }
        public int FeedTwitterId { get; set; }
    }
}
using HungryCake.API.Helpers;

namespace HungryCake.API.Models
{
    public class ColumnReddit : ColumnParent
    {
        public FeedReddit FeedReddit { get; set; }
        public int FeedRedditId { get; set; }
        public RedditTopRange TopRange { get; set; }
    }
}
using HungryCake.API.Helpers;

namespace HungryCake.API.Models
{
    public class ColumnHtml : ColumnParent
    {
        public FeedHtml FeedHtml { get; set; }
        public int FeedHtmlId { get; set; }
    }
}
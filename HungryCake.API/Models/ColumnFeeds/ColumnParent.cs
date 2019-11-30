using HungryCake.API.Helpers;

namespace HungryCake.API.Models
{
    public abstract class ColumnParent
    {
        public Column Column { get; set; }
        public int ColumnId { get; set; }
        public Filter Filter { get; set; }
        public int FilterId { get; set; }
        public FeedType Type { get; set; }
    }
}
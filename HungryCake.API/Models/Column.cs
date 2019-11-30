using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HungryCake.API.Helpers;

namespace HungryCake.API.Models
{
    public class Column
    {
        [Required]
        public int Id { get; set; }
        public Grid Grid { get; set; }
        public int GridId { get; set; }
        public string Name { get; set; } = "Untitled Column";
        public IEnumerable<ColumnRegex> FeedsRegex { get; set; }
        public IEnumerable<ColumnReddit> FeedsReddit { get; set; }
        public IEnumerable<ColumnRss> FeedsRss { get; set; }
        public IEnumerable<ColumnTwitter> FeedsTwitter { get; set; }
        public int RowPos { get; set; } = 1;
        public int ColumnPos { get; set; } = 1;
        public int MaxItems { get; set; } = 50;
        // public bool ShowRollbar { get; set; } = false;
        // public bool ShowImage { get; set; } = false;
        public bool ShowSummary { get; set; } = false;
        // public bool ShowDateTime { get; set; } = false;
        // public string DateTimeFormat { get; set; } = "dd/mm/yy hh:MM:ss";
        public bool ShowFeedIcon { get; set; } = true;
    }
}
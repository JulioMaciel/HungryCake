using System.ComponentModel.DataAnnotations;

namespace HungryCake.API.Models
{
    public class UserColumn
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public UserGrid UserGrid { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FeedsJSON { get; set; }
        public int Width { get; set; }
        public int QuantItems { get; set; }
        public bool ShowRollbar { get; set; }
        public bool ShowFeedPicture { get; set; }
        public bool ShowSummary { get; set; }
        public bool ShowDateTime { get; set; }
        public string DatetimeFormat { get; set; }
        public int GridPositionRow { get; set; }
        public int GridPositionColumn { get; set; }
    }
}
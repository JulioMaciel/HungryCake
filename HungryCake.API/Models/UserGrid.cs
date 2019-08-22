using System.ComponentModel.DataAnnotations;

namespace HungryCake.API.Models
{
    public class UserGrid
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public int QuantColumns { get; set; }
        [Required]
        public int QuantRows { get; set; }
        [Required]
        public int FontSize { get; set; }
        [Required]
        public int Template { get; set; }
    }
}
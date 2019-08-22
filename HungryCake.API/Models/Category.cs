using System.ComponentModel.DataAnnotations;

namespace HungryCake.API.Models
{
    public class Category
    {
        [Required]
        public int Id { get; set; }
        public Category ParentId { get; set; }
        [Required]
        public string English { get; set; }
        public string Portuguese { get; set; }
        public string Spanish { get; set; }
    }
}
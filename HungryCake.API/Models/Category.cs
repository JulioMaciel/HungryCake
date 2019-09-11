using System;
using System.ComponentModel.DataAnnotations;

namespace HungryCake.API.Models
{
    public class Category
    {
        public int Id { get; set; }
        public Category Parent { get; set; }
        public Nullable<int> ParentId { get; set; }
        [Required]
        public string English { get; set; }
        public string Portuguese { get; set; }
        public string Spanish { get; set; }
    }
}
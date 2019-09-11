using System.ComponentModel.DataAnnotations;
using HungryCake.API.Models;

namespace HungryCake.API.Dtos
{
    public class CategoryAddDto
    {
        [Required]
        public Category Parent { get; set; }
        [Required]
        public string English { get; set; }
        public string Portuguese { get; set; }
        public string Spanish { get; set; }
    }
}
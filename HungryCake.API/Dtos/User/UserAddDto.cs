using System;
using System.ComponentModel.DataAnnotations;

namespace HungryCake.API.Dtos
{
    public class UserAddDto
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 8 characters.")]
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }

        public UserAddDto() 
        {
            Created = DateTime.Now;
            LastActive = DateTime.Now;
        }
    }
}
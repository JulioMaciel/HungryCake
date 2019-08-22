using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HungryCake.API.Helpers.Enums;
using Microsoft.AspNetCore.Identity;

namespace HungryCake.API.Models
{
    public class Feed
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public Language Language { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public User Creator { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public bool LoadedLastTime { get; set; }
        public bool HasPayWall { get; set; }
    }
}
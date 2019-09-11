using System;
using System.ComponentModel.DataAnnotations;
using HungryCake.API.Helpers.Enums;
using HungryCake.API.Models;

namespace HungryCake.API.Dtos
{
    public class FeedRssAddDto
    {
        [Required]
        public string Name { get; set; }
        public int CreatorId { get; set; }
        // public User Creator { get; set; }
        public DateTime Created { get; private set; } = DateTime.Now;
        public string UrlSite { get; set; }
        public string Url { get; set; }
        public int CategoryId { get; set; }
        // public Category Category { get; set; }
        public int Language { get; set; }

    }
}
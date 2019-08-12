using System;
using System.ComponentModel.DataAnnotations;
using HungryCake.API.Models;

namespace HungryCake.API.Dtos
{
    public class FeedCreateDto
    {
        [Required]
        public string FeedName { get; set; }
        public User Creator { get; set; }
        public DateTime Created { get; set; }
        public string UrlSite { get; set; }
        public string UrlFeed { get; set; }
        public string Topic { get; set; }
        public string Language { get; set; }

        public FeedCreateDto() 
        {
            Created = DateTime.Now;
        }
    }
}
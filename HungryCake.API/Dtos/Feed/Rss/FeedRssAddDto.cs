using System;
using System.ComponentModel.DataAnnotations;

namespace HungryCake.API.Dtos
{
    public class FeedRssAddDto
    {
        [Required]
        public string Name { get; set; }
        public DateTime Created { get; private set; } = DateTime.Now;
        public string UrlSite { get; set; }
        public string UrlRss { get; set; }
        public string Description { get; set; }
        public string NewIconPath { get; set; }

        [Required]
        public bool IsActive { get; set; }

    }
}
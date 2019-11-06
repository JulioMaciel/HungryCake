using System;
using System.ComponentModel.DataAnnotations;

namespace HungryCake.API.Dtos
{
    public class FeedRssEditDto
    {
        [Required]
        public int Id { get; set; }        
        [Required]
        public string Name { get; set; }
        public string UrlSite { get; set; }
        public string UrlRss { get; set; }
        public string Description { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public byte[] Icon { get; set; }
        public string NewIconPath { get; set; }
    }
}
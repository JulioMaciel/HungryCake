using System.ComponentModel.DataAnnotations;

namespace HungryCake.API.Models
{
    public class FeedRss : Feed
    {
        [Required]
        public string UrlSite { get; set; }

    }
}
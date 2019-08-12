using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HungryCake.API.Models
{
    public class Feed
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public User Creator { get; set; }
        public string FeedName { get; set; }
        public string UrlSite { get; set; }
        public string UrlFeed { get; set; }
        public string Topic { get; set; }
        public string Language { get; set; }
        public bool IsActive { get; set; }
        public ICollection<UserFeed> UserFeeds { get; set; }
    }
}
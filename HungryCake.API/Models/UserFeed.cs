using Microsoft.AspNetCore.Identity;

namespace HungryCake.API.Models
{
    public class UserFeed
    {   public string UserId { get; set; }
        public User User { get; set; }
        public string FeedId { get; set; }
        public Feed Feed { get; set; }
        
        // public UserFeed(User user, Feed feed)
        // {
        //     this.User = user;
        //     this.Feed = feed;

        // }
    }
}
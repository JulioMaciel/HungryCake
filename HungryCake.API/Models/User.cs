using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HungryCake.API.Models
{
    public class User : IdentityUser
    {
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }

        // public List<int> Interests { get; set; } // WIP next version
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserFeed> UserFeeds { get; set; }
    }
}
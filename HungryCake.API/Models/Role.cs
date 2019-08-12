using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HungryCake.API.Models
{
    public class Role : IdentityRole
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
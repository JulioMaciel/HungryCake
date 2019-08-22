using Microsoft.AspNetCore.Identity;

namespace HungryCake.API.Models
{
    public class UserRole : IdentityUserRole<int>
    {
        public User User { get; set; }
        public Role Role { get; set; }
        
    }
}
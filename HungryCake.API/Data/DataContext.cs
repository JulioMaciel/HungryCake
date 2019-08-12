using HungryCake.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HungryCake.API.Data
{
    public class DataContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<Feed> Feeds { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().Ignore(c=>c.PhoneNumber).Ignore(c=>c.PhoneNumberConfirmed);

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId).IsRequired();

                userRole.HasOne(ur => ur.User).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.UserId).IsRequired();
            });

            builder.Entity<UserFeed>(userFeed =>
            {
                userFeed.HasKey(ur => new { ur.UserId, ur.FeedId });

                userFeed.HasOne(ur => ur.Feed).WithMany(r => r.UserFeeds).HasForeignKey(ur => ur.FeedId).IsRequired();

                userFeed.HasOne(ur => ur.User).WithMany(r => r.UserFeeds).HasForeignKey(ur => ur.UserId).IsRequired();
            });
        }
    }
}
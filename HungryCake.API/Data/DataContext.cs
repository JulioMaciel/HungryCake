using HungryCake.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HungryCake.API.Data
{
    public class DataContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>,
    UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<FeedRss> FeedsRss { get; set; }
        public DbSet<FeedHtml> FeedsHtml { get; set; }
        public DbSet<FeedReddit> FeedsReddit { get; set; }
        public DbSet<FeedTwitter> FeedsTwitter { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserColumn> UserColumns { get; set; }
        public DbSet<UserGrid> UserGrids { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().Ignore(c => c.PhoneNumber).Ignore(c => c.PhoneNumberConfirmed);

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId).IsRequired();

                userRole.HasOne(ur => ur.User).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.UserId).IsRequired();
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
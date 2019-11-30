using HungryCake.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HungryCake.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Column> Columns { get; set; }
        public DbSet<Grid> Grids { get; set; }
        public DbSet<FeedRss> FeedsRss { get; set; }
        public DbSet<FeedRegex> FeedsHtml { get; set; }
        public DbSet<FeedReddit> FeedsReddit { get; set; }
        public DbSet<FeedTwitter> FeedsTwitter { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Column>()
                .HasOne(g => g.Grid)
                .WithMany(c => c.Columns)
                .HasForeignKey(c => c.GridId);


            builder.Entity<ColumnRegex>()
                .HasKey(ch => new { ch.ColumnId, ch.FeedRegexId });

            builder.Entity<ColumnRegex>()
                .HasOne(ch => ch.Column)
                .WithMany(c => c.FeedsRegex)
                .HasForeignKey(ch => ch.ColumnId);

            builder.Entity<ColumnRegex>()
                .HasOne(ch => ch.FeedRegex)
                .WithMany(f => f.ColumnsRegex)
                .HasForeignKey(ch => ch.FeedRegexId);


            builder.Entity<ColumnRss>()
                .HasKey(ch => new { ch.ColumnId, ch.FeedRssId });

            builder.Entity<ColumnRss>()
                .HasOne(ch => ch.Column)
                .WithMany(c => c.FeedsRss)
                .HasForeignKey(ch => ch.ColumnId);

            builder.Entity<ColumnRss>()
                .HasOne(ch => ch.FeedRss)
                .WithMany(f => f.ColumnsRss)
                .HasForeignKey(ch => ch.FeedRssId);


            builder.Entity<ColumnReddit>()
                .HasKey(ch => new { ch.ColumnId, ch.FeedRedditId });

            builder.Entity<ColumnReddit>()
                .HasOne(ch => ch.Column)
                .WithMany(c => c.FeedsReddit)
                .HasForeignKey(ch => ch.ColumnId);

            builder.Entity<ColumnReddit>()
                .HasOne(ch => ch.FeedReddit)
                .WithMany(f => f.ColumnsReddit)
                .HasForeignKey(ch => ch.FeedRedditId);


            builder.Entity<ColumnTwitter>()
                .HasKey(ch => new { ch.ColumnId, ch.FeedTwitterId });

            builder.Entity<ColumnTwitter>()
                .HasOne(ch => ch.Column)
                .WithMany(c => c.FeedsTwitter)
                .HasForeignKey(ch => ch.ColumnId);

            builder.Entity<ColumnTwitter>()
                .HasOne(ch => ch.FeedTwitter)
                .WithMany(f => f.ColumnsTwitter)
                .HasForeignKey(ch => ch.FeedTwitterId);
        }
    }
}
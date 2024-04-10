using Microsoft.EntityFrameworkCore;
using Rift.GG.Models;

namespace Rift.GG.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Champion> Champions { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<UserStats> UserStats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserMatch> UserMatches { get; set; } // Add DbSet for UserMatch

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserStats)
                .WithOne(us => us.User)
                .HasForeignKey<UserStats>(us => us.UserId);

            modelBuilder.Entity<UserMatch>() // Configure many-to-many relationship
                .HasKey(um => new { um.UserId, um.MatchId });

            modelBuilder.Entity<UserMatch>()
                .HasOne(um => um.User)
                .WithMany(u => u.UserMatches)
                .HasForeignKey(um => um.UserId);

            modelBuilder.Entity<UserMatch>()
                .HasOne(um => um.Match)
                .WithMany(m => m.UserMatches)
                .HasForeignKey(um => um.MatchId);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.User)
                .WithMany(u => u.Messages)
                .HasForeignKey(m => m.UserId);
        }
    }
}

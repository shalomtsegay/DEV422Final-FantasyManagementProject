using Microsoft.EntityFrameworkCore;
using PerformanceTrackingService.Models;

namespace PerformanceTrackingService.Data
{
    public class PerformanceContext : DbContext
    {
        public PerformanceContext(DbContextOptions<PerformanceContext> options) : base(options) { }

        public DbSet<PerformanceStats> PerformanceStats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PerformanceStats>().HasData(
                new PerformanceStats { Id = 1, PlayerId = 101, MatchesPlayed = 0, GoalsScored = 0, Assists = 0 },
                new PerformanceStats { Id = 2, PlayerId = 102, MatchesPlayed = 0, GoalsScored = 0, Assists = 0 }
            );
        }
    }
}

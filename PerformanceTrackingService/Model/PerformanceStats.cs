using System.ComponentModel.DataAnnotations;

namespace PerformanceTrackingService.Models
{
    public class PerformanceStats
    {
        [Key]
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int MatchesPlayed { get; set; }
        public int GoalsScored { get; set; }
        public int Assists { get; set; }
    }
}

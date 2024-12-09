using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerformanceTrackingService.Data;
using PerformanceTrackingService.Models;

namespace PerformanceTrackingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceController : ControllerBase
    {
        private readonly PerformanceContext _context;

        public PerformanceController(PerformanceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PerformanceStats>>> GetAllStats()
        {
            return await _context.PerformanceStats.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PerformanceStats>> GetStats(int id)
        {
            var stats = await _context.PerformanceStats.FindAsync(id);
            if (stats == null)
            {
                return NotFound();
            }
            return stats;
        }

        [HttpPost("simulate")]
        public async Task<IActionResult> SimulateCompetition([FromBody] int playerId)
        {
            var playerStats = await _context.PerformanceStats.FirstOrDefaultAsync(p => p.PlayerId == playerId);
            if (playerStats == null)
            {
                return NotFound($"Player with ID {playerId} not found.");
            }

            // Simulate performance stats
            playerStats.MatchesPlayed += 1;
            playerStats.GoalsScored += new Random().Next(0, 3); // Random goals between 0-2
            playerStats.Assists += new Random().Next(0, 2);    // Random assists between 0-1

            await _context.SaveChangesAsync();

            // Notify leaderboard (placeholder for actual service integration)
            Console.WriteLine($"Notified Leaderboard Service: Player {playerId} stats updated.");

            return Ok(playerStats);
        }
    }
}

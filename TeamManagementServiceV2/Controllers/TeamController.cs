using TeamManagementServiceV2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamManagementServiceV2.Data;

namespace TeamManagementServiceV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly TeamContext context;
        public TeamController(TeamContext context)
        {
            this.context = context;
        }

        // get function to retreive all teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetAllTeams()
        {
            return await context.Teams.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var team = await context.Teams.FindAsync(id);

            // validation
            if(team == null)
            {
                return NotFound();
            }
            return team;
        }

        // Create a new team
        [HttpPost]
        public async Task<ActionResult<Team>> CreateTeam([FromBody] CreateTeamRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.TeamName))
            {
                return BadRequest("Team name is required.");
            }

            var newTeam = new Team
            {
                TeamName = request.TeamName,
                PlayerIds = string.Empty
            };

            context.Teams.Add(newTeam);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeam), new { id = newTeam.TeamId }, newTeam);
        }

        public class CreateTeamRequest
        {
            public string TeamName { get; set; } = string.Empty;
        }



    }
}

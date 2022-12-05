using Microsoft.AspNetCore.Mvc;

namespace BasketballLeague.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Team>>> GetTeams()
        {
            return new List<Team> { 
                new Team 
                {
                    Name = "LA Lakers"
                },
                new Team
                {
                    Name = "Boston Celtics"
                },
                new Team
                {
                    Name = "Chicago Bulls"
                }
            };
        }
    }
}

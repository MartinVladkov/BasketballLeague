using BasketballLeague.API.Data.Models;
using BasketballLeague.API.Services.Teams;
using Microsoft.AspNetCore.Mvc;

namespace BasketballLeague.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamGameService teamGame;

        public TeamController(ITeamGameService teamGame)
        {
            this.teamGame = teamGame;
        }

        [HttpGet]
        public async Task<ActionResult<List<Team>>> GetTeams()
        {
            return Ok(await teamGame.GetTeams());
        }

        [HttpGet]
        [Route("TopOffensiveTeams")]
        public async Task<ActionResult<List<TeamsGames>>> GetTopOffensiveTeams()
        {
            return Ok(await teamGame.getTeamsScoredPoints()); 
        }

        [HttpGet]
        [Route("TopDefensiveTeams")]
        public async Task<ActionResult<List<TeamsGames>>> GetTopDefensiveTeams()
        {
            return Ok(await teamGame.getTeamsOpponentsPoints());
        }
    }
}

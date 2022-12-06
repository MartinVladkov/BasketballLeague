using BasketballLeague.API.Data;
using BasketballLeague.API.Data.Models;
using BasketballLeague.API.Services.Teams;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasketballLeague.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ITeamGameService teamGame;

        public GameController(ITeamGameService teamGame)
        {
            this.teamGame = teamGame;
        }

        [HttpGet]
        public async Task<ActionResult<List<TeamsGames>>> GetGames()
        {
            return Ok(await teamGame.GetGames());
        }

        [HttpGet]
        [Route("HighlightGame")]
        public async Task<ActionResult<List<TeamsGames>>> GetHighlightGame()
        {  
            return Ok(await teamGame.getHighlightGame());
        }
    }
}

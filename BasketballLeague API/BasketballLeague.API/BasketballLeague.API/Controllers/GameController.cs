using BasketballLeague.API.Data;
using BasketballLeague.API.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasketballLeague.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly BasketballLeagueDbContext dbContext;

        public GameController(BasketballLeagueDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<TeamsGames>>> GetGames()
        {
            return Ok(await dbContext.TeamsGames
                .FromSqlRaw<TeamsGames>("spGetAllGames")
                .ToListAsync());
        }

        [HttpGet]
        [Route("HighlightGame")]
        public async Task<ActionResult<List<TeamsGames>>> GetHighlightGame()
        {
            var allGames = await dbContext.TeamsGames
               .FromSqlRaw<TeamsGames>("spGetAllGames")
               .ToListAsync();

            var highlightMatch = allGames
                .Select(x => new
                {
                    x.Id,
                    x.homeTeam,
                    x.awayTeam,
                    x.homeTeamScore,
                    x.awayTeamScore,
                    scoreCombined = x.homeTeamScore + x.awayTeamScore
                })
                .OrderByDescending(x => x.scoreCombined)
                .FirstOrDefault();
                
            return Ok(highlightMatch);
        }
    }
}

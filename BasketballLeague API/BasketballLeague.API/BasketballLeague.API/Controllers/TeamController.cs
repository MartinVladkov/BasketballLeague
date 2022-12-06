using BasketballLeague.API.Data;
using BasketballLeague.API.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasketballLeague.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly BasketballLeagueDbContext dbContext;

        public TeamController(BasketballLeagueDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Team>>> GetTeams()
        {
            return Ok(await dbContext.Teams
                .FromSqlRaw<Team>("spGetAllTeams")
                .ToListAsync());
        }

        [HttpGet]
        [Route("TopOffensiveTeams")]
        public async Task<ActionResult<List<TeamsGames>>> GetTopOffensiveTeams()
        {
            var allGames = await dbContext.TeamsGames
                .FromSqlRaw<TeamsGames>("spGetAllGames")
                .ToListAsync();

            var teams = allGames
                .Select(x => x.homeTeam)
                .Distinct();

            Dictionary<string, int> topOffensiveTeams = new Dictionary<string, int>();

            foreach (var team in teams)
            {
                var scoresAsHomeTeam = allGames
                    .Select(x => x)
                    .Where(x => x.homeTeam == team)
                    .Sum(x => x.homeTeamScore);

                var scoresAsAwayTeam = allGames
                    .Select(x => x)
                    .Where(x => x.awayTeam == team)
                    .Sum(x => x.awayTeamScore);

                topOffensiveTeams[team] = scoresAsHomeTeam + scoresAsAwayTeam;
            }

            var response = topOffensiveTeams.OrderByDescending(x => x.Value);

            return Ok(response); 
        }

        [HttpGet]
        [Route("TopDefensiveTeams")]
        public async Task<ActionResult<List<TeamsGames>>> GetTopDefensiveTeams()
        {
            var allGames = await dbContext.TeamsGames
                .FromSqlRaw<TeamsGames>("spGetAllGames")
                .ToListAsync();

            var teams = allGames
                .Select(x => x.homeTeam)
                .Distinct();

            Dictionary<string, int> topDefensiveTeams = new Dictionary<string, int>();

            foreach (var team in teams)
            {
                var awayOponentsScore = allGames
                    .Select(x => x)
                    .Where(x => x.homeTeam == team)
                    .Sum(x => x.awayTeamScore);

                var homeOponentsScore = allGames
                    .Select(x => x)
                    .Where(x => x.awayTeam == team)
                    .Sum(x => x.homeTeamScore);

                topDefensiveTeams[team] = awayOponentsScore + homeOponentsScore;
            }

            var response = topDefensiveTeams.OrderBy(x => x.Value);

            return Ok(response);
        }
    }
}

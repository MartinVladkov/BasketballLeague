using BasketballLeague.API.Data;
using BasketballLeague.API.Data.Models;
using BasketballLeague.API.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace BasketballLeague.API.Services.Teams
{
    public class TeamGameService : ITeamGameService
    {
        private BasketballLeagueDbContext data { get; set; }

        public TeamGameService(BasketballLeagueDbContext data) 
        {
            this.data = data;
        }

        public async Task<List<Team>> GetTeams()
        {
            var allTeams = await data.Teams
                .FromSqlRaw<Team>("spGetAllTeams")
                .ToListAsync();

            return allTeams;
        }

        public async Task<List<TeamsGames>> GetGames()
        {
            var allGames = await data.TeamsGames
                .FromSqlRaw<TeamsGames>("spGetAllGames")
                .ToListAsync();

            return allGames;
        }

        public async Task<List<TeamScore>> getTeamsScoredPoints()
        {
            var teamsScore = await data.TeamsScores
                .FromSqlRaw<TeamScore>("spGetTeamsScore")
                .ToListAsync();

            return teamsScore;
        }

        public async Task<List<TeamScore>> getTeamsOpponentsPoints()
        {
            var teamsOponentsScore = await data.TeamsScores
                .FromSqlRaw<TeamScore>("spGetTeamsOponentsScore")
                .ToListAsync();

            return teamsOponentsScore;
        }

        public async Task<HighlightGame> getHighlightGame()
        {
            var highlightGame = await data.HighlightGames
                .FromSqlRaw<HighlightGame>("spGetHighlightGame")
                .ToListAsync();

            return highlightGame.FirstOrDefault();
        }
    }
}

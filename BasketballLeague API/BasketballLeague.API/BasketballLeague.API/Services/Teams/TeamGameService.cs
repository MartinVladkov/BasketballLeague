namespace BasketballLeague.API.Services.Teams
{
    using BasketballLeague.API.Data;
    using BasketballLeague.API.Data.Models;
    using BasketballLeague.API.Services.Models;
    using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<KeyValuePair<string,int>>> getTeamsScoredPoints()
        {
            var allGames = await GetGames();

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

            return response;
        }

        public async Task<IEnumerable<KeyValuePair<string, int>>> getTeamsOpponentsPoints()
        {
            var allGames = await GetGames();

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

            return response;
        }

        public async Task<HighlightGame> getHighlightGame()
        {
            var allGames = await GetGames();

            var highlightMatch = allGames
                .Select(x => new HighlightGame
                {
                    Id = x.Id,
                    homeTeam = x.homeTeam,
                    awayTeam = x.awayTeam,
                    homeTeamScore = x.homeTeamScore,
                    awayTeamScore = x.awayTeamScore,
                    scoreCombined = x.homeTeamScore + x.awayTeamScore
                })
                .OrderByDescending(x => x.scoreCombined)
                .FirstOrDefault();

            return highlightMatch;
        }
    }
}

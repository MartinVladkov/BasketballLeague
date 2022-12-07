using BasketballLeague.API.Data.Models;
using BasketballLeague.API.Services.Models;

namespace BasketballLeague.API.Services.Teams
{
    public interface ITeamGameService
    {
        Task<List<Team>> GetTeams();

        Task<List<TeamsGames>> GetGames();

        Task<HighlightGame> getHighlightGame();

        Task<List<TeamScore>> getTeamsScoredPoints();

        Task<List<TeamScore>> getTeamsOpponentsPoints();
    }
}

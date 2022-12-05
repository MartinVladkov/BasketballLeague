namespace BasketballLeague.API.Data.Models
{
    public class TeamsGames
    {
        public int Id { get; set; }

        public string homeTeam { get; set; }

        public string awayTeam { get; set; }

        public int homeTeamScore { get; set; }

        public int awayTeamScore { get; set; }

    }
}

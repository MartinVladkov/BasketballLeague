namespace BasketballLeague.API.Services.Models
{
    public class HighlightGame
    {
        public int Id { get; set; }

        public string homeTeam { get; set; }

        public string awayTeam { get; set; }

        public int homeTeamScore { get; set; }

        public int awayTeamScore { get; set; }

        public int scoreCombined { get; set; }

    }
}

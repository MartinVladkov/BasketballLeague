using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasketballLeague.API.Migrations
{
    public partial class spGetHighlightGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE spGetHighlightGame
                                AS
                                SELECT Games.Id, homeTeam.Name as homeTeam, awayTeam.Name as awayTeam, Games.homeTeamScore, 
                                Games.awayTeamScore, (Games.homeTeamScore + Games.awayTeamScore) as scoreCombined 
                                INTO #games_combined_score
                                FROM Games
                                INNER JOIN Teams homeTeam ON Games.homeTeamId = homeTeam.Id 
                                INNER JOIN Teams awayTeam ON Games.awayTeamId = awayTeam.Id
                                ORDER BY scoreCombined DESC
                                
                                SELECT TOP 1 * FROM #games_combined_score
                                ORDER BY scoreCombined DESC
                                GO";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP PROCEDURE spGetHighlightGame";

            migrationBuilder.Sql(procedure);
        }
    }
}

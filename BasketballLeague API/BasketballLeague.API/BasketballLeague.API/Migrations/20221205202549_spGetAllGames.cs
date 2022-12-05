using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasketballLeague.API.Migrations
{
    public partial class spGetAllGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE spGetAllGames
                                AS
                                SELECT Games.Id, homeTeam.Name as homeTeam, awayTeam.Name as awayTeam, Games.homeTeamScore, 
                                Games.awayTeamScore, Games.homeTeamId, Games.awayTeamId FROM Games
                                INNER JOIN Teams homeTeam ON Games.homeTeamId = homeTeam.Id 
                                INNER JOIN Teams awayTeam ON Games.awayTeamId = awayTeam.Id
                                ORDER BY homeTeam";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP PROCEDURE spGetAllGames";

            migrationBuilder.Sql(procedure);

        }
    }
}
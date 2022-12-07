using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasketballLeague.API.Migrations
{
    public partial class spGetTeamsScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE spGetTeamsScore
                                AS
                                SELECT Teams.Id, Teams.Name, SUM(Games.homeTeamScore) as homeScore
                                INTO #team_home_score
                                FROM Teams
                                LEFT JOIN Games ON Games.homeTeamId = Teams.Id
                                GROUP BY Teams.id, Teams.Name
                                
                                SELECT Teams.Id, Teams.Name, SUM(Games.awayTeamScore) as awayScore
                                INTO #team_away_score
                                FROM Teams
                                LEFT JOIN Games ON Games.awayTeamId = Teams.Id
                                GROUP BY Teams.id, Teams.Name
                                
                                SELECT home.Id, home.Name, (home.homeScore + away.awayScore) as TotalScore FROM #team_home_score as home
                                RIGHT JOIN #team_away_score away ON home.Id = away.Id
                                ORDER BY TotalScore DESC
                                GO";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP PROCEDURE spGetTeamsScore";

            migrationBuilder.Sql(procedure);
        }
    }
}

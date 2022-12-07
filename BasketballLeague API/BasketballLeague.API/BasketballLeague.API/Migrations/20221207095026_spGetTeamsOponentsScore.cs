using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasketballLeague.API.Migrations
{
    public partial class spGetTeamsOponentsScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE spGetTeamsOponentsScore
                                AS
                                SELECT Teams.Id, Teams.Name, SUM(Games.awayTeamScore) as awayOponentScore
                                INTO #team_home_oponent_score
                                FROM Teams
                                LEFT JOIN Games ON Games.homeTeamId = Teams.Id
                                GROUP BY Teams.id, Teams.Name
                                
                                SELECT Teams.Id, Teams.Name, SUM(Games.homeTeamScore) as homeOponentScore
                                INTO #team_away_oponent_score
                                FROM Teams
                                LEFT JOIN Games ON Games.awayTeamId = Teams.Id
                                GROUP BY Teams.id, Teams.Name
                                
                                SELECT home.Id, home.Name, (home.awayOponentScore + away.homeOponentScore) as TotalScore FROM #team_home_oponent_score as home
                                RIGHT JOIN #team_away_oponent_score away ON home.Id = away.Id
                                ORDER BY TotalScore
                                GO";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP PROCEDURE spGetTeamsOponentsScore";

            migrationBuilder.Sql(procedure);
        }
    }
}

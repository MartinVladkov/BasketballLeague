using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasketballLeague.API.Migrations
{
    public partial class spGetAllTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE spGetAllTeams
                                AS
                                SELECT * FROM Teams";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP PROCEDURE spGetAllTeams";

            migrationBuilder.Sql(procedure);
        }
    }
}

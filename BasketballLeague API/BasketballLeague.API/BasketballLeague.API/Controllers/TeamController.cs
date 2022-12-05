using BasketballLeague.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasketballLeague.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly BasketballLeagueDbContext dbContext;

        public TeamController(BasketballLeagueDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Team>>> GetTeams()
        {
            return Ok(await dbContext.Teams
                .FromSqlRaw<Team>("spGetAllTeams")
                .ToListAsync());
        }
    }
}

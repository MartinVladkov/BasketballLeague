using BasketballLeague.API.Data.Models;
using BasketballLeague.API.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace BasketballLeague.API.Data
{
    public class BasketballLeagueDbContext : DbContext
    {
        public DbSet<Team> Teams => Set<Team>();

        public DbSet<Game> Games => Set<Game>();

        public DbSet<TeamsGames> TeamsGames => Set<TeamsGames>();

        public DbSet<TeamScore> TeamsScores => Set<TeamScore>();

        public DbSet<HighlightGame> HighlightGames => Set<HighlightGame>();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Game>()
                .HasOne(g => g.homeTeam)
                .WithMany(t => t.homeGames)
                .HasForeignKey(g => g.homeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
             .Entity<Game>()
             .HasOne(g => g.awayTeam)
             .WithMany(t => t.awayGames)
             .HasForeignKey(g => g.awayTeamId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TeamsGames>().Metadata.SetIsTableExcludedFromMigrations(true);
            builder.Entity<TeamScore>().Metadata.SetIsTableExcludedFromMigrations(true);
            builder.Entity<HighlightGame>().Metadata.SetIsTableExcludedFromMigrations(true);

            base.OnModelCreating(builder);
        }

        public BasketballLeagueDbContext(DbContextOptions<BasketballLeagueDbContext> options) : base(options) { }

    }
}

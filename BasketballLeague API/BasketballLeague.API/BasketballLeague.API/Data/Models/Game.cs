using System.ComponentModel.DataAnnotations;

namespace BasketballLeague.API.Data.Models
{
    public class Game
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int homeTeamId { get; set; }

        [Required]
        public Team homeTeam { get; set; }

        public int awayTeamId { get; set; }

        [Required]
        public Team awayTeam { get; set; }

        [Required]
        public int homeTeamScore { get; set; }

        [Required]
        public int awayTeamScore { get; set; }
    }
}

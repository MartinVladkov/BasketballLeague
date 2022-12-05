using BasketballLeague.API.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace BasketballLeague.API
{
    public class Team
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<Game> homeGames { get; set; } = new List<Game>();

        public IEnumerable<Game> awayGames { get; set; } = new List<Game>();
    }
}

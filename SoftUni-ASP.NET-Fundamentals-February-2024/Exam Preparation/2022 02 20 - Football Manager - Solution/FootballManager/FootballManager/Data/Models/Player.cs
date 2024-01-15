namespace FootballManager.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Player
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(80)]
        public string FullName { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        [MaxLength(20)]
        public string Position { get; set; }

        public byte Speed { get; set; }

        public byte Endurance { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public ICollection<UserPlayer> UserPlayers { get; set; } = new HashSet<UserPlayer>();
    }
}

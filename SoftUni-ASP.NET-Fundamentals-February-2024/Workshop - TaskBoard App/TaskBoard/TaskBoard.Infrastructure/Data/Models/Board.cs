namespace TaskBoard.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.ValidationConstants.Board;
    public class Board
    {
        public Board()
        {
            this.Tasks = new HashSet<Task>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(MinNameLength)]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; } = null!;

        public ICollection<Task> Tasks { get; set; }

    }
}

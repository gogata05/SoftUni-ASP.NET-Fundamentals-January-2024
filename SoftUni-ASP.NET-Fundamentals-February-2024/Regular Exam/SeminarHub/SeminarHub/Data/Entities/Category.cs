using System.ComponentModel.DataAnnotations;
namespace SeminarHub.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<Seminar> Seminars { get; set; } = new List<Seminar>();
    }
}

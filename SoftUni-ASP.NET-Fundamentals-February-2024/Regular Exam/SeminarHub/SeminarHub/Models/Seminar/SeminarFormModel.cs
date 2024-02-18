using System.ComponentModel.DataAnnotations;
using SeminarHub.Data;
using SeminarHub.Models.Category;
namespace SeminarHub.Models.Seminar
{
    public class SeminarFormModel
    {
        [Required]
        [StringLength(DataConstants.SeminarTopicMaxLength, MinimumLength = DataConstants.SeminarTopicMinLength)]
        public string Topic { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.SeminarLecturerMaxLength, MinimumLength = DataConstants.SeminarLecturerMinLength)]
        public string Lecturer { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.SeminarDetailsMaxLength, MinimumLength = DataConstants.SeminarDetailsMinLength)]
        public string Details { get; set; } = null!;

        [Required]
        public DateTime DateAndTime { get; set; }

        [Range(DataConstants.SeminarDurationMinLength, DataConstants.SeminarDurationMaxLength)]
        public int Duration { get; set; }

        [Required]
        public int CategoryId { get; set; }


        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
       
    }
}
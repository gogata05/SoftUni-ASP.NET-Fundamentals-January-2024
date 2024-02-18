using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarHub.Data.Entities
{
    public class Seminar
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.SeminarTopicMaxLength)] 
        public string Topic { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.SeminarLecturerMaxLength)]  
        public string Lecturer { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.SeminarDetailsMaxLength)]   
        public string Details { get; set; } = null!;

        [Required]
        public string OrganizerId { get; set; } = null!;

        [Required]
        public IdentityUser Organizer { get; set; } = null!;

        [Required]
        public DateTime DateAndTime { get; set; }

        public int Duration { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; } = null!;

    }
}
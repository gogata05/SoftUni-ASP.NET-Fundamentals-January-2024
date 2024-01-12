using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Library.Data.DataConstants;

namespace Library.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(MaxBookTitle)]
        public string Title { get; set; }

        [Required]
        [MaxLength(MaxAuthorName)]
        public string Author { get; set; }

        [Required]
        [MaxLength(MaxDescription)]

        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [Column(TypeName = "decimal(4,2)")]//!
        public decimal Rating { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public ICollection<ApplicationUserBook> UsersBooks { get; set; }
    }
}
//pk,fk,req,max,*

// Book 
// Has Id – a unique integer, Primary Key 
// Has Title – a string with min length 10 and max length 50 (required) 
// Has Author – a string with min length 5 and max length 50 (required) 
// Has Description – a string with min length 5 and max length 5000 (required) 
// Has ImageUrl – a string (required) 
// Has Rating – a decimal with min value 0.00 and max value 10.00 (required) 
// Has CategoryId – an integer, foreign key (required) 
// Has Category – a Category (required) 
// Has ApplicationUsersBooks – a collection of type ApplicationUserBook 
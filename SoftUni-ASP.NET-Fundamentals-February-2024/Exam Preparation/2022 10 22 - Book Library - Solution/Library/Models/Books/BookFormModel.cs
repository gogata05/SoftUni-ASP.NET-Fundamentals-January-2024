using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using static Library.Data.DataConstants;

namespace Library.Models.Books
{
    public class AddBookFormModel
    {
        [Required]
        [StringLength(MaxBookTitle, MinimumLength = MinBookTitle,
            ErrorMessage = "Title should be at least {2} characters long.")]
        public string Title { get; set; }

        [Required]
        [StringLength(MaxAuthorName, MinimumLength = MinAuthorName)]
        public string Author { get; set; }

        [Required]
        [StringLength(MaxDescription, MinimumLength = MinDescription,
            ErrorMessage = "Description should be at least {2} characters long.")]
        public string Description { get; set; }

        [Required]
        //[Display(Name = "Image URL")]
        public string Url { get; set; }

        [Column(TypeName = "decimal(4,2)")]//!
        [Range(0.00, 10.00)]
        public decimal Rating { get; set; }

        //[Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<BookCategoryModel> Categories { get; set; }
            = new List<BookCategoryModel>();
    } 
}
//req,"?",min,max,range,regular,email,enum int range,displayname,*

// Add shape:
// asp-for=@Model.Title
// asp-for=@Model.Author
// asp-for=@Model.Description
// asp-for=@Model.Url
// asp-for="Rating"
// asp-for=@Model.CategoryId
// asp-for=@Model.Categories



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
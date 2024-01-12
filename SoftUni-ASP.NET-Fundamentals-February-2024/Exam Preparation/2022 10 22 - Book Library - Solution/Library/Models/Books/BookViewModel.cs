using Library.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Library.Models.Books
{
    public class AllBookViewModel
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Rating { get; set; }
        
        public string Category { get; set; }

        public string Description { get; set; }

    }
}
//All,Profile shape:
// @book.Id
// @book.ImageUrl
// @book.Title
// @book.Author
// @book.Rating
// @book.Category
 
// @book.Description


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






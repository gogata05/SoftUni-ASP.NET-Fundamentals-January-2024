using Library.Data.Entities;

namespace Library.Models.Books
{
    public class BookCategoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Book> Categories { get; set; } = new List<Book>();
    }
}
//Category shape:
//value="@category.Id">@category.Name
//@Model.Categories


// Category 
// Has Id – a unique integer, Primary Key 
// Has Name – a string with min length 5 and max length 50 (required) 
// Has Books – a collection of type Books  
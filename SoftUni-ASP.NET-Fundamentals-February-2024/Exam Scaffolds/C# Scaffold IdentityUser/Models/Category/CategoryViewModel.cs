// if "Category" exists

// CategoryViewModel.cs
//pp,pp5
namespace Solution.Models.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public IEnumerable<Book> Categories { get; set; } = new List<Book>();
    }
}
//All,Profile,Add,Edit
//category shape:
//value="@type.Id">@type.Name
//@Model.Categories

// Category 
// Has Id – a unique integer, Primary Key 
// Has Name – a string with min length 3 and max length 15 (required) 
// Has Ads – a collection of type Ad 
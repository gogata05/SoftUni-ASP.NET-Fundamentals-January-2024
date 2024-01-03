namespace SoftUniBazar.Models.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
//All,Profile,Add,Edit
//category shape:
//value="@type.Id">@type.Name

// Category 
// Has Id – a unique integer, Primary Key 
// Has Name – a string with min length 3 and max length 15 (required) 
// Has Ads – a collection of type Ad 
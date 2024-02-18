// if "Category" exists

// only properties with only: int, string, decimal, double
//pp,pp5
namespace Solution.Models.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

    }
}
//copy "All","Profile","Add","Edit" category shape here from Views.Item:
//< option value = "@type.Id" > @type.Name </ option >

// copy Category description here:   and delete unused properties:
//Category 
// Has Id – a unique integer, Primary Key 
// Has Name – a string with min length 3 and max length 15 (required) 
// Has Ads – a collection of type Ad 
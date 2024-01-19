// Export DB
//pp,pp5
using System.ComponentModel.DataAnnotations;
using Solution.Models.Category;
using static Solution.Data.DataConstants;
namespace Solution.Models.Item
{
    
        public class ItemViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;

        public decimal Price { get; set; }

        public string Owner { get; set; } = null!;
    }
}
//All,Profile shape:

// @a.Name
// a.ImageUrl
// @a.CreatedOn
// @a.Category
// a.Description
// @a.Price
// @a.Owner
// @a.Id


// Ad 
// Has Id – a unique integer, Primary Key 
// Has Name – a string with min length 5 and max length 25 (required) 
// Has Description – a string with min length 15 and max length 250 (required) 
// Has Price – a decimal (required) 
// Has OwnerId – a string (required) 
// Has Owner – an IdentityUser (required) 
// Has ImageUrl – a string (required) 
// Has CreatedOn – a DateTime with format "yyyy-MM-dd H:mm" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one) 
// Has CategoryId – an integer, foreign key (required) 
// Has Category – a Category (required) 
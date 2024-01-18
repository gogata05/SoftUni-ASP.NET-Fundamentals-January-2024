// ItemFormModel.cs
//pp,pp5
//dbw,using
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static Solution.Data.DataConstants;
using Solution.Models.Category;
namespace Solution.Models.Item
{
    public class ItemFormModel
    {
        [Required]
        [StringLength(ItemNameMax, MinimumLength = ItemNameMin,
            ErrorMessage = "Item name must be between {2} and {1} characters.")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(ItemDescriptionMax, MinimumLength = ItemDescriptionMin,
            ErrorMessage = "Description must be between {2} and {1} characters.")]
        public string Description { get; set; } = null!;

        [Required]
        //[Column(TypeName = "decimal(4,2)")]//10.00//4 numbers,2 after. //rear
        public decimal Price { get; set; }

        [Required]
        [DisplayName("Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
            = new List<CategoryViewModel>();
    }
}
//req,"?",min,max,range,regular,email,enum int range,displayname,*

//"Add","Edit" form shape:

// @Model.Name
// @Model.Description
// @Model.ImageUrl
// @Model.Price
// @Model.CategoryId
// Model.Categories

// Ad 
// Has Id – a unique integer, Primary Key 
// Has Name – a string with min length 5 and max length 25 (required) *
// Has Description – a string with min length 15 and max length 250 (required)* 
// Has Price – a decimal (required) 
// Has OwnerId – a string (required) 
// Has Owner – an IdentityUser (required) 
// Has ImageUrl – a string (required) 
// Has CreatedOn – a DateTime with format "yyyy-MM-dd H:mm" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one) 
// Has CategoryId – an integer, foreign key (required) 
// Has Category – a Category (required) 
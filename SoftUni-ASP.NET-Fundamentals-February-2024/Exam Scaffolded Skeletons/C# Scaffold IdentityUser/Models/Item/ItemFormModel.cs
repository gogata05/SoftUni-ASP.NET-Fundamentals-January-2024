//full info properties 
//pp,pp5
//dbw,sl2
//IEnumerable-list
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

// copy "Add","Edit" form shape from Views.Item:

// Model.Name
// Model.Description
// Model.ImageUrl
// Model.Price
// Model.CategoryId
// Model.Categories

// copy Item description here:   and delete unused properties:
//Ad 
// Has Name – a string with min length 5 and max length 25 (required) *
// Has Description – a string with min length 15 and max length 250 (required)* 
// Has ImageUrl – a string (required) 
// Has Price – a decimal (required) 
// Has CategoryId – an integer, foreign key (required) 
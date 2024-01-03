using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using static SoftUniBazar.Data.DataConstants;
using SoftUniBazar.Models.Category;
namespace SoftUniBazar.Models.Ad
{
    public class AdFormModel
    {
        [Required]
        [StringLength(AdNameMax, MinimumLength = AdNameMin)]
        //[StringLength(AdNameMax, MinimumLength = AdNameMin,ErrorMessage = "Ad name must be between 5 and 25 characters.")]//ErrorMessage not needed
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(AdDescriptionMax, MinimumLength = AdDescriptionMin)]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        //[DisplayName("Image URL")]//DisplayName not needed
        public string ImageUrl { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
            = new List<CategoryViewModel>();
    }
}
//req,"?",min,max,range,regular,email,enum int range,displayname,*

//"add" form shape:
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
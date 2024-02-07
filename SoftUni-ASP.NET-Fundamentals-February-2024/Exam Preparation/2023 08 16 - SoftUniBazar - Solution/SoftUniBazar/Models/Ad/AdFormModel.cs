
//pp,pp5
//dbw,stringLength3-Error

using System.ComponentModel.DataAnnotations;
using SoftUniBazar.Data;
using SoftUniBazar.Models.Category;

namespace SoftUniBazar.Models.Ad
{
    public class AdFormModel
    {
        [Required]
        [StringLength(DataConstants.AdNameMaxLength, MinimumLength = DataConstants.AdNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.AdDescriptionMaxLength, MinimumLength = DataConstants.AdDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
        
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
//req,"?",min,max,range,regular,email,enum int range,displayname,*

// copy "Add","Edit" shape here:
//Model.Name
//Model.Description
//Model.ImageUrl
//Model.Price
//Model.CategoryId
//Model.Categories

// copy Item description here:   and delete unused properties:
//    •	Has Name – a string with min length 5 and max length 25 (required)
//    •	Has Description – a string with min length 15 and max length 250 (required)
//    •	Has Price – a decimal (required)
//    •	Has ImageUrl – a string (required)
//    •	Has CreatedOn – a DateTime with format "yyyy-MM-dd H:mm" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one)
//    •	Has CategoryId – an integer, foreign key (required)

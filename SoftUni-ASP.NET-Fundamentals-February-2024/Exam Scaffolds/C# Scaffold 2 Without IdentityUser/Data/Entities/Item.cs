//DB Level

//pp,pp5
//db,using,
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;
using Microsoft.AspNetCore.Identity;
using static Solution.Data.DataConstants;
namespace Solution.Data.Models
{
    public class Item
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(ItemNameMax)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(ItemDescriptionMax)]
        public string Description { get; set; } = null!;

        [Required]
        //[Column(TypeName = "decimal(4,2)")]//10.00//4 numbers,2 after. //rear
        public decimal Price { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        public string OwnerId { get; set; } = null!;

        [Required]
        public IdentityUser Owner { get; set; } = null!;
    }
}
//pk,fk,req,max,*

//Ad
//    •	Has Id – a unique int, Primary Key
//    •	Has Name – a string with min length 5 and max length 25 (required)*
//    •	Has Description – a string with min length 15 and max length 250 (required)*
//    •	Has Price – a decimal (required)
//    •	Has OwnerId – a string (required)
//    •	Has Owner – an IdentityUser (required)
//    •	Has ImageUrl – a string (required)
//    •	Has CreatedOn – a DateTime with format "yyyy-MM-dd H:mm" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one)
//    •	Has CategoryId – an int, foreign key (required)
//    •	Has Category – a Category (required)

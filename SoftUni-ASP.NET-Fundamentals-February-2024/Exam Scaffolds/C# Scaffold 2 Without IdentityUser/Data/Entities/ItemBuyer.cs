//DB Level

//pp,pp5
//db,using,
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
namespace Solution.Data.Models
{
    public class ItemBuyer
    {
        [Required]
        public string BuyerId { get; set; } = null!;

        [ForeignKey(nameof(BuyerId))]
        public IdentityUser Buyer { get; set; } = null!;

        [Required]
        public int ItemId { get; set; }

        [ForeignKey(nameof(ItemId))]
        public Item Item { get; set; } = null!;
    }
}
//fk,req,max,*

//AdBuyer
//    •	BuyerId – a  string, Primary Key, foreign key (required)
//    •	Buyer – IdentityUser
//    •	AdId – an integer, Primary Key, foreign key (required)
//    •	Ad – Ad

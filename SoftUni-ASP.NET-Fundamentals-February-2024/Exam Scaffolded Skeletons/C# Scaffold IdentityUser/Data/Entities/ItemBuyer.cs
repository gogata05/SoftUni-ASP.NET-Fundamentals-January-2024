

//pp,pp5
//db,sl1
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

//copy description here:
//AdBuyer
//    •	BuyerId – a  string, Primary Key, foreign key (required)
//    •	Buyer – IdentityUser
//    •	AdId – an integer, Primary Key, foreign key (required)
//    •	Ad – Ad

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
namespace SoftUniBazar.Data.Models
{
    public class AdBuyer
    {
        [Required]
        public string BuyerId { get; set; } = null!;

        [ForeignKey(nameof(BuyerId))]
        public IdentityUser Buyer { get; set; } = null!;

        [Required]
        public int AdId { get; set; }

        [ForeignKey(nameof(AdId))]
        public Ad Ad { get; set; } = null!;
    }
}
//fk,req,max,*

// AdBuyer 
// BuyerId – a  string, Primary Key, foreign key (required) 
// Buyer – IdentityUser 
// AdId – an integer, Primary Key, foreign key (required) 
// Ad – Ad 
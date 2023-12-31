using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Infrastructure.Model
{
    [Comment("Product table")]
    public class Product
    {
        [Comment("Product Id")]
        [Key]
        public string Id { get; set; } = null!;

        [Comment("Product name")]
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string ProductName { get; set; } = null!;

        public decimal? Price { get; set; }
    }
}

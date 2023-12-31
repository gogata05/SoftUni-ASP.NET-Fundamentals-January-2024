namespace ShoppingList.Core.Models
{
    public class ProductViewModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public decimal? Price { get; set; }
    }
}

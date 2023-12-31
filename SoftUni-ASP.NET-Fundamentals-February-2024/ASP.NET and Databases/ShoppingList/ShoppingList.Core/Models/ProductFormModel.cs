namespace ShoppingList.Core.Models
{
    public class ProductFormModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;

        public decimal? Price { get; set; }
    }
}

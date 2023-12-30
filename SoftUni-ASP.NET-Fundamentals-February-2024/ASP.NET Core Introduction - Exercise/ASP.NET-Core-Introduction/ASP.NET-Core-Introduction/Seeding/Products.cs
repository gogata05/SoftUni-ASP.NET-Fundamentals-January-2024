using ASP.NET_Core_Introduction.Models;

namespace ASP.NET_Core_Introduction.Seeding
{
    public static class Products
    {
        public static ICollection<ProductViewModel> _products =
            new List<ProductViewModel>()
            {
                new ProductViewModel()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cheese",
                    Price = 7.00m
                },
                new ProductViewModel()
                {
                    Id = Guid.NewGuid(),
                    Name = "Ham",
                    Price = 5.50m
                },
                new ProductViewModel()
                {
                    Id = Guid.NewGuid(),
                    Name = "Bread",
                    Price = 1.50m
                }
            };
    }
}

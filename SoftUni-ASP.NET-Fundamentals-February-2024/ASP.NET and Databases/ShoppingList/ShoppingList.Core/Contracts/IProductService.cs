using ShoppingList.Core.Models;
using ShoppingList.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Core.Contracts
{
    public interface IProductService
    {
        public Task<ICollection<ProductViewModel>> AllAsync();

        public Task CreateAsync(ProductAddModel product);

        public Task<ProductFormModel> GetByIdAsync(string id);

        public Task EditAsync (ProductFormModel product);

        public Task Delete (string id);
    }
}

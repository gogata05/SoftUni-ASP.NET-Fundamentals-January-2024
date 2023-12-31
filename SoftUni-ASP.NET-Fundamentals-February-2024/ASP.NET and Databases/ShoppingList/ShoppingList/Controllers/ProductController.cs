using Microsoft.AspNetCore.Mvc;
using ShoppingList.Core.Contracts;
using ShoppingList.Core.Models;

namespace ShoppingList.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.AllAsync();
            return View(products);
        }

        public IActionResult Add()
        {
            return View(new ProductAddModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                await _productService.CreateAsync(model);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id)
        {
            ProductFormModel product = await _productService.GetByIdAsync(id);

            return View(product);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductFormModel product)
        {
            
            if(!ModelState.IsValid)
            {
                return View(product);
            }

            await _productService.EditAsync(product);


            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(string id)
        {
            await _productService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}

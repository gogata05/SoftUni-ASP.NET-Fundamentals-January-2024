using ASP.NET_Core_Introduction.Models;
using ASP.NET_Core_Introduction.Seeding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ASP.NET_Core_Introduction.Controllers
{
    public class ProductController : Controller
    {
        [ActionName("My-Products")]
        public IActionResult All(string keyword)
        {
             if(keyword != null)
            {
                List <ProductViewModel> products = Products._products.
                               Where(p => p.Name.ToLower()
                                          .Contains(keyword.ToLower()))
                                          .ToList();

                return View(products);
            }
            return View(Products._products);
        }

        public IActionResult ById(string id)
        {
            ProductViewModel currentProduct = Products._products.FirstOrDefault(p => p.Id.ToString() == id);
            if(currentProduct == null)
            {
                return RedirectToAction("All");
            }

            return View(currentProduct);
        }

        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            return Json(Products._products,options);
        }

        public IActionResult AllAsText()
        {
            StringBuilder sb = new StringBuilder();
            int counter = 1;

            foreach(var  item in Products._products)
            {
                sb.AppendLine($"Product {counter}: {item.Name} - {item.Price} lv.");
                counter++;
            }

            return Content(sb.ToString());
        }

        public IActionResult AllAsTextFile()
        {
            StringBuilder sb = new StringBuilder();
           
            int counter = 1;

            foreach (var item in Products._products)
            {
                sb.AppendLine($"Product {counter}: {item.Name} - {item.Price} lv.");
                counter++;
            }

            Response.Headers.Add(HeaderNames.ContentDisposition,
                @"atachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()),"text/plain");
        }
    }
}

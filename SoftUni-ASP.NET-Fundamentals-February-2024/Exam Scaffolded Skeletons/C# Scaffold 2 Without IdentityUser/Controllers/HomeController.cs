
//if logged, users no need to be redirected from "/" to "/Item/All" don't use extra code
//only return View(); like "Book Library" task

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SoftUniBazar.Models;

namespace SoftUniBazar.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Replace "Item" with "name"
            //remove "if" if no need to redirect from "/"
            if (User?.Identity?.IsAuthenticated ?? false)//if logged
            {
                return RedirectToAction("All", "Item");//redirect "/" to "/Ad/All"
                //action "All",Controller "Ad"
            }
            return View();
        }
        //remove "ResponseCache" and "Error" if no need to redirect from "/"
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]//stop cache
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });//redirect to error view
        }
    }
}
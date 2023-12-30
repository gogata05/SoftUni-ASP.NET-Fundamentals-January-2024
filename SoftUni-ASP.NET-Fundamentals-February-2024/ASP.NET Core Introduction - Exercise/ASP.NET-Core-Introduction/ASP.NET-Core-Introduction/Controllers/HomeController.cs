using ASP.NET_Core_Introduction.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP.NET_Core_Introduction.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Hello world!";
            ViewData["Msg"] = "This is the";
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Msg"] = "This is an ASP.NET Core MVC App.";
            ViewData["AboutMsg"] = "This is the about page for our first ASP.NET Core MVC app.";
            return View();
        }

        public IActionResult Numbers ()
        {
            return View();
        }

       public IActionResult NumbersToN(int count = -1)
        {
            ViewBag.Count = count;

            return View();
        }
    }
}
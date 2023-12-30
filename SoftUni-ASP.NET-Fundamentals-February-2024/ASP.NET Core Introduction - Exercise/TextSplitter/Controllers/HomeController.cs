using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TextSplitter.Models;

namespace TextSplitter.Controllers;
public class HomeController : Controller
{

    public IActionResult Index(TextViewModel model)
    {
       

        return View(model);
    }


    [HttpPost]
    public IActionResult Split(TextViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Index", model);
        }


        var splitTextArr = model.Text
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

        model.SplitText = string.Join(Environment.NewLine, splitTextArr);

        return RedirectToAction("Index", model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    
}

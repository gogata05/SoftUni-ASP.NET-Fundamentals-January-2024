using ASPNETCore_Demo_Introduction.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCore_Demo_Introduction.Controllers
{
    public class CoolCarController : Controller
    {
  
        public IActionResult MyCar()
        {
            ICoolCar car = new CoolCar
            {
                Id = 1,
                Make = "VW",
                Model = "Passat",
                Price = 5999
            };
            ViewBag.OwnerName = "Gmooc";
            ViewData["Age"] = 44;
            return View(car);
        }   
    }
}

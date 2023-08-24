using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Controllers
{
    // define Controller, name = Home
    public class HomeController : Controller
    {

        // define action of controller
        public IActionResult Index() {
            return View("Views/Default.cshtml");
        }

        public IActionResult List()
        {
            return View();
        }

        public string Show()
        {
            return "Action Show";
        }
    }
}

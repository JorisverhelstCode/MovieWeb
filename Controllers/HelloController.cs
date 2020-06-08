using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWeb
{
    public class HelloController : Controller
    {

        public IActionResult Welcome(string name = "idiot", int numberOfTimes = 1) 
        {
            ViewData["name"] = name;
            ViewData["numberOfTimes"] = numberOfTimes;
            return View();
        }
    }
}

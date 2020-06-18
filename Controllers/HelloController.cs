using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWeb
{
    public class HelloController : Controller
    {
        private readonly IConfiguration _configuration;

        public HelloController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Welcome(string name = "idiot", int numberOfTimes = 1) 
        {
            ViewData["name"] = name;
            ViewData["numberOfTimes"] = numberOfTimes;
            return View();
        }

        public IActionResult Dev()
        {
            var model = new HelloDevViewModel
            {
                FirstName = _configuration["Dev:FirstName"],
                LastName = _configuration["Dev:LastName"]
            };

            return View(model);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MovieWeb.Controllers
{
    public class TodayController : Controller
    {
        public IActionResult Today()
        {
            return View();
        }
    }
}
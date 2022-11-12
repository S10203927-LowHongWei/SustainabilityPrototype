using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SustainabilityPrototype.Controllers
{
    public class PointController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

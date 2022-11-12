using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SustainabilityPrototype.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SustainabilityPrototype.DAL;
using Microsoft.AspNetCore.Http;

namespace SustainabilityPrototype.Controllers
{
    public class Order : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CanteenDAL canteenContext = new CanteenDAL();

        public IActionResult Index()
        {
            return View();
        }
    }
}

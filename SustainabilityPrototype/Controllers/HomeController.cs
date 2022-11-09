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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private StudentDAL studentContext = new StudentDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public ActionResult Login()
        {
            Console.WriteLine("fds");
            return View();
        }
        [HttpPost]
        public ActionResult Login(IFormCollection formData)
        {
            
            string username = formData["username"].ToString();
            string password = formData["password"].ToString();
            Student s = studentContext.GetStudent(username,password);
            if(s.StudentId == username)
            {
                return RedirectToAction("Register");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

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
using Nancy.Json;

namespace SustainabilityPrototype.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private StudentDAL studentContext = new StudentDAL();
        private VendorDAL vendorContext = new VendorDAL();
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
            return View();
        }
        [HttpPost]
        public ActionResult Login(IFormCollection formData)
        {
            
            string username = formData["username"].ToString();
            string password = formData["password"].ToString();
            if(username.Length != 0)
            {
                if (username[0].ToString().ToLower() == "s")
                {
                    Student s = studentContext.GetStudent(username, password);
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    string jsonObj = jss.Serialize(s);
                    HttpContext.Session.SetString("User", jsonObj);
                    if (s.Username == username)
                    {
                        return RedirectToAction("Index", "Point",new { User = "Student", Student = s});
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                else if (username[0].ToString().ToLower() == "v")
                {
                    Vendor v = vendorContext.GetVendor(username, password);
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    string jsonObj = jss.Serialize(v);
                    HttpContext.Session.SetString("User", jsonObj);
                    if (v.Username == username)
                    {
                        return RedirectToAction("Index", "Point", new { User = "Vendor", Vendor = v }) ;
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    TempData["ErrorMsg"] = "Wrong Details Entered";
                    return RedirectToAction("Login");
                }
            }
            TempData["ErrorMsg"] = "Please Input Details";
            return RedirectToAction("Login");
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Registered()
        {
            Student student = new Student();
            return View(student);
        }


        // POST: Register
        [HttpPost]
        public ActionResult Registered(Student student)
        {
            //Add staff record to database
            studentContext.Register(student);
            //Redirect user to Customer/Index view
            return RedirectToAction("Login");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SustainabilityPrototype.Models;

namespace SustainabilityPrototype.Controllers
{
    public class PointController : Controller
    {
        public IActionResult Index()
        {
            string studentObj = HttpContext.Session.GetString("Student");
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Student s = jss.Deserialize<Student>(studentObj);
            ViewData["Name"] = s.StudentName;
            ViewData["Email"] = s.StudentEmailAddr;
            ViewData["DOB"] = s.DOB;
            return View();
        }
    }
}

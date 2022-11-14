using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using System;
using System.Linq;
using SustainabilityPrototype.Models;
using QRCoder;
using System.Drawing;

    public class PointController : Controller
    {
        public IActionResult Index()
        {
            string studentObj = HttpContext.Session.GetString("Student");
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Student s = jss.Deserialize<Student>(studentObj);
            ViewData["Name"] = s.StudentName;
            ViewData["Email"] = s.StudentEmailAddr;
            ViewData["DOB"] = Convert.ToDateTime(s.DOB).ToShortDateString();
            return View();
        }
        public IActionResult Redeem()
        {
            QRCodeGenerator qrGen = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGen.CreateQrCode("S10203927",QRCodeGenerator.ECCLevel.Q);
            QRCode qrcode = new QRCode(qrCodeData);
            Bitmap qrImg = qrcode.GetGraphic(20);
            Console.WriteLine(qrImg.ToString());
            ViewData["QR"] = qrImg;
            return View();
        }
    }
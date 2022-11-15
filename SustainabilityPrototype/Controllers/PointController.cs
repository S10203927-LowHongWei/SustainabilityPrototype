using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using System;
using System.Linq;
using SustainabilityPrototype.Models;
using QRCoder;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

public class PointController : Controller
{
    private Student state()
    {
        string studentObj = HttpContext.Session.GetString("Student");
        JavaScriptSerializer jss = new JavaScriptSerializer();
        Student s = jss.Deserialize<Student>(studentObj);
        return s;
    }
    public IActionResult Index(string user)
    {
        if(user == "Student")
        {
            string UserObj = HttpContext.Session.GetString("User");
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Student s = jss.Deserialize<Student>(UserObj);
            ViewData["Name"] = s.StudentName;
            ViewData["Email"] = s.StudentEmailAddr;
            ViewData["DOB"] = Convert.ToDateTime(s.DOB).ToShortDateString();
            ViewData["User"] = user;
        }
        else if(user == "Vendor")
        {
            string UserObj = HttpContext.Session.GetString("User");
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Vendor v = jss.Deserialize<Vendor>(UserObj);
            ViewData["Name"] = v.StallName;
            ViewData["User"] = user;
        }

        return View();
    }
    public IActionResult Redeem()
    {
        return View();
    }
    public IActionResult QRCode()
    {
        bool f = false;
        Student s = state();
        if (f == true)
        {
            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode("VoucherID", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            MemoryStream ms = new MemoryStream();
            using (Bitmap bitmap = qrCode.GetGraphic(10))
            {
                bitmap.Save(ms, ImageFormat.Png);
                ViewData["QR"] = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
            }
            ViewData["RedeemOption"] = "Scan Voucher";
        }
        else if (f == false)
        {
            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(s.Username.ToString(), QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            MemoryStream ms = new MemoryStream();
            using (Bitmap bitmap = qrCode.GetGraphic(10))
            {
                bitmap.Save(ms, ImageFormat.Png);
                ViewData["QR"] = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
            }
            ViewData["RedeemOption"] = "Earn Points";
        }
        return View();
    }
}
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
using SustainabilityPrototype.DAL;

public class PointController : Controller
{
    private Student state()
    {
        string studentObj = HttpContext.Session.GetString("User");
        JavaScriptSerializer jss = new JavaScriptSerializer();
        Student s = jss.Deserialize<Student>(studentObj);
        return s;
    }
    private StudentDAL studentContext = new StudentDAL();
    public IActionResult Index(string user)
    {
            string UserObj = HttpContext.Session.GetString("User");
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Student s = jss.Deserialize<Student>(UserObj);
            ViewData["Name"] = s.StudentName;
            ViewData["Email"] = s.StudentEmailAddr;
            ViewData["DOB"] = Convert.ToDateTime(s.DOB).ToShortDateString();
            ViewData["User"] = user;
        TempData["StudentID"] = s.StudentId;
        ViewData["studentPoints"] = TempData["Points"];
        

        return View();
    }
    public IActionResult Redeem()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Redeem(int points)
    {
        int id = studentContext.CreateVoucher(points);
        studentContext.RemovePoints(TempData["StudentID"].ToString(),points);
        TempData["VoucherID"] = id;
        return RedirectToAction("QRCode");
    }
    public IActionResult QRCode()
    {
        Student s = state();
        if (TempData["VoucherID"] != null)
        {
            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(TempData["VoucherID"].ToString(), QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            MemoryStream ms = new MemoryStream();
            using (Bitmap bitmap = qrCode.GetGraphic(10))
            {
                bitmap.Save(ms, ImageFormat.Png);
                ViewData["QR"] = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
            }
            ViewData["RedeemOption"] = "Scan Voucher";
            TempData["VoucherID"] = null;
        }
        else
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
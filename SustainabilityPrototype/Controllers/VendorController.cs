using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SustainabilityPrototype.DAL;
using SustainabilityPrototype.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ZXing;

namespace SustainabilityPrototype.Controllers
{
    public class VendorController : Controller
    {
        private IHostingEnvironment hostingEnvironment;
        private StudentDAL studentContext = new StudentDAL();
        private VendorDAL vendorContext = new VendorDAL();

        public VendorController(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
        // GET: VendorController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VendorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VendorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VendorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VendorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VendorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VendorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VendorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       //GET: VendorController/QrCodeChoice/
       public ActionResult QRCodeChoice()
        {
            return View();
        }

        //GET VendorController/GivingVoucher

        public ActionResult GivingVoucher()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GivingVoucher(IFormCollection point)
        {
            var points = point["total"].ToString();
            TempData["Points"] = points;
            return RedirectToAction("GivePoints");
        }

        //VendorController/QRCodeSuccess
        public ActionResult CurrentOrders()
        {
            return View();
        }
        //GET: VendorController/RedeemVoucher
        public IActionResult RedeemVoucher()
        {
            return View();
        }

        //POST: VendorController/RedeemVoucher
        [HttpPost]
        public ActionResult RedeemVoucher(string name)
        {
            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            var filepath = Path.Combine(hostingEnvironment.WebRootPath, "images", "QRCode.png");
                            // Save image file in local folder
                            if (!string.IsNullOrEmpty(filepath))
                            {
                                using (FileStream fileStream = System.IO.File.Create(filepath))
                                {
                                    file.CopyTo(fileStream);
                                    fileStream.Flush();
                                }
                            }

                        }
                    }
                    try
                    {
                        string UploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                        string FilePath = Path.Combine(UploadFolder, "QRCode.png");
                        using (Bitmap image = (Bitmap)Bitmap.FromFile(FilePath))
                        {
                            var reader = new BarcodeReader();
                            var msg = reader.Decode(image); // This is where the result of the message goes
                            if (msg == null)
                            {
                                TempData["Scan"] = "Did not scan properly! Try Again";
                            }
                            else if (msg != null)
                            {
                                TempData["Scan"] = "QR Code Successfully Scanned!";

                            }
                        }
                        if(TempData["Scan"].ToString() == "Did not scan properly! Try Again") 
                        {
                            ViewData["Err"] = "Did not scan properly! Try Again";
                            return View();
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Failed");
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult GivePoints()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GivePoints(string name)
        {
            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            var filepath = Path.Combine(hostingEnvironment.WebRootPath, "images", "QRCode.png");
                            // Save image file in local folder
                            if (!string.IsNullOrEmpty(filepath))
                            {
                                using (FileStream fileStream = System.IO.File.Create(filepath))
                                {
                                    file.CopyTo(fileStream);
                                    fileStream.Flush();
                                }
                            }

                        }
                    }
                    try
                    {
                        string UploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                        string FilePath = Path.Combine(UploadFolder, "QRCode.png");
                        using (Bitmap image = (Bitmap)Bitmap.FromFile(FilePath))
                        {
                            var reader = new BarcodeReader();
                            var msg = reader.Decode(image); // This is where the result of the message goes
                            if (msg == null)
                            {
                                TempData["Scan"] = "Did not scan properly! Try Again";
                            }
                            else if (msg != null)
                            {
                                TempData["Scan"] = "QR Code Successfully Scanned!";
                                int rows = studentContext.UpdatePoints(msg.ToString(), Convert.ToInt32(TempData["Points"])/2);
                                return RedirectToAction("Index");
                            }
                        }
                        if (TempData["Scan"].ToString() == "Did not scan properly! Try Again")
                        {
                            ViewData["Err"] = "Did not scan properly! Try Again";
                            return View();
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Failed");
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
       
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SustainabilityPrototype.Models;
using Microsoft.AspNetCore.Http;

namespace SustainabilityPrototype.Controllers
{
    public class OrderController : Controller
    {
        //Order cart to store all the selected items
        private List<string> amtRice = new List<string> {"100 grams", "200 grams"};


        // GET: OrderController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Foodclub()
        {
            return View();
        }

        public ActionResult Indonesian()
        {
            return View();
        }

        public ActionResult NasiLemak()
        {
            ViewData["amtRice"] = amtRice;

            Orderdetails orderdetails = new Orderdetails
            {

            };
            return View();
        }
        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
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

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
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

        //GET: OrderContoller/SelectedStall
        public ActionResult SelectedStall()
        {
            return View();
        }

        public ActionResult OrderSummary()
        {
            return View();
        }
    }
}

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
        //List to store all the order details temporarily
        List<Orderdetails> personalOrder = new List<Orderdetails>();
        //Order qty
        private List<SelectListItem> FoodQty = new List<SelectListItem>();

        public OrderController()
        {
            //Populate the selection list for drop-down list
            for (int i = 1; i <= 10; i++)
            {
                FoodQty.Add(
                new SelectListItem
                {
                    Value = i.ToString(),
                    Text = i.ToString(),
                });
            }
        }

        // GET: OrderController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Foodclub()
        {
            return View();
        }

        //Inonesian food stall controller actions
        public ActionResult Indonesian()
        {
            return View();
        }

        public ActionResult NasiLemak()
        {
            Orderdetails newOrderdetail = new Orderdetails();
            newOrderdetail.OrderQty = 1;
            newOrderdetail.FoodId = 5;
            return View(newOrderdetail);
        }

        public ActionResult AddToBasketConfirmation()
        {
            return View();
        }

        public ActionResult OrderComplete()
        {
            return View();
        }

        public ActionResult CreateOrderItem(Orderdetails newOrderdetail)
        {
            personalOrder.Append(newOrderdetail);
            return RedirectToAction("AddToBasketConfirmation");
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

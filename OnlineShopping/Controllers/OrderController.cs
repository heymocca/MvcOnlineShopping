using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopping.Controllers
{
    public class OrderController : Controller
    {
        // Complete purchase
        public ActionResult Complete()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Complete(FormCollection form)
        {
            // TODO: Save order detail and shopping cart to database

            // TODO: Once finish shopping, clear all shopping information

            return RedirectToAction("Index","Home");
        }
    }
}
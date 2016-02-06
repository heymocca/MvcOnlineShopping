using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopping.Controllers
{
    public class ShoppingCartController : Controller
    {

        // List shopping cart items
        public ActionResult Index()
        {
            return View();
        }


        // Post: ShoppingCart
        // Add product to shopping cart, if no value pass from amount, then quantity is 1 by default.
        // Using Ajax calls this action.
        [HttpPost]
        public ActionResult AddToCart(int ProductId, int Amount = 1)
        {
            return View();
        }
        

        // Remove items from shopping cart, using Ajax calls this action.
        [HttpPost]
        public ActionResult Remove(int ProductId)
        {
            return View();
        }


        // Update shopping cart, using Ajax calls this action.
        public ActionResult UpdateAmount(int ProductId, int NewAmout)
        {
            return View();
        }

    }
}
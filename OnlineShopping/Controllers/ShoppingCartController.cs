using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShopping.Models;

namespace OnlineShopping.Controllers
{
    public class ShoppingCartController : BaseController
    {

        // List shopping cart items
        public ActionResult Index()
        {
            return View(this.ShoppingCarts);
        }


        // Post: ShoppingCart
        // Add product to shopping cart, if no value pass from amount, then quantity is 1 by default.
        // Using Ajax calls this action.
        [HttpPost]
        public ActionResult AddToCart(int ProductId, int Amount = 1)
        {
            var product = db.Products.Find(ProductId);

            if (product == null)
                return HttpNotFound();

            var existingCart = this.ShoppingCarts.FirstOrDefault(p => p.Product.Id == ProductId);

            if (existingCart != null)
            {
                existingCart.Amount += 1;
            }
            else
            {
                this.ShoppingCarts.Add(new ShoppingCart() { Product = product, Amount = Amount });
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.Created);
        }
        

        // Remove items from shopping cart, using Ajax calls this action.
        [HttpPost]
        public ActionResult Remove(int ProductId)
        {
            var existingCart = this.ShoppingCarts.FirstOrDefault(p => p.Product.Id == ProductId);

            if (existingCart != null)
            {
                this.ShoppingCarts.Remove(existingCart);
            }
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }


        // Update shopping cart, using Ajax calls this action.
        public ActionResult UpdateAmount(List<ShoppingCart> ShoppingCarts)
        {
            foreach (var item in ShoppingCarts)
            {
                var existingCart = this.ShoppingCarts.FirstOrDefault(p => p.Product.Id == item.Product.Id);

                if (existingCart != null)
                {
                    existingCart.Amount = item.Amount;
                }
            }
            return RedirectToAction("Index","ShoppingCart");
        }

    }
}
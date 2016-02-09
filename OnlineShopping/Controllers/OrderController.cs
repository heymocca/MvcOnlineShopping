using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopping.Controllers
{
    public class OrderController : BaseController
    {
        // Complete purchase
        public ActionResult Complete(OrderHeader form)
        {
            var member = db.Members.Where(m => m.Email == User.Identity.Name).FirstOrDefault();

            if (member == null)

                return RedirectToAction("Index","Home");

            if (this.ShoppingCarts.Count == 0)

                return RedirectToAction("Index","ShoppingCart");

            OrderHeader orderHeader = new OrderHeader()
            {
                Member = member,
                ContactName = form.ContactName,
                ContactNumber = form.ContactNumber,
                DeliveryAddress = form.DeliveryAddress,
                BuyOn = DateTime.Now,
                Memo = form.Memo,
                OrderDetails = new List<OrderDetail>()                
            };

            int totalAmount = 0;

            foreach (var item in this.ShoppingCarts)
            {
                var product = db.Products.Find(item.Product.Id);

                if (product == null)
                    return RedirectToAction("Index","ShoppingCart");

                totalAmount += item.Product.Price * item.Amount;

                orderHeader.OrderDetails.Add(new OrderDetail()
                {
                    Product = product, Price = product.Price, Amount = item.Amount
                });
            }

            orderHeader.TotalPrice = totalAmount;

            db.OrderHeaders.Add(orderHeader);
            db.SaveChanges();

            this.ShoppingCarts.Clear();

            return RedirectToAction("Index","Home");
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
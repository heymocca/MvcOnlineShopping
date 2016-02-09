using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShopping.Models;
using OnlineShopping.DAL;
using System.Web.Mvc;

namespace OnlineShopping.Controllers
{
    public class BaseController : Controller
    {
        protected OnlineShoppingContext db = new OnlineShoppingContext();

        protected List<ShoppingCart> ShoppingCarts
        {
            get
            {
                if (Session["ShoppingCart"] == null)
                {
                    Session["ShoppingCart"] = new List<ShoppingCart>();
                }
                return (Session["ShoppingCart"] as List<ShoppingCart>);
            }
            set { Session["ShoppingCart"] = value; }
        }
    }
}
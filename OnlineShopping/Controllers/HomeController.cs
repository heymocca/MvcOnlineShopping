using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;

namespace OnlineShopping.Controllers
{
    public class HomeController : Controller
    {
        #region// Index
        public ActionResult Index()
        {
            var data = new List<ProductCategory>
            {
                new ProductCategory () { Id = 1, Name = "MEN" },
                new ProductCategory () { Id = 2, Name = "WOMEN" },
                new ProductCategory () { Id = 3, Name = "KIDS" },
            };
            return View(data);
        }
        #endregion

        #region// Product List
        public ActionResult ProductList(int id)
        {
            var productCategory = new ProductCategory()
            { Id = id, Name = "Category" + id };

            var data = new List<Product>
            {
                new Product() {
                    Id = 1, Name = "Snapback Cap", ProductCategory = productCategory,
                    Price = 20, Color = Color.Black, Description = "Chicago Bulls NBA HWC Suedebuck 9FIFTY Snapback Cap",
                    PublishOn = DateTime.Now
                },
                new Product() {
                    Id = 1, Name = "Snapback Cap", ProductCategory = productCategory,
                    Price = 21, Color = Color.White, Description = "New Era NFL Super Bowl Team Rival 9FIFTY Snapback Cap",
                    PublishOn = DateTime.Now
                }
            };

            return View(data);
        }
        #endregion

        #region// Product Detail
        public ActionResult ProductDetail(int id)
        {
            var productCategory = new ProductCategory() { Id = 1, Name = "MEN" };

            var data = new Product()
            {
                Id = id,
                ProductCategory = productCategory,
                Name = "Product" + id,
                Description = "N/A",
                Price = 20,
                PublishOn = DateTime.Now,
                Color = Color.Black
            };


            return View(data);
        }
        #endregion
    }
}
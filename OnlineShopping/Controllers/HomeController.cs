using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using OnlineShopping.DAL;

namespace OnlineShopping.Controllers
{
    public class HomeController : Controller
    {
        private OnlineShoppingContext db = new OnlineShoppingContext();
        #region// Index
        public ActionResult Index()
        {
            var data = db.PorductCategories.ToList();

            // Give some data for testing
            if ( data.Count == 0 )
            {
                db.PorductCategories.Add(new ProductCategory() { Id = 1, Name = "MEN" });
                db.PorductCategories.Add(new ProductCategory() { Id = 2, Name = "WOMEN" });
                db.PorductCategories.Add(new ProductCategory() { Id = 3, Name = "KIDS" });
                db.PorductCategories.Add(new ProductCategory() { Id = 4, Name = "ACCESSORIES" });

                db.SaveChanges();

            data = db.PorductCategories.ToList();
            }
            return View(data);
        }
        #endregion

        #region// Product List
        public ActionResult ProductList(int id)
        {
            var productCategory = db.PorductCategories.Find(id);

            //if (productCategory != null)
            //{
                var data = productCategory.Products.ToList();

                //if (data.Count == 2)
                //{
                //    productCategory.Products.Add(new Product()
                //    {
                //        Name = productCategory.Name + "Snapback Cap",
                //        Color = Color.Black,
                //        Description = "Chicago Bulls NBA HWC Suedebuck 9FIFTY Snapback Cap",
                //        Price = 20,
                //        ProductCategory = productCategory,
                //        PublishOn = DateTime.Now
                //    });
                //    productCategory.Products.Add(new Product()
                //    {
                //        Name = productCategory.Name + "Snapback Cap",
                //        Color = Color.White,
                //        Description = "New Era NFL Super Bowl Team Rival 9FIFTY Snapback Cap",
                //        Price = 30,
                //        ProductCategory = productCategory,
                //        PublishOn = DateTime.Now
                //    });

                //    db.SaveChanges();

                //    data = productCategory.Products.ToList();
                //}

                return View(data);
            //}
            //else
            //{
            //    return HttpNotFound();
            //}

            

           

            
        }
        #endregion

        #region// Product Detail
        public ActionResult ProductDetail(int id)
        {
            var data = db.Products.Find(id);        

            return View(data);
        }
        #endregion
    }
}
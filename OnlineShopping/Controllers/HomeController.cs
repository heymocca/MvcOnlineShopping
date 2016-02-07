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

            #region // Give some data for testing
            if ( data.Count == 0 )
            {
                db.PorductCategories.Add(new ProductCategory() { Id = 1, Name = "MEN" });
                db.PorductCategories.Add(new ProductCategory() { Id = 2, Name = "WOMEN" });
                db.PorductCategories.Add(new ProductCategory() { Id = 3, Name = "KIDS" });
                db.PorductCategories.Add(new ProductCategory() { Id = 4, Name = "ACCESSORIES" });

                db.SaveChanges();

            data = db.PorductCategories.ToList();
            }
            #endregion
            return View(data);
        }
        #endregion

        #region// Product List
        public ActionResult ProductList(int id)
        {
            var productCategory = db.PorductCategories.Find(id);

            var data = productCategory.Products.ToList();

            return View(data);

            #region// Date for testing
            //if (productCategory != null)
            //{
            //    var data = productCategory.Products.ToList();

            //    if (data.Count < 4)
            //    {
            //        productCategory.Products.Add(new Product()
            //        {
            //            Name = productCategory.Name + "Belt",
            //            Color = ColorTranslator.ToHtml(Color.Green),
            //            Description = "New Era Canvas Belt",
            //            Price = 20,
            //            ProductCategory = productCategory,
            //            PublishOn = DateTime.Now
            //        });


            //        db.SaveChanges();

            //        data = productCategory.Products.ToList();
            //    }

            //    return View(data);
            //}
            //else
            //{
            //    return HttpNotFound();
            //}
            #endregion
            
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
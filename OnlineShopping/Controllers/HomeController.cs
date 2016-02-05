using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopping.Controllers
{
    public class HomeController : Controller
    {
        #region// Index
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region// Product List
        public ActionResult ProductList(int id)
        {
            return View();
        }
        #endregion

        #region// Product Detail
        public ActionResult ProductDetail(int id)
        {
            return View();
        }
        #endregion
    }
}
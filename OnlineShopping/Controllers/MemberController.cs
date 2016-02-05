using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShopping.Models;
using System.Web.Security;

namespace OnlineShopping.Controllers
{
    public class MemberController : Controller
    {
        #region// Member Register

        // GET: Member
        public ActionResult Register()
        {
            return View();
        }

        // POST: Member
        [HttpPost]
        public ActionResult Register([Bind(Exclude = "RegisterOn, AuthCode")] Member member)
        {
            return View();
        }
        #endregion

        #region// Member Login

        // GET: Member Login
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturenUrl = returnUrl;

            return View();
        }

        // Member Login
        [HttpPost]
        public ActionResult Login(string email, string password, string returnUrl)
        {
            if (ValidateUser(email, password))
            {
                FormsAuthentication.SetAuthCookie(email, false);

                if (String.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                else {
                    return Redirect(returnUrl);
                }
            }

            ModelState.AddModelError("","wrong user name or password");

            return View();
        }

        private bool ValidateUser(string email, string password)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region// Member Logout
        public ActionResult Logout()
        {
            // Clear Cookies
            FormsAuthentication.SignOut();

            // Clear Session
            Session.Clear();

            return RedirectToAction("Index","Home");
        }
        #endregion

    }
}
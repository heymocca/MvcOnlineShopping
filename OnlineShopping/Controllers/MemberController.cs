using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShopping.Models;
using System.Web.Security;
using System.Net.Mail;
using OnlineShopping.DAL;

namespace OnlineShopping.Controllers
{
    public class MemberController : Controller
    {
        private OnlineShoppingContext db = new OnlineShoppingContext();

        #region// Member Register

        // GET: Member
        public ActionResult Register()
        {
           return View();
        }

        private string pwSalt = "A1rySq1oPe2Mh784QQwG6jRAfkdPpDa90J0i";

        // POST: Member
        [HttpPost]
        public ActionResult Register([Bind(Exclude = "RegisterOn, AuthCode")] Member member)
        {
            var chk_member = db.Members.Where(m => m.Email == member.Email).FirstOrDefault();
            if (chk_member != null)
            {
                ModelState.AddModelError("Email", "This email already exists!");
            }
            if (ModelState.IsValid)
            {
                member.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(pwSalt + member.Password, "SHA1");
                member.RegisterOn = DateTime.Now;
                member.AuthCode = Guid.NewGuid().ToString();

                db.Members.Add(member);
                db.SaveChanges();

                SendAuthCodeToMember(member);

                return RedirectToAction("Index", "Home");
            }
            else {

                return View();
            }
            
        }

        private void SendAuthCodeToMember(Member member)
        {
            
            string mailBody = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/EmailValidationTemplate.htm"));

            mailBody = mailBody.Replace("{{Name}}", member.UserName);
            mailBody = mailBody.Replace("{{RegisterOn}}", member.RegisterOn.ToString("F"));
            var auth_url = new UriBuilder(Request.Url)
            {
                Path = Url.Action("ValidateRegister", new { id = member.AuthCode }),
                Query = ""
            };
            mailBody = mailBody.Replace("{{AUTH_URL}}", auth_url.ToString());

            
            try
            {
                SmtpClient SmtpServer = new SmtpClient();
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("youremailaddress", "password");

                SmtpServer.EnableSsl = true;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("youremailaddress");
                mail.To.Add(member.Email);
                mail.Subject = "Register confirmation";
                mail.Body = mailBody;
                mail.IsBodyHtml = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        #endregion

        #region// Member Login

        // GET
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturenUrl = returnUrl;

            return View();
        }

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

            return View();
        }

        private bool ValidateUser(string email, string password)
        {
            var hash_pw = FormsAuthentication.HashPasswordForStoringInConfigFile(pwSalt + password, "SHA1");

            var member = (from p in db.Members
                          where p.Email == email && p.Password == hash_pw
                          select p).FirstOrDefault();

            
            if (member != null)
            {
                if (member.AuthCode == null)
                {
                    return true;
                }
                else {
                    ModelState.AddModelError("", "Please check your email and active your account first.");
                    return false;
                }
            }
            else {
                ModelState.AddModelError("", "Wrong user name or password.");
                return false;
            }
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

        public bool ValidateRegister(string email, string password)
        {
            var hash_pw = FormsAuthentication.HashPasswordForStoringInConfigFile(pwSalt + password, "SHA1");

            var member = (from p in db.Members
                          where p.Email == email && p.Password == hash_pw
                          select p).FirstOrDefault();

            // 如果 member 物件不為 null 則代表會員的帳號、密碼輸入正確
            if (member != null) {
                if (member.AuthCode == null) {
                    return true;
                } else {
                    ModelState.AddModelError("", "Please check your email to active your account!");
                    return false;
                }
            } else {
                ModelState.AddModelError("", "Incorrect email or password!");
                return false;
            }
        }

        [HttpPost]
        public ActionResult ChkEmail(string Email)
        {
            var member = db.Members.Where(m => m.Email == Email).FirstOrDefault();

            if (member != null)
                return Json(false);
            else
                return Json(true);
        }
    }
}
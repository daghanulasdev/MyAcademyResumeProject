using Resume.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Resume.MVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        //GET: Login
       [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblLogin p)
        {
            MyAcademyDbEntities db = new MyAcademyDbEntities();
            var userinfo = db.TblLogin.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
            if (userinfo != null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.Username, false);
                Session["UserName"] = userinfo.Username.ToString();
                return RedirectToAction("Index", "AdminLayout");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
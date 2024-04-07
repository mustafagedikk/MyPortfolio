using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyPortfolio.Controllers
{

    [AllowAnonymous]
    public class LoginController : Controller
    {
       MyportfolioEntities1 db=new MyportfolioEntities1();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(Tbl_Admin admin)
        {
            var values=db.Tbl_Admin.FirstOrDefault(x=>x.UserName==admin.UserName && x.Password==admin.Password);

            if(values!=null) 
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                //false cokie nin kalıcı olmaması için kullanıldı
                Session["userName"] = values.UserName;
                
                return RedirectToAction("Index", "About");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Yanlış");
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Default");
        }
    }
}
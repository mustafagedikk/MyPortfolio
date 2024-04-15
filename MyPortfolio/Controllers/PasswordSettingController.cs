using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class PasswordSettingController : Controller
    {
       MyportfolioEntities1 db= new MyportfolioEntities1();
        public ActionResult Index()
        {
            var values = db.Tbl_Admin.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult UpdatePassword(int id)
        {
            var values=db.Tbl_Admin.Find(id);
            return View(values);

        }
        [HttpPost]
        public ActionResult UpdatePassword(Tbl_Admin tbl_Admin)
        {
            var values = db.Tbl_Admin.Find(tbl_Admin.AdminId);
            
            values.Password = tbl_Admin.Password;
            db.SaveChanges();
            return RedirectToAction("Index", "PasswordSetting");
        }
    }
}
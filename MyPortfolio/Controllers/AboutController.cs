using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        // GET: About
        MyportfolioEntities1 db = new MyportfolioEntities1();
        public ActionResult Index()
        {
            var values = db.Tbl_Abouts.ToList();
           
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {

            return View();  
        }

        [HttpPost]

        public ActionResult AddAbout(Tbl_Abouts abouts)

        {
            db.Tbl_Abouts.Add(abouts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAbout(int id)
        {
            var values = db.Tbl_Abouts.Find(id);
            db.Tbl_Abouts.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var values = db.Tbl_Abouts.Find(id);
            return View(values);

        }
        [HttpPost]

        public ActionResult UpdateAbout(Tbl_Abouts abouts)
        {
            var values = db.Tbl_Abouts.Find(abouts.AboutId);
            values.ImageUrl = abouts.ImageUrl;
            values.Title = abouts.Title;
            values.Description = abouts.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
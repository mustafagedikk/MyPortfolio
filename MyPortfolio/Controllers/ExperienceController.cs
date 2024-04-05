using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        MyportfolioEntities1 db=new MyportfolioEntities1();

        public ActionResult Index()
        {
            var values = db.Tbl_Exp.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExperience(Tbl_Exp exp)
        {
            db.Tbl_Exp.Add(exp);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DeleteExperience(int id) 
        {
            var values = db.Tbl_Exp.Find(id);
            db.Tbl_Exp.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        
        }

        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            var values=db.Tbl_Exp.Find(id);

            return View(values);

        }
        [HttpPost]
        public ActionResult UpdateExperience(Tbl_Exp exp)
        {
            var values = db.Tbl_Exp.Find(exp.ExpId);
            values.StarYear = exp.StarYear;
            values.AndYear= exp.AndYear;
            values.Location = exp.Location;
            values.Company=exp.Company;
            values.Title = exp.Title;
            values.Description = exp.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
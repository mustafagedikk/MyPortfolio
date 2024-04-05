using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class SkillController : Controller
    {
        MyportfolioEntities1 db=new MyportfolioEntities1();
        public ActionResult Index()
        {
            var values=db.Tbl_Skills.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddSkill() 
        {
            return View();        
        }
        [HttpPost]

        public ActionResult AddSkill(Tbl_Skills skills) 
        {
            db.Tbl_Skills.Add(skills);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id) 
        {
            var values = db.Tbl_Skills.Find(id);
            db.Tbl_Skills.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSkill(int id) 
        
        {
            var values = db.Tbl_Skills.Find(id);
            return View(values);
        
        }
        [HttpPost]
        public ActionResult UpdateSkill(Tbl_Skills skills)
        {
            var values = db.Tbl_Skills.Find(skills.SkilId);
            values.Value = skills.Value;
            values.SkilName= skills.SkilName;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
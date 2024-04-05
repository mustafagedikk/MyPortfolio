using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class FeatureController : Controller
    {
        // GET: Feature
        MyportfolioEntities1 db = new MyportfolioEntities1();
        public ActionResult Index()
        {
            var values = db.Tbl_Features.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddFeature()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFeature(Tbl_Features features)
        {
            db.Tbl_Features.Add(features);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteFeature(int id)
        {
            var values = db.Tbl_Features.Find(id);
            db.Tbl_Features.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
         public ActionResult UpdateFeature(int id) 
        {
            var values = db.Tbl_Features.Find(id);
            return View(values);
        
        }

        [HttpPost]
        public ActionResult UpdateFeature(Tbl_Features features)
        {
            var values = db.Tbl_Features.Find(features.FeatureId);
            values.NameSurname = features.NameSurname;
            values.Title = features.Title;
            values.ImageUrl = features.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}
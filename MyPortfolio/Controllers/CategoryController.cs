using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class CategoryController : Controller
    {
        MyportfolioEntities1 db = new MyportfolioEntities1();
        public ActionResult Index()
        {
           var values= db.Tbl_Categories.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]

        public ActionResult AddCategory(Tbl_Categories category) 
        {
            db.Tbl_Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult DeleteCategory(int id) 
        {
            var values = db.Tbl_Categories.Find(id);
            db.Tbl_Categories.Remove(values);
            db.SaveChanges();
            return RedirectToAction("index");
        
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var values = db.Tbl_Categories.Find(id);

            return View(values);

        }
        [HttpPost]
        public ActionResult UpdateCategory(Tbl_Categories category)
        {
            var values = db.Tbl_Categories.Find(category.CategoryId);
            values.CategoryName = category.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

   
}
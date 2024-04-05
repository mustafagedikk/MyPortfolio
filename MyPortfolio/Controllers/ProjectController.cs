using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        MyportfolioEntities1 db=new MyportfolioEntities1();
        public ActionResult Index()
        {
            var values=db.Tbl_Projects.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddProject()
        {
            var categories = db.Tbl_Categories.ToList();

            List<SelectListItem> categoryList=(from x in  categories select new SelectListItem
            {
                Value=x.CategoryId.ToString(),
                Text=x.CategoryName
            }).ToList();
            ViewBag.category= categoryList;
            return View();
           
        }
        [HttpPost]
        public ActionResult AddProject(Tbl_Projects projects)
        {
            db.Tbl_Projects.Add(projects);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProject(int id) 
        {
            var values = db.Tbl_Projects.Find(id);
            db.Tbl_Projects.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var categoryList = db.Tbl_Categories.ToList();
            var value = db.Tbl_Projects.Find(id);

            List<SelectListItem> categories = (from x in categoryList select new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();
            
            ViewBag.category= categories;
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateProject (Tbl_Projects projects)
        {
            var values = db.Tbl_Projects.Find(projects.ProjectId);
            values.ProjectName = projects.ProjectName;
            values.ImageUrl = projects.ImageUrl;
            values.GithubUrl = projects.GithubUrl;
            values.CategoryId = projects.CategoryId;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
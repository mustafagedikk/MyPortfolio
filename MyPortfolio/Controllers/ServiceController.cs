using Microsoft.Ajax.Utilities;
using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ServiceController : Controller
    {
        MyportfolioEntities1 db=new MyportfolioEntities1();
        public ActionResult Index()
        {
            var values=db.Tbl_Services.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddService(Tbl_Services service) 
        {
            db.Tbl_Services.Add(service);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteService(int id)
        {
            var values = db.Tbl_Services.Find(id);
            db.Tbl_Services.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var values= db.Tbl_Services.Find(id);

            return View(values);
        
        }
        [HttpPost]

        public ActionResult UpdateService(Tbl_Services service)
        {
            var values = db.Tbl_Services.Find(service.ServiceId);
            values.Icon=service.Icon;
            values.Title=service.Title;
            values.Description=service.Description;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult MakeActiveService(int id)
        {
            var values = db.Tbl_Services.Find(id);
            values.Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult MakePassiveService(int id)
        {
            var values = db.Tbl_Services.Find(id);
            values.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
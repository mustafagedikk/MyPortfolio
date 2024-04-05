using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class TestimonialController : Controller
    {
        MyportfolioEntities1 db= new MyportfolioEntities1();
        public ActionResult Index()
        {
            var values=db.Tbl_Testimonials.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddTestimonial() 
        {
          return View();
        }
        [HttpPost]

        public ActionResult AddTestimonial(Tbl_Testimonials testimonials)
        {
            db.Tbl_Testimonials.Add(testimonials);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var values=db.Tbl_Testimonials.Find(id);
            db.Tbl_Testimonials.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var values = db.Tbl_Testimonials.Find(id);
            return View(values);

        }
        [HttpPost]

        public ActionResult UpdateTestimonial(Tbl_Testimonials testimonials)
        {
            var values = db.Tbl_Testimonials.Find(testimonials.TestimonialId);
            values.ImageUrl = testimonials.ImageUrl;
            values.Comment = testimonials.Comment;
            values.NameSurname=testimonials.NameSurname;
            values.Title=testimonials.Title;
            values.Status=testimonials.Status;
            values.CommentDate=testimonials.CommentDate;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
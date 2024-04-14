using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        MyportfolioEntities1 db=new MyportfolioEntities1();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultFeaturePartial()
        {
            var values = db.Tbl_Features.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultAboutPartial()
        {
            var values=db.Tbl_Abouts.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
           
            return PartialView();
        }

        [HttpPost]
        public ActionResult SendMessage(Tbl_Messages messages)
        {
            var values=db.Tbl_Messages.Add(messages);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public PartialViewResult DefaultService()
        {
            var values = db.Tbl_Services.Where(x=>x.Status==true).ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultSkillPartial()
        {
            var values = db.Tbl_Skills.ToList();
            return PartialView(values);

        }

        public PartialViewResult DefaultProjectPartial()
        {
            var categories=db.Tbl_Categories.ToList();
            ViewBag.categories=categories;
            var values = db.Tbl_Projects.ToList();
               return PartialView(values);
            

        }

        public PartialViewResult DefaultExperiencePartial()
        {
            var values = db.Tbl_Exp.ToList();

            return PartialView(values);
        }

        public PartialViewResult DefaultTestimonialPartial()
        {
            var values = db.Tbl_Testimonials.ToList();
            return PartialView(values); 
        }

        public PartialViewResult DefaultTeamPartial()
        {
            var values=db.Tbl_Teams.ToList();

            return PartialView(values);
        }

        public PartialViewResult DefaultSocialMediaPartial()
        {

            var values=db.Tbl_SocialMedias.ToList();
           
            return PartialView(values);
        }
    }
}
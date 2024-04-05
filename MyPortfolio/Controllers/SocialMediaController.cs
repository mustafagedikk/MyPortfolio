using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        MyportfolioEntities1 db=new MyportfolioEntities1();
        public ActionResult Index()
        {
            var values=db.Tbl_SocialMedias.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocialMedia(Tbl_SocialMedias socialMedias)
        {
            db.Tbl_SocialMedias.Add(socialMedias);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSocialMedia(int id) 
        {
            var values = db.Tbl_SocialMedias.Find(id);
            db.Tbl_SocialMedias.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var values = db.Tbl_SocialMedias.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(Tbl_SocialMedias socialMedias)
        {
            var values = db.Tbl_SocialMedias.Find(socialMedias.SocialMediaId);
            values.SocialMediaName = socialMedias.SocialMediaName;
            values.Url= socialMedias.Url; 
            values.Icon= socialMedias.Icon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
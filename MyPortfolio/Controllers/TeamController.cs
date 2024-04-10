using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class TeamController : Controller
    {
      MyportfolioEntities1 db=new MyportfolioEntities1();   
        public ActionResult Index()
        {
            var values = db.Tbl_Teams.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddTeam(Tbl_Teams teams)
        {
             db.Tbl_Teams.Add(teams);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTeam(int id)
        {
            var values = db.Tbl_Teams.Find(id);
            db.Tbl_Teams.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTeam(int id)
        {
            var values = db.Tbl_Teams.Find(id);
            return View(values);

        }
        [HttpPost]
            public ActionResult UpdateTeam(Tbl_Teams teams)
        {
            var values = db.Tbl_Teams.Find(teams.TeamId);
            values.ImageUrl = teams.ImageUrl;
            values.NameSurname= teams.NameSurname;
            values.Description= teams.Description;
            values.TwitterUrl = teams.TwitterUrl;
            values.FacebookUrl= teams.FacebookUrl;
            values.LinkedinUrl= teams.LinkedinUrl;
            values.İnstagramUrl = teams.İnstagramUrl;
            values.Title = teams.Title;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
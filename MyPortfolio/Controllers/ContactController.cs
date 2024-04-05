using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ContactController : Controller
    {
      MyportfolioEntities1 db=new MyportfolioEntities1();
        public ActionResult Index()
        {
            var values = db.Tbl_Contacts.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddContact()
        {

            return View();

        }

        [HttpPost]

        public ActionResult AddContact(Tbl_Contacts contacts)
        {
            db.Tbl_Contacts.Add(contacts);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var values=db.Tbl_Contacts.Find(id);
            return View(values);

        }

        public ActionResult UpdateContact(Tbl_Contacts tbl_Contacts) 
        
        {
            var values = db.Tbl_Contacts.Find(tbl_Contacts.ContactId);
            values.Phone = tbl_Contacts.Phone;
            values.NameSurname = tbl_Contacts.NameSurname;
            values.Email = tbl_Contacts.Email;
            values.Adress = tbl_Contacts.Adress;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteContact(int id) 
        { var values=db.Tbl_Contacts.Find(id);
          db.Tbl_Contacts.Remove(values); db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
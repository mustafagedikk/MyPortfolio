using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class MessageController : Controller
    {
        MyportfolioEntities1 db=new MyportfolioEntities1();
        public ActionResult Index()
        {
            var values=db.Tbl_Messages.ToList();
            
            return View(values);
        }

        
    }
}
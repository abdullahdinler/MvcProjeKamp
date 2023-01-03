using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace MvcProjeKamp.Controllers
{
    
    public class AdminContentController : Controller
    {
        private ContentManager cm = new ContentManager(new EfContentDal());
        // GET: AdminContent
        //public ActionResult Index()
        //{
        //    var c = cm.GetList();
        //    return View(c);
        //}

        [HttpGet]
        public ActionResult ContentGetByHeading(int id)
        {
            var c = cm.GetListById(id);
            return View(c);
        }
    }
}
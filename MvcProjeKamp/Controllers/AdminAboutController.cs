using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MvcProjeKamp.Controllers
{
    public class AdminAboutController : Controller
    {
        private AboutManager am = new AboutManager(new EfAboutDal());
        // GET: AdminAbout
        public ActionResult Index()
        {
           var a=  am.GetList();
            return View(a);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(About entity)
        {
            am.Add(entity);
            return RedirectToAction("Index");
        }

        public PartialViewResult PartialViewAdd(About entity)
        {
            return PartialView();
        }
    }
}
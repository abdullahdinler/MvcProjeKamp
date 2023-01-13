using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MvcProjeKamp.Controllers
{
    public class WriterPanelContentController : Controller
    {
        private ContentManager cm = new ContentManager(new EfContentDal());
        private WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult MyContent(string p)
        {
            p = (string) Session["Mail"];
            var writerId = wm.GetList().Where( x=> x.Mail == p).Select(y=>y.Id).FirstOrDefault();
            var result = cm.GetListContent(writerId);
            return View(result);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content entity)
        {
            string p = (string)Session["Mail"];
            var writerId = wm.GetList().Where(x => x.Mail == p).Select(y => y.Id).FirstOrDefault();
            entity.DateTimee = DateTime.Parse(DateTime.Now.ToShortDateString());
            entity.WriterId = writerId;
            entity.Status = true;
            cm.Add(entity);
            return RedirectToAction("MyContent");
        }
    }
}
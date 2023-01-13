using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using PagedList.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class WriterPanelController : Controller
    {
        private HeadingManager hm = new HeadingManager(new EfHeadingDal());

        private CategoryManager cm = new CategoryManager(new EfCategoryDal());
        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult GetHeading(string p)
        {
            p = (string) Session["Mail"];
            var headingId = hm.GetList().Where(x => x.Writer.Mail == p).Select(y => y.WriterId).FirstOrDefault();
            var result = hm.GetList(headingId);
            return View(result);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> resultCategory = (from item in cm.GetList()
                select new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                }).ToList();
            ViewBag.ValueCategory = resultCategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading entity,string p)
        {
            p = (string) Session["Mail"];
            var writerId = hm.GetList().Where(x => x.Writer.Mail == p).Select(y => y.WriterId).FirstOrDefault();
            entity.DateTimee = DateTime.Parse(DateTime.Now.ToShortDateString());
            entity.WriterId = writerId;
            entity.Status = false;
            hm.Add(entity);
            return RedirectToAction("GetHeading");
        }
        public ActionResult Delete(int id)
        {
            var h = hm.GetById(id);
            h.Status = false;
            hm.Delete(h);
            return RedirectToAction("GetHeading","WriterPanel");
        }

        public ActionResult AllGetHeading(int p = 1)
        {
            var result = hm.GetList().ToPagedList(p,5);
            return View(result);
        }
    }
}
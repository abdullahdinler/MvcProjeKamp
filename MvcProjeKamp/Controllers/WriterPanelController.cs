using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using PagedList.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class WriterPanelController : Controller
    {
        private HeadingManager hm = new HeadingManager(new EfHeadingDal());

        private CategoryManager cm = new CategoryManager(new EfCategoryDal());

        private WriterManager wm = new WriterManager(new EfWriterDal());
        // GET: WriterPanel
        [HttpGet]
        public ActionResult WriterProfile()
        {
            string mail = (string) Session["Mail"];
            var writerId = wm.GetList().Where(x => x.Mail == mail).Select(y => y.Id).FirstOrDefault();
            var result = wm.GetById(writerId);
            return View(result);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer entity)
        {

            WriterValidator validator = new WriterValidator();
            ValidationResult result = validator.Validate(entity);
            if (result.IsValid)
            {
                wm.Update(entity);
                return RedirectToAction("AllGetHeading","WriterPanel");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
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
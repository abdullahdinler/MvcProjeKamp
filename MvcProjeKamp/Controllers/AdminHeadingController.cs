using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MvcProjeKamp.Controllers
{
    public class AdminHeadingController : Controller
    {
        // GET: AdminHeading
        private HeadingManager hm = new HeadingManager(new EfHeadingDal());
        private CategoryManager cm = new CategoryManager(new EfCategoryDal());
        private WriterManager wm = new WriterManager(new EfWriterDal());
        
        public ActionResult Index()
        {
            var h = hm.GetList();
            return View(h);
        }

        public ActionResult Rapor()
        {
            var h = hm.GetList();
            return View(h);
        }
        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> valueItems = (from x in cm.GetList()
                select new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();

            List<SelectListItem> valueWriter = (from x in wm.GetList()
                select new SelectListItem
                {
                    Text = x.Name + " " + x.SurName,
                    Value = x.Id.ToString()
                }).ToList();

            ViewBag.ItemsWriter = valueWriter;

            ViewBag.Items = valueItems;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Heading entity)
        {
            HeadingValidator validator = new HeadingValidator();
            ValidationResult result = validator.Validate(entity);
            if (result.IsValid)
            {
                entity.DateTimee = DateTime.Parse(DateTime.Now.ToShortTimeString());
                hm.Add(entity);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName,error.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var categoryget = (from x in cm.GetList()
                select new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();
            ViewBag.Item = categoryget;
            var h = hm.GetById(id);
            return View(h);
        }

        [HttpPost]
        public ActionResult Update(Heading entity)
        {
            HeadingValidator validator = new HeadingValidator();
            ValidationResult result = validator.Validate(entity);
            if (result.IsValid)
            {
                hm.Update(entity);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            var h = hm.GetById(id);
            h.Status = false;
            hm.Delete(h);
            return RedirectToAction("Index");
        }
    }
}
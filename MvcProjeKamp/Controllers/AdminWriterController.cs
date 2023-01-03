using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MvcProjeKamp.Controllers
{
    public class AdminWriterController : Controller
    {
        private WriterManager manager = new WriterManager(new EfWriterDal());
        // GET: Writer
        public ActionResult Index()
        {
          var w = manager.GetList();
            return View(w);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Writer entity)
        {
            WriterValidator validator = new WriterValidator();
            ValidationResult result = validator.Validate(entity);
            if (result.IsValid)
            {
               manager.Add(entity);
               return RedirectToAction("Index");

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
        [HttpGet]
        public ActionResult Update(int id)
        {
            var w = manager.GetById(id);
            return View(w);
        }

        [HttpPost]
        public ActionResult Update(Writer entity)
        {

            WriterValidator validator = new WriterValidator();
            ValidationResult result = validator.Validate(entity);
            if (result.IsValid)
            {
                manager.Update(entity);
                return RedirectToAction("Index");

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

    }
}
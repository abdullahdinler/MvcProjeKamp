using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MvcProjeKamp.Controllers
{
    public class AdminCategoryController : Controller
    {
        private CategoryManager _category = new CategoryManager(new EfCategoryDal());
       
        [Authorize(Roles = "b")] // sadece b rolunw sahip admin bu bölüme erişebilir.
        public ActionResult Index()
        {
            var c = _category.GetList();
            return View(c);
        }

        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CategoryAdd(Category entity)
        {
            CategoryValidator validator = new CategoryValidator();
            ValidationResult result = validator.Validate(entity);      
            if (result.IsValid)
            {
                _category.CatagoryAdd(entity);
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

        public ActionResult Delete(int id)
        {
            var c = _category.GetById(id);
            _category.Delete(c);
            return RedirectToAction("Delete");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var c = _category.GetById(id);
            return View(c);
        }

        [HttpPost]
        public ActionResult Update(Category entity)
        {
            _category.Update(entity);
            return RedirectToAction("Index");
        }
    }
}
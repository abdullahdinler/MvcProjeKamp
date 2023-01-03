using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace MvcProjeKamp.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryManager category = new CategoryManager(new EfCategoryDal());
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryGetList()
        {
           var categoryvalue = category.GetList();
            return View(categoryvalue);
        }

        [HttpGet] 
        public ActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CategoryAdd(Category entity)
        {
            CategoryValidator validator = new CategoryValidator(); // category validator new lyip nesene oluşturduk
            ValidationResult result = validator.Validate(entity);
            if (result.IsValid)
            {
                category.CatagoryAdd(entity);
                return RedirectToAction("CategoryGetList");
            }
            else
            {
                foreach (var error in result.Errors) // result tan gelen hata mesajlarını dongü icine alıp yazdırdık
                {
                    ModelState.AddModelError(error.PropertyName,error.ErrorMessage);
                }
            }
            return View();
        }
    }
}
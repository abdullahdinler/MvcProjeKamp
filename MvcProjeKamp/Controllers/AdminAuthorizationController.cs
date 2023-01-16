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
    public class AdminAuthorizationController : Controller
    {
        private AdminManager adm = new AdminManager(new EfAdminDal());
        private AdminValidator av = new AdminValidator();
        private ValidationResult vr;
        [HttpGet]
        public ActionResult Index()
        {
            var result = adm.GetList();
            return View(result);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Admin entity)
        {
            vr = av.Validate(entity);
            if (vr.IsValid)
            {
                adm.Add(entity);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in vr.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = adm.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(Admin entity)
        {
            vr = av.Validate(entity);
            if (vr.IsValid)
            {
                adm.Update(entity);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in vr.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            return View();
        }



        [HttpPost]
        public ActionResult Status(int id)
        {
            var result = adm.GetById(id);
            adm.Update(result);
            return RedirectToAction("Index");
        }
    }
}
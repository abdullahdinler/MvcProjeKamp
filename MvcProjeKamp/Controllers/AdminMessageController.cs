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
    public class AdminMessageController : Controller
    {
        private MessageManager mm = new MessageManager(new EfMessageDal());
        private DraftManager dm = new DraftManager(new EfDraftDal());

        private MessageValidator mv = new MessageValidator();
        // GET: AdminMessage
        [HttpGet]
        public ActionResult InBox()
        {
            var m = mm.GetListInBox();
            return View(m);
        }
        [HttpGet]
        public ActionResult SendBox()
        {
            var m = mm.GetListSendBox();
            return View(m);
        }

        [HttpGet]
        public ActionResult Add()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult Add(Message entity)
        {
            ValidationResult result = mv.Validate(entity);
            if (result.IsValid)
            {
                entity.DateTimee = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.Add(entity);
                return RedirectToAction("SendBox");
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

        public ActionResult GetDetailMessage(int id)
        {
            var m = mm.GetById(id);
            return View(m);
        }
    }
}
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
    public class WriterPanelMessageController : Controller
    {
        private MessageManager mm = new MessageManager(new EfMessageDal());
        private ContactManager cm = new ContactManager(new EfContactDal());
        private MessageValidator mv = new MessageValidator();
        
        // GET: WriterPanelMessage
        public ActionResult InBox()
        {
            var p = (string)Session["Mail"];
            var result = mm.GetListInBox().Where(x => x.ReceiverMail == p);
            return View(result.ToList());
        }

        public ActionResult SendBox()
        {
            var p = (string)Session["Mail"];
            var result = mm.GetListSendBox().Where(x => x.SendMail == p);
            return View(result.ToList());
        }

        public PartialViewResult GetBox()
        {
            var p = (string)Session["Mail"];
            var mesageSend = mm.GetListSendBox().Where(x=>x.SendMail == p).Count(x=>x.Situation == true);
            var mesageinbOXd = mm.GetListInBox().Where(x => x.ReceiverMail == p).Count(x=>x.Situation == true);
            ViewBag.SendBox = mesageSend;
            ViewBag.InBox = mesageinbOXd;
            return PartialView();
        }

        public ActionResult GetDetailMessage(int id)
        {
            var result = mm.GetById(id);
            result.Situation = false;
            mm.Update(result);
            return View(result);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message entity)
        {
            ValidationResult vr = mv.Validate(entity);
            if (vr.IsValid)
            {
                var p = (string) Session["Mail"];
                entity.SendMail = p;
                entity.DateTimee = DateTime.Parse(DateTime.Now.ToShortDateString()); 
                mm.Add(entity);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var error in vr.Errors)
                {
                    ModelState.AddModelError(error.PropertyName,error.ErrorMessage);
                }
            }
            return View();
        }
    }
}
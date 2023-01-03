using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;

namespace MvcProjeKamp.Controllers
{
    public class AdminMessageController : Controller
    {
        private MessageManager mm = new MessageManager(new EfMessageDal());

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
    }
}
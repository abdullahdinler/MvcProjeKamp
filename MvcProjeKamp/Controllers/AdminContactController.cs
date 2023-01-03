using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;

namespace MvcProjeKamp.Controllers
{
    public class AdminContactController : Controller
    {
        private ContactManager cm = new ContactManager(new EfContactDal());
        private MessageManager mm = new MessageManager(new EfMessageDal());

        private ContactValidator cv = new ContactValidator();
        // GET: AdminContact
        public ActionResult Index()
        {
            var c = cm.GetsList();
            return View(c);
        }

        [HttpGet]
        public ActionResult GetContactDetail(int id)
        {
            var c=cm.GetById(id);
            return View(c);
        }

        public PartialViewResult GetBox()
        {
            var mesageSend =  mm.GetListSendBox().Count();

            var mesageinbOXd = mm.GetListInBox().Count();
            ViewBag.SendBox = mesageSend;
            ViewBag.InBox = mesageinbOXd;
            var c = cm.GetsList().Count;
            ViewBag.Iletisim = c;
            return PartialView();
        }
    }
}
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
    public class AdminDraftController : Controller
    {
        private DraftManager dm = new DraftManager(new EfDraftDal());

        private DraftValidator validator = new DraftValidator();
        // GET: AdminDraft
        public ActionResult Index()
        {
            var draftList = dm.GetList();
            return View(draftList);
        }
    }
}
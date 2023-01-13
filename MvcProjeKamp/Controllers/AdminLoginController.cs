using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.Ajax.Utilities;

namespace MvcProjeKamp.Controllers
{
    [AllowAnonymous] // Burası autorizer kısmından etkilenmeyecek
    public class AdminLoginController : Controller
    {
        private AdminManager adm = new AdminManager(new EfAdminDal());
        private WriterManager wm = new WriterManager(new EfWriterDal());

        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin entity)
        {

            var result = adm.GetList().FirstOrDefault(x => x.UserName == entity.UserName && x.Password == entity.Password);
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(entity.UserName,false);
                Session["UserName"] = entity.UserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer entity)
        {
            var result = wm.GetList().FirstOrDefault(x => x.Mail == entity.Mail && x.Password == entity.Password);
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(entity.Mail,false);
                Session["Mail"] = entity.Mail;
                return RedirectToAction("NewHeading", "WriterPanel");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }

    }
}
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
        private WriterLoginManager wlm = new WriterLoginManager(new EfWriterDal());

        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.msg = TempData["msg"] as string;
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
                //TempData["msg"] = "false";
                return Json(new { success = false });
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
            //var result = wm.GetList().FirstOrDefault(x => x.Mail == entity.Mail && x.Password == entity.Password);
            var result = wlm.GetWriter(entity.Mail, entity.Password);
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(entity.Mail,false);
                Session["Mail"] = entity.Mail;
                return RedirectToAction("WriterProfile", "WriterPanel");
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
            return RedirectToAction("Index2", "Home");
        }

    }
}
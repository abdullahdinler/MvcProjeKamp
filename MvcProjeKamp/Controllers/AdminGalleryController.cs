using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MvcProjeKamp.Controllers
{
    public class AdminGalleryController : Controller
    {
        // GET: AdminGallery
        private GalleryFileManager gfm = new GalleryFileManager(new EfGalleryFileDal());
        private GalleryFileValidator gfv = new GalleryFileValidator();
        public ActionResult Index()
        {
            var value = gfm.GetList();
            return View(value);
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace MvcProjeKamp.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private HeadingManager hm = new HeadingManager(new EfHeadingDal());

        private ContentManager cm = new ContentManager(new EfContentDal());
        // GET: Default
        public PartialViewResult Index(int id)
        {
            id = 0;
            if (id != 0 && id != null)
            {
                var result = cm.GetListById(id);
                return PartialView(result);
            }
            else
            {
                var result = cm.GetList();
                return PartialView(result);
            }
        }

        public ActionResult Headings()
        {
            var result = hm.GetList();
            return View(result);
        }

        
    }
}
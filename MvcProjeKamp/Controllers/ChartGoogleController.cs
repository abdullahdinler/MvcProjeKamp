using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace MvcProjeKamp.Controllers
{
    public class ChartGoogleController : Controller
    {
        private GoogleChartManager c = new GoogleChartManager(new EfGoogleChartDal());
        private WriterManager wm = new WriterManager(new EfWriterDal());

        // GET: ChartGoogle
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Chart()
        {
            return Json(c.AllGetList(), JsonRequestBehavior.DenyGet);
        }

        public ActionResult Chart2()
        {
            return Json(wm.GetList(), JsonRequestBehavior.DenyGet);
        }
    }
    
}
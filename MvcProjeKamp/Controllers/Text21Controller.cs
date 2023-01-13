using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class Text21Controller : Controller
    {
        // GET: Text21
        public ActionResult Index()
        {
            return View();
        }

        // GET: Text21/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Text21/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Text21/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Text21/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Text21/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Text21/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Text21/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

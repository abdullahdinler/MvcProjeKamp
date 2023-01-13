using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace MvcProjeKamp.Controllers
{
    public class test343Controller : Controller
    {
        private Context db = new Context();

        // GET: test343
        public async Task<ActionResult> Index()
        {
            return View(await db.Abouts.ToListAsync());
        }

        // GET: test343/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = await db.Abouts.FindAsync(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // GET: test343/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: test343/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Details,Details2,Img,Img2")] About about)
        {
            if (ModelState.IsValid)
            {
                db.Abouts.Add(about);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(about);
        }

        // GET: test343/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = await db.Abouts.FindAsync(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // POST: test343/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Details,Details2,Img,Img2")] About about)
        {
            if (ModelState.IsValid)
            {
                db.Entry(about).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(about);
        }

        // GET: test343/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = await db.Abouts.FindAsync(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // POST: test343/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            About about = await db.Abouts.FindAsync(id);
            db.Abouts.Remove(about);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

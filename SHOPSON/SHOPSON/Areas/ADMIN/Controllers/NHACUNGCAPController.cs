using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SHOPSON.Areas.ADMIN.Models;

namespace SHOPSON.Areas.ADMIN.Controllers
{
    [Authorize]
    public class NHACUNGCAPController : Controller
    {
        SHOPSONEntities db = new SHOPSONEntities();

        // GET: ADMIN/NHACUNGCAP
        public async Task<ActionResult> Index()
        {
            return View(await db.NHACUNGCAPs.ToListAsync());
        }

        // GET: ADMIN/NHACUNGCAP/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHACUNGCAP nHACUNGCAP = await db.NHACUNGCAPs.FindAsync(id);
            if (nHACUNGCAP == null)
            {
                return HttpNotFound();
            }
            return View(nHACUNGCAP);
        }

        // GET: ADMIN/NHACUNGCAP/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ADMIN/NHACUNGCAP/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MANCC,TENNCC")] NHACUNGCAP nHACUNGCAP)
        {
            if (ModelState.IsValid)
            {
                db.NHACUNGCAPs.Add(nHACUNGCAP);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(nHACUNGCAP);
        }

        // GET: ADMIN/NHACUNGCAP/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHACUNGCAP nHACUNGCAP = await db.NHACUNGCAPs.FindAsync(id);
            if (nHACUNGCAP == null)
            {
                return HttpNotFound();
            }
            return View(nHACUNGCAP);
        }

        // POST: ADMIN/NHACUNGCAP/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MANCC,TENNCC")] NHACUNGCAP nHACUNGCAP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHACUNGCAP).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nHACUNGCAP);
        }

        // GET: ADMIN/NHACUNGCAP/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHACUNGCAP nHACUNGCAP = await db.NHACUNGCAPs.FindAsync(id);
            if (nHACUNGCAP == null)
            {
                return HttpNotFound();
            }
            return View(nHACUNGCAP);
        }

        // POST: ADMIN/NHACUNGCAP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            NHACUNGCAP nHACUNGCAP = await db.NHACUNGCAPs.FindAsync(id);
            db.NHACUNGCAPs.Remove(nHACUNGCAP);
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

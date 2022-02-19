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
using System.Linq;

namespace SHOPSON.Areas.ADMIN.Controllers
{
    [Authorize]
    public class DANHMUCController : Controller
    {
        SHOPSONEntities db = new SHOPSONEntities();
        // GET: ADMIN/DANHMUC
        public async Task<ActionResult> Index()
        {
            return View(await db.DANHMUCs.ToListAsync());
        }

        // GET: ADMIN/DANHMUC/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANHMUC dANHMUC = await db.DANHMUCs.FindAsync(id);
            if (dANHMUC == null)
            {
                return HttpNotFound();
            }
            return View(dANHMUC);
        }

        // GET: ADMIN/DANHMUC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ADMIN/DANHMUC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,TENDM")] DANHMUC dANHMUC)
        {
            if (ModelState.IsValid)
            {
                db.DANHMUCs.Add(dANHMUC);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(dANHMUC);
        }

        // GET: ADMIN/DANHMUC/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANHMUC dANHMUC = await db.DANHMUCs.FindAsync(id);
            if (dANHMUC == null)
            {
                return HttpNotFound();
            }
            return View(dANHMUC);
        }

        // POST: ADMIN/DANHMUC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,TENDM")] DANHMUC dANHMUC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dANHMUC).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dANHMUC);
        }

        // GET: ADMIN/DANHMUC/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANHMUC dANHMUC = await db.DANHMUCs.FindAsync(id);
            if (dANHMUC == null)
            {
                return HttpNotFound();
            }
            return View(dANHMUC);
        }

        // POST: ADMIN/DANHMUC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            DANHMUC dANHMUC = await db.DANHMUCs.FindAsync(id);
            db.DANHMUCs.Remove(dANHMUC);
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

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
    public class TINTUCController : Controller
    {
        SHOPSONEntities db = new SHOPSONEntities();

        // GET: ADMIN/TINTUC
        public async Task<ActionResult> Index()
        {
            return View(await db.TINTUCs.ToListAsync());
        }
        public void addimg(TINTUC tINTUC)
        {

            var file = Request.Files["image"];
            if (file != null && file.ContentLength > 0)
            {
                var parh = Server.MapPath("~/Areas/img/tintuc/") +tINTUC.ID.ToString() + file.FileName;
                file.SaveAs(parh);
                tINTUC.ANH = tINTUC.ID.ToString() + file.FileName;
                ViewBag.FileName = file.FileName;
                ViewBag.Filesize = file.ContentLength;
                ViewBag.Filetype = file.ContentType;
            }

        }
        // GET: ADMIN/TINTUC/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINTUC tINTUC = await db.TINTUCs.FindAsync(id);
            if (tINTUC == null)
            {
                return HttpNotFound();
            }
            return View(tINTUC);
        }

        // GET: ADMIN/TINTUC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ADMIN/TINTUC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,MOTA,NGAYDANG,ANH,TIEUDE,TRANGTHAI")] TINTUC tINTUC)
        {
            if (ModelState.IsValid)
            {
                addimg(tINTUC);
                db.TINTUCs.Add(tINTUC);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tINTUC);
        }

        // GET: ADMIN/TINTUC/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINTUC tINTUC = await db.TINTUCs.FindAsync(id);
            if (tINTUC == null)
            {
                return HttpNotFound();
            }
            return View(tINTUC);
        }

        // POST: ADMIN/TINTUC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,MOTA,NGAYDANG,ANH,TIEUDE,TRANGTHAI")] TINTUC tINTUC)
        {
            if (ModelState.IsValid)
            {
                addimg(tINTUC);
                db.Entry(tINTUC).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tINTUC);
        }

        // GET: ADMIN/TINTUC/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINTUC tINTUC = await db.TINTUCs.FindAsync(id);
            if (tINTUC == null)
            {
                return HttpNotFound();
            }
            return View(tINTUC);
        }

        // POST: ADMIN/TINTUC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            TINTUC tINTUC = await db.TINTUCs.FindAsync(id);
            db.TINTUCs.Remove(tINTUC);
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

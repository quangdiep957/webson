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
    public class LOAISPController : Controller
    {
        SHOPSONEntities db = new SHOPSONEntities();

        // GET: ADMIN/LOAISP
        public async Task<ActionResult> Index(string Search)
        {
            var lOAISPs = db.LOAISPs.Include(l => l.NHACUNGCAP);
            //return View(await lOAISPs.ToListAsync());
         
            if (!string.IsNullOrEmpty(Search))
            {
                lOAISPs = lOAISPs.Where(x => x.TLSP.Contains(Search));


            }
           // ViewBag.NAME = new SelectList(db.SANPHAMs, "ID", "NAME");

            return View(lOAISPs.ToList());
        }

        // GET: ADMIN/LOAISP/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISP lOAISP = await db.LOAISPs.FindAsync(id);
            if (lOAISP == null)
            {
                return HttpNotFound();
            }
            return View(lOAISP);
        }
        public void addimg(LOAISP lsp)
        {

            var file = Request.Files["image"];
            if (file != null && file.ContentLength > 0)
            {
                var parh = Server.MapPath("~/Areas/img/loaisp/") + lsp.MLSP.ToString() + file.FileName;
                file.SaveAs(parh);
                lsp.ANH = lsp.MLSP.ToString() + file.FileName;
                ViewBag.FileName = file.FileName;
                ViewBag.Filesize = file.ContentLength;
                ViewBag.Filetype = file.ContentType;
            }

        }
        // GET: ADMIN/LOAISP/Create
        public ActionResult Create()
        {
            ViewBag.MANCC = new SelectList(db.NHACUNGCAPs, "MANCC", "TENNCC");
            return View();
        }

        // POST: ADMIN/LOAISP/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MLSP,TLSP,MANCC,ANH")] LOAISP lOAISP)
        {
            if (ModelState.IsValid)
            {
                addimg(lOAISP);
                db.LOAISPs.Add(lOAISP);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MANCC = new SelectList(db.NHACUNGCAPs, "MANCC", "TENNCC", lOAISP.MANCC);
            return View(lOAISP);
        }

        // GET: ADMIN/LOAISP/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISP lOAISP = await db.LOAISPs.FindAsync(id);
            if (lOAISP == null)
            {
                return HttpNotFound();
            }
            ViewBag.MANCC = new SelectList(db.NHACUNGCAPs, "MANCC", "TENNCC", lOAISP.MANCC);
            return View(lOAISP);
        }

        // POST: ADMIN/LOAISP/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MLSP,TLSP,MANCC,ANH")] LOAISP lOAISP)
        {
            if (ModelState.IsValid)
            {
                addimg(lOAISP);
                db.Entry(lOAISP).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MANCC = new SelectList(db.NHACUNGCAPs, "MANCC", "TENNCC", lOAISP.MANCC);
            return View(lOAISP);
        }

        // GET: ADMIN/LOAISP/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISP lOAISP = await db.LOAISPs.FindAsync(id);
            if (lOAISP == null)
            {
                return HttpNotFound();
            }
            return View(lOAISP);
        }

        // POST: ADMIN/LOAISP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            LOAISP lOAISP = await db.LOAISPs.FindAsync(id);
            db.LOAISPs.Remove(lOAISP);
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

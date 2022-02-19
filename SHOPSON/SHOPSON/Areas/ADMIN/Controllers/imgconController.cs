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
    public class imgconController : Controller
    {
        SHOPSONEntities db = new SHOPSONEntities();
        // GET: ADMIN/imgcon
        public async Task<ActionResult> Index()
        {
            var imgcons = db.imgcons.Include(i => i.SANPHAM);
            return View(await imgcons.ToListAsync());
        }

        // GET: ADMIN/imgcon/Details/5
        public void addimgcon(imgcon IMG)
        {

            var file1 = Request.Files["img1"];
            var file2 = Request.Files["img2"];
            var file3 = Request.Files["img3"];
            var file4 = Request.Files["img4"];
            if (file1 != null && file1.ContentLength > 0 && file2 != null && file2.ContentLength > 0 && file3 != null && file3.ContentLength > 0 && file4 != null && file4.ContentLength > 0)
            {
                var parh1 = Server.MapPath("~/Areas/img/sanpham/") + IMG.MASP.ToString() + file1.FileName;
                var parh2 = Server.MapPath("~/Areas/img/sanpham/") + IMG.MASP.ToString() + file2.FileName;
                var parh3 = Server.MapPath("~/Areas/img/sanpham/") + IMG.MASP.ToString() + file3.FileName;
                var parh4 = Server.MapPath("~/Areas/img/sanpham/") + IMG.MASP.ToString() + file4.FileName;
                file1.SaveAs(parh1);
                file2.SaveAs(parh2);
                file3.SaveAs(parh3);
                file4.SaveAs(parh4);
                IMG.IMG1 = IMG.MASP.ToString() + file1.FileName;
                IMG.IMG2 = IMG.MASP.ToString() + file2.FileName;
                IMG.IMG3 = IMG.MASP.ToString() + file3.FileName;
                IMG.IMG4 = IMG.MASP.ToString() + file4.FileName;

            }
        }

            // GET: ADMIN/imgcon/Create
            public ActionResult Create()
        {
            ViewBag.MASP = new SelectList(db.SANPHAMs, "MASP", "TENSP");
            return View();
        }

        // POST: ADMIN/imgcon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       
        public  ActionResult Create([Bind(Include = "ID,MASP,IMG1,IMG2,IMG3,IMG4")] imgcon imgcon)
        {
            if (ModelState.IsValid)
            {
                addimgcon(imgcon);
                db.imgcons.Add(imgcon);
                 db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MASP = new SelectList(db.SANPHAMs, "MASP", "TENSP", imgcon.MASP);
            return View(imgcon);
        }

        // GET: ADMIN/imgcon/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            imgcon imgcon = await db.imgcons.FindAsync(id);
            if (imgcon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MASP = new SelectList(db.SANPHAMs, "MASP", "TENSP", imgcon.MASP);
            return View(imgcon);
        }

        // POST: ADMIN/imgcon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,MASP,IMG1,IMG2,IMG3,IMG4")] imgcon imgcon)
        {
            if (ModelState.IsValid)
            {
                addimgcon(imgcon);
                db.Entry(imgcon).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MASP = new SelectList(db.SANPHAMs, "MASP", "TENSP", imgcon.MASP);
            return View(imgcon);
        }

        // GET: ADMIN/imgcon/Delete/5
     

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

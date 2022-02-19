using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SHOPSON.Areas.ADMIN.Models;

namespace SHOPSON.Areas.ADMIN.Controllers
{
    [Authorize]
    public class NHANVIENsController : Controller
    {

        SHOPSONEntities db = new SHOPSONEntities();
        [AllowAnonymous]
        // GET: ADMIN/NHANVIENs
        public ActionResult Index()
        {
            return View(db.NHANVIENs.ToList());
        }
        [HttpPost]
        public ActionResult Seach(string search)
        {
            return View(db.NHANVIENs.Where(x => x.TENNV.Contains(search)) .ToList());
        }

        // GET: ADMIN/NHANVIENs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }
        // add img 
        public void addimg(NHANVIEN nv)
        {

            var file = Request.Files["image"];
            if (file != null && file.ContentLength > 0)
            {
                var parh = Server.MapPath("~/Areas/img/nhanvien/") + nv.MANV.ToString() + file.FileName;
                file.SaveAs(parh);
                nv.ANH = nv.MANV.ToString() + file.FileName;
                ViewBag.FileName = file.FileName;
                ViewBag.Filesize = file.ContentLength;
                ViewBag.Filetype = file.ContentType;
            }

        }


        // GET: ADMIN/NHANVIENs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ADMIN/NHANVIENs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MANV,TENNV,SDT,CHUCVU,LUONG,ANH")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                addimg(nHANVIEN);
                db.NHANVIENs.Add(nHANVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nHANVIEN);
        }

        // GET: ADMIN/NHANVIENs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: ADMIN/NHANVIENs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MANV,TENNV,SDT,CHUCVU,LUONG,ANH")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                addimg(nHANVIEN);
                db.Entry(nHANVIEN).State = EntityState.Modified;              
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(nHANVIEN);
        }

        // GET: ADMIN/NHANVIENs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: ADMIN/NHANVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            db.NHANVIENs.Remove(nHANVIEN);
            db.SaveChanges();
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

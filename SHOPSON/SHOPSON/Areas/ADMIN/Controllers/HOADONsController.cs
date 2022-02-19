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
    public class HOADONsController : Controller
    {
        SHOPSONEntities db = new SHOPSONEntities();
        // GET: ADMIN/HOADONs
        public async Task<ActionResult> Index()
        {
            var hOADONs = db.HOADONs.Include(h => h.KHACHHANG).Include(h => h.NHANVIEN).Include(h => h.THONGKE);
            return View(await hOADONs.ToListAsync());
        }

        // GET: ADMIN/HOADONs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = await db.HOADONs.FindAsync(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            return View(hOADON);
        }

        // GET: ADMIN/HOADONs/Create
        public ActionResult Create()
        {
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENKH");
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENNV");
            ViewBag.MATK = new SelectList(db.THONGKEs, "MATK", "NGAYLAP");
            return View();
        }

        // POST: ADMIN/HOADONs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MAHD,NGAYLAP,SOLUONG,GIA,TONGTIEN,MANV,MAKH,MATK,DIACHI,MAMAU,TRANGTHAI,MOTA,PHUONGTHUCTT,THETICH")] HOADON hOADON)
        {
            if (ModelState.IsValid)
            {
                db.HOADONs.Add(hOADON);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENKH", hOADON.MAKH);
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENNV", hOADON.MANV);
            ViewBag.MATK = new SelectList(db.THONGKEs, "MATK", "NGAYLAP", hOADON.MATK);
            return View(hOADON);
        }

        // GET: ADMIN/HOADONs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = await db.HOADONs.FindAsync(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENKH", hOADON.MAKH);
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENNV", hOADON.MANV);
            ViewBag.MATK = new SelectList(db.THONGKEs, "MATK", "NGAYLAP", hOADON.MATK);
            return View(hOADON);
        }

        // POST: ADMIN/HOADONs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MAHD,NGAYLAP,SOLUONG,GIA,TONGTIEN,MANV,MAKH,MATK,DIACHI,MAMAU,TRANGTHAI,MOTA,PHUONGTHUCTT,THETICH")] HOADON hOADON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOADON).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENKH", hOADON.MAKH);
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENNV", hOADON.MANV);
            ViewBag.MATK = new SelectList(db.THONGKEs, "MATK", "NGAYLAP", hOADON.MATK);
            return View(hOADON);
        }

        // GET: ADMIN/HOADONs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = await db.HOADONs.FindAsync(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            return View(hOADON);
        }

        // POST: ADMIN/HOADONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HOADON hOADON = await db.HOADONs.FindAsync(id);
            db.HOADONs.Remove(hOADON);
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

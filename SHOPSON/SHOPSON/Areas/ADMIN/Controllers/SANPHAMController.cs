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
    public class SANPHAMController : Controller
    {
        SHOPSONEntities db = new SHOPSONEntities();

        // GET: ADMIN/SANPHAM
        public ActionResult Index(string Search)
        {
            // var sANPHAMs = db.SANPHAMs.Include(s => s.LOAISP);
            //return View(sANPHAMs.ToList());
            var sANPHAMs = db.SANPHAMs.Include(s => s.LOAISP);
            if (!string.IsNullOrEmpty(Search))
            {
              
                sANPHAMs = sANPHAMs.Where(x => x.TENSP.Contains(Search));
            }
            ViewBag.NAME = new SelectList(db.SANPHAMs, "ID", "NAME");

            return View(sANPHAMs.ToList());
        }
        /*[HttpPost]
        public ActionResult Index(string Search)
        {
            var sANPHAMs = db.SANPHAMs.Include(s => s.LOAISP);
  
                if(Search=="top3")
            {   //string query = "select * from SANPHAM WHERE MASP LIKE '%" + Search + "%'";
                //return db.Database.SqlQuery<SANPHAM>(query).FirstOrDefault(); 
                 sANPHAMs = sANPHAMs.Where(x => x.TENSP.Contains(Search)).Take(3);
            }
            else if(Search=="top10")
            {
               sANPHAMs = sANPHAMs.Where(x => x.TENSP.Contains(Search)).Take(10);
            }
         
                return View(sANPHAMs.ToList());
            
          
        }*/
        public void addimg(SANPHAM sANPHAM)
        {

            var file = Request.Files["image"];
            if (file != null && file.ContentLength > 0)
            {
                var parh = Server.MapPath("~/Areas/img/sanpham/") + sANPHAM.MASP.ToString() + file.FileName;
                file.SaveAs(parh);
                sANPHAM.ANH = sANPHAM.MASP.ToString() + file.FileName;
                ViewBag.FileName = file.FileName;
                ViewBag.Filesize = file.ContentLength;
                ViewBag.Filetype = file.ContentType;
            }

        }
      
        

        // GET: ADMIN/SANPHAM/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // GET: ADMIN/SANPHAM/Create
        public ActionResult Create()
        {
            ViewBag.MLSP = new SelectList(db.LOAISPs, "MLSP", "TLSP");
            return View();
        }

        // POST: ADMIN/SANPHAM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MASP,TENSP,GIA,THETICH,TRANGTHAI,MOTA,MLSP,CAPDO,MAMAU,ANH,HSD")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {

                addimg(sANPHAM);
                db.SANPHAMs.Add(sANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {

                ViewBag.MLSP = new SelectList(db.LOAISPs, "MLSP", "TLSP", sANPHAM.MLSP);
                return View(sANPHAM);
            }



        }
     
    
      

        // GET: ADMIN/SANPHAM/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.MLSP = new SelectList(db.LOAISPs, "MLSP", "TLSP", sANPHAM.MLSP);
            return View(sANPHAM);
        }

        // POST: ADMIN/SANPHAM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MASP,TENSP,GIA,THETICH,TRANGTHAI,MOTA,MLSP,CAPDO,MAMAU,ANH,HSD")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                addimg(sANPHAM);
                db.Entry(sANPHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MLSP = new SelectList(db.LOAISPs, "MLSP", "TLSP", sANPHAM.MLSP);
            return View(sANPHAM);
        }

        // GET: ADMIN/SANPHAM/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // POST: ADMIN/SANPHAM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            db.SANPHAMs.Remove(sANPHAM);
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

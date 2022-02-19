using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHOPSON.Areas.ADMIN.Models;

namespace SHOPSON.Controllers
{
   
    public class patralController : Controller
    {
        SHOPSONEntities db = new SHOPSONEntities();
        // GET: patral
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult viewsp()
        {

            List<SANPHAM> lst = db.SANPHAMs.Where(x =>x.TRANGTHAI == true).Take(4).ToList();
            return PartialView(lst);
        }
        [ChildActionOnly]
        public ActionResult create()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult viewspall()
        {

            List<SANPHAM> lst = db.SANPHAMs.Where(x => x.TRANGTHAI == true).ToList();
            return PartialView(lst);
        }
        [ChildActionOnly]
        public ActionResult viewsp3()
        {

            List<SANPHAM> lst = db.SANPHAMs.Where(x => x.TRANGTHAI == true).Take(3).ToList();
            return PartialView(lst);
        }
        [ChildActionOnly]
        public ActionResult viewsplq(string search)
        {

            List<SANPHAM> lst = db.SANPHAMs.Where(x => x.MLSP==search).ToList();
           // string query = "select * from SANPHAM where MLSP '% '" + search + " %'";

               // lst = lst.Where(x => x.MLSP.Contains(search)).Take(3).ToList();

            return PartialView(lst);
        }
        [ChildActionOnly]
        public ActionResult viewsplq3()
        {

            List<SANPHAM> lst = db.SANPHAMs.Where(x=>x.TRANGTHAI==true).Take(3).ToList();
            // string query = "select * from SANPHAM where MLSP '% '" + search + " %'";

            // lst = lst.Where(x => x.MLSP.Contains(search)).Take(3).ToList();

            return PartialView(lst);
        }
        public ActionResult viewimg(string id)
        {
            List<imgcon> lst = db.imgcons.Where(x=>x.MASP==id).ToList();
            return PartialView(lst);
        }
        public ActionResult viewtenlsp()
        {
            List<LOAISP> lst = db.LOAISPs.ToList();
            return PartialView(lst);
        }
        [ChildActionOnly]
        public ActionResult viewATM()
        {

            Thanh_toan lst = db.Thanh_toans.FirstOrDefault();
            return PartialView(lst);
        }
    }
}
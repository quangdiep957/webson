using SHOPSON.Areas.ADMIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHOPSON.Areas.ADMIN.Controllers
{
    [Authorize]
    public class ThongkeController : Controller
    {

        SHOPSONEntities db = new SHOPSONEntities();
        // GET: ADMIN/Thongke
        public ActionResult Index()
        {
           // ViewBag.Tong = thongkeSL();
            ViewBag.TongTien = thongkeTien().ToString("N0");
            ViewBag.view = HttpContext.Application["demview"].ToString() ;//Lấy số lượng người truy cập
            ViewBag.online = HttpContext.Application["demonline"].ToString();
            return View();
        }

       /* public int thongkeSL()
        {
            int Tong = db.HOADONs.Sum(n => n.SOLUONG);
            return Tong;
        }*/
        public double thongkeTien()
        {
            double TongTien =db.HOADONs.Sum(n=>n.TONGTIEN).Value;
            return TongTien;
        }
        [ChildActionOnly]
        public ActionResult viewhd()
        {

            List<HOADON> lst = db.HOADONs.Where(x => x.TRANGTHAI == true).ToList();
            return PartialView(lst);
        }
        [ChildActionOnly]
        public ActionResult viewhd_choduyet()
        {

            List<HOADON> lst = db.HOADONs.Where(x => x.TRANGTHAI == false).ToList();
            return PartialView(lst);
        }


    }
}
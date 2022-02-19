using SHOPSON.Areas.ADMIN.Models;
using SHOPSON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHOPSON.Controllers
{
    public class giohangController : Controller
    {
       SHOPSONEntities db = new SHOPSONEntities();
        // GET: giohang

        public ActionResult Index()
        {
            var cart = Session["ListSesition"];
            var list = new List<giohangct>();
            if (cart != null)
            {

                list = (List<giohangct>)cart;
                double tong = 0;
                int sl = 0;
                foreach (var item in list)
                {
                    double a = item.soluong;
                    double b = double.Parse((item.sanpham.GIA).ToString());
                    double c = a * b;
                    int d = int.Parse((item.soluong).ToString());
                    sl += d;
                    tong += c;
                    ViewBag.tong = tong;
                    ViewBag.sl = sl;
                }
            }
            return View();
        }
        public ActionResult deleteitem(string masp)
        {
            var sessionCart = (List<giohangct>)Session["ListSesition"];
            sessionCart.RemoveAll(x => x.sanpham.MASP == masp);
            Session["ListSesition"] = sessionCart;
            return RedirectToAction("Index");
        }
        [ChildActionOnly]
        public ActionResult tablegh()
        {
            var cart = Session["ListSesition"];
            var list = new List<giohangct>();
            if (cart != null)
            {
               
                    list = (List<giohangct>)cart;
                    double tong = 0;
                    int sl = 0;
                    foreach (var item in list)
                    {
                        double a = item.soluong;
                        double b = double.Parse((item.sanpham.GIA).ToString());
                        double c = a * b;
                        int d = int.Parse((item.soluong).ToString());
                        sl += d;
                        tong += c;
                    ViewBag.tong = tong;
                    ViewBag.sl = sl;
                    }
                }
            return PartialView(list);
        }

        /*
        [HttpPost]
        public ActionResult Index(string masp)
        {
            var sanpham = db.SANPHAMs.Where(s => s.MASP.Equals(masp)).FirstOrDefault();
            var giohang = Session["ListSesition"];
            if (giohang == null)
            {
                
                //tạo mới đối tượng giỏ hàng
                var item = new giohangct();
                item.sanpham.MASP = masp;
                
                var list = new List<giohangct>();
                list.Add(item);
                Session["ListSesition"] = list;
               
            }
            return View();
        }*/
        [HttpPost]
        public ActionResult Additem(string masp,long soluong)
        {

            var product = db.SANPHAMs.FirstOrDefault(c => c.MASP== masp);
            var cart = Session["ListSesition"];
            if (cart != null)
            {
                var list = (List<giohangct>)cart;
                if (list.Exists(x => x.sanpham.MASP == masp))
                {

                    foreach (var item in list)
                    {
                        if (item.sanpham.MASP == masp)
                        {
                            item.soluong += soluong;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new giohangct();
                    item.sanpham = product;
                    item.soluong = soluong;
                    list.Add(item);
                }
                //Gán vào session
                Session["ListSesition"] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new giohangct();
                item.sanpham = product;
                item.soluong = soluong;
                var list = new List<giohangct>();
                list.Add(item);
                //Gán vào session
                Session["ListSesition"] = list;
            }
            return RedirectToAction("Index");
        }
    }
}
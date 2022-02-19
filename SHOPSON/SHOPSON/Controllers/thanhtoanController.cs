using SHOPSON.Areas.ADMIN.Models;
using SHOPSON.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SHOPSON.Controllers
{
  
    public class thanhtoanController : Controller
    {
        SHOPSONEntities db = new SHOPSONEntities();
        // GET: thanhtoan
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult wecome()
        {
            return View();
        }
        public ActionResult Xacnhan(Giohang_add giohang)
        {
            ViewBag.mahd = giohang.MAHD;
           
            return View();
        }
        public ActionResult Edit(string mahd)
        {
            return View();
            
        }


        [HttpPost]
        public ActionResult Edit([Bind(Include = "MAHD,NGAYLAP,SOLUONG,GIA,TONGTIEN,MANV,MAKH,MATK,DIACHI,MAMAU,TRANGTHAI,MOTA,PHUONGTHUCTT,THETICH")] HOADON hOADON,int mahd)
        {

            if(mahd!=null)
            {
                hOADON = db.HOADONs.Where(s => s.MAHD.Equals(mahd)).FirstOrDefault();
                if(hOADON!=null)
                {
                    hOADON.TRANGTHAI = true;
                    db.Entry(hOADON).State = EntityState.Modified;                
                    db.SaveChanges();
                    return RedirectToAction("Edit", "thanhtoan");
                }
            }
            return RedirectToAction("Index");
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatGioHang(Giohang_add giohang ,int makh)
        {
           if(makh==null)
            {
                return RedirectToAction("Creare", "khachhang");
            }
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
                }
                {
                    //var listkh = new KHACHHANG();
                   // Session["NAMEKH"] = listkh.EMAIL;
                    if (ModelState.IsValid)
                    {
                     //   string makh= "mkh01";
                        KHACHHANG listkh = db.KHACHHANGs.Where(s => s.MAKH.Equals(makh)).FirstOrDefault();

                        if (listkh == null)
                        {
                            return RedirectToAction("Create");
                        }
                        else
                        {
                            listkh.DIACHI = giohang.DIACHI;

                        }

                        /*
                         var khachhang = new KHACHHANG()
                         {
                             MAKH = giohang.MAKH,
                             EMAIL = giohang.EMAIL,
                             TENKH = giohang.TENKH,
                             SDT = giohang.SDT,
                             DIACHI = giohang.DIACHI,

                         };

                     */

                        var hoadon = new HOADON()
                        {

                           // MAHD = giohang.MAHD,
                            NGAYLAP = DateTime.Now,
                            SOLUONG = sl,
                            GIA = giohang.GIA,
                            TONGTIEN = tong,
                            DIACHI = giohang.DIACHI,
                            PHUONGTHUCTT = giohang.pttt,
                            MOTA = giohang.MOTA,
                            THETICH = "18L",
                            MAMAU="WHITE",
                            TRANGTHAI = false,
                            MAKH = listkh.MAKH,


                        };
                     
                    
                      //  db.KHACHHANGs.Add(listkh);
                        db.Entry(listkh).State = EntityState.Modified;
                        db.HOADONs.Add(hoadon);
                        db.SaveChanges();

                        //   var cart = new List<giohangct>();

                        foreach (var item in list)
                        {
                            var cthoadon = new CTHOADON()
                            {
                                MAHD = hoadon.MAHD,
                                MASP = item.sanpham.MASP,
                                DONGIA = item.sanpham.GIA,
                                SOLUONG = item.soluong.ToString(),
                                THANHTIEN = (item.soluong) * (item.sanpham.GIA),
                                
                              

                            };
                           
                            db.CTHOADONs.Add(cthoadon);
                            db.SaveChanges();
                          
                           
                        }
                        string subject = "Thông báo đặt hàng ";
                        string email =listkh.EMAIL;
                        List<string> cc = new List<string>()
                            {email };
                        StringBuilder sb = new StringBuilder();
                        sb.Append($"<h3>Xin chào : {listkh.TENKH}</h3>");
                       // sb.Append($"<table>");
                        foreach (var item1 in list)
                        {
                             sb.Append($" <img src ='https://www.sonboss.com.vn/pictures/catalog/logo/logo.png'>");
                           // sb.Append($"<h2>Xin Chào:</h2>");
                           
                            sb.Append($"<h3 style='color:red'>Chúc mừng bạn đã mua hàng thành công vui lòng xác nhận cho chúng tôi biết </h3>");
                            sb.Append($"<p> Vui lòng đăng nhập Shop để xác nhận bạn đã nhận hàng và hài lòng với sản phẩm trong vòng 3 ngày.Sau khi bạn xác nhận, chúng tôi sẽ thanh toán cho Người bán pinkbeauty.auth.Nếu bạn không xác nhận trong khoảng thời gian này.</ p > ");
                            sb.Append($"<p> Tổng tiền = {hoadon.TONGTIEN} đ </p>");
                            sb.Append($"<a href='http://localhost:57119/thanhtoan/Xacnhan'>truy cập </a>");
                            sb.Append($"<div style='border: 1px solid black; '> Xác nhận<div>");
                            sb.Append($"<p> Mã đơn hàng:#211011GWHKPNQW </p>");
                            sb.Append($"<p> Ngày đặt hàng: {hoadon.NGAYLAP} </p>");
                            sb.Append($" <p> Người bán: SHOPSON </p>");
                            sb.Append($"<p> Tên sản phẩm :{giohang.TENSP}</p>");
                            sb.Append($"<p> Ảnh :<img src='~/Areas/img/sanpham/{giohang.TENSP}'/></p>");
                            sb.Append($" <p> Mẫu mã:{giohang.MASP}</p>");
                            sb.Append($" <p> Số lượng: { item1.soluong } </p>");
                            sb.Append($"  <p> Giá: 	{giohang.GIA.Value.ToString("N0")}₫</p>");
                            sb.Append($"   <p> Tổng tiền: {giohang.THANHTIEN.Value.ToString("N0")}₫ </p>");
                            sb.Append($" <p> Phí vận chuyển:0₫ </p>");
                            sb.Append($"  <p> Tổng thanh toán: {tong}₫	 </p>");
                            sb.Append($"  <h2> BƯỚC TIẾP THEO</h2>");
                            sb.Append($"   <p> Bạn không hài lòng về sản phẩm? </p>");
                            sb.Append($"  <p> Bạn có thể gửi yêu cầu trả hàng trên ứng dụng Shopee trong vòng 3 ngày kể từ khi nhận được email này.</p>");
                            sb.Append($"   <p> Lưu ý: Shop sẽ từ chối hỗ trợ các khiếu nại sau khi Người mua nhấn trên ứng dụng và Người bán đã nhận được thanh toán cho đơn hàng. </p>");
                            sb.Append($"     <p> Tìm hiểu thêm về chính sách Trả hàng / Hoàn tiền của chúng tôi. </p>");
                            sb.Append($"  <p> Chúc bạn luôn có những trải nghiệm tuyệt vời khi mua sắm tại SHOPSON. </p>");
                            sb.Append($" <p> Trả hàng / Hoàn tiền </p>");
                            sb.Append($"  <p> Trân trọng,</p>");
                            sb.Append($"  <p> Bạn có thắc mắc? Liên hệ chúng tôi tại đây.0911067145 </p>");
                          
                            sb.Append($"</form>");







                            /*

                           sb.Append($"<tr>");
                           sb.Append($"<td>{ item1.soluong }</td>");
                           sb.Append($"<td>{ item1.sanpham.TENSP }</td>");
                           sb.Append($"<td>{ item1.sanpham.MOTA }</td>");
                           sb.Append($"<td>{ item1.sanpham.MAMAU }</td>");

                           sb.Append($"</table>");
                           sb.Append($"<p>tổng tiền :{(item1.soluong) * (item1.sanpham.GIA)} </p>");*/
                        }

                        var mailSender = new Class1();
                        mailSender.Send(email, subject, sb.ToString(), cc);
                        var sessionCart = (List<giohangct>)Session["ListSesition"];
                        sessionCart.Clear();
                        Session["ListSesition"] = sessionCart;
                       Session["mahd"] = hoadon.MAHD;
                        return RedirectToAction("wecome", "thanhtoan");
                      
                    }
                    else
                    {
                        ModelState.AddModelError("", "Vui lòng nhập dữ liệu");
                    }
                }
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
         
            return RedirectToAction("Index");
        }
    }
}
using SHOPSON.Areas.ADMIN.Models;
using SHOPSON.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SHOPSON.Controllers
{
    public class khachhangController : Controller
    {
        // GET: khachhang
        SHOPSONEntities db = new SHOPSONEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "MAKH,TENKH,SDT,DIACHI,PASSWORD,DANHGIA,ANH,EMAIL")] KHACHHANG kHACHHANG)
        {
              
                db.KHACHHANGs.Add(kHACHHANG);
                db.SaveChanges();
            // return RedirectToAction("Index");
            
            return View(kHACHHANG);
            



        }
      
        [HttpPost]

        public ActionResult Edit([Bind(Include = "MAKH,TENKH,SDT,DIACHI,PASSWORD,DANHGIA,ANH,EMAIL")] string email,string mota, KHACHHANG kHACHHANG)
        {
           
                    //  bool ktra = logincheck.checkemail(email);
                    if (email!=null)
                {
                    kHACHHANG= db.KHACHHANGs.Where(s => s.EMAIL.Equals(email)).FirstOrDefault();

                    if (kHACHHANG == null)
                    {
                        return RedirectToAction("Create");
                    }
                    kHACHHANG.DANHGIA = mota;
                    db.Entry(kHACHHANG).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else 
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                return RedirectToAction("Index","DetailSP");

          
        }
        [ChildActionOnly]
        public ActionResult viewkh()
        {
            List<KHACHHANG> lst = db.KHACHHANGs.Where(x=>x.DANHGIA!=null).ToList();
            return PartialView(lst);
        }
        public ActionResult Logout()
        {
            var sessionCart = (List<giohangct>)Session["ListSesition"];
            sessionCart = null;
             Session["ListSesition"] = sessionCart;
            Session["NAMEKH"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Create", "khachhang");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(metakh user)

        {
            if (ModelState.IsValid)
            {
                bool ktra = logincheck.checkloginkh(user.EMAIL, user.PASSWORD);
                if (ktra == true)
                {
                   
                    KHACHHANG kh = db.KHACHHANGs.Where(x => x.EMAIL == user.EMAIL&& x.PASSWORD== user.PASSWORD).FirstOrDefault();
                    Session["makh"] = kh.MAKH;
                    Session["NAMEKH"] = kh.TENKH;
                    //Session["makh"] = kHACHHANG.TENKH;
                    // var userSesstion = new metalogin();
                    //userSesstion.USERNAME = user.USERNAME;
                    //  userSesstion.Add();
                    FormsAuthentication.SetAuthCookie(user.EMAIL, false);


                    // lay param
                    var url = Request.QueryString["ReturnUrl"];
                    if (url != null)
                    {
                        Redirect(url);
                    }
                    /*  if(Models.sesstion.sestionheper.GetUsersesstion()!=null)
                       {
                           Models.sesstion.sestionheper.Setsession(new Models.sesstion.usersesstion() { USERNAME = user.USERNAME });

                       }*/
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không chính xác !");
                }

            }

            return View(user);

        }
    }
}
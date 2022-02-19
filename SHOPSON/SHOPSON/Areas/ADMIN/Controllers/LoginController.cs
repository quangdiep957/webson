using SHOPSON.Areas.ADMIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SHOPSON.Areas.ADMIN.Controllers
{
    public class LoginController : Controller
    {
        SHOPSONEntities db = new SHOPSONEntities();
        // GET: ADMIN/Login
        public ActionResult Index()
        {
           
            return View();
        }
    
        public ActionResult Logout()
        {
           Session["NAME"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("/");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Models.metalogin user)

        {
            if (ModelState.IsValid)
            {
                bool ktra = SHOPSON.Areas.ADMIN.Models.logincheck.checklogin(user.USERNAME, user.PASSWORD);
                if (ktra == true)
                {
                    Session["NAME"] = user.USERNAME;
                    // var userSesstion = new metalogin();
                    //userSesstion.USERNAME = user.USERNAME;
                    //  userSesstion.Add();
                    FormsAuthentication.SetAuthCookie(user.USERNAME, false);
                    

                    // lay param
                    var url =Request.QueryString["ReturnUrl"];
                    if(url!=null)
                    {
                      return  Redirect(url);
                    }
                 /*  if(Models.sesstion.sestionheper.GetUsersesstion()!=null)
                    {
                        Models.sesstion.sestionheper.Setsession(new Models.sesstion.usersesstion() { USERNAME = user.USERNAME });
                       
                    }*/
                    return RedirectToAction("Index", "Thongke");

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
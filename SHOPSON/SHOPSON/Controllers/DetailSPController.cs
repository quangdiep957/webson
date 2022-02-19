using SHOPSON.Areas.ADMIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHOPSON.Controllers
{
    public class DetailSPController : Controller
    {
        SHOPSONEntities db = new SHOPSONEntities();
        // GET: DetailSP
        public ActionResult Index(string msp)
        { 
            List<SANPHAM> lst = db.SANPHAMs.Where(x => x.TRANGTHAI == true && x.MASP ==msp).ToList();
            return View(lst);
        }
       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHOPSON.Areas.ADMIN.Models;
namespace SHOPSON.Controllers
{
    public class gdloaispController : Controller
    {
        SHOPSONEntities db = new SHOPSONEntities();
        // GET: gdloaisp
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult viewlsp()
        {
            List<LOAISP> lst = db.LOAISPs.ToList();
            return PartialView(lst);
        }
    }
}
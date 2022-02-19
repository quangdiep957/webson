using SHOPSON.Areas.ADMIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHOPSON.Controllers
{
    public class patraltintucController : Controller
    {
        SHOPSONEntities db = new SHOPSONEntities();
        // GET: patraltintuc
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult viewtt()
        {

            List<TINTUC> lst = db.TINTUCs.Where(x => x.TRANGTHAI == true).ToList();
            return PartialView(lst);
        }
    }
}
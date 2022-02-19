using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHOPSON.Areas.ADMIN.Models.sesstion
{
    public class sestionheper
    {
        public static void Setsession(usersesstion session)
        {
            HttpContext.Current.Session["loginSession"] = session;
        }
        public static usersesstion GetUsersesstion()
        {
            var session = HttpContext.Current.Session["loginSession"];
            if (session==null)
            {
                return null;
            }
            else
            {
                return session as usersesstion;
            }
        }
    }
}
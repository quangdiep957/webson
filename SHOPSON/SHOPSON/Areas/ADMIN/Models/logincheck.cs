using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHOPSON.Areas.ADMIN.Models
{
    public class logincheck
    {
        static SHOPSONEntities db = new SHOPSONEntities();
        public static bool checklogin(string username, string passsword)
        {
            int count = db.TAIKHOANs.Count(x => x.USERNAME == username && x.PASSWORD == passsword || x.EMAIL == username && x.PASSWORD == passsword);
           
            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool checkloginkh(string email, string passsword)
        {
            int count = db.KHACHHANGs.Count(x => x.EMAIL == email && x.PASSWORD == passsword || x.SDT == email && x.PASSWORD == passsword);

            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool checkemail(string email)
        {
            int count = db.KHACHHANGs.Count(x => x.EMAIL == email);

            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
using SHOPSON.Areas.ADMIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHOPSON.Models
{
    [Serializable]
    public partial class giohangct
    {
        public long soluong { set; get; }
        public SANPHAM sanpham { set; get; }
    }
}
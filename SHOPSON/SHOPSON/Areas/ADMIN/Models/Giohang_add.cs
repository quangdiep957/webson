using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SHOPSON.Areas.ADMIN.Models
{
    public partial class Giohang_add
    {

        public string MAHD { get; set; }
        public Nullable<System.DateTime> NGAYLAP { get; set; }
        public Nullable<int> SOLUONG { get; set; }
        public Nullable<double> GIA { get; set; }
        public string MAKH { get; set; }
        public string MASP { get; set; }
        public Nullable<double> THANHTIEN { get; set; }
        public string TENKH { get; set; }
        public string SDT { get; set; }
        public string DIACHI { get; set; }
        public string DANHGIA { get; set; }
        public string ANH { get; set; }
        public string EMAIL { get; set; }
        public virtual HOADON HOADON { get; set; }
        public virtual SANPHAM SANPHAM { get; set; }
        public string ID { get; set; }
        public string TENSP { get; set; }
        public string THETICH { get; set; }
        public string MOTA { get; set; }
        public string MAMAU { get; set; }
        public string pttt { get; set; }
        public Nullable<System.DateTime> HSD { get; set; }
        public Nullable<bool> TRANGTHAI { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SHOPSON.Areas.ADMIN.Models
{
    public partial class  metaSP
    {
        [DisplayName("Mã sản phẩm")]    
        [Required(ErrorMessage = "Không thể bỏ trống")]
        public string MASP { get; set; }
        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage = "Không thể bỏ trống")]
        public string TENSP { get; set; }
        [DisplayName("Giá")]
        [Required(ErrorMessage = "Không thể bỏ trống")]
        public Nullable<double> GIA { get; set; }
        [DisplayName("Thể tích")]
        [Required(ErrorMessage = "Không thể bỏ trống")]
        public string THETICH { get; set; }
        [DisplayName("Trạng thái")] 
        public Nullable<bool> TRANGTHAI { get; set; }
        [DisplayName("Mô tả")]
        [Required(ErrorMessage = "Không thể bỏ trống")]
        public string MOTA { get; set; }
        [DisplayName("Mã loại sản phẩm")]
        [Required(ErrorMessage = "Không thể bỏ trống")]
        public string MLSP { get; set; }
        [DisplayName("Cấp độ")]
        public string CAPDO { get; set; }
        [DisplayName("Mã màu")]
        [Required(ErrorMessage = "Không thể bỏ trống")]
        public string MAMAU { get; set; }
        [DisplayName("Ảnh")]   
        public string ANH { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SHOPSON.Areas.ADMIN.Models
{
    public partial class metalogin
    {
       [Required(ErrorMessage ="Tài khoản không được bỏ trống!")]
        public string USERNAME { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống!")]
        public string PASSWORD { get; set; }
        public string EMAIL { get; set; }
    }
}
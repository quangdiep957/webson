using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SHOPSON.Areas.ADMIN.Models
{
    public partial class metakh
    {
       
    
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống!")]
        public string PASSWORD { get; set; } 
        [Required(ErrorMessage = "Tài khoản không được bỏ trống!")]
        public string EMAIL { get; set; }
    }
}
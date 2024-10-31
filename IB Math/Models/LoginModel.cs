using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IB_Math.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Required!")]
        public string User_email { get; set; }

        [Required(ErrorMessage ="Required!")]
        public string User_password { get; set; }
    }
}
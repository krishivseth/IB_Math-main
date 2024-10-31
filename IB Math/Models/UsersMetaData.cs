using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IB_Math.Models
{
    public class UsersMetaData
    {

        [Required(ErrorMessage = "Enter correct Password")]
        public string User_password { get; set; }


        [Required(ErrorMessage = "Enter correct Fname")]
        [Display(Name = "Name")]
        public string User_fname { get; set; }

        [Required(ErrorMessage = "Enter Email ID",AllowEmptyStrings = false)]
        [Remote("IsUserNameAvailable", "Users", ErrorMessage = "Email Already Available")]
        [Display(Name = "E-mail")]
        public string User_email { get; set; }


        [Required(ErrorMessage = "Enter  age")]
        [Display(Name = "Age")]
        public int User_age { get; set; }

        [Display(Name = "Class")]
        public string User_class { get; set; }

        public string User_grade { get; set; }

        [Display(Name = "Academic Position")]
        public string User_academicposition { get; set; }

    }
    [MetadataType(typeof(UsersMetaData))]
    public partial class User
    {
        //[Required(ErrorMessage = "Enter Correct Email ID")]
        //[Display(Name = "E-mail")]
       // public string EmailAddress { get; set; }
    }
}
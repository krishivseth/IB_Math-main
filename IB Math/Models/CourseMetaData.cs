using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IB_Math.Models
{
    public class CourseMetaData
    {
        [Required(ErrorMessage = "Enter Correct Course Name")]
        public string Course_name { get; set; }
    }
    [MetadataType(typeof(CourseMetaData))]
    public partial class Cours
    {

    }
}
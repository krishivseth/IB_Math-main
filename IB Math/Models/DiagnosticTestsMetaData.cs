using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IB_Math.Models
{
    public class DiagnosticTestsMetaData
    {
        public int Diagtest_id { get; set; }
        [Required(ErrorMessage="Enter correct Daigtestname ")]
        public string Diagtest_name { get; set; }

        public int Course_id { get; set; }
        [Required(ErrorMessage ="Enter correct Diagtest que ")]
        [AllowHtml]
        public string Diagtest_que { get; set; }
        [Required(ErrorMessage ="Enter correct option ")]

        public string Option1 { get; set; }
        [Required(ErrorMessage = "Enter correct option ")]
        public string Option2 { get; set; }
        [Required(ErrorMessage = "Enter correct option ")]
        public string Option3 { get; set; }
        [Required(ErrorMessage = "Enter correct option ")]
        public string Option4 { get; set; }
        [Required(ErrorMessage = "Enter correct Numeric ")]
        public int Weightage { get; set; }

        [Required(ErrorMessage ="Enter valid Answer")]
        public string Diagtest_answer { get; set; }


    }
    [MetadataType(typeof(DiagnosticTestsMetaData))]
    public partial class DiagnosticTest
    {

    }
}
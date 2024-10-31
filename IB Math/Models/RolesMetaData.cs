using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IB_Math.Models
{
    
    public class RolesMetaData
    {  
        [Required(ErrorMessage ="Enter RoleName")]
        public string Role_name { get; set; }
    }

    [MetadataType(typeof(RolesMetaData))]
    public partial class Role
    {

    }
}
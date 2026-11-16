using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ESAD_CS_R72_M_06_MVC_D005.Models.ViewModels
{
    public class CheckBoxModel
    {
        public int TagId { get; set; }
       
        public string TagName { get; set; }
        public bool Selected { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ESAD_CS_R72_M_06_MVC_D005.Models.ViewModels
{
    public class ArticleViewModel
    {
        public int ArticleId { get; set; }
        [Required, StringLength(100)]
        public string  Title { get; set; }
        [Required,Column(TypeName ="date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode =true), Display(Name = "Publish Date")]
        public DateTime  PublishDate { get; set; }
        public string  Tags { get; set; }
    }
}
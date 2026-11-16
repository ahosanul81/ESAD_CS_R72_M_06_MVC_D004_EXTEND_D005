using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ESAD_CS_R72_M_06_MVC_D005.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        [Required, StringLength(100)]
        public string Title { get; set; }


        [
            Required, 
            Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), 
            Display(Name = "Publish date")
        ]
        public DateTime Publishdate { get; set; }

        public virtual ICollection<ArticleTag> ArticleTags { get; set; } = new List<ArticleTag>();
    }

    public class Tag
    {
        public int TagId { get; set; }
        [Required, StringLength(100), Display(Name = "Tag Name")]
        public string TagName { get; set; }

        public virtual ICollection<ArticleTag> ArticleTags { get; set; } = new List<ArticleTag>();
    }

    public class ArticleTag
    {
        [Key, Column(Order = 1), ForeignKey("Article")]
        public int ArticleId { get; set; }

        [Key, Column(Order = 2), ForeignKey("Tag")]
        public int TagId { get; set; }

        // navigation
        public virtual Article Article { get; set; }
        public virtual Tag Tag { get; set; }
    }

    public class ArticleDbContext : DbContext
    {
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
    }
}
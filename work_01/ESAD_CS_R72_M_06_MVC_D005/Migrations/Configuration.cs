namespace ESAD_CS_R72_M_06_MVC_D005.Migrations
{
    using ESAD_CS_R72_M_06_MVC_D005.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ESAD_CS_R72_M_06_MVC_D005.Models.ArticleDbContext>
    {
       
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ESAD_CS_R72_M_06_MVC_D005.Models.ArticleDbContext db)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            Tag t1 = new Tag() { TagName = "C#"};
            Tag t2 = new Tag() { TagName = "PHT"};
            Tag t3 = new Tag() { TagName = "Angular"};
            Tag t4 = new Tag() { TagName = "API"};

            db.Tags.AddRange(new Tag[]
            {
                t1,t2,t3,t4
            });

            Article a = new Article()
            {
                Title = "Getting started with MVC C#",
                Publishdate = new DateTime(2021,5,21),
                ArticleTags = new ArticleTag[]
                {
                    new ArticleTag{Tag= t1},
                    new ArticleTag{Tag= t3}
                }
            };

            db.Articles.Add(a);
            db.SaveChanges();
        }
    }
}

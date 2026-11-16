using ESAD_CS_R72_M_06_MVC_D005.Models;
using ESAD_CS_R72_M_06_MVC_D005.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESAD_CS_R72_M_06_MVC_D005.Controllers
{
    public class HomeController : Controller
    {
        ArticleDbContext db = new ArticleDbContext();
        public ActionResult Index()
        {
            var viewModelData = db.Articles
                                .AsEnumerable()
                                .Select(a => new ArticleViewModel
                                {
                                    ArticleId = a.ArticleId,
                                    Title = a.Title,
                                    PublishDate = a.Publishdate,
                                    Tags = String.Join(", ", a.ArticleTags.Select(t => t.Tag.TagName).ToArray())
                                });
            return View(viewModelData);
        }

        public ActionResult Create()
        {
            ViewBag.CheckBoxData = db.Tags.ToList();

            return View();
        }
        [HttpPost]
        public ActionResult Create(Article a , int[] tagIds)
        {
            if (ModelState.IsValid)
            {
                foreach (int id in tagIds)
                {
                    
                    a.ArticleTags.Add(new ArticleTag
                    {
                        TagId = id
                    });
                }
                db.Articles.Add(a);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
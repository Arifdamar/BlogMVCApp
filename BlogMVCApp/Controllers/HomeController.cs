using BlogMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext context = new BlogContext();
        // GET: Home
        public ActionResult Index()
        {
            var blogs = context.Blogs.Where(i => i.IsConfirmed == true && i.IsHomePage == true).Select(i => new BlogModel
            {
                Id = i.Id,
                Title = i.Title,
                Photo = i.Photo,
                CreationDate = i.CreationDate,
                Explanation = i.Explanation.Length > 100 ? i.Explanation.Substring(0, 100) + "..." : i.Explanation,
                IsConfirmed = i.IsConfirmed,
                IsHomePage = i.IsHomePage
            });

            return View(blogs.ToList());
        }
    }
}
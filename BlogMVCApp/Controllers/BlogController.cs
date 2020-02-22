using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogMVCApp.Models;

namespace BlogMVCApp.Controllers
{
    public class BlogController : Controller
    {
        private BlogContext db = new BlogContext();

        public ActionResult List(int? id)
        {
            var blogs = db.Blogs
                .Where(i => i.IsConfirmed == true)
                .Select(i => new BlogModel
                {
                    Id = i.Id,
                    Title = i.Title,
                    Photo = i.Photo,
                    CreationDate = i.CreationDate,
                    Explanation = i.Explanation.Length > 100 ? i.Explanation.Substring(0, 100) + "..." : i.Explanation,
                    IsConfirmed = i.IsConfirmed,
                    IsHomePage = i.IsHomePage,
                    CategoryId = i.CategoryId
                }).AsQueryable();

            if(id != null)
            {
                blogs = blogs.Where(i => i.CategoryId == id);
            }

            return View(blogs.ToList());

        }

        // GET: Blog
        public ActionResult Index()
        {
            var blogs = db.Blogs.Include(b => b.Category);
            return View(blogs.ToList());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
            return View();
        }

        // POST: Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Explanation,Content,Photo,CategoryId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.CreationDate = DateTime.Now;
                blog.IsConfirmed = false;
                blog.IsHomePage = false;


                db.Blogs.Add(blog);
                db.SaveChanges();

                TempData["BlogCreate"] = blog;

                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", blog.CategoryId);
            return View(blog);
        }

        // POST: Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Explanation,Content,Photo,IsConfirmed,IsHomePage,CategoryId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                var entity = db.Blogs.Find(blog.Id);

                if (entity != null)
                {
                    entity.Title = blog.Title;
                    entity.Explanation = blog.Explanation;
                    entity.Content = blog.Content;
                    entity.Photo = blog.Photo;
                    entity.IsConfirmed = blog.IsConfirmed;
                    entity.IsHomePage = blog.IsHomePage;
                    entity.CategoryId = blog.CategoryId;
                    
                    db.SaveChanges();

                    TempData["Blog"] = entity;

                    return RedirectToAction("Index");
                }
                
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

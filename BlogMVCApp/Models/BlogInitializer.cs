using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogMVCApp.Models
{
    public class BlogInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            List<Category> categories = new List<Category>()
            {
                new Category() { CategoryName = "C#"},
                new Category() { CategoryName = "Asp.net MVC"},
                new Category() { CategoryName = "Asp.net WebForm"},
                new Category() { CategoryName = "Windows Form"}
            };

            foreach (var item in categories)
            {
                context.Categories.Add(item);
            }

            context.SaveChanges();

            List<Blog> blogs = new List<Blog>()
            {
                new Blog()
                {
                    Title = "C# Delegates",
                    Explanation = "How useful C# delegates",
                    CreationDate = DateTime.Now.AddDays(-10),
                    IsHomePage = true,
                    IsConfirmed = true,
                    Content = "There is some long technical essay about C# elegates \nLorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Photo = "1.jpg",
                    CategoryId = 1
                },
                new Blog()
                {
                    Title = "C# Generic List",
                    Explanation = "How useful C# generic list",
                    CreationDate = DateTime.Now.AddDays(-10),
                    IsHomePage = true,
                    IsConfirmed = true,
                    Content = "There is some long technical essay about C# generic list\nLorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Photo = "2.jpg",
                    CategoryId = 1
                },
                new Blog()
                {
                    Title = "Asp.net MVC Controller",
                    Explanation = "How useful Asp.net MVC Controller",
                    CreationDate = DateTime.Now.AddDays(-9),
                    IsHomePage = false,
                    IsConfirmed = true,
                    Content = "There is some long technical essay about Asp.net MVC Controller\nLorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Photo = "3.jpg",
                    CategoryId = 2
                },
                new Blog()
                {
                    Title = "Asp.net MVC View",
                    Explanation = "How useful Asp.net MVC View",
                    CreationDate = DateTime.Now.AddDays(-8),
                    IsHomePage = true,
                    IsConfirmed = true,
                    Content = "There is some long technical essay about Asp.net MVC View\nLorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Photo = "4.jpg",
                    CategoryId = 2
                },
                new Blog()
                {
                    Title = "Asp.net MVC Model",
                    Explanation = "How useful Asp.net MVC Model",
                    CreationDate = DateTime.Now.AddDays(-8),
                    IsHomePage = true,
                    IsConfirmed = true,
                    Content = "There is some long technical essay about Asp.net MVC Model\nLorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Photo = "4.jpg",
                    CategoryId = 2
                },
                new Blog()
                {
                    Title = "Asp.net WebForm",
                    Explanation = "How useful Asp.net WebForm",
                    CreationDate = DateTime.Now.AddDays(-6),
                    IsHomePage = true,
                    IsConfirmed = true,
                    Content = "There is some long technical essay about Asp.net WebForm\nLorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Photo = "5.jpg",
                    CategoryId = 3
                },
                new Blog()
                {
                    Title = "Windows Form",
                    Explanation = "How useful Windows Form",
                    CreationDate = DateTime.Now.AddDays(-1),
                    IsHomePage = false,
                    IsConfirmed = false,
                    Content = "There is some long technical essay about Windows Form\nLorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Photo = "6.jpg",
                    CategoryId = 4
                },
            };

            foreach (var item in blogs)
            {
                context.Blogs.Add(item);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMVCApp.Models
{
    public class BlogModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Explanation { get; set; }
        public string Photo { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsHomePage { get; set; }
        public int CategoryId { get; set; }
    }
}
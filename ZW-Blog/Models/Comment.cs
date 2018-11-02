using System;
using System.Web.Mvc;

namespace ZW_Blog.Models
{
    public class Comment
    {
        //primary key (PK)
        public int Id { get; set; }

        //foreign key (FK) points to certain Blog Post
        public int BlogPostId { get; set; }

        //FK points to PK of AspNetUsers table
        public string AuthorId { get; set; }
        public string Body { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        public string UpdateReason { get; set; }

        public virtual ApplicationUser Author { get; set; }
        public virtual BlogPost BlogPost { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ZW_Blog.Models
{
    public class BlogPost
    {
        public BlogPost()
        {
            Comments = new HashSet<Comment>();
        }

        //primary key (PK)
        public int Id { get; set; }
        public DateTimeOffset Created { get; set; }

        // ? means the item can be null
        public DateTimeOffset? Updated { get; set; }
        public string Title { get; set; }

        //an abstract is a 1-2 sentence section that helps
        //a would-be user to determine if they are interested
        //in reading the entire blog post
        public string Abstract { get; set; }

        //alternate title; provides alternate route to classes
        public string Slug { get; set; }

        [AllowHtml]
        public string Body { get; set; }

        //path to image
        public string MediaURL{ get; set; }

        //make the post public to all
        public bool Published { get; set; }
      
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
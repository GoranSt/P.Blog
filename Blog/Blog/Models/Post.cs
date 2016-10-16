using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Post
    {

        public int PostId{ get; set; }

        [Required(ErrorMessage = "Title is required")]
        
        public string Title { get; set; }

        [Required(ErrorMessage = "Body is required")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual List<Comment> Comments { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
    }
}
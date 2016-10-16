using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Models
{
    public class Comment
    {
        [HiddenInput(DisplayValue = false)]
        public int CommentId { get; set; }


       [Required(ErrorMessage = "Required")]
        [DataType(DataType.MultilineText)]
        [StringLength(150,MinimumLength = 1, ErrorMessage = "Maximum allowed characters are 150, minimum is 1 character")]
        public string Text { get; set; }

   


    
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

       
        public virtual List<Comment> Replies { get; set; }


        public string UserId { get; set; }



    }
}
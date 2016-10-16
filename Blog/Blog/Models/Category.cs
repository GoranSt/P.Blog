using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Category
    {

        public int CategoryId { get; set; }


        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

    


        public virtual List<Post> Posts { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

    }
}
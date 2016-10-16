using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.ViewModels
{
    public class CategoryPostDetails
    {



        public Category Category { get; set; }

        public IEnumerable<Post> RecentPosts { get; set; }
        public IEnumerable<Comment> LatestComments { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.DAL;
using Blog.Models;
using Blog.CustomFilters;
using Microsoft.AspNet.Identity;

namespace Blog.Controllers
{

    
    public class PostsController : Controller
    {
        private BlogContext db = new BlogContext();
        private ApplicationDbContext appdb = new ApplicationDbContext();
        // GET: Posts

            [AllowAnonymous]
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Category);

            //ViewBag.recentPosts = db.Posts.Count();


            return View(posts.ToList());
        }

        // GET: Posts/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        [AuthLog(Roles = "Administrator")]
        public ActionResult Create(int id)
        {
          
           ViewBag.Categ = id;

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Title");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthLog(Roles = "Administrator")]
        public ActionResult Create([Bind(Include = "PostId,Title,Content,CategoryId")] Post post)
        {
            if (ModelState.IsValid)
            {

                post.Date = DateTime.Now;
             

                db.Posts.Add(post);
                db.SaveChanges();

                string url = "/Categories/Details/" + post.CategoryId;
                
                return Redirect(url);
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Title", post.CategoryId);
            return View(post);
        }

        // GET: Posts/Edit/5
        [AuthLog(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Title", post.CategoryId);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthLog(Roles = "Administrator")]
        public ActionResult Edit([Bind(Include = "PostId,Title, Content, CategoryId")] Post post)
        {
            if (ModelState.IsValid)
            {

                post.Date = DateTime.Now;
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("/Categories/Details/" + post.CategoryId);
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Title", post.CategoryId);
            return View(post);
        }

        [AuthLog(Roles = "Administrator, User")]
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult AddComment([Bind(Include = "Text, PostId")] Comment comment, int id)
        {
            string url = "/Show/" + id;
            comment.PostId = id;
           
            if (ModelState.IsValid)
            {

                string user = User.Identity.GetUserId();
                // preku ova go naogame najaveniot user
                ApplicationUser currentUser = appdb.Users.FirstOrDefault(x => x.Id == user);

                // go vnesuvame imeto na korisnikot vo modelot
                comment.UserId = currentUser.UserName;

                comment.Date = DateTime.Now;

                db.Comments.Add(comment);
                db.SaveChanges();

               
                return RedirectToAction(url);

            }

            return RedirectToAction(url);
        }

        [AllowAnonymous]
        public ActionResult Show(int? id, int? commentId)
        {

           Post post = db.Posts.Find(id);


            


            return View(post);


        }






        // GET: Posts/Delete/5
        [AuthLog(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [AuthLog(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            
            db.Posts.Remove(post);
            db.SaveChanges();

            return Redirect("/Categories/Details/" + post.CategoryId);
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

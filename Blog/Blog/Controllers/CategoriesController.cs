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
using PagedList;
using Blog.CustomFilters;
using Blog.ViewModels;

namespace Blog.Controllers
{

    [AuthLog(Roles = "Administrator")]
    public class CategoriesController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: Categories
        [AllowAnonymous]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.currentSort = sortOrder;


            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
           
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            ViewBag.CountPostsSortParm = sortOrder == "min" ? "max" : "min";

            if (searchString != null)
            {

                page = 1;
            }
            else
            {

                searchString = currentFilter;
            }



           


            var categories = from s in db.Categories select s;


            if (!String.IsNullOrEmpty(searchString))
            {
                categories = categories.Where(s => s.Title.Contains(searchString));

            }



            switch (sortOrder)
            {
                case "name_desc":
                  categories = categories.OrderByDescending(s => s.Title);
                    break;

                case "Date":

                     categories =  categories.OrderBy(s => s.Date);
                    break;
                    
                case "date_desc":

                    categories = categories.OrderByDescending(s => s.Date);
                    break;


                case "max":

                    categories = categories.OrderByDescending(s => s.Posts.Count);
                    break;

                case "min":

                    categories = categories.OrderBy(s => s.Posts.Count);
                    break;


                default:
                    categories = categories.OrderBy(s => s.Title);
                   
                    break;

            }


            int pageSize = 10;
            int pageNumber = (page ?? 1);


         


           

            var posts = db.Posts.ToList().OrderByDescending(s => s.Date).Take(3);
            var comments = db.Comments.ToList().OrderByDescending(s => s.Date).Take(4);
            ViewBag.posts = posts;
            ViewBag.comments = comments;



            ViewBag.countCategories =  db.Categories.Count();

            return View(categories.ToPagedList(pageNumber, pageSize));
           
        }
        


        [AllowAnonymous]
        public ActionResult DetailsPosts()
        {
            return View();
        }









        //  probno GET: Categories/id

            [AllowAnonymous]
        public ActionResult Show(int? id)
        {


          Category category = db.Categories.Find(id);




            return View(category);
        }



     



        // GET: Categories/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id, string sortOrder, string currentFilter, string searchString, int? page)
        {
            CategoryPostDetails cpd = new CategoryPostDetails();

            ViewBag.currentSort = sortOrder;
          

            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";



            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";




                    if (searchString != null)
            {

                page = 1;
            }
            else
            {

                searchString = currentFilter;
            }

           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            cpd.Category = db.Categories.Find(id);
            if (cpd.Category == null)
            {
                return HttpNotFound();
            }
            



            if (!String.IsNullOrEmpty(searchString))
            {
                cpd.Category.Posts = cpd.Category.Posts.Where(s => s.Title.Contains(searchString)).ToList();

            }
            


            switch (sortOrder)
            {
                case "name_desc":
                    cpd.Category.Posts = cpd.Category.Posts.OrderByDescending(s => s.Title).ToList();
                    break;
                        case "Date":

                    cpd.Category.Posts = cpd.Category.Posts.OrderBy(s => s.Date).ToList();
                            break;

                        case "date_desc":

                    cpd.Category.Posts = cpd.Category.Posts.OrderByDescending(s => s.Date).ToList();
                            break;
                        default:
                    cpd.Category.Posts = cpd.Category.Posts.OrderBy(s => s.Title).ToList();

                    break;

            }



           cpd.RecentPosts = db.Posts.ToList().OrderByDescending(s => s.Date).Take(3);
           cpd.LatestComments = db.Comments.ToList().OrderByDescending(s => s.Date).Take(4);
           


            return View(cpd);


        }

        // GET: Categories/Create
        //[AuthLog(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,Title")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.Date = DateTime.Now;
                
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,Title")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.Date = DateTime.Now;
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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

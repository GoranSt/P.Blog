namespace Blog.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Blog.DAL.BlogContext>
    {

       
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Blog.DAL.BlogContext";
           
        }

        protected override async void Seed(Blog.DAL.BlogContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

           
           

            //if (!context2.Users.Any(u => u.UserName == "Admin"))
            //{
            //    var store = new UserStore<ApplicationUser>(context2);
            //    var manager = new UserManager<ApplicationUser>(store);
            //    var user = new ApplicationUser { UserName = "Admin1" };

            //    manager.Create(user, "Password@123");
              
            //    manager.AddToRole(user.Id, "Administrator");
           
            //}
          



            context.Categories.AddOrUpdate(

            new Category
               {
                   Title = "Technology",
                   Date = DateTime.Now,
                   Posts =
               new List<Post> {
                   new Post { Title = "Zero-carbon fuel made of carbon dioxide", Content = "Improbable as it sounds, a few different companies have developed working prototypes which turn carbon dioxide into a fuel. All rely on sucking CO2 out of the air, then converting it into a diesel fuel, which, amazingly, emits no carbon when burned.", Date = DateTime.Now,
                   Comments = new List<Comment> {
                   new Comment { Text = "awesome post!", Date = DateTime.Now.AddMonths(3), UserId = "Marija" },
                   new Comment { Text = "looks good!", Date = DateTime.Now.AddMonths(3), UserId = "Marko" },
                   new Comment { Text = "third comment", Date = DateTime.Now.AddMonths(3), UserId = "Robert" },
                   new Comment { Text = "aww!", Date = DateTime.Now.AddMonths(3), UserId = "Lewandowski" }
               }
               },
                        new Post { Title = "A robot to schedule your meetings", Content = "Artificial Intelligence still can't have a totally convincing chat with us, but it's now sophisticated enough to carry out online customer service, and, as it turns out, be your personal assistant. New app x.ai lets you email about a meeting you want to set up, and she liases with you and the other person to find a time that works.", Date = DateTime.Now.AddDays(1),
                   Comments = new List<Comment> {
                   new Comment { Text = "awesome post!", Date = DateTime.Now.AddMonths(3), UserId = "Marija" },
                   new Comment { Text = "looks good!", Date = DateTime.Now.AddMonths(3), UserId = "Marko" },
                   new Comment { Text = "third comment", Date = DateTime.Now.AddMonths(3), UserId = "Robert" },
                   new Comment { Text = "aww!", Date = DateTime.Now.AddMonths(3), UserId = "Lewandowski" }
               }
               },
                                new Post { Title = "A hotel in space", Content = "Russian company Orbital Technologies reckons it'll be sending tourists into space as early as next year. Guests would zoom up to the Commercial Space Station on a rocket, then spend their time in one of the station's four cabins enjoying zero gravity and watching earth through the ship's giant portholes. And this is only the beginning: Mashable has totted up nine commercial companies planning to send normal people into space over the next decade or so.", Date = DateTime.Now,
                   Comments = new List<Comment> {
                   new Comment { Text = "awesome post!", Date = DateTime.Now.AddMonths(3), UserId = "Marija" },
                   new Comment { Text = "looks good!", Date = DateTime.Now.AddMonths(3), UserId = "Marko" },
                   new Comment { Text = "third comment", Date = DateTime.Now.AddMonths(3), UserId = "Robert" },
                   new Comment { Text = "aww!", Date = DateTime.Now.AddMonths(3), UserId = "Lewandowski" }
               }
               },
                   new Post { Title = "Solar panel phone screens", Content = "I've been predicting that these will be A Big Deal for over a year, and have partly included them because I just think they're really cool. But as with many new technologies, several sets of researchers are currently working to make transparent solar panels better and cheaper, which means that next year could be the year consumers finally get hold of them. Once on the market, they could invisibly collect solar power on phone and computer screens, and even on windows.", Date = DateTime.Now.AddHours(5),
                   Comments = new List<Comment> {
                   new Comment { Text = "awesome post!", Date = DateTime.Now.AddMonths(3), UserId = "Marija" },
                   new Comment { Text = "looks good!", Date = DateTime.Now.AddMonths(3), UserId = "Marko" },
                   new Comment { Text = "third comment", Date = DateTime.Now.AddMonths(3), UserId = "Robert" },
                   new Comment { Text = "aww!", Date = DateTime.Now.AddMonths(3), UserId = "Lewandowski" }
               }
               },
                        new Post { Title = "Self-driving cars", Content = "Yes, they've been around for ages, but now we have on-the-road testing and the beginnings of a legislative framework for the cars, they could soon be an everyday reality. Google has announced it's teaming up with Ford to build self-driving vehicles, hinting at large-scale commercial production in the near future.", Date = DateTime.Now.AddDays(2),
                   Comments = new List<Comment> {
                   new Comment { Text = "awesome post!", Date = DateTime.Now.AddMonths(3), UserId = "Marija" },
                   new Comment { Text = "looks good!", Date = DateTime.Now.AddMonths(3), UserId = "Marko" },
                   new Comment { Text = "third comment", Date = DateTime.Now.AddMonths(3), UserId = "Robert" },
                   new Comment { Text = "aww!", Date = DateTime.Now.AddMonths(3), UserId = "Lewandowski" }
               }
               },
                             new Post { Title = "The suncream pill", Content = "Fish and coral both excrete a compound that protects them from the sun, and for the past five years or so scientists have been working to use these substances in a pill which, when consumed by humans, would offer the same protection. If it works, it could cut rates of sunburn and skin cancer, and spare you from endless bouts of greasy reapplication.", Date = DateTime.Now.AddDays(4),
                   Comments = new List<Comment> {
                   new Comment { Text = "awesome post!", Date = DateTime.Now.AddMonths(3), UserId = "Marija" },
                   new Comment { Text = "looks good!", Date = DateTime.Now.AddMonths(3), UserId = "Marko" },
                   new Comment { Text = "third comment", Date = DateTime.Now.AddMonths(3), UserId = "Robert" },
                   new Comment { Text = "aww!", Date = DateTime.Now.AddMonths(3), UserId = "Lewandowski" }
               }
               }
               }
               },


               new Category
               {
                   Title = "Science",
                   Date = DateTime.Now,
                   Posts =
                  new List<Post> {
                   new Post { Title = "Fact 1", Content = "There are 62,000 miles of blood vessels in the human body – laid end to end they would circle the earth 2.5 times.", Date = DateTime.Now,
                   Comments = new List<Comment> {
                   new Comment { Text = "awesome post!", Date = DateTime.Now.AddMonths(3), UserId = "Marija" },
                   new Comment { Text = "looks good!", Date = DateTime.Now.AddMonths(3), UserId = "Marko" },
                   new Comment { Text = "third comment", Date = DateTime.Now.AddMonths(3), UserId = "Robert" },
                   new Comment { Text = "aww!", Date = DateTime.Now.AddMonths(3), UserId = "Lewandowski" }
               }
               },
                        new Post { Title = "Fact 2", Content = "The risk of being struck by a falling meteorite for a human is one occurrence every 9,300 years.", Date = DateTime.Now.AddDays(1),
                   Comments = new List<Comment> {
                   new Comment { Text = "awesome post!", Date = DateTime.Now.AddMonths(3), UserId = "Marija" },
                   new Comment { Text = "looks good!", Date = DateTime.Now.AddMonths(3), UserId = "Marko" },
                   new Comment { Text = "third comment", Date = DateTime.Now.AddMonths(3), UserId = "Robert" },
                   new Comment { Text = "aww!", Date = DateTime.Now.AddMonths(3), UserId = "Lewandowski" }
               }
               },
                                new Post { Title = "Fact 3", Content = "A typical hurricane produces the energy equivalent of 8,000 one megaton bombs.", Date = DateTime.Now,
                   Comments = new List<Comment> {
                   new Comment { Text = "awesome post!", Date = DateTime.Now.AddMonths(3), UserId = "Marija" },
                   new Comment { Text = "looks good!", Date = DateTime.Now.AddMonths(3), UserId = "Marko" },
                   new Comment { Text = "third comment", Date = DateTime.Now.AddMonths(3), UserId = "Robert" },
                   new Comment { Text = "aww!", Date = DateTime.Now.AddMonths(3), UserId = "Lewandowski" }
               }
               },
                   new Post { Title = "Fact 4", Content = "The highest speed ever achieved on a bicycle is 166.94 mph, by Fred Rompelberg.", Date = DateTime.Now.AddHours(5),
                   Comments = new List<Comment> {
                   new Comment { Text = "awesome post!", Date = DateTime.Now.AddMonths(3), UserId = "Marija" },
                   new Comment { Text = "looks good!", Date = DateTime.Now.AddMonths(3), UserId = "Marko" },
                   new Comment { Text = "third comment", Date = DateTime.Now.AddMonths(3), UserId = "Robert" },
                   new Comment { Text = "aww!", Date = DateTime.Now.AddMonths(3), UserId = "Lewandowski" }
               }
               },

                             new Post { Title = "Fact 5", Content = "The temperature on the surface of Mercury exceeds 430 degrees C during the day, and, at night, plummets to minus 180 degrees centigrade.", Date = DateTime.Now.AddDays(4),
                   Comments = new List<Comment> {
                   new Comment { Text = "awesome post!", Date = DateTime.Now.AddMonths(3), UserId = "Marija" },
                   new Comment { Text = "looks good!", Date = DateTime.Now.AddMonths(3), UserId = "Marko" },
                   new Comment { Text = "third comment", Date = DateTime.Now.AddMonths(3), UserId = "Robert" },
                   new Comment { Text = "aww!", Date = DateTime.Now.AddMonths(3), UserId = "Lewandowski" }
               }
               }
               }
               },
               new Category { Title = "Adventure", Date = DateTime.Now, Posts = new List<Post> {
                   new Post { Title = "The Lost World and Angel Falls", Content = "Conan Doyle’s classic adventure novel was inspired by Venezuela’s “Lost World”, a region of dense jungle and rolling grassland dominated by immense sandstone table mountains known as tepuis. You’ll trek to the summit of Mount Roraima, a maze of blackened rock and babbling streams with unique plants and rare carnivorous frogs. Visit Auyán-tepui and see Angel Falls, the world’s highest waterfall, as it plunges 3,200ft.", Date = DateTime.Now.AddHours(8), Comments = new List<Comment> {
                       new Comment { Text = "awesome post!", Date = DateTime.Now.AddMonths(3), UserId = "Dimitar" } } }, new Post { Title = "Australia’s Red Centre", Content = "Opened in 2002, the 140-mile (225km) Larapinta Trail from Alice Springs to Mount Sonder through the West MacDonnell Ranges is one of the world’s great bush walks. The trail can be done in shorter stretches, but why not go for the full 14-day experience? There will be challenging stages of up to 20 miles on some days, but you’ll carry only your day pack.", Date = DateTime.Now.AddHours(8), Comments = new List<Comment> {
                           new Comment { Text = "awesome post!", Date = DateTime.Now.AddMonths(3), UserId = "Dimitar" } } } } },
               new Category { Title = "Food", Date = DateTime.Now, Posts = new List<Post> {
                   new Post { Title = "Mattake or Matsutake Mushrooms – $1,000", Content = "The mattake, or matsutake, mushroom is the most expensive mushroom in the world today. This is a highly coveted mycorrhizal mushroom that can be found in Asia, North America and Europe, particularly in Japan, China, Korea, the United States, Canada, Finland and Sweden. The most popular is the one associated with the Japanese Red Pine. It is usually hidden under fallen leaves on the forest floor. While simple to harvest, it is extremely hard to find. The annual harvest in Japan is less than a thousand tons only.", Date = DateTime.Now, Comments = new List<Comment> {
                       new Comment { Text = "awesome post!", Date = DateTime.Now, UserId = "Goran" } } } } },
               new Category { Title = "Sport", Date = DateTime.Now },

               new Category { Title = "Life", Date = DateTime.Now, Posts = new List<Post> {
                   new Post { Title = "Walking on earth", Content = "If you find it difficult to get active, why not start walking? It's really easy to get started, you don't need any special equipment - and best of all it counts towards your recommended amount of physical activity. Walking can improve your health, your happiness and, if you join one of our groups, it will give you the chance to explore the outdoors, get to know your local area and meet new people.", Date = DateTime.Now, Comments = new List<Comment> {
                       new Comment { Text = "awesome post!", Date = DateTime.Now.AddMonths(3), UserId = "Marko" }, new Comment { Text = "looks good", Date = DateTime.Now.AddMonths(3), UserId = "Robert" },
                       new Comment { Text = "tip of the year!", Date = DateTime.Now.AddMonths(3), UserId = "Natasha" } } } } },
               new Category { Title = "Media & TV", Date = DateTime.Now },
               new Category { Title = "Biology", Date = DateTime.Now },
               new Category { Title = "Fashion", Date = DateTime.Now },
               new Category { Title = "Religion", Date = DateTime.Now },

               new Category { Title = "Nature", Date = DateTime.Now },
               new Category { Title = "Traveling", Date = DateTime.Now }


                );
            context.SaveChanges();


        }
    }
}

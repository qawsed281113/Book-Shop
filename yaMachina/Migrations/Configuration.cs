namespace yaMachina.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using yaMachina.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<yaMachina.Models.BookShopDBContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "yaMachina.Models.BookShopDBContext";
   
        }

        protected override void Seed(yaMachina.Models.BookShopDBContext context)
        {


            context.Genres.AddRange(new[] 
            {
                new Genre { ID = 1, Name = "Mystery" },
                new Genre { ID = 2, Name = "Thriller" },
                new Genre { ID = 3, Name = "Horror." },
                new Genre { ID = 4, Name = "Historical" },
                new Genre { ID = 5, Name = "Romance" },
                new Genre { ID= 6,Name ="Western"},
                new Genre { ID = 7, Name = "Bildungsroman" },
                new Genre { ID = 8, Name = "Dystopian" },
                new Genre { ID= 9,Name ="Realist_Literature"}
            });
            context.Publishers.AddRange(new[]
            {
                new Publisher { ID = 1, Name ="Видавництво Старого Лева"},
                new Publisher { ID = 2, Name ="Наш Формат"},
                new Publisher { ID = 3, Name =@"Видавничий дім ""Школа"""},
                new Publisher { ID = 4, Name ="Ранок"},
                new Publisher { ID = 5, Name ="Книголав"},
                new Publisher { ID = 6, Name ="НК-Богдан"},


            });
            List<Year> list = new List<Year>();
            int id = 1;
            for(int i = 1970; i <= DateTime.Now.Year; i++)
            {
                list.Add(new Year { ID = id, YearPublished = i});
                id++;
            }

            context.Years.AddRange(list);

            context.SaveChanges();



        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace yaMachina.Models
{
    public class BookShopDBContext : DbContext
    {

        public DbSet<Book> Books { get; set; }
        public DbSet<FIO> FIOs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Year> Years { get; set; }
        public BookShopDBContext() : base("name=BookShop")
        { 




        }
    }
}

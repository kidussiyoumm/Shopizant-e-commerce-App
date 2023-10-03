using Microsoft.EntityFrameworkCore;
using Shopizant.CodeFirst.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopizant.CodeFirst.DAL.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class ShopizantDBContext : DbContext //Database
    {
        public ShopizantDBContext()
        {

        }


        //Representing table rows as a collection using Dbset from the model class created 
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CardDetails> CardDetail { get; set; }
        public DbSet<Users> User { get; set; }
        public DbSet<Roles> Role { get; set; }
        public DbSet<PurchaseDetails> PurchaseDetail { get; set; }
        public DbSet<Cart> cart { get; set; }
        public DbSet<CartItems> cartItems { get; set; }


        //DbContextOptionsbuilder lets us select a Database and conect to it connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source =LTUS160774\\SQLEXPRESS2019; Initial Catalog=ShopizantDB;Integrated Security=true");
            }
        }
    }
}


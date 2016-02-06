using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OnlineShopping.Models;

namespace OnlineShopping.DAL
{
    public class OnlineShoppingContext : DbContext
    {

        public OnlineShoppingContext()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<ProductCategory> PorductCategories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<OrderDetail> OrderDtails { get; set; }

        public DbSet<OrderHeader> OrderHeaders { get; set; }

    }
}
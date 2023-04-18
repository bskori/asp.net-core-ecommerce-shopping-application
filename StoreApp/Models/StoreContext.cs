using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> opt) : base(opt) 
        { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MainCategory> MainCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<DispatchAgency> DispatchAgencies { get; set; }
        public DbSet<UserOrder> UserOrders { get; set; }
        public DbSet<UserOrderDetails> UserOrderDetails { get; set; }
        public DbSet<UserOrderDispatch> UserOrderDispatches { get; set; }
        public DbSet<Cart> Carts { get; set; }
       
    }
}

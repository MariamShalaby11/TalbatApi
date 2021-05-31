using System;
using System.Data.Entity;
using System.Linq;

namespace TalbatApi.Models
{
    public class Talabat : DbContext
    {
        // Your context has been configured to use a 'Talabat' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TalbatApi.Models.Talabat' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Talabat' 
        // connection string in the application configuration file.
        public Talabat()
            : base("name=Talabat")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Cuisine> Cuisines { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<MealOrder> MealOrders { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Partener> Parteners { get; set; }
        public virtual DbSet<RestaurantCustomer> RestaurantCustomers { get; set; }
        public virtual DbSet<RestaurantCusine> RestaurantCusines { get; set; }


    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
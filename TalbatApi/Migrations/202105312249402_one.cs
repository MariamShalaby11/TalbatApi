namespace TalbatApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        BuildingNo = c.Int(),
                        Street = c.String(),
                        floorNo = c.Int(),
                        LandMark = c.String(),
                        city = c.String(nullable: false),
                        lat = c.Double(nullable: false),
                        lang = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MenuID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Menus", t => t.MenuID, cascadeDelete: true)
                .Index(t => t.MenuID);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        MenuID = c.Int(nullable: false, identity: true),
                        RestaurantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MenuID)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantID, cascadeDelete: true)
                .Index(t => t.RestaurantID);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false, identity: true),
                        RestaurantName = c.String(nullable: false),
                        Image = c.Binary(),
                        HotLine = c.String(nullable: false, maxLength: 5),
                        Description = c.String(nullable: false),
                        WebSite = c.String(),
                        StartWorkingHours = c.Int(nullable: false),
                        EndWorkingHours = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        MaxDeliveryTime = c.Int(nullable: false),
                        PartenerID = c.Int(nullable: false),
                        AddressID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RestaurantId)
                .ForeignKey("dbo.Addresses", t => t.AddressID, cascadeDelete: true)
                .ForeignKey("dbo.Parteners", t => t.PartenerID, cascadeDelete: true)
                .Index(t => t.PartenerID)
                .Index(t => t.AddressID);
            
            CreateTable(
                "dbo.RestaurantCustomers",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Rate = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => new { t.RestaurantId, t.CustomerId })
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 10),
                        LastName = c.String(nullable: false, maxLength: 10),
                        Username = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Parteners",
                c => new
                    {
                        PartenerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 10),
                        LastName = c.String(nullable: false, maxLength: 10),
                        Username = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Approval = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartenerId);
            
            CreateTable(
                "dbo.RestaurantCusines",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false),
                        CuisineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RestaurantId, t.CuisineId })
                .ForeignKey("dbo.Cuisines", t => t.CuisineId, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId)
                .Index(t => t.CuisineId);
            
            CreateTable(
                "dbo.Cuisines",
                c => new
                    {
                        CuisineID = c.Int(nullable: false, identity: true),
                        CuisineName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CuisineID);
            
            CreateTable(
                "dbo.MealOrders",
                c => new
                    {
                        MealId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MealId, t.OrderId })
                .ForeignKey("dbo.Meals", t => t.MealId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.MealId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        MealId = c.Int(nullable: false, identity: true),
                        Mealname = c.String(nullable: false),
                        MealDescription = c.String(nullable: false),
                        MealPrice = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        Image = c.Binary(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MealId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderTime = c.DateTime(nullable: false),
                        PaymentMethod = c.Int(nullable: false),
                        EstimatedTime = c.DateTime(nullable: false),
                        SubTotal = c.Int(nullable: false),
                        status = c.String(),
                        DeliveryFee = c.Int(nullable: false),
                        RestId = c.Int(nullable: false),
                        Add_Id = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Addresses", t => t.Add_Id, cascadeDelete: false)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.RestId, cascadeDelete: false)
                .Index(t => t.RestId)
                .Index(t => t.Add_Id)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MealOrders", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "RestId", "dbo.Restaurants");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "Add_Id", "dbo.Addresses");
            DropForeignKey("dbo.MealOrders", "MealId", "dbo.Meals");
            DropForeignKey("dbo.Meals", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "MenuID", "dbo.Menus");
            DropForeignKey("dbo.Menus", "RestaurantID", "dbo.Restaurants");
            DropForeignKey("dbo.RestaurantCusines", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.RestaurantCusines", "CuisineId", "dbo.Cuisines");
            DropForeignKey("dbo.Restaurants", "PartenerID", "dbo.Parteners");
            DropForeignKey("dbo.RestaurantCustomers", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.RestaurantCustomers", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Restaurants", "AddressID", "dbo.Addresses");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Orders", new[] { "Add_Id" });
            DropIndex("dbo.Orders", new[] { "RestId" });
            DropIndex("dbo.Meals", new[] { "CategoryId" });
            DropIndex("dbo.MealOrders", new[] { "OrderId" });
            DropIndex("dbo.MealOrders", new[] { "MealId" });
            DropIndex("dbo.RestaurantCusines", new[] { "CuisineId" });
            DropIndex("dbo.RestaurantCusines", new[] { "RestaurantId" });
            DropIndex("dbo.RestaurantCustomers", new[] { "CustomerId" });
            DropIndex("dbo.RestaurantCustomers", new[] { "RestaurantId" });
            DropIndex("dbo.Restaurants", new[] { "AddressID" });
            DropIndex("dbo.Restaurants", new[] { "PartenerID" });
            DropIndex("dbo.Menus", new[] { "RestaurantID" });
            DropIndex("dbo.Categories", new[] { "MenuID" });
            DropTable("dbo.Orders");
            DropTable("dbo.Meals");
            DropTable("dbo.MealOrders");
            DropTable("dbo.Cuisines");
            DropTable("dbo.RestaurantCusines");
            DropTable("dbo.Parteners");
            DropTable("dbo.Customers");
            DropTable("dbo.RestaurantCustomers");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Menus");
            DropTable("dbo.Categories");
            DropTable("dbo.Addresses");
        }
    }
}

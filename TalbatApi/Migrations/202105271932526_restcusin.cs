namespace TalbatApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restcusin : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cuisines", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.Cuisines", new[] { "RestaurantId" });
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
            
            DropColumn("dbo.Cuisines", "RestaurantId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cuisines", "RestaurantId", c => c.Int(nullable: false));
            DropForeignKey("dbo.RestaurantCusines", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.RestaurantCusines", "CuisineId", "dbo.Cuisines");
            DropIndex("dbo.RestaurantCusines", new[] { "CuisineId" });
            DropIndex("dbo.RestaurantCusines", new[] { "RestaurantId" });
            DropTable("dbo.RestaurantCusines");
            CreateIndex("dbo.Cuisines", "RestaurantId");
            AddForeignKey("dbo.Cuisines", "RestaurantId", "dbo.Restaurants", "RestaurantId", cascadeDelete: true);
        }
    }
}

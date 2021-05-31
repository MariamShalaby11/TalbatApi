namespace TalbatApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class two : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Restaurants", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restaurants", "Date", c => c.DateTime(nullable: false));
        }
    }
}

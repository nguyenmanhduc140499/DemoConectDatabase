namespace DemoConectDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Table_Pro_Cate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.String(nullable: false, maxLength: 128),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.String(nullable: false, maxLength: 128),
                        ProductName = c.String(),
                        CategoryID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}

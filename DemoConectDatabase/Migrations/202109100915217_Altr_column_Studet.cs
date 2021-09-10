namespace DemoConectDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Altr_column_Studet : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "StudentName", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "StudentName", c => c.String(unicode: false));
        }
    }
}

namespace DemoConectDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_column_Roles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 10),
                        RoleName = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.RoleID);
            
            AddColumn("dbo.Accounts", "RoleID", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "RoleID");
            DropTable("dbo.Roles");
        }
    }
}

namespace DemoConectDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Table_People_Children : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Peopleinheritances",
                c => new
                    {
                        PeopleID = c.String(nullable: false, maxLength: 128),
                        PeopleName = c.String(),
                        childrenID = c.String(),
                        Age = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PeopleID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Peopleinheritances");
        }
    }
}

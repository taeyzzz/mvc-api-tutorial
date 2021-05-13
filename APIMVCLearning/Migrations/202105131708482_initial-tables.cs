namespace APIMVCLearning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        email = c.String(nullable: false, unicode: false),
                        firstName = c.String(unicode: false),
                        lastName = c.String(unicode: false),
                        telephoneNumber = c.String(unicode: false),
                        birthday = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}

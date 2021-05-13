namespace APIMVCLearning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedescriptionuser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "description", c => c.String(unicode: false));
        }
    }
}

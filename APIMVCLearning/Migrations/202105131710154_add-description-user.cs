namespace APIMVCLearning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddescriptionuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "description", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "description");
        }
    }
}

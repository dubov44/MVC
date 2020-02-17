namespace CustomLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoginDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "Login", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "Login");
        }
    }
}

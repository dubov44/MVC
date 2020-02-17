namespace CustomLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tagsDbRight : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "TagId");
            DropColumn("dbo.Tags", "PostId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "PostId", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "TagId", c => c.Int(nullable: false));
        }
    }
}

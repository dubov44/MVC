namespace CustomLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class questResDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionaryResults",
                c => new
                    {
                        QuestionaryResultId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Sex = c.String(),
                        Languages = c.String(),
                    })
                .PrimaryKey(t => t.QuestionaryResultId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.QuestionaryResults");
        }
    }
}

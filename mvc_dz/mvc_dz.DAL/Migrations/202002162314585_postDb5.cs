namespace CustomLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postDb5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.QuestionaryResults", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.QuestionaryResults", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.QuestionaryResults", "Sex", c => c.String(nullable: false));
            AlterColumn("dbo.QuestionaryResults", "Languages", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.QuestionaryResults", "Languages", c => c.String());
            AlterColumn("dbo.QuestionaryResults", "Sex", c => c.String());
            AlterColumn("dbo.QuestionaryResults", "Surname", c => c.String());
            AlterColumn("dbo.QuestionaryResults", "Name", c => c.String());
        }
    }
}

namespace WePoll.Infrastructure1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVotesAndRespondents : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Votes", "UserId", "dbo.Respondents");
            DropForeignKey("dbo.Respondents", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Respondents", new[] { "QuestionId" });
            DropIndex("dbo.Votes", new[] { "UserId" });
            RenameColumn(table: "dbo.Respondents", name: "QuestionId", newName: "Question_QuestionId");
            AlterColumn("dbo.Respondents", "Question_QuestionId", c => c.Int());
            CreateIndex("dbo.Respondents", "Question_QuestionId");
            AddForeignKey("dbo.Respondents", "Question_QuestionId", "dbo.Questions", "QuestionId");
            DropColumn("dbo.Votes", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Votes", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Respondents", "Question_QuestionId", "dbo.Questions");
            DropIndex("dbo.Respondents", new[] { "Question_QuestionId" });
            AlterColumn("dbo.Respondents", "Question_QuestionId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Respondents", name: "Question_QuestionId", newName: "QuestionId");
            CreateIndex("dbo.Votes", "UserId");
            CreateIndex("dbo.Respondents", "QuestionId");
            AddForeignKey("dbo.Respondents", "QuestionId", "dbo.Questions", "QuestionId", cascadeDelete: true);
            AddForeignKey("dbo.Votes", "UserId", "dbo.Respondents", "UserId", cascadeDelete: true);
        }
    }
}

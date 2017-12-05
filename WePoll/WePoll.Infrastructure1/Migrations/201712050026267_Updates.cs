namespace WePoll.Infrastructure1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Respondents", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Answers", "Poll_PollId", "dbo.Polls");
            DropIndex("dbo.Answers", new[] { "Poll_PollId" });
            DropIndex("dbo.Respondents", new[] { "Question_QuestionId" });
            DropColumn("dbo.Answers", "Poll_PollId");
            DropColumn("dbo.Respondents", "Question_QuestionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Respondents", "Question_QuestionId", c => c.Int());
            AddColumn("dbo.Answers", "Poll_PollId", c => c.Int());
            CreateIndex("dbo.Respondents", "Question_QuestionId");
            CreateIndex("dbo.Answers", "Poll_PollId");
            AddForeignKey("dbo.Answers", "Poll_PollId", "dbo.Polls", "PollId");
            AddForeignKey("dbo.Respondents", "Question_QuestionId", "dbo.Questions", "QuestionId");
        }
    }
}

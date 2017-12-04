namespace WePoll.Infrastructure1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnswers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Polls", "Answer_AnswerId", "dbo.Answers");
            DropForeignKey("dbo.Polls", "Answer_AnswerId1", "dbo.Answers");
            DropIndex("dbo.Polls", new[] { "Answer_AnswerId" });
            DropIndex("dbo.Polls", new[] { "Answer_AnswerId1" });
            DropColumn("dbo.Polls", "Answer_AnswerId");
            DropColumn("dbo.Polls", "Answer_AnswerId1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Polls", "Answer_AnswerId1", c => c.Int());
            AddColumn("dbo.Polls", "Answer_AnswerId", c => c.Int());
            CreateIndex("dbo.Polls", "Answer_AnswerId1");
            CreateIndex("dbo.Polls", "Answer_AnswerId");
            AddForeignKey("dbo.Polls", "Answer_AnswerId1", "dbo.Answers", "AnswerId");
            AddForeignKey("dbo.Polls", "Answer_AnswerId", "dbo.Answers", "AnswerId");
        }
    }
}

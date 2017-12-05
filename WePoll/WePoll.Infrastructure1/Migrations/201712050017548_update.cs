namespace WePoll.Infrastructure1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Polls", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Polls", new[] { "QuestionId" });
            DropColumn("dbo.Polls", "QuestionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Polls", "QuestionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Polls", "QuestionId");
            AddForeignKey("dbo.Polls", "QuestionId", "dbo.Questions", "QuestionId", cascadeDelete: true);
        }
    }
}

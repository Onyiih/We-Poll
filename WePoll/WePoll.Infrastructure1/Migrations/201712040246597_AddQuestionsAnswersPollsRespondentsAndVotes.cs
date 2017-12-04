namespace WePoll.Infrastructure1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuestionsAnswersPollsRespondentsAndVotes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        QuestionId = c.Int(nullable: false),
                        Poll_PollId = c.Int(),
                        Initiator_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.Polls", t => t.Poll_PollId)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Initiators", t => t.Initiator_UserId)
                .Index(t => t.QuestionId)
                .Index(t => t.Poll_PollId)
                .Index(t => t.Initiator_UserId);
            
            CreateTable(
                "dbo.Polls",
                c => new
                    {
                        PollId = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        Answer_AnswerId = c.Int(),
                        Answer_AnswerId1 = c.Int(),
                    })
                .PrimaryKey(t => t.PollId)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Answers", t => t.Answer_AnswerId)
                .ForeignKey("dbo.Answers", t => t.Answer_AnswerId1)
                .Index(t => t.QuestionId)
                .Index(t => t.Answer_AnswerId)
                .Index(t => t.Answer_AnswerId1);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Initiator_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Initiators", t => t.Initiator_UserId)
                .Index(t => t.Initiator_UserId);
            
            CreateTable(
                "dbo.Respondents",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        AnswerId = c.Int(nullable: false),
                        Poll_PollId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Answers", t => t.AnswerId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Polls", t => t.Poll_PollId)
                .Index(t => t.UserId)
                .Index(t => t.QuestionId)
                .Index(t => t.AnswerId)
                .Index(t => t.Poll_PollId);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        VoteId = c.Int(nullable: false, identity: true),
                        DateVoted = c.DateTime(nullable: false),
                        Count = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        AnswerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VoteId)
                .ForeignKey("dbo.Answers", t => t.AnswerId, cascadeDelete: true)
                .ForeignKey("dbo.Respondents", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.AnswerId);
            
            AddColumn("dbo.Users", "Address", c => c.String());
            AddColumn("dbo.Users", "Image", c => c.String());
            DropColumn("dbo.Initiators", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Initiators", "Address", c => c.String());
            DropForeignKey("dbo.Votes", "UserId", "dbo.Respondents");
            DropForeignKey("dbo.Votes", "AnswerId", "dbo.Answers");
            DropForeignKey("dbo.Polls", "Answer_AnswerId1", "dbo.Answers");
            DropForeignKey("dbo.Polls", "Answer_AnswerId", "dbo.Answers");
            DropForeignKey("dbo.Respondents", "Poll_PollId", "dbo.Polls");
            DropForeignKey("dbo.Polls", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Respondents", "UserId", "dbo.Users");
            DropForeignKey("dbo.Questions", "Initiator_UserId", "dbo.Initiators");
            DropForeignKey("dbo.Answers", "Initiator_UserId", "dbo.Initiators");
            DropForeignKey("dbo.Respondents", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Respondents", "AnswerId", "dbo.Answers");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Answers", "Poll_PollId", "dbo.Polls");
            DropIndex("dbo.Votes", new[] { "AnswerId" });
            DropIndex("dbo.Votes", new[] { "UserId" });
            DropIndex("dbo.Respondents", new[] { "Poll_PollId" });
            DropIndex("dbo.Respondents", new[] { "AnswerId" });
            DropIndex("dbo.Respondents", new[] { "QuestionId" });
            DropIndex("dbo.Respondents", new[] { "UserId" });
            DropIndex("dbo.Questions", new[] { "Initiator_UserId" });
            DropIndex("dbo.Polls", new[] { "Answer_AnswerId1" });
            DropIndex("dbo.Polls", new[] { "Answer_AnswerId" });
            DropIndex("dbo.Polls", new[] { "QuestionId" });
            DropIndex("dbo.Answers", new[] { "Initiator_UserId" });
            DropIndex("dbo.Answers", new[] { "Poll_PollId" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropColumn("dbo.Users", "Image");
            DropColumn("dbo.Users", "Address");
            DropTable("dbo.Votes");
            DropTable("dbo.Respondents");
            DropTable("dbo.Questions");
            DropTable("dbo.Polls");
            DropTable("dbo.Answers");
        }
    }
}

namespace WePoll.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedResponses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Responses", "PollID", "dbo.Polls");
            DropIndex("dbo.Responses", new[] { "PollID" });
            DropColumn("dbo.Polls", "Response");
            DropTable("dbo.Responses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Responses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Choice = c.Boolean(nullable: false),
                        RespondentIP = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        PollID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Polls", "Response", c => c.String());
            CreateIndex("dbo.Responses", "PollID");
            AddForeignKey("dbo.Responses", "PollID", "dbo.Polls", "PollId", cascadeDelete: true);
        }
    }
}

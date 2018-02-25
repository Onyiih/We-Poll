namespace WePoll.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Polls",
                c => new
                    {
                        PollId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PollId);
            
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Polls", t => t.PollID, cascadeDelete: true)
                .Index(t => t.PollID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Address = c.String(),
                        Password = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Responses", "PollID", "dbo.Polls");
            DropIndex("dbo.Responses", new[] { "PollID" });
            DropTable("dbo.Users");
            DropTable("dbo.Responses");
            DropTable("dbo.Polls");
        }
    }
}

namespace WePoll.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddResponseTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Votes", "OptionId", "dbo.Options");
            DropForeignKey("dbo.Votes", "RespondentId", "dbo.Respondents");
            DropIndex("dbo.Votes", new[] { "RespondentId" });
            DropIndex("dbo.Votes", new[] { "OptionId" });
            CreateTable(
                "dbo.Responses",
                c => new
                    {
                        ResponseID = c.Int(nullable: false, identity: true),
                        OptionID = c.Int(nullable: false),
                        RespondentID = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ResponseID)
                .ForeignKey("dbo.Options", t => t.OptionID, cascadeDelete: false)
                .ForeignKey("dbo.Respondents", t => t.RespondentID, cascadeDelete: false)
                .Index(t => t.OptionID)
                .Index(t => t.RespondentID);
            
            DropTable("dbo.Votes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        RespondentId = c.Int(nullable: false),
                        OptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RespondentId);
            
            DropForeignKey("dbo.Responses", "RespondentID", "dbo.Respondents");
            DropForeignKey("dbo.Responses", "OptionID", "dbo.Options");
            DropIndex("dbo.Responses", new[] { "RespondentID" });
            DropIndex("dbo.Responses", new[] { "OptionID" });
            DropTable("dbo.Responses");
            CreateIndex("dbo.Votes", "OptionId");
            CreateIndex("dbo.Votes", "RespondentId");
            AddForeignKey("dbo.Votes", "RespondentId", "dbo.Respondents", "RespondentId");
            AddForeignKey("dbo.Votes", "OptionId", "dbo.Options", "OptionId", cascadeDelete: true);
        }
    }
}

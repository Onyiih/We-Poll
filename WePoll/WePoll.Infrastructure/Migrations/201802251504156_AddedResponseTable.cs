namespace WePoll.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedResponseTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Responses",
                c => new
                    {
                        ResponseId = c.Int(nullable: false, identity: true),
                        Option = c.String(),
                        Count = c.Int(nullable: false),
                        PollId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResponseId)
                .ForeignKey("dbo.Polls", t => t.PollId, cascadeDelete: true)
                .Index(t => t.PollId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Responses", "PollId", "dbo.Polls");
            DropIndex("dbo.Responses", new[] { "PollId" });
            DropTable("dbo.Responses");
        }
    }
}

namespace WePoll.Infrastructure1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "Initiator_UserId", "dbo.Initiators");
            DropForeignKey("dbo.Initiators", "UserId", "dbo.Users");
            DropForeignKey("dbo.Respondents", "UserId", "dbo.Users");
            DropForeignKey("dbo.Votes", "AnswerId", "dbo.Answers");
            DropForeignKey("dbo.Questions", "Initiator_UserId", "dbo.Initiators");
            DropIndex("dbo.Answers", new[] { "Initiator_UserId" });
            DropIndex("dbo.Respondents", new[] { "UserId" });
            DropIndex("dbo.Initiators", new[] { "UserId" });
            DropIndex("dbo.Votes", new[] { "AnswerId" });
            RenameColumn(table: "dbo.Questions", name: "Initiator_UserId", newName: "Initiator_InitiatorId");
            RenameIndex(table: "dbo.Questions", name: "IX_Initiator_UserId", newName: "IX_Initiator_InitiatorId");
            DropPrimaryKey("dbo.Respondents");
            DropPrimaryKey("dbo.Initiators");
            AddColumn("dbo.Respondents", "RespondentId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Respondents", "FirstName", c => c.String());
            AddColumn("dbo.Respondents", "LastName", c => c.String());
            AddColumn("dbo.Respondents", "Email", c => c.String());
            AddColumn("dbo.Respondents", "PhoneNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Respondents", "Address", c => c.String());
            AddColumn("dbo.Respondents", "Password", c => c.String());
            AddColumn("dbo.Respondents", "Image", c => c.String());
            AddColumn("dbo.Initiators", "InitiatorId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Initiators", "FirstName", c => c.String());
            AddColumn("dbo.Initiators", "LastName", c => c.String());
            AddColumn("dbo.Initiators", "Email", c => c.String());
            AddColumn("dbo.Initiators", "PhoneNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Initiators", "Address", c => c.String());
            AddColumn("dbo.Initiators", "Password", c => c.String());
            AddColumn("dbo.Initiators", "Image", c => c.String());
            AddColumn("dbo.Polls", "ResponseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Polls", "Count", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Respondents", "RespondentId");
            AddPrimaryKey("dbo.Initiators", "InitiatorId");
            AddForeignKey("dbo.Questions", "Initiator_InitiatorId", "dbo.Initiators", "InitiatorId");
            DropColumn("dbo.Answers", "Initiator_UserId");
            DropColumn("dbo.Respondents", "UserId");
            DropColumn("dbo.Initiators", "UserId");
            DropTable("dbo.Users");
            DropTable("dbo.Votes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        VoteId = c.Int(nullable: false, identity: true),
                        DateVoted = c.DateTime(nullable: false),
                        Count = c.Int(nullable: false),
                        AnswerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VoteId);
            
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
            
            AddColumn("dbo.Initiators", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Respondents", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Answers", "Initiator_UserId", c => c.Int());
            DropForeignKey("dbo.Questions", "Initiator_InitiatorId", "dbo.Initiators");
            DropPrimaryKey("dbo.Initiators");
            DropPrimaryKey("dbo.Respondents");
            DropColumn("dbo.Polls", "Count");
            DropColumn("dbo.Polls", "ResponseDate");
            DropColumn("dbo.Initiators", "Image");
            DropColumn("dbo.Initiators", "Password");
            DropColumn("dbo.Initiators", "Address");
            DropColumn("dbo.Initiators", "PhoneNumber");
            DropColumn("dbo.Initiators", "Email");
            DropColumn("dbo.Initiators", "LastName");
            DropColumn("dbo.Initiators", "FirstName");
            DropColumn("dbo.Initiators", "InitiatorId");
            DropColumn("dbo.Respondents", "Image");
            DropColumn("dbo.Respondents", "Password");
            DropColumn("dbo.Respondents", "Address");
            DropColumn("dbo.Respondents", "PhoneNumber");
            DropColumn("dbo.Respondents", "Email");
            DropColumn("dbo.Respondents", "LastName");
            DropColumn("dbo.Respondents", "FirstName");
            DropColumn("dbo.Respondents", "RespondentId");
            AddPrimaryKey("dbo.Initiators", "UserId");
            AddPrimaryKey("dbo.Respondents", "UserId");
            RenameIndex(table: "dbo.Questions", name: "IX_Initiator_InitiatorId", newName: "IX_Initiator_UserId");
            RenameColumn(table: "dbo.Questions", name: "Initiator_InitiatorId", newName: "Initiator_UserId");
            CreateIndex("dbo.Votes", "AnswerId");
            CreateIndex("dbo.Initiators", "UserId");
            CreateIndex("dbo.Respondents", "UserId");
            CreateIndex("dbo.Answers", "Initiator_UserId");
            AddForeignKey("dbo.Questions", "Initiator_UserId", "dbo.Initiators", "UserId");
            AddForeignKey("dbo.Votes", "AnswerId", "dbo.Answers", "AnswerId", cascadeDelete: true);
            AddForeignKey("dbo.Respondents", "UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.Initiators", "UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.Answers", "Initiator_UserId", "dbo.Initiators", "UserId");
        }
    }
}

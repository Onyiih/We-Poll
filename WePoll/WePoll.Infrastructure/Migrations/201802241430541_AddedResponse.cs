namespace WePoll.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedResponse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Polls", "Response", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Polls", "Response");
        }
    }
}

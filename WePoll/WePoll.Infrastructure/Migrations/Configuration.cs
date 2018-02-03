namespace WePoll.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<WePoll.Infrastructure.Entities.DataEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Entities.DataEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (!context.Polls.Any())
            {
                context.Polls.AddOrUpdate(p => p.PollId, new Entities.Poll
                {
                    Text = "Private beach for Christmas party!",
                    DateCreated = DateTime.Today
                },
                new Entities.Poll
                {
                    Text = "We should have a Reunion.",
                    DateCreated = DateTime.Today
                },
                new Entities.Poll
                {
                    Text = "Lets have a Football competion!",
                    DateCreated = DateTime.Today
                },
                new Entities.Poll
                {
                    Text = "I think we should build and fornish a Computer Lab with 100 computers in our former Department!",
                    DateCreated = DateTime.Today
                });
            }
        }
    }
}

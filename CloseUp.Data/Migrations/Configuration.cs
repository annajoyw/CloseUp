namespace CloseUp.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CloseUp.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CloseUp.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Prompts.AddOrUpdate(x => x.PromptId,
                new PromptItem() { PromptId = 1, Prompt = "What do you wish more people knew about you?" },
                new PromptItem() { PromptId = 2, Prompt = "Write what you need to hear." },
                new PromptItem() { PromptId = 3, Prompt = "What brings you comfort?" },
                new PromptItem() { PromptId = 4, Prompt = "How are you? Really" }
                );
        }
    }
}

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
            ContextKey = "CloseUp.Data.ApplicationDbContext";
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

            context.PromptItems.AddOrUpdate(
                p => p.PromptId,
                new PromptItem() { PromptId = 1, Prompt = "What is the dominate emotion in your life right now?", Category = "" },
                new PromptItem() { PromptId = 2, Prompt = "What brings you comfort?", Category = "" },
                new PromptItem() { PromptId = 3, Prompt = "Write what you need to hear.", Category = "" },
                new PromptItem() { PromptId = 4, Prompt = "What does unconditional love mean to you?", Category = "" },
                new PromptItem() { PromptId = 5, Prompt = "What would you do if you knew you could not fail?", Category = "" },
                new PromptItem() { PromptId = 6, Prompt = "What is something you wish others knew about you?", Category = "" },
                new PromptItem() { PromptId = 7, Prompt = "What changes do you need to make to have the life you want?", Category = "" }
                );

            context.HelpResources.AddOrUpdate(
                p => p.ResourceId,
                new HelpResource() { ResourceId = 1, ResourceInfo = "What is Mindfulness? Heres a quick read to get a better idea of how Mindfulness and Meditation work.", URL = "https://www.mindful.org/what-is-mindfulness/", Tag = Tag.Mindfulness },
                new HelpResource() { ResourceId = 2, ResourceInfo = "Check out this site to read about the lates news invloving LGBT+ Community!", URL = "https://www.mindful.org/what-is-mindfulness/", Tag = Tag.LGBT },
                new HelpResource() { ResourceId = 3, ResourceInfo = "If you're feeling overwhelmed, it might be worth checking out the Trevor Project. This site is loaded with support.", URL = "https://www.thetrevorproject.org/", Tag = Tag.LGBT },
                new HelpResource() { ResourceId = 4, ResourceInfo = "Black Lives Matter official website", URL = "https://blacklivesmatter.com/", Tag = Tag.BLM },
                new HelpResource() { ResourceId = 5, ResourceInfo = "Black Lives Matter 2020 impact report", URL = "https://blacklivesmatter.com/2020-impact-report/", Tag = Tag.BLM },
                new HelpResource() { ResourceId = 6, ResourceInfo = "You can search for an anxiety/depression support group near you through ADAA's support group listing.", URL = "https://adaa.org/supportgroups", Tag = Tag.AnxietyAndDepression },
                new HelpResource() { ResourceId = 7, ResourceInfo = "Search here for a therapist licensed to help with anxiety, depression, OCD, PTSD, and related disorders", URL = "https://members.adaa.org/page/FATMain", Tag = Tag.AnxietyAndDepression },
                new HelpResource() { ResourceId = 8, ResourceInfo = "10 habits worth adopting into your life!", URL = "https://health.clevelandclinic.org/11-simple-health-habits-worth-adopting-into-your-life/", Tag = Tag.HealthAndWellness },
                new HelpResource() { ResourceId = 9, ResourceInfo = "Wondering if you have ADHD? This page offers a deeper look into adult ADHD", URL = "https://www.nimh.nih.gov/health/publications/could-i-have-adhd/index.shtml?utm_source=NIMHwebsite&utm_medium=Portal&utm_campaign=shareNIMH", Tag = Tag.AdhdAndAutism },
                new HelpResource() { ResourceId = 10, ResourceInfo = "Resources and Information regarding Autism Spectrum Disorder", URL = "https://medlineplus.gov/autismspectrumdisorder.html", Tag = Tag.AdhdAndAutism},
                new HelpResource() { ResourceId = 11, ResourceInfo = "SAMHSA’s National Helpline is a free, confidential, 24/7, 365-day-a-year treatment referral and information service for individuals facing mental and/or substance use disorders.", URL = "https://www.samhsa.gov/find-help/national-helpline", Tag = Tag.SubstanceAbuse}
                );
            
        }
    }
}

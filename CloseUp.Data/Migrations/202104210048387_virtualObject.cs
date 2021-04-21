namespace CloseUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class virtualObject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JournalEntry", "Prompt", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JournalEntry", "Prompt");
        }
    }
}

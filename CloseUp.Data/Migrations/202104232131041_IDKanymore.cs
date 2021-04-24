namespace CloseUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDKanymore : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HelpResource", "Tag", c => c.Int(nullable: false));
            AddColumn("dbo.JournalEntry", "Tag", c => c.Int(nullable: false));
            DropColumn("dbo.HelpResource", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HelpResource", "Category", c => c.String(nullable: false));
            DropColumn("dbo.JournalEntry", "Tag");
            DropColumn("dbo.HelpResource", "Tag");
        }
    }
}

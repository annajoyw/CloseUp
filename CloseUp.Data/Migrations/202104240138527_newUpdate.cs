namespace CloseUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JournalEntry", "Prompt", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JournalEntry", "Prompt", c => c.String(nullable: false));
        }
    }
}

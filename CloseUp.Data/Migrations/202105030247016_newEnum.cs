namespace CloseUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newEnum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JournalEntry", "PublicOrPrivate", c => c.Int(nullable: false));
            DropColumn("dbo.JournalEntry", "IsPublic");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JournalEntry", "IsPublic", c => c.Boolean(nullable: false));
            DropColumn("dbo.JournalEntry", "PublicOrPrivate");
        }
    }
}

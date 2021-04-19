namespace CloseUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PromptItem", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PromptItem", "Category");
        }
    }
}

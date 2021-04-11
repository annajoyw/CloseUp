namespace CloseUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lol : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PromptItem", "PromptItem_PromptId", "dbo.PromptItem");
            DropIndex("dbo.PromptItem", new[] { "PromptItem_PromptId" });
            DropColumn("dbo.PromptItem", "PromptItem_PromptId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PromptItem", "PromptItem_PromptId", c => c.Int());
            CreateIndex("dbo.PromptItem", "PromptItem_PromptId");
            AddForeignKey("dbo.PromptItem", "PromptItem_PromptId", "dbo.PromptItem", "PromptId");
        }
    }
}

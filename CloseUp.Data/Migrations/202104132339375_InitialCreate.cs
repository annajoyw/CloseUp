namespace CloseUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HelpResource",
                c => new
                    {
                        ResourceId = c.Int(nullable: false, identity: true),
                        Category = c.String(nullable: false),
                        ResourceInfo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ResourceId);
            
            CreateTable(
                "dbo.JournalEntry",
                c => new
                    {
                        JournalEntryId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        Content = c.String(nullable: false),
                        PhotoUrl = c.String(),
                        IsPublic = c.Boolean(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        PromptId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JournalEntryId)
                .ForeignKey("dbo.PromptItem", t => t.PromptId, cascadeDelete: true)
                .Index(t => t.PromptId);
            
            CreateTable(
                "dbo.PromptItem",
                c => new
                    {
                        PromptId = c.Int(nullable: false, identity: true),
                        Prompt = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PromptId);
            
            CreateTable(
                "dbo.Reply",
                c => new
                    {
                        ReplyId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        Comment = c.String(nullable: false),
                        JournalEntryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReplyId)
                .ForeignKey("dbo.JournalEntry", t => t.JournalEntryId, cascadeDelete: true)
                .Index(t => t.JournalEntryId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Reply", "JournalEntryId", "dbo.JournalEntry");
            DropForeignKey("dbo.JournalEntry", "PromptId", "dbo.PromptItem");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Reply", new[] { "JournalEntryId" });
            DropIndex("dbo.JournalEntry", new[] { "PromptId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Reply");
            DropTable("dbo.PromptItem");
            DropTable("dbo.JournalEntry");
            DropTable("dbo.HelpResource");
        }
    }
}

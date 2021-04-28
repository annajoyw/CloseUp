namespace CloseUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class url : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HelpResource", "URL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HelpResource", "URL");
        }
    }
}

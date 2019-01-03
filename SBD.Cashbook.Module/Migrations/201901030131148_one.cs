namespace SBD.Cashbook.Module.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GLAccounts", "Code", c => c.String(maxLength: 60));
            CreateIndex("dbo.GLAccounts", "Code", unique: true);
            DropColumn("dbo.GLAccounts", "ShortName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GLAccounts", "ShortName", c => c.String(maxLength: 450));
            DropIndex("dbo.GLAccounts", new[] { "Code" });
            DropColumn("dbo.GLAccounts", "Code");
        }
    }
}

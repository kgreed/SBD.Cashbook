namespace SBD.Cashbook.Module.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 450),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GLAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.Int(nullable: false),
                        ShortName = c.String(maxLength: 450),
                        Notes = c.String(),
                        OpeningBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ParentAccount_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GLAccounts", t => t.ParentAccount_Id)
                .Index(t => t.ParentAccount_Id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 450),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModelDifferenceAspects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Xml = c.String(),
                        Owner_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ModelDifferences", t => t.Owner_ID)
                .Index(t => t.Owner_ID);
            
            CreateTable(
                "dbo.ModelDifferences",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ContextId = c.String(),
                        Version = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ModuleInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Version = c.String(),
                        AssemblyFileName = c.String(),
                        IsMain = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PermissionPolicyRoleBases",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsAdministrative = c.Boolean(nullable: false),
                        CanEditModel = c.Boolean(nullable: false),
                        PermissionPolicy = c.Int(nullable: false),
                        IsAllowPermissionPriority = c.Boolean(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PermissionPolicyNavigationPermissionObjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ItemPath = c.String(),
                        TargetTypeFullName = c.String(),
                        NavigateState = c.Int(),
                        Role_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PermissionPolicyRoleBases", t => t.Role_ID)
                .Index(t => t.Role_ID);
            
            CreateTable(
                "dbo.PermissionPolicyTypePermissionObjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TargetTypeFullName = c.String(),
                        ReadState = c.Int(),
                        WriteState = c.Int(),
                        CreateState = c.Int(),
                        DeleteState = c.Int(),
                        NavigateState = c.Int(),
                        Role_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PermissionPolicyRoleBases", t => t.Role_ID)
                .Index(t => t.Role_ID);
            
            CreateTable(
                "dbo.PermissionPolicyMemberPermissionsObjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Members = c.String(),
                        Criteria = c.String(),
                        ReadState = c.Int(),
                        WriteState = c.Int(),
                        TypePermissionObject_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PermissionPolicyTypePermissionObjects", t => t.TypePermissionObject_ID)
                .Index(t => t.TypePermissionObject_ID);
            
            CreateTable(
                "dbo.PermissionPolicyObjectPermissionsObjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Criteria = c.String(),
                        ReadState = c.Int(),
                        WriteState = c.Int(),
                        DeleteState = c.Int(),
                        NavigateState = c.Int(),
                        TypePermissionObject_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PermissionPolicyTypePermissionObjects", t => t.TypePermissionObject_ID)
                .Index(t => t.TypePermissionObject_ID);
            
            CreateTable(
                "dbo.PermissionPolicyUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        ChangePasswordOnFirstLogon = c.Boolean(nullable: false),
                        StoredPassword = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DebitAccount_Id = c.Int(nullable: false),
                        CreditAccount_Id = c.Int(nullable: false),
                        BankId = c.String(maxLength: 20),
                        Memo = c.String(),
                        Card_Id = c.Int(),
                        job_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.Card_Id)
                .ForeignKey("dbo.GLAccounts", t => t.CreditAccount_Id)
                .ForeignKey("dbo.GLAccounts", t => t.DebitAccount_Id)
                .ForeignKey("dbo.Jobs", t => t.job_Id)
                .Index(t => t.DebitAccount_Id)
                .Index(t => t.CreditAccount_Id)
                .Index(t => t.BankId, unique: true)
                .Index(t => t.Card_Id)
                .Index(t => t.job_Id);
            
            CreateTable(
                "dbo.PermissionPolicyUserPermissionPolicyRoles",
                c => new
                    {
                        PermissionPolicyUser_ID = c.Int(nullable: false),
                        PermissionPolicyRole_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PermissionPolicyUser_ID, t.PermissionPolicyRole_ID })
                .ForeignKey("dbo.PermissionPolicyUsers", t => t.PermissionPolicyUser_ID)
                .ForeignKey("dbo.PermissionPolicyRoleBases", t => t.PermissionPolicyRole_ID)
                .Index(t => t.PermissionPolicyUser_ID)
                .Index(t => t.PermissionPolicyRole_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "job_Id", "dbo.Jobs");
            DropForeignKey("dbo.Transactions", "DebitAccount_Id", "dbo.GLAccounts");
            DropForeignKey("dbo.Transactions", "CreditAccount_Id", "dbo.GLAccounts");
            DropForeignKey("dbo.Transactions", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.PermissionPolicyUserPermissionPolicyRoles", "PermissionPolicyRole_ID", "dbo.PermissionPolicyRoleBases");
            DropForeignKey("dbo.PermissionPolicyUserPermissionPolicyRoles", "PermissionPolicyUser_ID", "dbo.PermissionPolicyUsers");
            DropForeignKey("dbo.PermissionPolicyTypePermissionObjects", "Role_ID", "dbo.PermissionPolicyRoleBases");
            DropForeignKey("dbo.PermissionPolicyObjectPermissionsObjects", "TypePermissionObject_ID", "dbo.PermissionPolicyTypePermissionObjects");
            DropForeignKey("dbo.PermissionPolicyMemberPermissionsObjects", "TypePermissionObject_ID", "dbo.PermissionPolicyTypePermissionObjects");
            DropForeignKey("dbo.PermissionPolicyNavigationPermissionObjects", "Role_ID", "dbo.PermissionPolicyRoleBases");
            DropForeignKey("dbo.ModelDifferenceAspects", "Owner_ID", "dbo.ModelDifferences");
            DropForeignKey("dbo.GLAccounts", "ParentAccount_Id", "dbo.GLAccounts");
            DropIndex("dbo.PermissionPolicyUserPermissionPolicyRoles", new[] { "PermissionPolicyRole_ID" });
            DropIndex("dbo.PermissionPolicyUserPermissionPolicyRoles", new[] { "PermissionPolicyUser_ID" });
            DropIndex("dbo.Transactions", new[] { "job_Id" });
            DropIndex("dbo.Transactions", new[] { "Card_Id" });
            DropIndex("dbo.Transactions", new[] { "BankId" });
            DropIndex("dbo.Transactions", new[] { "CreditAccount_Id" });
            DropIndex("dbo.Transactions", new[] { "DebitAccount_Id" });
            DropIndex("dbo.PermissionPolicyObjectPermissionsObjects", new[] { "TypePermissionObject_ID" });
            DropIndex("dbo.PermissionPolicyMemberPermissionsObjects", new[] { "TypePermissionObject_ID" });
            DropIndex("dbo.PermissionPolicyTypePermissionObjects", new[] { "Role_ID" });
            DropIndex("dbo.PermissionPolicyNavigationPermissionObjects", new[] { "Role_ID" });
            DropIndex("dbo.ModelDifferenceAspects", new[] { "Owner_ID" });
            DropIndex("dbo.GLAccounts", new[] { "ParentAccount_Id" });
            DropTable("dbo.PermissionPolicyUserPermissionPolicyRoles");
            DropTable("dbo.Transactions");
            DropTable("dbo.PermissionPolicyUsers");
            DropTable("dbo.PermissionPolicyObjectPermissionsObjects");
            DropTable("dbo.PermissionPolicyMemberPermissionsObjects");
            DropTable("dbo.PermissionPolicyTypePermissionObjects");
            DropTable("dbo.PermissionPolicyNavigationPermissionObjects");
            DropTable("dbo.PermissionPolicyRoleBases");
            DropTable("dbo.ModuleInfoes");
            DropTable("dbo.ModelDifferences");
            DropTable("dbo.ModelDifferenceAspects");
            DropTable("dbo.Jobs");
            DropTable("dbo.GLAccounts");
            DropTable("dbo.Cards");
        }
    }
}

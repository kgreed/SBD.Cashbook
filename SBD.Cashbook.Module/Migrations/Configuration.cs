namespace SBD.Cashbook.Module.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SBD.Cashbook.Module.BusinessObjects.CashbookDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SBD.Cashbook.Module.BusinessObjects.CashbookDbContext";
        }

        protected override void Seed(SBD.Cashbook.Module.BusinessObjects.CashbookDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}

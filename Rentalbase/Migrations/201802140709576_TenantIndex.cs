namespace Rentalbase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TenantIndex : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Invoice", "PropertyID");
            AddForeignKey("dbo.Invoice", "PropertyID", "dbo.Property", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoice", "PropertyID", "dbo.Property");
            DropIndex("dbo.Invoice", new[] { "PropertyID" });
        }
    }
}

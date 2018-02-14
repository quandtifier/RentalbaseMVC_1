namespace Rentalbase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TenantAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tenant", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Tenant", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Tenant", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tenant", "Email", c => c.String());
            AlterColumn("dbo.Tenant", "Phone", c => c.String());
            AlterColumn("dbo.Tenant", "Name", c => c.String());
        }
    }
}

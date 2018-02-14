namespace Rentalbase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PropertyID = c.Int(nullable: false),
                        DateIssued = c.DateTime(nullable: false),
                        DatePaid = c.DateTime(nullable: false),
                        Description = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceType_Type = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InvoiceType", t => t.InvoiceType_Type)
                .Index(t => t.InvoiceType_Type);
            
            CreateTable(
                "dbo.InvoiceType",
                c => new
                    {
                        Type = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Type);
            
            CreateTable(
                "dbo.Landlord",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Property",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LandlordID = c.Int(nullable: false),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        Description = c.String(),
                        PropertyType_Type = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Landlord", t => t.LandlordID)
                .ForeignKey("dbo.PropertyType", t => t.PropertyType_Type)
                .Index(t => t.LandlordID)
                .Index(t => t.PropertyType_Type);
            
            CreateTable(
                "dbo.Lease",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PropertyID = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        RateMonthly = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Property", t => t.PropertyID)
                .Index(t => t.PropertyID);
            
            CreateTable(
                "dbo.Tenant",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PropertyID = c.Int(),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Property", t => t.PropertyID)
                .Index(t => t.PropertyID);
            
            CreateTable(
                "dbo.PropertyType",
                c => new
                    {
                        Type = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Type);
            
            CreateTable(
                "dbo.LeaseInstructor",
                c => new
                    {
                        LeaseID = c.Int(nullable: false),
                        TenantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LeaseID, t.TenantID })
                .ForeignKey("dbo.Lease", t => t.LeaseID, cascadeDelete: true)
                .ForeignKey("dbo.Tenant", t => t.TenantID, cascadeDelete: true)
                .Index(t => t.LeaseID)
                .Index(t => t.TenantID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Property", "PropertyType_Type", "dbo.PropertyType");
            DropForeignKey("dbo.LeaseInstructor", "TenantID", "dbo.Tenant");
            DropForeignKey("dbo.LeaseInstructor", "LeaseID", "dbo.Lease");
            DropForeignKey("dbo.Tenant", "PropertyID", "dbo.Property");
            DropForeignKey("dbo.Lease", "PropertyID", "dbo.Property");
            DropForeignKey("dbo.Property", "LandlordID", "dbo.Landlord");
            DropForeignKey("dbo.Invoice", "InvoiceType_Type", "dbo.InvoiceType");
            DropIndex("dbo.LeaseInstructor", new[] { "TenantID" });
            DropIndex("dbo.LeaseInstructor", new[] { "LeaseID" });
            DropIndex("dbo.Tenant", new[] { "PropertyID" });
            DropIndex("dbo.Lease", new[] { "PropertyID" });
            DropIndex("dbo.Property", new[] { "PropertyType_Type" });
            DropIndex("dbo.Property", new[] { "LandlordID" });
            DropIndex("dbo.Invoice", new[] { "InvoiceType_Type" });
            DropTable("dbo.LeaseInstructor");
            DropTable("dbo.PropertyType");
            DropTable("dbo.Tenant");
            DropTable("dbo.Lease");
            DropTable("dbo.Property");
            DropTable("dbo.Landlord");
            DropTable("dbo.InvoiceType");
            DropTable("dbo.Invoice");
        }
    }
}

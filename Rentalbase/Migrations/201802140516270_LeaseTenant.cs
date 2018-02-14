namespace Rentalbase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LeaseTenant : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.LeaseInstructor", newName: "LeaseTenant");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.LeaseTenant", newName: "LeaseInstructor");
        }
    }
}

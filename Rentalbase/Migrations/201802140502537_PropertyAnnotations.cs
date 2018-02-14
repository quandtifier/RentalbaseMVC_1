namespace Rentalbase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Property", "Street", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Property", "City", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Property", "State", c => c.String(nullable: false, maxLength: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Property", "State", c => c.String());
            AlterColumn("dbo.Property", "City", c => c.String());
            AlterColumn("dbo.Property", "Street", c => c.String());
        }
    }
}

namespace odh_foundation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contacttab : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact", "cdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Contact", "status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contact", "status");
            DropColumn("dbo.Contact", "cdate");
        }
    }
}

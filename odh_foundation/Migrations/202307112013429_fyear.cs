namespace odh_foundation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fyear : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donar", "financialyear", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Donar", "financialyear");
        }
    }
}

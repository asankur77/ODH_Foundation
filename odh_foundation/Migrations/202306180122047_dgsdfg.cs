namespace odh_foundation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dgsdfg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donar", "DonarId", c => c.String());
            AddColumn("dbo.Volunteer", "VolunteerId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Volunteer", "VolunteerId");
            DropColumn("dbo.Donar", "DonarId");
        }
    }
}

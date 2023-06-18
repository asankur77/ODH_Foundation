namespace odh_foundation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kolj : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Volunteer", "RegistrationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Volunteer", "RegistrationDate");
        }
    }
}

namespace odh_foundation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Volunteer", "FName", c => c.String());
            AddColumn("dbo.Volunteer", "Opid", c => c.String());
            AddColumn("dbo.Volunteer", "DOB", c => c.DateTime(nullable: false));
            AddColumn("dbo.Volunteer", "AadharFront", c => c.String());
            AddColumn("dbo.Volunteer", "AadharBack", c => c.String());
            AddColumn("dbo.Volunteer", "ProfilePic", c => c.String());
            AddColumn("dbo.Volunteer", "Photonew", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Volunteer", "Photonew");
            DropColumn("dbo.Volunteer", "ProfilePic");
            DropColumn("dbo.Volunteer", "AadharBack");
            DropColumn("dbo.Volunteer", "AadharFront");
            DropColumn("dbo.Volunteer", "DOB");
            DropColumn("dbo.Volunteer", "Opid");
            DropColumn("dbo.Volunteer", "FName");
        }
    }
}

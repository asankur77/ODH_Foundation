namespace odh_foundation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaaaa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Volunteer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Mobile = c.String(),
                        WhatsupNumber = c.String(),
                        Address = c.String(),
                        Profession = c.String(),
                        VolunteerDuration = c.String(),
                        VolunteerPurpose = c.String(),
                        VolunteerAbility = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Volunteer");
        }
    }
}

namespace odh_foundation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Donar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupportType = c.String(),
                        DonateAmount = c.Double(nullable: false),
                        Name = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        Country = c.String(),
                        State = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        Pincode = c.String(),
                        PAN = c.String(),
                        DonationDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Donar");
        }
    }
}

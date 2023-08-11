namespace odh_foundation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subscriber : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subscriber",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        emailid = c.String(),
                        cdate = c.DateTime(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subscriber");
        }
    }
}

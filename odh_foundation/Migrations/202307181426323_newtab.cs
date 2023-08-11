namespace odh_foundation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtab : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PressRelease",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Heading = c.String(),
                        Summary = c.String(),
                        Image = c.String(),
                        Cdate = c.DateTime(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeamTab",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Heading = c.String(),
                        Summary = c.String(),
                        Image = c.String(),
                        Cdate = c.DateTime(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TeamTab");
            DropTable("dbo.PressRelease");
        }
    }
}

namespace odh_foundation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class headtab : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HeadTab",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        head = c.String(),
                        branchcode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HeadTab");
        }
    }
}

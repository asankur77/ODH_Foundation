namespace odh_foundation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fromattabnew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IdFormatTab",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FinancialYear = c.String(),
                        VolunteerIdFormat = c.String(),
                        DonarIdFormat = c.String(),
                        TxnidFormat = c.String(),
                        date = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.IdFormatTab");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.IdFormatTab",
                c => new
                    {
                    Id = c.Int(nullable: false, identity: true),
                    FinancialYear = c.String(),
                    VolunteerIdFormat = c.String(),
                    DonarIdFormat = c.String(),
                    TxnidFormat = c.String(),
                    date = c.DateTime(nullable: false),
                    Status = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.IdFormatTab");
        }
    }
}

namespace odh_foundation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class financialyeartab : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FinancialYearTab",
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FinancialYearTab");
        }
    }
}

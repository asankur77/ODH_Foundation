namespace odh_foundation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hjk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donar", "PaymentTransactionId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Donar", "PaymentTransactionId");
        }
    }
}

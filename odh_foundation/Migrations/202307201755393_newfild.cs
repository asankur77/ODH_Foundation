namespace odh_foundation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newfild : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donar", "PaymentMode", c => c.String());
            AddColumn("dbo.Donar", "PaymentState", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Donar", "PaymentState");
            DropColumn("dbo.Donar", "PaymentMode");
        }
    }
}

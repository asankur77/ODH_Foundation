namespace odh_foundation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class title : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donar", "title", c => c.String());
            AddColumn("dbo.Donar", "amountinwords", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Donar", "amountinwords");
            DropColumn("dbo.Donar", "title");
        }
    }
}

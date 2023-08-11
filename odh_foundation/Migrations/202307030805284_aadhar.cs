namespace odh_foundation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aadhar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donar", "aadharno", c => c.String());
            AddColumn("dbo.Donar", "otherno", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Donar", "otherno");
            DropColumn("dbo.Donar", "aadharno");
        }
    }
}

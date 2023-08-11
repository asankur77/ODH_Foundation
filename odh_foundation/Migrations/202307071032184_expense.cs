namespace odh_foundation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class expense : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expense", "paymethod", c => c.String());
            AddColumn("dbo.Expense", "bank", c => c.String());
            AddColumn("dbo.Expense", "Account", c => c.String());
            AddColumn("dbo.Expense", "chequeno", c => c.String());
            AddColumn("dbo.Expense", "ACholdername", c => c.String());
            AddColumn("dbo.Expense", "Branch", c => c.String());
            AddColumn("dbo.Expense", "IFSCCode", c => c.String());
            AddColumn("dbo.Expense", "ChequeAmount", c => c.String());
            AddColumn("dbo.Expense", "Chequedate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Expense", "Chequeimage", c => c.String());
            AddColumn("dbo.Expense", "transactiontype", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Expense", "transactiontype");
            DropColumn("dbo.Expense", "Chequeimage");
            DropColumn("dbo.Expense", "Chequedate");
            DropColumn("dbo.Expense", "ChequeAmount");
            DropColumn("dbo.Expense", "IFSCCode");
            DropColumn("dbo.Expense", "Branch");
            DropColumn("dbo.Expense", "ACholdername");
            DropColumn("dbo.Expense", "chequeno");
            DropColumn("dbo.Expense", "Account");
            DropColumn("dbo.Expense", "bank");
            DropColumn("dbo.Expense", "paymethod");
        }
    }
}

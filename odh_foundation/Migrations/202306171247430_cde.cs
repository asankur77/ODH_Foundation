namespace odh_foundation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cde : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WordLinePaymentResponse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TxnStatus = c.String(),
                        TxnMessage = c.String(),
                        TxnErrorMessage = c.String(),
                        ClntTxnRef = c.String(),
                        TPSLBankCd = c.String(),
                        MerchantTxnId = c.String(),
                        TxnAmt = c.String(),
                        ClntRequestMeta = c.String(),
                        MerchantTxnTime = c.String(),
                        BalanceAmt = c.String(),
                        CardId = c.String(),
                        AliasName = c.String(),
                        BankTransactionId = c.String(),
                        MandateRegNo = c.String(),
                        Token = c.String(),
                        Hash = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WordLinePaymentResponse");
        }
    }
}

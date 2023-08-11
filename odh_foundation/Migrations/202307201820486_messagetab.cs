namespace odh_foundation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messagetab : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MessageTemplateTab",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TemplateID = c.String(),
                        DltID = c.String(),
                        TemplateTitle = c.String(),
                        TemplateMessage = c.String(),
                        MessageType = c.String(),
                        MessageLanguage = c.String(),
                        cdate = c.DateTime(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MessageTemplateTab");
        }
    }
}

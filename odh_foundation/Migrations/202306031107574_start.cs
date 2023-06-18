namespace odh_foundation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankDetail_Tab",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        accountype = c.String(),
                        accountno = c.String(),
                        bankname = c.String(),
                        branchname = c.String(),
                        ifsccode = c.String(),
                        companyname = c.String(),
                        panno1 = c.String(),
                        panno2 = c.String(),
                        Authorisedsignatory1 = c.String(),
                        Authorisedsignatory2 = c.String(),
                        contact1 = c.String(),
                        contact2 = c.String(),
                        acopendate = c.DateTime(nullable: false),
                        branchaddress = c.String(),
                        opid = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CityStateTab",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        state = c.String(),
                        city = c.String(),
                        citycode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanyInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompanyLogo = c.String(),
                        Companysrtcut = c.String(),
                        HeadOffice = c.String(),
                        AdminId = c.String(),
                        SubAdminId = c.String(),
                        Password = c.String(),
                        RegistrationNo = c.String(),
                        Contact = c.String(),
                        Emailid = c.String(),
                        Address = c.String(),
                        IncomeType = c.String(),
                        State = c.String(),
                        Zipcode = c.String(),
                        DirectorName = c.String(),
                        SubAdminPassword = c.String(),
                        RegDate = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        emailid = c.String(),
                        mobile = c.String(),
                        subject = c.String(),
                        message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DepartmentTab",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeptName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DesignationTab",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Expense",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        head = c.String(),
                        Remark = c.String(),
                        amount = c.Double(nullable: false),
                        date_time = c.DateTime(nullable: false),
                        branchcode = c.String(),
                        opid = c.String(),
                        type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gallery",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        image = c.String(),
                        status = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ICardTab",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        agentid = c.Int(nullable: false),
                        name = c.String(),
                        rankname = c.String(),
                        intid = c.String(),
                        intname = c.String(),
                        intrankname = c.String(),
                        address = c.String(),
                        city = c.String(),
                        dob = c.String(),
                        mobno = c.String(),
                        issuedate = c.DateTime(nullable: false),
                        validupto = c.DateTime(nullable: false),
                        companylogo = c.String(),
                        photo = c.String(),
                        logo = c.Byte(nullable: false),
                        image = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InOutTime",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        login = c.String(),
                        logout = c.String(),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MacTab",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        userid = c.String(),
                        macaddress = c.String(),
                        type = c.String(),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Member_tab",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fee = c.Double(nullable: false),
                        MemberName = c.String(),
                        NewMemberId = c.String(),
                        MemberId = c.Int(nullable: false),
                        BranchCode = c.String(),
                        Address = c.String(),
                        District = c.String(),
                        Pin = c.String(),
                        state = c.String(),
                        Gender = c.String(),
                        Mobile = c.String(),
                        Nationality = c.String(),
                        Share = c.Int(nullable: false),
                        Mother = c.String(),
                        Father = c.String(),
                        Relationof = c.String(),
                        age = c.String(),
                        Type = c.String(),
                        Status = c.Int(nullable: false),
                        Cdate = c.DateTime(nullable: false),
                        Opid = c.String(),
                        DOB = c.DateTime(nullable: false),
                        NomineeName = c.String(),
                        NomineeAge = c.String(),
                        NomineeRel = c.String(),
                        Nomineeaddr = c.String(),
                        panno = c.String(),
                        bankname = c.String(),
                        accountno = c.String(),
                        IFSC = c.String(),
                        prefix = c.String(),
                        suffix = c.Int(nullable: false),
                        Id_img = c.String(),
                        Sign_img = c.String(),
                        photo = c.String(),
                        Email = c.String(),
                        Photonew = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NewLogin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Mobile = c.String(),
                        type = c.String(),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Operator",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OperatorName = c.String(),
                        OperatorId = c.String(),
                        BranchCode = c.String(),
                        OperatorPassword = c.String(),
                        OperatorMobile = c.String(),
                        OperatorAddress = c.String(),
                        Type = c.String(),
                        Status = c.Int(nullable: false),
                        Cdate = c.DateTime(nullable: false),
                        Operator_Mail = c.String(),
                        companyid = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StateTab",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        state = c.String(),
                        statecode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StateTab");
            DropTable("dbo.Operator");
            DropTable("dbo.NewLogin");
            DropTable("dbo.Member_tab");
            DropTable("dbo.MacTab");
            DropTable("dbo.InOutTime");
            DropTable("dbo.ICardTab");
            DropTable("dbo.Gallery");
            DropTable("dbo.Expense");
            DropTable("dbo.DesignationTab");
            DropTable("dbo.DepartmentTab");
            DropTable("dbo.Contact");
            DropTable("dbo.CompanyInfo");
            DropTable("dbo.CityStateTab");
            DropTable("dbo.BankDetail_Tab");
        }
    }
}

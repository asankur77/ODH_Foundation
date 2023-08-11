using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;


namespace odh_foundation.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<HeadTab> HeadTabs { get; set; }
        public DbSet<BankDetail_Tab> BankDetail_Tabs { get; set; }
        public DbSet<StateTab> StateTabs { get; set; }
        public DbSet<CityStateTab> CityStateTabs { get; set; }
        public DbSet<CompanyInfo> CompanyInfos { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Subscriber> Subscriber { get; set; } 
        public DbSet<DepartmentTab> DepartmentTabs { get; set; }
        public DbSet<DesignationTab> DesignationTabs { get; set; }        
        public DbSet<Expense> Expenses { get; set; }        
        public DbSet<ICardTab> ICardTabs { get; set; }
        public DbSet<InOutTime> InOutTimes { get; set; }
       
        public DbSet<MacTab> MacTabs { get; set; }    
        public DbSet<Member_tab> Member_tabs { get; set; }
        public DbSet<NewLogin> NewLogins { get; set; }
       
        public DbSet<Operator> Operators { get; set; }
       
        public DbSet<Gallery> Gallerys { get; set; }
       
        public DbSet<Donar> Donars { get; set; }

        public DbSet<WordLinePaymentResponse> WordLinePaymentResponses { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
       
        public DbSet<IdFormatTab> IdFormatTabs { get; set; }
        public DbSet<FinancialYearTab> FinancialYearTabs { get; set; }
        public DbSet<TeamTab> TeamTabs { get; set; }
        public DbSet<PressRelease> PressReleases { get; set; }
        public DbSet<MessageTemplateTab> MessageTemplateTabs { get; set; }
    }

    [Table("MessageTemplateTab")]
    public class MessageTemplateTab
    {
        [Key]
        public int id { get; set; }
        public string TemplateID { get; set; }
        public string DltID { get; set; }
        public string TemplateTitle { get; set; }
        public string TemplateMessage { get; set; }
        public string MessageType { get; set; }
        public string MessageLanguage { get; set; }
        public DateTime cdate { get; set; }
        public int status { get; set; }
    }

    [Table("TeamTab")]
    public class TeamTab
    {
        [Key]
        public int Id { get; set; }
        public string Heading { get; set; }
        public string Summary { get; set; }
        public string Image { get; set; }
        [DataType(DataType.Date)]
        public DateTime Cdate { get; set; }
        public int status { get; set; }
    }
    [Table("PressRelease")]
    public class PressRelease
    {
        [Key]
        public int Id { get; set; }
        public string Heading { get; set; }
        public string Summary { get; set; }
        public string Image { get; set; }
        [DataType(DataType.Date)]
        public DateTime Cdate { get; set; }
        public int status { get; set; }
    }

    [Table("Volunteer")]
    public class Volunteer
    {
        [Key]
        public int Id { get; set; }
        public string VolunteerId { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string Opid { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string WhatsupNumber { get; set; }
        public string Address { get; set; }
        public string Profession { get; set; }
        public string VolunteerDuration { get; set; }
        public string VolunteerPurpose { get; set; }
        public string VolunteerAbility { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int Status { get; set; }
        public string AadharFront { get; set; }

        public string AadharBack { get; set; }
        public string ProfilePic { get; set; }
       
        public byte[] Photonew { get; set; }
    }

    [Table("WordLinePaymentResponse")]
    public class WordLinePaymentResponse
    {
        [Key]
        public int Id { get; set; }
        public string TxnStatus { get; set; }
        public string TxnMessage { get; set; }
        public string TxnErrorMessage { get; set; }
        public string ClntTxnRef { get; set; }
        public string TPSLBankCd { get; set; }
        public string MerchantTxnId { get; set; }
        public string TxnAmt { get; set; }
        public string ClntRequestMeta { get; set; }
        public string MerchantTxnTime { get; set; }
        public string BalanceAmt { get; set; }
        public string CardId { get; set; }
        public string AliasName { get; set; }
        public string BankTransactionId { get; set; }
        public string MandateRegNo { get; set; }
        public string Token { get; set; }
        public string Hash { get; set; }
    }


    [Table("Donar")]
    public class Donar
    {
        [Key]
        public int Id { get; set; }
        public string DonarId { get; set; }
        public string SupportType { get; set; }
        public double DonateAmount { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string PAN { get; set; }
        public string aadharno { get; set; }
        public string otherno { get; set; }
        public DateTime DonationDate { get; set; }
        public string PaymentTransactionId { get; set; }
        public int Status { get; set; }
        public string title { get; set; }
        public string amountinwords { get; set; }
        public string financialyear { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentState { get; set; }
        //////////////PayMethodAdd//////////////
        //public string paymethod { get; set; }
        //public string bank { get; set; }
        //public string Account { get; set; }
        //public string chequeno { get; set; }
        //public string ACholdername { get; set; }
        //public string Branch { get; set; }
        //public string IFSCCode { get; set; }
        //public string ChequeAmount { get; set; }
        //[DataType(DataType.Date)]
        //public DateTime Chequedate { get; set; }
        //public string Chequeimage { get; set; }
        //public string transactiontype { get; set; }
    }

    [Table("HeadTab")]
    public class HeadTab
    {
        [Key]
        public int Id { get; set; }
        public string head { get; set; }
        public string branchcode { get; set; }
    }
    [Table("IdFormatTab")]
    public class IdFormatTab
    {
        [Key]
        public int Id { get; set; }
        public string FinancialYear { get; set; }
        public string VolunteerIdFormat { get; set; }
        public string DonarIdFormat { get; set; }
        public string TxnidFormat { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public int Status { get; set; }

    }



    [Table("FinancialYearTab")]
    public class FinancialYearTab
    {
        [Key]
        public int Id { get; set; }
        public string FinancialYear { get; set; }
        public string VolunteerIdFormat { get; set; }
        public string DonarIdFormat { get; set; }
        public string TxnidFormat { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public int Status { get; set; }

    }
    [Table("Gallery")]
    public class Gallery
    {
        [Key]
        public int Id { get; set; }
        public string image { get; set; }
        public int status { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
    }

    [Table("Operator")]
    public class Operator
    {
        [Key]
        public int Id { get; set; }
        public string OperatorName { get; set; }
        public string OperatorId { get; set; }
        public string BranchCode { get; set; }
        public string OperatorPassword { get; set; }
        public string OperatorMobile { get; set; }
        public string OperatorAddress { get; set; }
        public string Type { get; set; }
        public int Status { get; set; }
        [DataType(DataType.Date)]
        public DateTime Cdate { get; set; }
        public string Operator_Mail { get; set; }
        public string companyid { get; set; }

    }

    [Table("NewLogin")]
    public class NewLogin
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "User name")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string type { get; set; }
        public int status { get; set; }

    }
    [Table("MacTab")]
    public class MacTab
    {
        [Key]
        public int Id { get; set; }
        public string userid { get; set; }
        public string macaddress { get; set; }
        public string type { get; set; }
        public int status { get; set; }
    }

    [Table("CompanyInfo")]
    public class CompanyInfo
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public string Companysrtcut { get; set; }
        public string HeadOffice { get; set; }
        public string AdminId { get; set; }
        public string SubAdminId { get; set; }
        public string Password { get; set; }
        public string RegistrationNo { get; set; }
        public string Contact { get; set; }
        public string Emailid { get; set; }
        public string Address { get; set; }
        public string IncomeType { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string DirectorName { get; set; }

        public string SubAdminPassword { get; set; }
        [DataType(DataType.Date)]
        public DateTime RegDate { get; set; }
        public string Status { get; set; }

    }

    [Table("Contact")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string emailid { get; set; }
        public string mobile { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        [DataType(DataType.Date)]
        public DateTime cdate { get; set; }
        public int status { get; set; }

    }
    [Table("Subscriber")]
    public class Subscriber
    {
        [Key]
        public int Id { get; set; }
        public string emailid { get; set; }
        [DataType(DataType.Date)]
        public DateTime cdate { get; set; }
        public int status { get; set; }

    }

    [Table("DepartmentTab")]
    public class DepartmentTab
    {
        [Key]
        public int Id { get; set; }
        public string DeptName { get; set; }
    }

    [Table("DesignationTab")]
    public class DesignationTab
    {
        [Key]
        public int Id { get; set; }
        public string Designation { get; set; }
    }


    [Table("Member_tab")]
    public class Member_tab
    {
        [Key]
        public int Id { get; set; }
        public double Fee { get; set; }
        public string MemberName { get; set; }
        public string NewMemberId { get; set; }
        public int MemberId { get; set; }
        public string BranchCode { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string Pin { get; set; }
        public string state { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string Nationality { get; set; }
        public int Share { get; set; }
        public string Mother { get; set; }
        public string Father { get; set; }
        public string Relationof { get; set; }
        public string age { get; set; }
        public string Type { get; set; }
        public int Status { get; set; }
        [DataType(DataType.Date)]
        public DateTime Cdate { get; set; }
        public string Opid { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string NomineeName { get; set; }
        public string NomineeAge { get; set; }
        public string NomineeRel { get; set; }
        public string Nomineeaddr { get; set; }

        public string panno { get; set; }
        public string bankname { get; set; }
        public string accountno { get; set; }
        public string IFSC { get; set; }

        public string prefix { get; set; }
        public int suffix { get; set; }
        public string Id_img { get; set; }

        public string Sign_img { get; set; }
        public string photo { get; set; }
        public string Email { get; set; }
        public byte[] Photonew { get; set; }


    }
    [Table("ICardTab")]
    public class ICardTab
    {
        [Key]
        public int Id { get; set; }
        public int agentid { get; set; }
        public string name { get; set; }
        public string rankname { get; set; }
        public string intid { get; set; }
        public string intname { get; set; }
        public string intrankname { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string dob { get; set; }
        public string mobno { get; set; }
        [DataType(DataType.Date)]
        public DateTime issuedate { get; set; }
        [DataType(DataType.Date)]
        public DateTime validupto { get; set; }
        public string companylogo { get; set; }
        public string photo { get; set; }
        public Byte logo { get; set; }
        public Byte image { get; set; }

    }

    [Table("InOutTime")]
    public class InOutTime
    {
        [Key]
        public int Id { get; set; }
        public string login { get; set; }
        public string logout { get; set; }
        public int status { get; set; }

    }





    [Table("BankDetail_Tab")]
    public class BankDetail_Tab
    {
        [Key]
        public int Id { get; set; }
        public string accountype { get; set; }
        public string accountno { get; set; }
        public string bankname { get; set; }
        public string branchname { get; set; }
        public string ifsccode { get; set; }
        public string companyname { get; set; }
        public string panno1 { get; set; }
        public string panno2 { get; set; }
        public string Authorisedsignatory1 { get; set; }
        public string Authorisedsignatory2 { get; set; }
        public string contact1 { get; set; }
        public string contact2 { get; set; }
        public DateTime acopendate { get; set; }
        public string branchaddress { get; set; }
        public string opid { get; set; }
    }

    [Table("Expense")]
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        public string head { get; set; }
        public string Remark { get; set; }
        public Double amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime date_time { get; set; }
        public string branchcode { get; set; }
        public string opid { get; set; }
        public int type { get; set; }
        //-------Paymethod
        public string paymethod { get; set; }
        public string bank { get; set; }
        public string Account { get; set; }
        public string chequeno { get; set; }
        public string ACholdername { get; set; }
        public string Branch { get; set; }
        public string IFSCCode { get; set; }
        public string ChequeAmount { get; set; }
        [DataType(DataType.Date)]
        public DateTime Chequedate { get; set; }
        public string Chequeimage { get; set; }
        public string transactiontype { get; set; }
    }
    [Table("StateTab")]
    public class StateTab
    {
        [Key]
        public int Id { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
    }

    [Table("CityStateTab")]
    public class CityStateTab
    {
        [Key]
        public int Id { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string citycode { get; set; }
    }


}
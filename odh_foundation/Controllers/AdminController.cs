using odh_foundation.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Globalization;
using System.Data.Entity;
using CrystalDecisions.CrystalReports.Engine;

namespace odh_foundation.Controllers
{
    public class AdminController : Controller
    {
       

        SqlConnection con = new SqlConnection();
        UsersContext db = new UsersContext();
        public static DateTime ab = DateTime.Now, b = DateTime.Now;
        public static DateTime stdate = DateTime.Now.Date, enddate = DateTime.Now.Date;
        public static string shead= string.Empty;
        string gid()
        {

            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {

                i *= ((int)b + 1);
            }


            if (i < 0)
            {
                i = -i;
            }
            string s = i.ToString();
            return s.Substring(0, 10);


        }

        public bool IsLoggedIn()
        {

            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    int count = (from n in db.NewLogins where n.UserName == User.Identity.Name select n.UserName).Count();
                    if (count == 1)
                    {
                        var log = db.NewLogins.Single(a => a.UserName == User.Identity.Name);
                        if (log.status == 1 && log.type == "Admin")
                        {
                            GetLogged.logId = log.UserName;
                            GetLogged.logType = log.type;
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
        public JsonResult selectmessage(string templateid)
        {
            List<MessageTemplateTab> ct = new List<MessageTemplateTab>();
            ct = (from dcl in db.MessageTemplateTabs where dcl.TemplateID == templateid select dcl).ToList(); ;
            return Json(ct, JsonRequestBehavior.AllowGet);

        }
        public JsonResult AutoCompleteDonorID(string term)
        {
            var donorlist = db.Donars.ToList();
            var list = (from r in donorlist where r.PaymentTransactionId.ToLower().Contains(term.ToLower()) || r.Name.ToLower().Contains(term.ToLower()) select new { r.PaymentTransactionId, r.Name }).Distinct();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult AllReport()
        {
            return View();
        }
       
        [HttpGet]
        public ActionResult upload_video()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UpdateMenu()
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {

                return View();
            }
        }
       
        [HttpGet]
        public ActionResult FinancialYearUpdate()
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {

                return View();
            }
        }
       
        [HttpPost]
        public ActionResult FinancialYearUpdate(FinancialYearTab ob,int i=1)
        {
            if (User.Identity.IsAuthenticated)
            {

                    FinancialYearTab r = db.FinancialYearTabs.Single(c => c.Id == i);
                    r.FinancialYear = ob.FinancialYear;
                    r.VolunteerIdFormat = ob.VolunteerIdFormat;
                    r.DonarIdFormat = ob.DonarIdFormat;
                    r.TxnidFormat = ob.TxnidFormat;
                    r.Status = 1;
                    r.date = DateTime.Now.Date;
                    db.Entry(r).State = EntityState.Modified;
                    db.SaveChanges();

                    ViewBag.message = "Financial Year Updated Successfully.";
                    return View();
                
            }
            return RedirectToAction("Logout");
        }
        
        [HttpGet]
        public ActionResult BulkSms()
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult BulkSms(string chk1, string chk2, string message, string msgtype)
        {
            if (ModelState.IsValid)
            {

                var count = message.Count();
                if (chk1 == null && chk2 == null)
                {
                    ViewBag.msg = "Please select any checkbox...";
                }



                if (msgtype == "English")
                {

                    if (chk1 == null && chk2 != null)
                    {
                        var list = (from dbc in db.Volunteers select dbc).Distinct();
                        System.Text.StringBuilder aa = new System.Text.StringBuilder();
                        foreach (var item in list.ToList())
                        {
                            aa.Append(item.Mobile + ", ");
                        }
                        string bb = aa.ToString();
                        MyClass.Sendmsg(bb, message);
                        ViewBag.msg = "Message sent successfully to all Volunteers.";
                    }

                    if (chk1 != null && chk2 == null)
                    {

                        var list = (from dbc in db.Donars select dbc).ToList();
                        System.Text.StringBuilder aa = new System.Text.StringBuilder();
                        foreach (var item in list.ToList())
                        {
                            aa.Append(item.Phone + ", ");
                        }
                        string bb = aa.ToString();
                        MyClass.Sendmsg(bb, message);


                        ViewBag.msg = "Message sent successfully to All Donars.";
                    }

                }
               
            }
            return View();
        }
        [HttpGet]
        public ActionResult AddHead()
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {
                int count = (from n in db.NewLogins where n.UserName == User.Identity.Name select n.UserName).Count();
                if (count == 1)
                {
                    var log = db.NewLogins.Single(a => a.UserName == User.Identity.Name);
                    if (log.status == 1 && log.type == "Admin")
                    {

                        var head = db.HeadTabs.ToList();

                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Logout", "Admin");
                    }
                }
                else
                {
                    return RedirectToAction("Logout", "Admin");
                }
            }

        }
        [HttpPost]
        public ActionResult AddHead(HeadTab ob)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {

                var Duplicate = (from o in db.HeadTabs where o.head == ob.head select o).ToList();
                if (Duplicate.Count > 0)
                {
                    Response.Write("<script>alert('This Head Already exist ')</script>");
                }

                else
                {
                    HeadTab hob = new HeadTab();
                    
                        hob.head = ob.head;
                       
                        db.HeadTabs.Add(hob);
                        db.SaveChanges();
                   
                    Response.Write("<script>alert('Head Added successfully ')</script>");

                }
                var head = db.HeadTabs.ToList();

                return View();
            }
        }
        [HttpGet]
        public ActionResult PrintSection()
        {

            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {
                return View();

            }
        }
        [HttpGet]
        public ActionResult PrintCertificate()
        {

            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {
                return View();

            }
        }
       [HttpPost]
        public ActionResult PrintCertificate(string PaymentTransactionId)
        {
            List<Donar> donarlist = new List<Donar>();
            donarlist = (from o in db.Donars where o.PaymentTransactionId == PaymentTransactionId select o).ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/CReport"), "Income Certificate.rpt"));
            rd.SetDataSource(donarlist);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);

                return new FileStreamResult(stream, "application/pdf");
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            finally
            {
                rd.Close();
                rd.Dispose();
            }
            return View();
        }
        [HttpGet]
        public ActionResult Print80GReciept()
        {

            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {
                return View();

            }
        }
        [HttpPost]
        public ActionResult Print80GReciept(string PaymentTransactionId)
        {
            List<Donar> donarlist = new List<Donar>();
            donarlist = (from o in db.Donars where o.PaymentTransactionId == PaymentTransactionId select o).ToList();
            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/CReport"), "incoice.rpt"));
            rd.SetDataSource(donarlist);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);

                return new FileStreamResult(stream, "application/pdf");
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            finally
            {
                rd.Close();
                rd.Dispose();
            }
            return View();
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {

            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {
                return View();

            }
        }
        [HttpPost]
        public ActionResult ChangePassword(string Password, string NewPassword, string ConfirmPassword)
        {

            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {
                if (NewPassword == ConfirmPassword)
                {

                    con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "changepassword";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@user", User.Identity.Name);
                    cmd.Parameters.AddWithValue("@oldpass", Password);
                    cmd.Parameters.AddWithValue("@newpass", NewPassword);

                    SqlParameter p = new SqlParameter("@ans", SqlDbType.Int);
                    p.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(p);
                    try
                    {

                        con.Open();
                        cmd.ExecuteNonQuery();


                        string response1 = cmd.Parameters["@ans"].Value.ToString();
                        int a = Convert.ToInt32(response1);

                        if (a == 0)
                        {
                            ViewBag.msg = "Sorry,Old Password Not matching";

                        }
                        else if (a == 1)
                        {
                            ViewBag.msg = "Password Changed successfully";

                        }
                    }

                    catch (SqlException e)
                    {
                        ViewBag.msg = e.Message;

                    }
                    finally
                    {
                        con.Close();
                    }
                }
                else
                {
                    ViewBag.msg = "Password not matching";
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult AddExpense()
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {
                int count = (from n in db.NewLogins where n.UserName == User.Identity.Name select n.UserName).Count();
                if (count == 1)
                {
                    var log = db.NewLogins.Single(a => a.UserName == User.Identity.Name);
                    if (log.status == 1 && log.type == "Admin")
                    {

                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Logout", "Admin");
                    }
                }
                else
                {
                    return RedirectToAction("Logout", "Admin");
                }
            }
        }
        
        [HttpPost]
        public ActionResult AddExpense(Expense ep, string head, string remarks, string trbank, string transactionid, string transactiondate, string tramount, string trpmethod, string holderacno, string ddno, HttpPostedFileBase Chequeimage, DateTime date, Double amount = 0, Double DDamount = 0, int type = 0)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {
                Expense ob = new Expense();
                ob.head = head;
                ob.Remark = remarks;
                ob.amount = amount;
                ob.date_time = date;
                ob.branchcode = User.Identity.Name;
                ob.opid = User.Identity.Name;
                ob.type = type;
                ob.paymethod = ep.paymethod;
                if (ob.paymethod == "Cheque")
                {
                    ob.bank = ep.bank;
                    ob.Account = ep.Account;
                    ob.chequeno = ep.chequeno;
                    ob.ACholdername = ep.ACholdername;
                    ob.Branch = ep.Branch;
                    ob.IFSCCode = ep.IFSCCode;
                    ob.ChequeAmount = ep.ChequeAmount;
                    ob.Chequedate = ep.Chequedate;
                    ob.transactiontype = "NA";

                    if (Chequeimage != null)
                    {
                        string img = gid();
                        ob.Chequeimage = "~/Photo/" + img + ".jpg";
                        Chequeimage.SaveAs(HttpContext.Server.MapPath("~/Photo/" + img + ".jpg"));
                    }
                    else
                    {
                        ob.Chequeimage = "~/Photo/default.jpg";

                    }
                }
                else if (ob.paymethod == "banktransaction")
                {
                    ob.bank = trbank;
                    ob.Account = holderacno;
                    ob.chequeno = transactionid;
                    ob.ACholdername = "NA";
                    ob.Branch = "NA";
                    ob.IFSCCode = "NA";
                    ob.ChequeAmount = tramount;
                    ob.Chequedate = Convert.ToDateTime(transactiondate);
                    ob.Chequeimage = "~/Photo/default.jpg";
                    ob.transactiontype = ep.transactiontype;
                }
                else if (ob.paymethod == "DD")
                {
                    ob.bank = "NA";
                    ob.Account = "NA";
                    ob.chequeno = ddno;
                    ob.ACholdername = "NA";
                    ob.Branch = "NA";
                    ob.IFSCCode = "NA";
                    ob.ChequeAmount = DDamount.ToString();
                    ob.Chequedate = DateTime.Now.Date;
                    ob.Chequeimage = "~/Photo/default.jpg";
                    ob.transactiontype = "NA";
                }
                else if (ob.paymethod == "Cash")
                {
                    ob.bank = "NA";
                    ob.Account = "NA";
                    ob.chequeno = "NA";
                    ob.ACholdername = "NA";
                    ob.Branch = "NA";
                    ob.IFSCCode = "NA";
                    ob.ChequeAmount = amount.ToString();
                    ob.Chequedate = DateTime.Now.Date;
                    ob.Chequeimage = "~/Photo/default.jpg";
                    ob.transactiontype = "NA";
                }

                db.Expenses.Add(ob);
                db.SaveChanges();
                Response.Write("<script>alert('Expense added Successfully')</script>");
            }
            return View();
        }

        [HttpGet]
        public ActionResult DailyExpense()
        {
            List<Expense> ins = new List<Expense>();

            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {
                int count = (from n in db.NewLogins where n.UserName == User.Identity.Name select n.UserName).Count();
                if (count == 1)
                {
                    var log = db.NewLogins.Single(a => a.UserName == User.Identity.Name);
                    if (log.status == 1 && log.type == "Admin")
                    {

                        return View(ins);
                    }
                    else
                    {
                        return RedirectToAction("Logout", "Admin");
                    }
                }
                else
                {
                    return RedirectToAction("Logout", "Admin");
                }
            }

        }
        [HttpPost]
        public ActionResult DailyExpense(DateTime sdate, DateTime edate, string command)
        {
            List<Expense> ins = new List<Expense>();
            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {
                ins = (from dcl in db.Expenses where dcl.date_time >= sdate && dcl.date_time <= edate && dcl.type == 0 select dcl).ToList();
                ab = sdate;
                b = edate;
            }
            return View(ins);

        }
        [HttpGet]
        public ActionResult HeadWiseExpense()
        {
            List<HeadwiseExpense> ins = new List<HeadwiseExpense>();

            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {
                int count = (from n in db.NewLogins where n.UserName == User.Identity.Name select n.UserName).Count();
                if (count == 1)
                {
                    var log = db.NewLogins.Single(a => a.UserName == User.Identity.Name);
                    if (log.status == 1 && log.type == "Admin")
                    {

                        return View(ins);
                    }
                    else
                    {
                        return RedirectToAction("Logout", "Admin");
                    }
                }
                else
                {
                    return RedirectToAction("Logout", "Admin");
                }
            }

        }
        [HttpPost]
        public ActionResult HeadWiseExpense(DateTime sdate, DateTime edate, string head)
        {
            List<HeadwiseExpense> ins = new List<HeadwiseExpense>();
            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {
                var cr = db.CompanyInfos.Single(c => c.Id == 1);
                var headrow = (from dcl in db.Expenses where dcl.date_time >= sdate && dcl.date_time <= edate && dcl.head == head && dcl.type == 0 select dcl).ToList();
                foreach (var h in headrow)
                {
                    ins.Add(new HeadwiseExpense { head = head, date = h.date_time, remark = h.Remark, amount = h.amount, sdate = sdate, edate = edate, companyname = cr.CompanyName, branchname = User.Identity.Name });
                }
                shead = head;
                ab = sdate;
                b = edate;
            }
            return View(ins);

        }
        [HttpGet]
        public ActionResult TenBDReport()
        {

            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {
                int count = (from n in db.NewLogins where n.UserName == User.Identity.Name select n.UserName).Count();
                if (count == 1)
                {
                    var log = db.NewLogins.Single(a => a.UserName == User.Identity.Name);
                    if (log.status == 1 && log.type == "Admin")
                    {
                        List<Donar> donarlist = new List<Donar>();
                        return View(donarlist);
                    }
                    else
                    {
                        return RedirectToAction("Logout", "Admin");
                    }
                }
                else
                {
                    return RedirectToAction("Logout", "Admin");
                }
            }


        }
        [HttpPost]
        public ActionResult TenBDReport(DateTime sdate, DateTime edate)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {

                List<Donar> donarlist = new List<Donar>();
                //donarlist = (from o in db.Donars where o.DonationDate >= sdate && o.DonationDate.Date <= edate orderby o.DonationDate select o).ToList();
                donarlist = db.Donars.Where(c => DbFunctions.TruncateTime(c.DonationDate) >= sdate.Date && DbFunctions.TruncateTime(c.DonationDate) <= edate).OrderBy(c => c.DonationDate).ToList();

                enddate = edate;
                stdate = sdate;
                return View(donarlist);
            }
        }
        [HttpGet]
        public ActionResult DonationList()
        {

            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {
                int count = (from n in db.NewLogins where n.UserName == User.Identity.Name select n.UserName).Count();
                if (count == 1)
                {
                    var log = db.NewLogins.Single(a => a.UserName == User.Identity.Name);
                    if (log.status == 1 && log.type == "Admin")
                    {
                        List<Donar> donarlist = new List<Donar>();
                        return View(donarlist);
                    }
                    else
                    {
                        return RedirectToAction("Logout", "Admin");
                    }
                }
                else
                {
                    return RedirectToAction("Logout", "Admin");
                }
            }


        }
        [HttpPost]
        public ActionResult DonationList(DateTime sdate, DateTime edate)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {

                List<Donar> donarlist = new List<Donar>();
                //donarlist = (from o in db.Donars where o.DonationDate >= sdate && o.DonationDate.Date <= edate orderby o.DonationDate select o).ToList();
                donarlist = db.Donars.Where(c => DbFunctions.TruncateTime(c.DonationDate) >= sdate.Date && DbFunctions.TruncateTime(c.DonationDate) <= edate).OrderBy(c => c.DonationDate).ToList();

                enddate = edate;
                stdate = sdate;
                return View(donarlist);
            }
        }
        [HttpGet]
        public ActionResult VolunteerList()
        {

            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {
                int count = (from n in db.NewLogins where n.UserName == User.Identity.Name select n.UserName).Count();
                if (count == 1)
                {
                    var log = db.NewLogins.Single(a => a.UserName == User.Identity.Name);
                    if (log.status == 1 && log.type == "Admin")
                    {
                        List<Volunteer> volunteerlist = new List<Volunteer>();
                        return View(volunteerlist);
                    }
                    else
                    {
                        return RedirectToAction("Logout", "Admin");
                    }
                }
                else
                {
                    return RedirectToAction("Logout", "Admin");
                }
            }


        }
        [HttpPost]
        public ActionResult VolunteerList(DateTime sdate, DateTime edate)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {

                List<Volunteer> VolunteerList = new List<Volunteer>();
                //VolunteerList = (from o in db.Volunteers where o.RegistrationDate <= edate && o.RegistrationDate >= sdate orderby o.RegistrationDate select o).ToList();
                VolunteerList = db.Volunteers.Where(c => DbFunctions.TruncateTime(c.RegistrationDate) >= sdate.Date && DbFunctions.TruncateTime(c.RegistrationDate) <= edate).OrderBy(c => c.RegistrationDate).ToList();

                enddate = edate;
                stdate = sdate;
                return View(VolunteerList);
            }
        }
        public ActionResult Enquiry_list()
        {
            return View();
        }
        public ActionResult SubscriberList()
        {
            return View();
        }
        public ActionResult ExpenseMenu()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddVolunteer()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult AddDonor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDonor(FormCollection fc, string trbank, string transactionid, string transactiondate, string tramount, string trpmethod, string holderacno, string ddno, HttpPostedFileBase Chequeimage, DateTime date, Double amount = 0, Double DDamount = 0, int type = 0)
        {
            var cr = db.FinancialYearTabs.Single(ci => ci.Id == 1);
            string amountinwords = "( " + MyClass.ConvertAmount(Convert.ToDouble(fc["DonateAmount"])) + " )";
            int status = 0;
            try
            {

                if (!db.Donars.Any(a => a.PaymentTransactionId == Convert.ToString(fc["PaymentTransactionId"])))
                {
                    var donar = new Donar();
                    donar.Address = Convert.ToString(fc["Address"]) + "," + Convert.ToString(fc["City"]) + "," + Convert.ToString(fc["State"]) + "," + Convert.ToString(fc["Country"]) + "-" + Convert.ToString(fc["Pincode"]);
                    donar.City = Convert.ToString(fc["City"]);
                    donar.Country = Convert.ToString(fc["Country"]);
                    donar.DOB = Convert.ToDateTime(fc["DOB"]);
                    donar.DonateAmount = !String.IsNullOrEmpty(Convert.ToString(fc["DonateAmount"])) ? Convert.ToInt32(fc["DonateAmount"]) : 0;
                    donar.DonationDate = DateTime.Now;
                    donar.Email = Convert.ToString(fc["Email"]);
                    donar.Name = Convert.ToString(fc["Name"]);
                    donar.PAN = Convert.ToString(fc["PAN"]);
                    donar.aadharno = Convert.ToString(fc["aadharno"]);
                    donar.otherno = Convert.ToString(fc["otherno"]);
                    donar.title = Convert.ToString(fc["title"]);
                    donar.amountinwords = amountinwords;
                    donar.Phone = Convert.ToString(fc["Phone"]);
                    donar.Pincode = Convert.ToString(fc["Pincode"]);
                    donar.State = Convert.ToString(fc["State"]);
                    donar.SupportType = Convert.ToString(fc["SupportType"]);
                    donar.Status = 0;
                    donar.PaymentTransactionId = Convert.ToString(fc["PaymentTransactionId"]);
                    donar.DonarId = Convert.ToString(fc["custID"]);
                    donar.financialyear = cr.FinancialYear;
                    donar.PaymentMode = Convert.ToString(fc["PaymentMode"]);
                    donar.PaymentState = "Online";
                    //donar.paymethod = Convert.ToString(fc["paymethod"]);
                    //if (donar.paymethod == "Cheque")
                    //{
                    //    donar.bank = Convert.ToString(fc["bank"]);
                    //    donar.Account = Convert.ToString(fc["Account"]);
                    //    donar.chequeno = Convert.ToString(fc["chequeno"]);
                    //    donar.ACholdername = Convert.ToString(fc["ACholdername"]);
                    //    donar.Branch = Convert.ToString(fc["Branch"]);
                    //    donar.IFSCCode = Convert.ToString(fc["IFSCCode"]);
                    //    donar.ChequeAmount = Convert.ToString(fc["ChequeAmount"]);
                    //    donar.Chequedate = Convert.ToDateTime(fc["Chequedate"]);
                    //    donar.transactiontype = "NA";

                    //    if (Chequeimage != null)
                    //    {
                    //        string img = gid();
                    //        donar.Chequeimage = "~/Photo/" + img + ".jpg";
                    //        Chequeimage.SaveAs(HttpContext.Server.MapPath("~/Photo/" + img + ".jpg"));
                    //    }
                    //    else
                    //    {
                    //        donar.Chequeimage = "~/Photo/default.jpg";

                    //    }
                    //}
                    //else if (donar.paymethod == "banktransaction")
                    //{
                    //    donar.bank = trbank;
                    //    donar.Account = holderacno;
                    //    donar.chequeno = transactionid;
                    //    donar.ACholdername = "NA";
                    //    donar.Branch = "NA";
                    //    donar.IFSCCode = "NA";
                    //    donar.ChequeAmount = tramount;
                    //    donar.Chequedate = Convert.ToDateTime(fc["transactiondate)"]);
                    //    donar.Chequeimage = "~/Photo/default.jpg";
                    //    donar.transactiontype = Convert.ToString(fc["transactiontype"]);
                    //}
                    //else if (donar.paymethod == "DD")
                    //{
                    //    donar.bank = "NA";
                    //    donar.Account = "NA";
                    //    donar.chequeno = ddno;
                    //    donar.ACholdername = "NA";
                    //    donar.Branch = "NA";
                    //    donar.IFSCCode = "NA";
                    //    donar.ChequeAmount = DDamount.ToString();
                    //    donar.Chequedate = DateTime.Now.Date;
                    //    donar.Chequeimage = "~/Photo/default.jpg";
                    //    donar.transactiontype = "NA";
                    //}
                    //else if (donar.paymethod == "Cash")
                    //{
                    //    donar.bank = "NA";
                    //    donar.Account = "NA";
                    //    donar.chequeno = "NA";
                    //    donar.ACholdername = "NA";
                    //    donar.Branch = "NA";
                    //    donar.IFSCCode = "NA";
                    //    donar.ChequeAmount = amount.ToString();
                    //    donar.Chequedate = DateTime.Now.Date;
                    //    donar.Chequeimage = "~/Photo/default.jpg";
                    //    donar.transactiontype = "NA";
                    //}

                    db.Donars.Add(donar);
                    db.SaveChanges();

                    status = 1;

                    ViewBag.Txnid = donar.PaymentTransactionId;

                    Response.Write("<script>alert('Donar Added successfully!')</script>");
                }
                else
                {
                    Response.Write("<script>alert('This Transaction already exists')</script>");
                }
            }
            catch (Exception ex)
            {
                status = 0;
                Response.Write("<script>alert('Please fill in the required fields')</script>");
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

        public JsonResult medieagalleries(int newid)
        {
            var list = db.TeamTabs.Where(x => x.Id == newid).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult pressreleasegalleries(int newid)
        {
            var list = db.PressReleases.Where(x => x.Id == newid).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult PressRelease()
        {

            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {

                return View();
            }
        }

        [HttpPost]
        public ActionResult PressRelease(PressRelease ns, HttpPostedFileBase Image, string command, string Heading, string Summary, int newid = 0)
        {

            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {
                if (command == "Upload")
                {
                    var dd = new PressRelease();
                    dd.Heading = ns.Heading;
                    dd.Summary = ns.Summary;
                    dd.status = 1;
                    dd.Cdate = DateTime.Now.Date;

                    if (Image != null) // News Image
                    {
                        string imgname = gid();
                        Image.SaveAs(HttpContext.Server.MapPath("../slider/" + imgname + ".jpg"));
                        dd.Image = "~/PressRelease/" + imgname + ".jpg";
                    }
                    else
                    {
                        dd.Image = "~/Images/noImage.jpg";
                    }
                    db.PressReleases.Add(dd);
                    db.SaveChanges();
                    TempData["msg"] = "Added Gallery Successfully !";

                    return RedirectToAction("TeamUpdate", "Admin");
                }
                if (command == "Update")
                {
                    PressRelease obj = new PressRelease();
                    var achi = db.PressReleases.Single(x => x.Id == newid);
                    string imgname = gid();
                    if (Image != null)
                    {
                        Image.SaveAs(HttpContext.Server.MapPath("../slider/" + imgname + ".jpg"));
                        achi.Image = "~/PressRelease/" + imgname + ".jpg";
                    }
                    else
                    {
                        achi.Image = achi.Image;
                    }
                    achi.Heading = Heading;
                    achi.Summary = Summary;

                    db.Entry(achi).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["msg"] = "Update succesfully!!";
                    return RedirectToAction("PressRelease", "Admin");
                }
                return View();
            }
        }

        public ActionResult pressstatus(int opid = 0, int status = 0)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Home");
            }
            else
            {
                var getstatus = db.PressReleases.Single(x => x.Id == opid && x.status == status);

                if (status == 1)
                {
                    getstatus.status = 0;
                }
                else
                {
                    getstatus.status = 1;
                }

                db.Entry(getstatus).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("PressRelease", "Admin");

        }


        public ActionResult pressdelete(int opid = 0, int status = 0)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Home");
            }
            else
            {
                var getstatus = db.PressReleases.Single(x => x.Id == opid && x.status == status);
                getstatus.status = 3;
                db.Entry(getstatus).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("PressRelease", "Admin");

        }

        [HttpGet]
        public ActionResult TeamUpdate()
        {

            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {

                return View();
            }
        }

        [HttpPost]
        public ActionResult TeamUpdate(TeamTab ns, HttpPostedFileBase Image, string command, string Heading, string Summary, int newid = 0)
        {

            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {
                if (command == "Upload")
                {
                    var dd = new TeamTab();
                    dd.Heading = ns.Heading;
                    dd.Summary = ns.Summary;
                    dd.status = 1;
                    dd.Cdate = DateTime.Now.Date;

                    if (Image != null) // News Image
                    {
                        string imgname = gid();
                        Image.SaveAs(HttpContext.Server.MapPath("../slider/" + imgname + ".jpg"));
                        dd.Image = "~/TeamImage/" + imgname + ".jpg";
                    }
                    else
                    {
                        dd.Image = "~/Images/noImage.jpg";
                    }
                    db.TeamTabs.Add(dd);
                    db.SaveChanges();
                    TempData["msg"] = "Added Gallery Successfully !";

                    return RedirectToAction("TeamUpdate", "Admin");
                }
                if (command == "Update")
                {
                    TeamTab obj = new TeamTab();
                    var achi = db.TeamTabs.Single(x => x.Id == newid);
                    string imgname = gid();
                    if (Image != null)
                    {
                        Image.SaveAs(HttpContext.Server.MapPath("../slider/" + imgname + ".jpg"));
                        achi.Image = "~/TeamImage/" + imgname + ".jpg";
                    }
                    else
                    {
                        achi.Image = achi.Image;
                    }
                    achi.Heading = Heading;
                    achi.Summary = Summary;

                    db.Entry(achi).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["msg"] = "Update succesfully!!";
                    return RedirectToAction("TeamUpdate", "Admin");
                }
                return View();
            }
        }
        [HttpGet]
        public ActionResult CreateOperator()
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {
                int count = (from n in db.NewLogins where n.UserName == User.Identity.Name select n.UserName).Count();
                if (count == 1)
                {
                    var log = db.NewLogins.Single(a => a.UserName == User.Identity.Name);
                    if (log.status == 1 && log.type == "Admin")
                    {
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Logout", "Admin");
                    }
                }
                else
                {
                    return RedirectToAction("Logout", "Admin");
                }
            }
        }
        [HttpGet]
        public ActionResult OperatorList()
        {
            List<Operator> dclist = new List<Operator>();
            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {
                int count = (from n in db.NewLogins where n.UserName == User.Identity.Name select n.UserName).Count();
                if (count == 1)
                {
                    var log = db.NewLogins.Single(a => a.UserName == User.Identity.Name);
                    if (log.status == 1 && log.type == "Admin")
                    {

                        dclist = (from dcl in db.Operators select dcl).ToList();
                        return View(dclist);
                    }
                    else
                    {
                        return RedirectToAction("Logout", "Admin");
                    }
                }
                else
                {
                    return RedirectToAction("Logout", "Admin");
                }
            }

        }
        [HttpPost]
        public ActionResult CreateOperator(Operator model)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Branch");
            }
            else
            {
                var row = (from ob in db.Operators where ob.OperatorId == model.OperatorId select ob).ToList();
                if (row.Count > 0)
                {
                    ViewBag.msg = "This Operator already exists";
                }
                else
                {
                    var ci = db.CompanyInfos.Single(c => c.Id == 1);
                    string pass = gid();

                    Operator bob = new Operator();
                    NewLogin nl = new NewLogin();

                    bob.BranchCode = model.BranchCode;
                    bob.OperatorId = model.OperatorId.ToUpper();
                    bob.OperatorName = model.OperatorName.ToUpper();
                    bob.OperatorPassword = pass;
                    bob.OperatorMobile = model.OperatorMobile;
                    bob.Operator_Mail = model.Operator_Mail;
                    bob.OperatorAddress = model.OperatorAddress.ToUpper();
                    bob.Cdate = model.Cdate;
                    bob.Type = "Operator";
                    bob.Status = 1;
                    bob.companyid = ci.AdminId;

                    nl.UserName = model.OperatorId.ToUpper();
                    nl.Password = pass;
                    nl.Mobile = model.OperatorMobile;
                    nl.type = "Operator";
                    nl.status = 1;

                    db.NewLogins.Add(nl);
                    db.Operators.Add(bob);
                    db.SaveChanges();
                    //Dear {#var#}, your UserId is:{#var#} and Password:{#var#} Visit www.asrdpl.com
                    MyClass.Sendmsg1(model.OperatorMobile, "Dear " + model.OperatorName.ToUpper() + ",  your UserId is:" + model.OperatorId.ToUpper() + " and Password:" + pass + " Visit www.asrdpl.com", "1707163049957028563");
                    ViewBag.msg = "Operator Created Successfully....";

                }
                return View();
            }
        }
        public ActionResult mediastatus(int opid = 0, int status = 0)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Home");
            }
            else
            {
                var getstatus = db.TeamTabs.Single(x => x.Id == opid && x.status == status);

                if (status == 1)
                {
                    getstatus.status = 0;
                }
                else
                {
                    getstatus.status = 1;
                }

                db.Entry(getstatus).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("TeamUpdate", "Admin");

        }

       
        public ActionResult mediadelete(int opid = 0, int status = 0)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Home");
            }
            else
            {
                var getstatus = db.TeamTabs.Single(x => x.Id == opid && x.status == status);
                getstatus.status = 3;
                db.Entry(getstatus).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("TeamUpdate", "Admin");

        }

    }
}

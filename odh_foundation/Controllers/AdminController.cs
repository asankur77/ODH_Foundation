using odh_foundation.Models;
using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using static odh_foundation.Models.UsersContext;

namespace odh_foundation.Controllers
{
    public class AdminController : Controller
    {
        UsersContext db = new UsersContext();

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
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Media_Centre()
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
        public ActionResult upload_video()
        {
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

                        //var head = db.HeadTabs.ToList();

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
        //[HttpPost]
        //public ActionResult AddHead(head ob, string[] branchcode)
        //{
        //    if (!IsLoggedIn())
        //    {
        //        return RedirectToAction("Logout", "Admin");
        //    }
        //    else
        //    {

        //        var Duplicate = (from o in db.HeadTabs where o.head == ob.head select o).ToList();
        //        if (Duplicate.Count > 0)
        //        {
        //            Response.Write("<script>alert('This Head Already exist ')</script>");
        //        }

        //        else
        //        {
        //            HeadTab hob = new HeadTab();
        //            for (int i = 0; i < branchcode.Length; i++)
        //            {
        //                hob.head = ob.head;
        //                hob.branchcode = branchcode[i];
        //                db.HeadTabs.Add(hob);
        //                db.SaveChanges();
        //            }
        //            Response.Write("<script>alert('Head Added successfully ')</script>");

        //        }
        //        //var head = db.HeadTabs.ToList();

        //        return View();
        //    }
        //}
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
        public ActionResult AddExpense(string head, string remarks, Double amount, DateTime date, int type)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Admin");
            }
            else
            {
                Expense ob = new Expense();
                ob.head = head.ToUpper();
                ob.Remark = remarks;
                ob.amount = amount;
                ob.date_time = date;
                ob.branchcode = User.Identity.Name;
                ob.opid = User.Identity.Name;
                ob.type = type;
                db.Expenses.Add(ob);
                db.SaveChanges();
                Response.Write("<script>alert('Expense added Successfully')</script>");
                return View();
            }
        }

        public ActionResult ExpenseMenu()
        {
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

       
        public ActionResult Enquiry_list()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult logout()
        {
           return RedirectToAction("Index","Home");
            
        }

    }
}

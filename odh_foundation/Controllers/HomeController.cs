using Newtonsoft.Json.Linq;
using odh_foundation.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Security;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.Entity;
using System.Globalization;


namespace odh_foundation.Controllers
{
    public class HomeController : Controller
    {

       
          

        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            if (image == null)
            {

            }
            else
            {
                BinaryReader reader = new BinaryReader(image.InputStream);
                imageBytes = reader.ReadBytes((int)image.ContentLength);
                return imageBytes;
            }
            return imageBytes;
        }
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

        private static String[] units = { "Zero", "One", "Two", "Three",
    "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
    "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
    "Seventeen", "Eighteen", "Nineteen" };
        private static String[] tens = { "", "", "Twenty", "Thirty", "Forty",
    "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        public static String ConvertAmount(double amount)
        {
            try
            {
                Int64 amount_int = (Int64)amount;
                Int64 amount_dec = (Int64)Math.Round((amount - (double)(amount_int)) * 100);
                if (amount_dec == 0)
                {
                    return ConvertDigit(amount_int) + " Rupees Only";
                }
                else
                {
                    return ConvertDigit(amount_int) + " Point " + ConvertDigit(amount_dec) + " Rupees Only";
                }
            }
            catch (Exception e)
            {
                // TODO: handle exception  
            }
            return "";
        }

        public static String ConvertDigit(Int64 i)
        {
            if (i < 20)
            {
                return units[i];
            }
            if (i < 100)
            {
                return tens[i / 10] + ((i % 10 > 0) ? " " + ConvertDigit(i % 10) : "");
            }
            if (i < 1000)
            {
                return units[i / 100] + " Hundred"
                        + ((i % 100 > 0) ? " And " + ConvertDigit(i % 100) : "");
            }
            if (i < 100000)
            {
                return ConvertDigit(i / 1000) + " Thousand "
                + ((i % 1000 > 0) ? " " + ConvertDigit(i % 1000) : "");
            }
            if (i < 10000000)
            {
                return ConvertDigit(i / 100000) + " Lakh "
                        + ((i % 100000 > 0) ? " " + ConvertDigit(i % 100000) : "");
            }
            if (i < 1000000000)
            {
                return ConvertDigit(i / 10000000) + " Crore "
                        + ((i % 10000000 > 0) ? " " + ConvertDigit(i % 10000000) : "");
            }
            return ConvertDigit(i / 1000000000) + " Arab "
                    + ((i % 1000000000 > 0) ? " " + ConvertDigit(i % 1000000000) : "");
        }





        UsersContext db = new UsersContext();
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }
        [HttpPost]
        public ActionResult Index(Subscriber ob)
        {
            var cr = db.CompanyInfos.Single(ci => ci.Id == 1);
            if (ModelState.IsValid)
            {
                
                ob.cdate = DateTime.Now;
                ob.status = 1;
                db.Subscriber.Add(ob);
                db.SaveChanges();

                Response.Write("<script>alert('Thank you for subscribe us, we will contact you soon.')</script>");
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        public ActionResult CancellationPolicy()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        public ActionResult DonorPolicy()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        public ActionResult VolunteerInfo()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        public ActionResult TermCondition()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(Contact ob)
        {
            var cr = db.CompanyInfos.Single(ci => ci.Id == 1);
            if (ModelState.IsValid)
            {
                ob.cdate = DateTime.Now;
                ob.status = 1;
                db.Contacts.Add(ob);
                db.SaveChanges();

                MyClass.Sendmsg1(ob.mobile, "Dear " + ob.name.ToUpper() + ", Thank you for your message. We will get in touch with you as soon as possible. Regards- ODH Foundation", "1207168993362546499");

                Response.Write("<script>alert('Thank you for contacting us, we will contact you soon.')</script>");
            }

            return View();
        }
        public ActionResult PrivacyPolicy()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult FAQ()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult CSR()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Careers()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Our_Project()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Volunteer()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Volunteer(Volunteer request, HttpPostedFileBase AadharFront, HttpPostedFileBase AadharBack, HttpPostedFileBase ProfilePic, string Profession1, string VolunteerDuration1, string VolunteerPurpose1, string VolunteerAbility1)
        {

            var r = new Volunteer();
            if (ProfilePic != null)
            {
                string imgname = gid();
                r.ProfilePic = "~/Photo/" + imgname + ".jpg";
                ProfilePic.SaveAs(HttpContext.Server.MapPath("~/Photo/" + imgname + ".jpg"));
                var imgr = ConvertToBytes(ProfilePic);
                r.Photonew = imgr;
            }
            else
            {
                r.ProfilePic = "~/Photo/default.jpg";
                r.Photonew = new byte[] { };

            }


            if (AadharFront != null)
            {
                string imgname = gid();
                r.AadharFront = "~/Aadhar/" + imgname + ".jpg";
                AadharFront.SaveAs(HttpContext.Server.MapPath("~/Aadhar/" + imgname + ".jpg"));

            }

            if (AadharBack != null)
            {
                string imgname = gid();
                r.AadharBack = "~/Aadhar/" + imgname + ".jpg";
                AadharBack.SaveAs(HttpContext.Server.MapPath("~/Aadhar/" + imgname + ".jpg"));

            }
            var volunteer = new Volunteer()
            {
                Name = request.Name,
                FName = request.FName,
                Email = request.Email.ToLower(),
                Mobile = request.Mobile,
                WhatsupNumber = request.WhatsupNumber,
                DOB = Convert.ToDateTime(request.DOB),
                Address = request.Address,
                Profession = (request.Profession == "Other") ? Profession1 : request.Profession,
                VolunteerDuration = (request.VolunteerDuration == "Other") ? VolunteerDuration1 : request.VolunteerDuration,
                VolunteerPurpose = (request.VolunteerPurpose == "Other") ? VolunteerPurpose1 : request.VolunteerPurpose,
                VolunteerAbility = (request.VolunteerAbility == "Other") ? VolunteerAbility1 : request.VolunteerAbility,
                RegistrationDate = DateTime.Now,
                Status = 1,
                VolunteerId = GenerateRandomVolunteerId(5),
                AadharBack = r.AadharBack,
                AadharFront=r.AadharFront,
                ProfilePic=r.ProfilePic,
                Photonew=r.Photonew
               

            };

            db.Volunteers.Add(volunteer);
            db.SaveChanges();
            //Dear {#var#}, Thanks for subscribing to the ODH Foundation newsletter. we would like to personally thank you for choosing to receive updates from us. It means a lot to have donors like you on board. Regards- ODH Foundation
            //                                Hi {#var#}, Thank you from the bottom of heart for signing up as a volunteer at ODH Foundation. We are very grateful for your help! For more details contact us on {#var#}. Regards - ODH Foundation
            MyClass.Sendmsg1(request.Mobile, "Hi " + request.Name.ToUpper() + ", Thank you from the bottom of heart for signing up as a volunteer at ODH Foundation. We are very grateful for your help! For more details contact us on +91-9795505106 , 0512-2220000. Regards - ODH Foundation", "1207168992830508126");

            Response.Write("<script>alert('Registered successfully!')</script>");
            return View();
        }
        public ActionResult GirlEducation()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult SanitaryPad()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Disclaimer()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Donation(string cause)
        {
            try
            {

                if(!String.IsNullOrWhiteSpace(cause))
                {
                    ViewBag.cause = cause;
                }
                //ViewBag.startingPath = HttpContext.CurrentHandler.Request.Url.AbsoluteUri;
                //ViewBag.vbReturnUrl = Request.Url.AbsoluteUri.ToString() + "Response/responseHandler";
                ViewBag.vbReturnUrl = Request.Url.GetLeftPart(UriPartial.Authority) + "/Home/Successfull";


                string path = Server.MapPath("~/App_Data/");
                string tranId = GenerateRandomTransactionString(5);
                ViewBag.tranId = tranId;

                ViewBag.debitStartDate = DateTime.Now.ToString("yyyy-MM-dd");
                int year = Convert.ToInt32(DateTime.Now.Year.ToString());
                DateTime date = DateTime.Now;
                var enddate = date.AddYears(30);
                ViewBag.debitEndDate = enddate.ToString("yyyy-MM-dd");
                //dd-MM-yyyy
                using (StreamReader r = new StreamReader(path + "output.json"))
                {
                    string json = r.ReadToEnd();


                    ViewBag.config_data = json;
                    var jsonData = JObject.Parse(json).Children();
                    List<JToken> tokens = jsonData.Children().ToList();
                    if (Convert.ToBoolean(tokens[25]) == true)
                    {
                        if (Convert.ToBoolean(tokens[34]) == true)
                        {
                            ViewBag.enbSi = Convert.ToBoolean(tokens[25]);
                        }
                        else
                        {
                            ViewBag.enbSi = false;
                        }

                    }
                    else
                    {
                        ViewBag.enbSi = false;
                    }

                    ViewBag.vbMerchantCode = JObject.Parse(json)["merchantCode"].ToString();
                    ViewBag.vbMerchantSchemeCode = JObject.Parse(json)["merchantSchemeCode"].ToString();
                    ViewBag.vbSalt = JObject.Parse(json)["SALT"].ToString();
                    ViewBag.DonarId = GenerateRandomDonarId(5);

                }
            }
            catch (Exception ex)
            {

                // throw;
            }

            return View();
        }

        //[HttpPost]
        //public ActionResult Donation(Donar request)
        //{
        //    var donar = new Donar()
        //    {
        //        Address = request.Address,
        //        City = request.City,
        //        Country = request.Country,
        //        DOB = request.DOB,
        //        DonateAmount = request.DonateAmount,
        //        DonationDate = DateTime.Now,
        //        Email = request.Email,
        //        Name = request.Name,
        //        PAN = request.PAN,
        //        Phone = request.Phone,
        //        Pincode = request.Pincode,
        //        State = request.State,
        //        Status = 0,
        //        SupportType = request.SupportType
        //    };

        //    db.Donars.Add(donar);
        //    db.SaveChanges();


        //    return View();
        //}

        public ActionResult Education()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        public ActionResult WomenEmp()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        public ActionResult Health()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        public ActionResult Livelihood()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        public ActionResult Environment()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        public ActionResult Sports()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        public ActionResult Agriculture()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        public ActionResult UrbanRenewal()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        public ActionResult RuralDevelopment()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        public ActionResult DistaterManagement()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult ArtCulture()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        public ActionResult AbHarKoiPadega()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        public ActionResult CharitableSchool()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        public ActionResult MedicalCamp()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        public ActionResult CharitableHospital()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        public ActionResult AbBaariHaiHamari()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(NewLogin ft, string submit)
        {
            if (submit == "login")
            {
                var cnt = db.NewLogins.Where(e => e.UserName == ft.UserName && e.Password == ft.Password).Count();
                if (cnt == 1)
                {
                    var str = db.NewLogins.Single(e => e.UserName == ft.UserName && e.Password == ft.Password);
                    if (str.type == "Admin")
                    {
                        FormsAuthentication.SetAuthCookie(str.UserName, true);
                        return RedirectToAction("Create", "Admin");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Your Username or password is not valid !!')</script>");
                }
            }

            return View();
        } 

        // Payment Gateway Utility

        public JsonResult GenerateSHA512String(string inputString)
        {


            using (SHA512 sha512Hash = SHA512.Create())
            {
                //From String to byte array
                byte[] sourceBytes = Encoding.UTF8.GetBytes(inputString);
                byte[] hashBytes = sha512Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

                System.Security.Cryptography.SHA512Managed sha512 = new System.Security.Cryptography.SHA512Managed();

                Byte[] EncryptedSHA512 = sha512.ComputeHash(System.Text.Encoding.UTF8.GetBytes(hash));

                sha512.Clear();

                var bts = Convert.ToBase64String(EncryptedSHA512);

                return Json(hash, JsonRequestBehavior.AllowGet);
            }
        }
        public string GenerateRandomString(int size)
        {
            var temp = Guid.NewGuid().ToString().Replace("-", string.Empty);
            var barcode = Regex.Replace(temp, "[a-zA-Z]", string.Empty).Substring(0, 10);

            return barcode.ToString();
        }

        public string GenerateRandomTransactionString(int size)
        {
            var newid = Convert.ToString(MyClass.GetFinancialYear().TxnidFormat);
            var temp = Guid.NewGuid().ToString().Replace("-", string.Empty);
            var barcode = newid + Convert.ToString(Regex.Replace(temp, "[a-zA-Z]", string.Empty).Substring(0, size));

            var donarCount = db.WordLinePaymentResponses.Where(a => a.ClntTxnRef == barcode).Count();
            while (donarCount == 1)
            {
                barcode = Regex.Replace(temp, "[a-zA-Z]", string.Empty).Substring(0, size);
                donarCount = db.WordLinePaymentResponses.Where(a => a.ClntTxnRef == barcode).Count();
            }

            return barcode;
        }

        public string GenerateRandomDonarId(int size)
        {

            var newid = Convert.ToString(MyClass.GetFinancialYear().DonarIdFormat);
            var temp = Guid.NewGuid().ToString().Replace("-", string.Empty);
            var barcode = newid + Convert.ToString(Regex.Replace(temp, "[a-zA-Z]", string.Empty).Substring(0, size));

            var donarCount = db.Donars.Where(a => a.DonarId == barcode).Count();
            while(donarCount==1)
            {
                barcode = Regex.Replace(temp, "[a-zA-Z]", string.Empty).Substring(0, size);
                donarCount = db.Donars.Where(a => a.DonarId == barcode).Count();
            }

            return barcode;
        }

        public string GenerateRandomVolunteerId(int size)
        {
            var newid = Convert.ToString(MyClass.GetFinancialYear().VolunteerIdFormat);
            var temp = Guid.NewGuid().ToString().Replace("-", string.Empty);
            var barcode = newid + Convert.ToString(Regex.Replace(temp, "[a-zA-Z]", string.Empty).Substring(0, size));

            var volunteerCount = db.Volunteers.Where(a => a.VolunteerId == barcode).Count();
            while (volunteerCount == 1)
            {
                barcode = Regex.Replace(temp, "[a-zA-Z]", string.Empty).Substring(0, size);
                volunteerCount = db.Volunteers.Where(a => a.VolunteerId == barcode).Count();
            }

            return barcode;
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }


        public ActionResult Successfull(FormCollection formCollection)
        {
            try
            {

                foreach (var key in formCollection.AllKeys)
                {
                    var value = formCollection[key];
                }

                string path = Server.MapPath("~/App_Data/");

                string json = "";


                using (StreamReader r = new StreamReader(path + "output.json"))
                {
                    json = r.ReadToEnd();

                    r.Close();

                }
                JObject config_data = JObject.Parse(json);
                var data = formCollection["msg"].ToString().Split('|');
                if (data == null)
                {//|| data[1].ToString()== "User Aborted"
                    ViewBag.abrt = true;
                    return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
                }
                ViewBag.online_transaction_msg = data;
                if (data[0] == "0300")
                {
                    //var request_str = "{ :merchant => { :identifier => " + config_data["merchantCode"].ToString() + "} ," +
                    //                " :transaction => { :deviceIdentifier => 'S', " +
                    //                     ":currency => " + config_data["currency"] + "," +
                    //                     ":dateTime => " + string.Format("{0:d/M/yyyy", data[8]) + "," +
                    //                     ":token => " + data[5].ToString() + "," +
                    //                     ":requestType => 'S'" +
                    //                     "}" +
                    //                    "}";
                    ViewBag.abrt = false;

                    var strJ = new
                    {
                        merchant = new
                        {
                            identifier = config_data["merchantCode"].ToString()
                        },
                        transaction = new
                        {
                            deviceIdentifier = "S",
                            currency = config_data["currency"],
                            dateTime = string.Format("{0:d/M/yyyy}", data[8].ToString()),
                            token = data[5].ToString(),
                            requestType = "S"
                        }
                    };
                    //     var request_str = Newtonsoft.Json.JsonConvert.SerializeObject(strJ);

                    //  JObject request_data = JObject.Parse(request_str);
                    //using (var client = new HttpClient())
                    //{
                    //    client.BaseAddress = new Uri("https://www.paynimo.com/api/paynimoV2.req");

                    //    //HTTP POST
                    //    var postTask = client.PostAsync("https://www.paynimo.com/api/paynimoV2.req", request_data);
                    //    postTask.Wait();

                    //    var result = postTask.Result;
                    //    if (result.IsSuccessStatusCode)
                    //    {
                    //        return RedirectToAction("Index");
                    //    }
                    //}


                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("https://www.paynimo.com/api/paynimoV2.req");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PostAsJsonAsync("https://www.paynimo.com/api/paynimoV2.req", strJ).Result;
                    var a = response.Content.ReadAsStringAsync();

                    JObject dual_verification_result = JObject.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(a));
                    var jsonData = JObject.Parse(dual_verification_result["Result"].ToString()).Children();

                    List<JToken> tokens = jsonData.Children().ToList();

                    var jsonData1 = JObject.Parse(tokens[6].ToString()).Children();
                    List<JToken> tokens1 = jsonData.Children().ToList();
                    ViewBag.dual_verification_result = dual_verification_result;
                    ViewBag.a = a;
                    ViewBag.jsonData = jsonData;
                    ViewBag.tokens = tokens;
                    ViewBag.paramsData = formCollection["msg"];
                    // return response;
                }

                var wpr = new WordLinePaymentResponse()
                {
                    TxnStatus = data[0],
                    TxnMessage = data[1],
                    TxnErrorMessage = data[2],
                    ClntTxnRef = data[3],
                    TPSLBankCd = data[4],
                    MerchantTxnId = data[5],
                    TxnAmt = data[6],
                    ClntRequestMeta = data[7],
                    MerchantTxnTime = data[8],
                    BalanceAmt = data[9],
                    CardId = data[10],
                    AliasName = data[11],
                    BankTransactionId = data[12],
                    MandateRegNo = data[13],
                    Token = data[14],
                    Hash = data[15],
                };

                db.WordLinePaymentResponses.Add(wpr);
                db.SaveChanges();

                // Updating status in donar table
                var donardata = db.Donars.Single(b => b.PaymentTransactionId == wpr.ClntTxnRef);
                if (ViewBag.online_transaction_msg[1] == "success" || ViewBag.online_transaction_msg[1] == "SUCCESS")
                {
                    if (db.Donars.Any(a => a.PaymentTransactionId == wpr.ClntTxnRef))
                    {
                        var donar = db.Donars.Single(a => a.PaymentTransactionId == wpr.ClntTxnRef);
                        donar.Status = 1;
                        db.Entry(donar).State = EntityState.Modified;
                        db.SaveChanges();
                        //Thank you, {#var#}, for your contribution. Your kindness will make a significant impact on our mission. You may visit www.odhfoundation.org to view your receipt, and we’ve also sent a copy to your email {#var#} so you can claim it as a tax deduction. Regards, ODH Foundation.
                        MyClass.Sendmsg1(donardata.Phone, "Thank you, " + donardata.Name.ToUpper() + ", for your contribution. Your kindness will make a significant impact on our mission. You may visit www.odhfoundation.org to view your receipt, and we’ve also sent a copy to your email " + donardata.Email + " so you can claim it as a tax deduction. Regards, ODH Foundation.", "1207168975797980000");

                    }
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Thankyou for your contribution, Please click Ok to continue.')</script>");
            }

            return View();
        }

        public JsonResult DonarCreation(FormCollection fc)
        {
            var cr = db.FinancialYearTabs.Single(ci => ci.Id == 1);
            string amountinwords ="( "+ ConvertAmount(Convert.ToDouble(fc["DonateAmount"]))+ " )";
            int status = 0;
            try
            {
                var donar = new Donar();
                donar.Address = Convert.ToString(fc["Address"]) + "," + Convert.ToString(fc["City"]) + "," + Convert.ToString(fc["State"]) + "," + Convert.ToString(fc["Country"]) + "-" + Convert.ToString(fc["Pincode"]);
                donar.City = Convert.ToString(fc["City"]);
                donar.Country = Convert.ToString(fc["Country"]);
                donar.DOB = Convert.ToDateTime(fc["DOB"]);
                donar.DonateAmount = !String.IsNullOrEmpty(Convert.ToString(fc["DonateAmount"])) ? Convert.ToInt32(fc["DonateAmount"]) : 0;
                donar.DonationDate = DateTime.Now;
                donar.Email = Convert.ToString(fc["Email"]).ToLower();
                donar.Name = Convert.ToString(fc["Name"]);
                donar.PAN = Convert.ToString(fc["PAN"]).ToUpper();
                donar.aadharno = Convert.ToString(fc["aadharno"]);
                donar.otherno = Convert.ToString(fc["otherno"]);
                donar.title = Convert.ToString(fc["title"]);
                donar.amountinwords = amountinwords;
                donar.Phone = Convert.ToString(fc["Phone"]);
                donar.Pincode = Convert.ToString(fc["Pincode"]);
                donar.State = Convert.ToString(fc["State"]);
                donar.SupportType = Convert.ToString(fc["SupportType"]);
                donar.Status = 0;
                donar.PaymentTransactionId = Convert.ToString(fc["txn_id"]);
                donar.DonarId = Convert.ToString(fc["custID"]);
                donar.financialyear = cr.FinancialYear;
                donar.PaymentState = "Online";
                donar.PaymentMode = "Online";

                db.Donars.Add(donar);
                db.SaveChanges();

                status = 1;
                //MyClass.Sendmsg1(model.OperatorMobile, "Dear " + model.OperatorName.ToUpper() + ",  your UserId is:" + model.OperatorId.ToUpper() + " and Password:" + pass + " Visit www.asrdpl.com", "1707163049957028563");


            }
            catch (Exception ex)
            {
                status = 0;
                Response.Write("<script>alert('Please fill in the required fields')</script>");
            }

            return Json(status, JsonRequestBehavior.AllowGet);
        }


        public ActionResult PrintInvoiceCrystal(string txnid)
        {
            List<Donar> donarlist = new List<Donar>();
            donarlist = (from o in db.Donars where o.PaymentTransactionId == txnid  select o).ToList();
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
        public ActionResult PrintCertificateCrystal(string txnid)
        {
            List<Donar> donarlist = new List<Donar>();
            donarlist = (from o in db.Donars where o.PaymentTransactionId == txnid select o).ToList();
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
        public ActionResult PrintInvoice(string txnid)
        {
            return Reports.PrintInvoice(txnid);
        }

        public ActionResult PrintCertificate(string txnid)
        {
            return Reports.PrintCertificate(txnid);
        }
    }
}

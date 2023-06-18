using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace odh_foundation.Models
{
    public class MyClass
    {
        public static void Sendmsg(string receiver, string msg)
        {
            //string url = @"http://sms.technomate.mobi/api/swsend.asp?username=t1welltoss&password=34937074&sender=DASGRP&sendto=" + receiver + "&message=" + msg + "";
            //string url = @"http://sms.xpertgroup.in/api/pushsms.php?username=XPRTGPRS&password=XPRTGPRS&sender=DASGRP&message=" + msg + "&numbers=" + receiver + "&unicode=false";
            // string url = @"http://zapsms.co.in/vendorsms/pushsms.aspx?user=skywebsoft&password=M3T7uCks23&msisdn=" + receiver + "&sid=DASGRP&msg=" + msg + "&fl=0&gwid=2";
            // string url = @"http://alotsolutions.in/API/WebSMS/Http/v1.0a/index.php?msgtype=unicode&username=XPRTGP&password=XPRTGP&sender=DASGRP&to=" + receiver + "&message=" + msg + "";
            // string url = @"http://sms.escroll.in/api/mt/SendSMS?user=DIGINEST&password=DIGINEST&senderid=DASGRP" + "&channel=TRANS&DCS=0&flashsms=0&number=" + receiver + "&text=" + msg + "&route=23 ";
            string url = @"http://sms.technomate.mobi/api/swsend.asp?username=t1welltoss&password=carewe078066&sender=XPRTGP&entityID=1701160639054261180&sendto=" + receiver + "&message=" + msg + "";
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                string aaa = resp.ResponseUri.ToString();
                if (aaa.StartsWith("Wrong UserName or Password"))
                {
                    msg = "Message not Sent";
                }
                else
                {
                    msg = "Message Sent";
                }
            }
            catch (Exception)
            {

            }

        }
        public static void Sendmsg1(string receiver, string msg, string templateid)
        {

            //string url=http://smsw.co.in/API/WebSMS/Http/v1.0a/index.php?username=frizby&password=99@frizbyltd&sender=FRIZBY&to=my+recipient&message=Hello+Test+Message&reqid=1&format={json|text}&pe_id=""&template_id=""&route_id=route+id&callback=Any+Callback+URL&unique=0&sendondate=02-09-2021T10:54:00;
            //string url = @"http://sms.technomate.mobi/api/swsend.asp?username=t1welltoss&password=carewe078066&sender=XPRTGP&sendto=" + receiver + "&message=" + msg + "";
            //string url = @"http://sms.escroll.in/api/mt/SendSMS?user=DIGINEST&password=DIGINEST&sender=FRIZBY&channel=TRANS&DCS=0&flashsms=0&number=" + receiver + "&text=" + msg + "&route=23";
            string url = "http://sms.xpertgroup.org//api/pushsms.php?user=t5xpertgroup&key=010Eq1cY0XFQezVI7Gl1&sender=ASRDPL&mobile=" + receiver + "&text=" + msg + "&entityid=1701162977693667836&templateid=" + templateid + "";
            //http://sms.xpertgroup.in/api/pushsms.php?user=t5xpertgroup&key=010Eq1cY0XFQezVI7Gl1&sender=PODHLY&mobile=8127192924&text=%E0%A4%AA%E0%A5%8D%E0%A4%B0%E0%A4%BF%E0%A4%AF%20DK%20%E0%A4%86%E0%A4%AA%20%E0%A4%AA%E0%A4%82%E0%A4%9A%E0%A4%B5%E0%A4%9F%E0%A5%80%20%E0%A4%B9%E0%A4%B0%E0%A4%BF%E0%A4%A4%20%E0%A4%85%E0%A4%AD%E0%A4%BF%E0%A4%AF%E0%A4%BE%E0%A4%A8%20%E0%A4%95%E0%A5%80%20%E0%A4%8F%E0%A4%95%20%E0%A4%B5%E0%A5%83%E0%A4%95%E0%A5%8D%E0%A4%B7%20%E0%A4%AF%E0%A5%8B%E0%A4%9C%E0%A4%A8%E0%A4%BE%20%E0%A4%95%E0%A5%87%20%E0%A4%B8%E0%A4%BE%E0%A4%AE%E0%A4%BE%E0%A4%A8%E0%A5%8D%E0%A4%AF%20%E0%A4%B8%E0%A4%A6%E0%A4%B8%E0%A5%8D%E0%A4%AF%20%E0%A4%AC%E0%A4%A8%20%E0%A4%97%E0%A4%AF%E0%A5%87%20%E0%A4%B9%E0%A5%88%E0%A4%82%E0%A5%A4%20%E0%A4%86%E0%A4%AA%E0%A4%95%E0%A4%BE%20%E0%A4%AF%E0%A5%82%E0%A4%9C%E0%A4%B0%20%E0%A4%86%E0%A4%88%E0%A4%A1%E0%A5%80%20%E0%A4%A8%E0%A4%82%E0%A4%AC%E0%A4%B0%20-%20ONE145581-344%20%20%E0%A4%B9%E0%A5%88%E0%A5%A4%20%E0%A4%B8%E0%A4%95%E0%A5%8D%E0%A4%B0%E0%A4%BF%E0%A4%AF%20%E0%A4%B8%E0%A4%A6%E0%A4%B8%E0%A5%8D%E0%A4%AF%E0%A4%A4%E0%A4%BE%20%E0%A4%B9%E0%A5%87%E0%A4%A4%E0%A5%81%20%E0%A4%B8%E0%A4%95%E0%A5%8D%E0%A4%B0%E0%A4%BF%E0%A4%AF%20%E0%A4%85%E0%A4%A8%E0%A5%81%E0%A4%B0%E0%A5%8B%E0%A4%A7%20%E0%A4%AA%E0%A5%87%E0%A4%9C%20%E0%A4%AA%E0%A4%B0%20%E0%A4%95%E0%A5%8D%E0%A4%B2%E0%A4%BF%E0%A4%95%20%E0%A4%95%E0%A4%B0%E0%A5%87%E0%A4%82.%20%E0%A4%A7%E0%A4%A8%E0%A5%8D%E0%A4%AF%E0%A4%B5%E0%A4%BE%E0%A4%A6%E0%A5%A4-%E0%A4%AA%E0%A4%82%E0%A4%9A%E0%A4%B5%E0%A4%9F%E0%A5%80&entityid=1701163099623774916&templateid=1707163168249619933
            //string url=@"http://sms.xpertgroup.in/api/pushsms.php?user=your profile id&key=your key&sender=Sender id&mobile=9810000000,9891000000,9300000000&text=Text message&entityid=12345##############&templateid=856978############
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                string aaa = resp.ResponseUri.ToString();
                if (aaa.StartsWith("Wrong UserName or Password"))
                {
                    msg = "Message not Sent";
                }
                else
                {
                    msg = "Message Sent";
                }
            }
            catch (Exception)
            {

            }

        }
    }

    public class MonthName
    {
        public String numbertomonthname(int month)
        {

            String name = "";
            switch (month)
            {
                case 1:
                    name = "January";
                    break;
                case 2:
                    name = "February";
                    break;
                case 3:
                    name = "March";
                    break;
                case 4:
                    name = "April";
                    break;
                case 5:
                    name = "May";
                    break;
                case 6:
                    name = "June";
                    break;
                case 7:
                    name = "July";
                    break;
                case 8:
                    name = "August";
                    break;
                case 9:
                    name = "September";
                    break;
                case 10:
                    name = "October";
                    break;
                case 11:
                    name = "November";
                    break;
                case 12:
                    name = "December";
                    break;
            }
            return name;
        }
        public DateTime getdate(int month, int year)
        {
            DateTime sdt;
            string sdate = string.Empty;
            if (month < 10)
            {
                sdate = "0" + month.ToString() + "/01/" + year.ToString();
            }
            else if (month >= 10)
            {
                sdate = month.ToString() + "/01/" + year.ToString();
            }
            sdt = Convert.ToDateTime(sdate);
            return sdt;
        }
    }

    public class NumberToEnglish
    {

        public String changeToWords(String numb, bool isCurrency)
        {
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
            String endStr = (isCurrency) ? ("Only") : ("");
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = (isCurrency) ? ("") : ("rupees");// just to separate whole numbers from points/cents

                        endStr = (isCurrency) ? ("paise " + endStr) : ("");
                        if (points.Length > 2)
                        {
                            points = points.Substring(0, 2);
                        }
                        pointStr = translateCents(points);
                    }
                }
                val = String.Format("{0} {1}{2} {3}", translateWholeNumber(wholeNo).Trim() + " Rupees", andStr + " ", pointStr, endStr);
            }
            catch { ;}
            return val;
        }
        private String translateWholeNumber(String number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;//tests for 0XX

                double dblAmt = (Convert.ToDouble(number));
                //if ((dblAmt > 0) && number.StartsWith("0"))
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric
                    beginsZero = number.StartsWith("0");
                    int numDigits = number.Length;
                    switch (numDigits)
                    {
                        case 1://ones' range
                            word = ones(number);
                            break;
                        case 2://tens' range
                            word = tens(number);
                            break;
                        case 3://hundreds' range
                            word = ones(number.Substring(0, 1)) + " Hundred  " + tens(number.Substring(1, 2));
                            break;
                        case 4://thousands' range
                            word = ones(number.Substring(0, 1)) + " Thousand ";
                            if (number.Substring(1, 1) != "0")
                            {
                                word += ones(number.Substring(1, 1)) + " Hundred  ";
                            }
                            if (number.Substring(2, 2) != "0")
                            {
                                word += tens(number.Substring(2, 2));
                            }
                            break;
                        case 5://ten thousand's range      
                            word = tens(number.Substring(0, 2)) + " Thousand ";
                            if (number.Substring(2, 1) != "0")
                            {
                                word += ones(number.Substring(2, 1)) + " Hundred  ";
                            }
                            if (number.Substring(3, 2) != "0")
                            {
                                word += tens(number.Substring(3, 2));
                            }
                            break;
                        case 6://lakh' range
                            word = ones(number.Substring(0, 1)) + " Lakh ";
                            if (number.Substring(1, 2) != "0")
                            {
                                word += tens(number.Substring(1, 2)) + " Thousand ";
                            }
                            if (number.Substring(3, 1) != "0")
                            {
                                word += ones(number.Substring(3, 1)) + " Hundred  ";
                            }
                            if (number.Substring(4, 2) != "0")
                            {
                                word += tens(number.Substring(4, 2));
                            }
                            break;
                        case 7://ten lakh's
                            word = tens(number.Substring(0, 2)) + " Lakh ";
                            if (number.Substring(2, 2) != "0")
                            {
                                word += tens(number.Substring(2, 2)) + " Thousand ";
                            }
                            if (number.Substring(4, 1) != "0")
                            {
                                word += ones(number.Substring(4, 1)) + " Hundred  ";
                            }
                            if (number.Substring(5, 2) != "0")
                            {
                                word += tens(number.Substring(5, 2));
                            }
                            break;
                        case 8://crore's range
                            word = ones(number.Substring(0, 1)) + " Crore ";
                            if (number.Substring(1, 2) != "0")
                            {
                                word += tens(number.Substring(1, 2)) + " Lakh ";
                            }
                            if (number.Substring(3, 2) != "0")
                            {
                                word += tens(number.Substring(3, 2)) + " Thousand ";
                            }
                            if (number.Substring(5, 1) != "0")
                            {
                                word += ones(number.Substring(5, 1)) + " Hundred  ";
                            }
                            if (number.Substring(6, 2) != "0")
                            {
                                word += tens(number.Substring(6, 2));
                            }
                            break;
                        case 9://ten crore's range
                            word = tens(number.Substring(0, 2)) + " Crore ";
                            if (number.Substring(2, 2) != "0")
                            {
                                word += tens(number.Substring(2, 2)) + " Lakh ";
                            }
                            if (number.Substring(4, 2) != "0")
                            {
                                word += tens(number.Substring(4, 2)) + " Thousand ";
                            }
                            if (number.Substring(6, 1) != "0")
                            {
                                word += ones(number.Substring(6, 1)) + " Hundred  ";
                            }
                            if (number.Substring(7, 2) != "0")
                            {
                                word += tens(number.Substring(7, 2));
                            }
                            break;
                        default:
                            word = "Zero";
                            break;
                    }

                }
                else
                {
                    word = "Zero";
                }
            }
            catch
            {

            }
            return word.Trim();
        }
        private String tens(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = null;
            switch (digt)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (digt > 0)
                    {
                        name = tens(digit.Substring(0, 1) + "0") + " " + ones(digit.Substring(1));
                    }
                    break;
            }
            return name;
        }
        private String ones(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = "";
            switch (digt)
            {
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }
        private String translateCents(String cents)
        {

            String cts = "";
            if (cents.Length == 2 && cents.Substring(0, 1) == "0")
            {
                cts = ones(cents.Substring(1, 1));
            }
            else if (cents.Length == 2)
            {
                if (Convert.ToInt32(cents) > 10 && Convert.ToInt32(cents) < 20)
                {
                    cts = tens(cents);
                }
                else
                {
                    cts = tens(cents.Substring(0, 1) + "0") + " " + ones(cents.Substring(1, 1));
                }
            }
            else
            {
                if (cents.Length == 1)
                {
                    cents += "0";
                }
                cts = tens(cents);
            }
            return cts;
        }

    }
}
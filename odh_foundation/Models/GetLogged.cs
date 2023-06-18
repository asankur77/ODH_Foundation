using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace odh_foundation.Models
{
    public class GetLogged
    {
        public static string logId { get; set; }
        public static string logType { get; set; }
    }
    public class LogNames
    {
        public readonly static string
            Company = "Company",
            Admin = "Admin",
            Customer = "Customer";
    }
}
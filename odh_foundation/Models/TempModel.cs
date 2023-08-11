using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace odh_foundation.Models
{
    
        public class HeadwiseExpense
        {
            public string head { get; set; }
            public string remark { get; set; }
            public Double amount { get; set; }
            [DataType(DataType.Date)]
            public DateTime date { get; set; }
            [DataType(DataType.Date)]
            public DateTime sdate { get; set; }
            [DataType(DataType.Date)]
            public DateTime edate { get; set; }
            public string companyname { get; set; }
            public string branchname { get; set; }
        }
        
}

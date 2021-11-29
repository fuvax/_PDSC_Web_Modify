using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class GetListProjectPersentModel
    {
        public string Sale_Order { get; set; }
        public string Site_Code { get; set; }
        public string Site_Name { get; set; }
        public string Site_Name2 { get; set; }
        public string Site_Address { get; set; }
        public string PE { get; set; }
        public string QC { get; set; }
        public string Test { get; set; }
        public string Sub_Con { get; set; }
        public decimal Progress { get; set; }
        public int Remain_Day { get; set; }
        public string Color_Status { get; set; }
        public string Stage { get; set; }
        public string Color_Code { get; set; }
    }
}
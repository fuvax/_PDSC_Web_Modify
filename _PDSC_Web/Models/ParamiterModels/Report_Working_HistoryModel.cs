using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ParamiterModels
{
    public class Report_Working_HistoryModel
    {
        public string Type { get; set; }
        public string Site_Code { get; set; }
        public string Employee_Code { get; set; }
        public DateTime Working_Start_Date { get; set; }
        public DateTime Working_End_Date { get; set; }
    }
}
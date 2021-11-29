using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class List_ViewPlan_Model
    {
        public string Sale_Order { get; set; }
        public string MFG { get; set; }
        public string EQ_No { get; set; }
        public string Model_Type { get; set; }
        public string Item_Description { get; set; }
        public string WorkApproveLimit { get; set; }
        public DateTime Plan_Start_Date { get; set; }
        public DateTime Plan_Finish_Date { get; set; }
        public DateTime Actual_Start_Date { get; set; }
        public DateTime Actual_Finish_Date { get; set; }
        public decimal Percent_Progress { get; set; }
        public DateTime Handover_Date { get; set; }
        public DateTime RHO_Revise_Handover { get; set; }
        public string SM_Code { get; set; }
        public string SM_Name { get; set; }
    }
}
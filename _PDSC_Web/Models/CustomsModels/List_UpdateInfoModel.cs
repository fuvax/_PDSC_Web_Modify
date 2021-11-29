using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class List_UpdateInfoModel
    {
        public string MFG { get; set; }
        public string Sale_Order { get; set; }
        public string EQ_No { get; set; }
        public string Item_Description { get; set; }
        public string Model_Type { get; set; }
        public string WorkApproveLimit { get; set; }
        public decimal Percent_Progress { get; set; }
        public int Remain_Day { get; set; }
        public string Color_Code { get; set; }
        public string Color_Status { get; set; }
        public string SM_Code { get; set; }
        public string Stage { get; set; }
        public string QC_Result_Code { get; set; }
        public string QC_Result_Name { get; set; }
    }
}
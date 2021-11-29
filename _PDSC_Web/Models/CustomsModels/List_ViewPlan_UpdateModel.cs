using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class List_ViewPlan_UpdateModel
    {
        public string MFG { get; set; }
        public string Sale_Order { get; set; }

        public string EQ_No { get; set; }
        public string Item_Description { get; set; }
        public string Model_Type { get; set; }
        public string WorkApproveLimit { get; set; }
        public DateTime P_Prepare_Start_Date { get; set; }
        public DateTime P_Delivery_Start_Date { get; set; }
        public DateTime P_Delivery_Finish_Date { get; set; }
        public DateTime P_Install_Start_Date { get; set; }
        public DateTime P_Install_Finish_Date { get; set; }
        public DateTime P_Power_Supply_Start_Date { get; set; }
        public DateTime P_Power_Supply_Finish_Date { get; set; }
        public DateTime P_Testing_Start_Date { get; set; }
        public DateTime P_QC_Start_Date { get; set; }
        public DateTime P_QC_Finish_Date { get; set; }
        public decimal Percent_Progress { get; set; }
        public DateTime Handover_Date { get; set; }
        public DateTime RHO_Revise_Handover { get; set; }
    }
}
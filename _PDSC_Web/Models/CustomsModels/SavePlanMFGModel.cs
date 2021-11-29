using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class SavePlanMFGModel
    {
        public string MFG_No { get; set; }
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
        public string Update_by { get; set; }
        public DateTime Last_Update { get; set; }
    }
}
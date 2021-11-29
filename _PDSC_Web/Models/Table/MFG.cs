using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.Table
{
    public class MFG
    {
        public string MFG_No { get; set; }
        public string Site_Code { get; set; }
        public int Remain_Day { get; set; }
        public string CS_Code { get; set; }
        public string SM_Code { get; set; }
        public decimal Task_Percent { get; set; }
        public string PE { get; set; }
        public string Test { get; set; }
        public string QC { get; set; }
        public string Sub_Con { get; set; }
        public DateTime Last_Update { get; set; }
        public string Last_by { get; set; }
        public string IsActive { get; set; }
        public string Manufac_C_Code { get; set; }
        public DateTime Manufac_Last_Update { get; set; }
        public string Manufac_Last_by { get; set; }
        public string WAL_Delivery { get; set; }
        public string WAL_Install { get; set; }
        public string WAL_Testing { get; set; }
        public string WAL_HandOver { get; set; }
        public DateTime WAL_Last_Update { get; set; }
        public string WAL_Last_by { get; set; }
        public DateTime RHO_Revise_Handover { get; set; }
        public DateTime RHO_Last_Update { get; set; }
        public string RHO_Last_by { get; set; }
        public DateTime P_Prepare_Start_Date { get; set; }
        public DateTime P_Delivery_Start_Date { get; set; }
        public DateTime P_Delivery_Finish_Date { get; set; }
        public DateTime P_Install_Start_Date { get; set; }
        public DateTime P_Install_Finish_Date { get; set; }
        public DateTime P_Power_Supply_Start_Date { get; set; }
        public DateTime P_P_Power_Supply_Finish_Date { get; set; }
        public DateTime P_Testing_Start_Date { get; set; }
        public DateTime P_QC_Start_Date { get; set; }
        public DateTime P_QC_Finish_Date { get; set; }
        public DateTime Plan_Last_Update { get; set; }
        public string Plan_Last_by { get; set; }

        public DateTime Partial_Date { get; set; }
        public string Partial_Item { get; set; }

        public string Work_SheetQC { get; set; }

        public DateTime Partial_Last_Update { get; set; }
        public string Partial_Last_by { get; set; }
    }
}
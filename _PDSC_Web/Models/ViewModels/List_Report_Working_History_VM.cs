using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ViewModels
{
    public class List_Report_Working_History_VM
    {
        public Guid TT_Code { get; set; }
        public string Site_Code { get; set; }
        public string Site_Name { get; set; }
        public string MFG { get; set; }
        public string EQ_No { get; set; }
        public string Item_Description { get; set; }
        public string Working_by_Code { get; set; }
        public string Working_by_Name { get; set; }
        public string PDSC_Position_Code { get; set; }
        public string Position_Group { get; set; }
        public DateTime TT_Working_Date { get; set; }
        public string SM_Code { get; set; }
        public string SM_Name { get; set; }
        public string Task_Code { get; set; }
        public string Task_Name { get; set; }
        public string TT_Result { get; set; }
        public string Result_Name { get; set; }
        public string TT_Problem_Code { get; set; }
        public string TT_Problem_Name { get; set; }
        public string TT_Problem_Note { get; set; }
        public DateTime Create_Date { get; set; }
    }
}
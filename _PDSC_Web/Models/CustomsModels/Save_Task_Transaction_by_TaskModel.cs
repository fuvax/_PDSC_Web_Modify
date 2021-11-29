using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class Save_Task_Transaction_by_TaskModel
    {
        public Guid TT_Code { get; set; }
        public string TT_MFG_No { get; set; }
        public string Task_Code { get; set; }
        public DateTime TT_Working_Date { get; set; }
        public string TT_Result { get; set; }
        public string TT_Problem { get; set; }
        public string TT_Problem_Note { get; set; }
        public string TT_Update_by { get; set; }
        public DateTime TT_Modified_Date { get; set; }
        public bool IsEdit { get; set; }
        public bool Source { get; set; }
    }
}
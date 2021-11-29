using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class ListTaskByStageModel
    {
        public string Task_Code { get; set; }
        public string Task_Name { get; set; }
        public DateTime TT_Working_Date { get; set; }
        public string TT_Result { get; set; }      
        public int Percent_Progress { get; set; }
        public string TT_Problem { get; set; }
       
        public string TT_Problem_Note { get; set; }
        public DateTime TT_Create_Date { get; set; }
        public bool TT_Source { get; set; }
        public string Result_Name { get; set; }
        public string Problem_Name { get; set; }
    }
}
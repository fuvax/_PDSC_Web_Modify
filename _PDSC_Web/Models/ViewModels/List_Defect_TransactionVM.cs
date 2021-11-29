using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ViewModels
{
    public class List_Defect_TransactionVM
    {
        [Key]
        public Guid DT_Code { get; set; }
        public string DI_Code { get; set; }
        public string Item_Descriptiom { get; set; }
        public string DT_Rank { get; set; }
        public DateTime DT_Issue_Date { get; set; }
        public string DT_Issue_by { get; set; }
        public string DICP_Code { get; set; }
        public string DICP_Description { get; set; }
        public string DResp_Code { get; set; }
        public string DResp_Description { get; set; }
        public string DCause_Code { get; set; }
        public string DCause_Description { get; set; }
        public string DT_Note_Defect { get; set; }
        public DateTime DT_Plan_Rectify_Finish { get; set; }
        public DateTime DT_Rectify_Complete_Date { get; set; }
        public string DRR_Code { get; set; }
        public string DRR_Description { get; set; }
        public string DT_Note_Rectify_Result { get; set; }
        public string Rectify_by { get; set; }
        public bool DT_Source { get; set; }
    }
}
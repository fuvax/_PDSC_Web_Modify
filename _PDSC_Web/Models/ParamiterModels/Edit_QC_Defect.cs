using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ParamiterModels
{
    public class Edit_QC_Defect
    {
        public Guid DT_Code { get; set; }
        public string DefectItem { get; set; }
        public string Rank { get; set; }
        public DateTime IssueDate { get; set; }
        public string IssueBy { get; set; }
        public string InChargePerson { get; set; }
        public string Responsibility { get; set; }
        public string Case { get; set; }
        public string NoteDefect { get; set; }

      //  public DateTime PlanRectify { get; set; }
    }
}
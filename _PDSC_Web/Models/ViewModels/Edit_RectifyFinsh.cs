using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ViewModels
{
    public class Edit_RectifyFinsh
    {
        public Guid DT_Code { get; set; }
        public string DefectItem { get; set; }     
        public DateTime PlanRectify { get; set; }
    }
}
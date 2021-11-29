using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class PlantDateInfoModel
    {
        public DateTime Plan_Start_Date { get; set; }
        public DateTime Plan_Finish_Date { get; set; }
        public decimal Percent_Progress { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class SavePlanFieldModel
    {
        public string Site_Code { get; set; }
        public string Field_Name { get; set; }
        public DateTime Plan_Date { get; set; }
        public string Update_by { get; set; }
        public DateTime Last_Update { get; set; }
    }
}
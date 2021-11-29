using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ViewModels
{
    public class Report_Unit_on_hand_VM
    {
        public Guid Temp_Code { get; set; }
        public string DM_Code { get; set; }
        public string DM_Name { get; set; }
        public string Leader_Code { get; set; }
        public string Leader_Name { get; set; }
        public string Engineer_Code { get; set; }
        public string Engineer_Name { get; set; }
        public int Green { get; set; }
        public int Yellow { get; set; }
        public int Orange { get; set; }
        public int Red { get; set; }
        public int Grand_Total { get; set; }
    }
}
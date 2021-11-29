using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ParamiterModels
{
    public class Save_User_ManagementModel
    {
        public string Employee_Code { get; set; }
        public string User_Type { get; set; }
        public string Position_Code { get; set; }
        public string Username { get; set; }
        public string pwd { get; set; }
        public bool Status { get; set; }
        public string Link_Image { get; set; }
        public DateTime Last_Update { get; set; }
    }
}
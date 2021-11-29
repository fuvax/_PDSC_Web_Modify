using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.Table
{
    public class Engineer_Master
    {
        public string PEM_Engineer_Code { get; set; }
        public string PEM_Leader_Code { get; set; }
        public string PEM_DM_Code { get; set; }
        public bool PEM_IsActive { get; set; }
        public DateTime PEM_Create_Date { get; set; }
        public DateTime PEM_Last_Update { get; set; }
        public string PEM_Last_By { get; set; }
    }
}
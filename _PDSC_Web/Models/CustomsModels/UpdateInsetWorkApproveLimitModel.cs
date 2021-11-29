using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class UpdateInsetWorkApproveLimitModel
    {
        public string MFG_No { get; set; }
        public bool WAL_Delivery { get; set; }
        public bool WAL_Install { get; set; }
        public bool WAL_Testing { get; set; }
        public bool WAL_HandOver { get; set; }
        public Guid TWAL_Code { get; set; }
        public string Update_by { get; set; }
        public DateTime Last_Update { get; set; }
        public string WAL_Remark { get; set; }
    }
}
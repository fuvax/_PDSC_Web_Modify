using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class Save_Engineer_Master_Model
    {
        public string Engineer_Code { get; set; }
        public string Leader_Code { get; set; }
        public string DM_Code { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Update_by { get; set; }
        public DateTime Last_Update { get; set; }
    }
}
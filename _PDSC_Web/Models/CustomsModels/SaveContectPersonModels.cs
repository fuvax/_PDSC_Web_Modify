using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class SaveContectPersonModels
    {
        public Guid ContactP_Code { get; set; }
        public string Site_Code { get; set; }
        public string PType_Code { get; set; }
        public string Employee_Code { get; set; }
        public string Company_Code { get; set; }
        public string Contact_Name { get; set; }
        public string Position_Code { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string LineID { get; set; }
        public string CG_Code { get; set; }
        public string Note { get; set; }
        public string Update_by { get; set; }
        public DateTime Last_Update { get; set; }
    }
}
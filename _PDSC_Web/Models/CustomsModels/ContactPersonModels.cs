using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class ContactPersonModels
    {
        public Guid ContactP_Code { get; set; }
        public string PType_Code { get; set; }
        public string PType_Name { get; set; }
        public string Employee_Code { get; set; }
        public string Employee_Name { get; set; }
        public string Company_Code { get; set; }
        public string Company_Name { get; set; }
        public string Contact_Name { get; set; }
        public string Position_Code { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string LineID { get; set; }
        public string CG_Code { get; set; }
        public string CG_Name { get; set; }
        public string Note { get; set; }
        public string Link_Image { get; set; }
    }
}
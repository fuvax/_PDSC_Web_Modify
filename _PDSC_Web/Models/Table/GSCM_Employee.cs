using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.Table
{
    public class GSCM_Employee
    {
        public string Employee_Code { get; set; }
        public string Company { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string LDAP_ID { get; set; }
        public string Work_Status { get; set; }
        public string Mobile_no { get; set; }
        public string Email { get; set; }
        public string LineID { get; set; }
        public string Position_Code { get; set; }

        public bool Flag { get; set; }
        public string Leader { get; set; }
        public string Link_Image { get; set; }
    }
}
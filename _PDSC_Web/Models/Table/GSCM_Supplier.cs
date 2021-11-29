using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.Table
{
    public class GSCM_Supplier
    {
        public string Supplier_Code { get; set; }
        public string Supplier_Name { get; set; }
        public string Status { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}
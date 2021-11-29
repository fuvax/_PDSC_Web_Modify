using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.Table
{
    public class GSCM_Customer
    {
        public string Customer { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string Customer_Type { get; set; }
        public string Customer_Code_GSCM { get; set; }
        public string Customer_Code_HET { get; set; }
        public string Postal_Address { get; set; }
        public string Name_1 { get; set; }
        public string Name_2 { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string Address_3 { get; set; }
        public string Address_4 { get; set; }
        public string Print_Bill_Payment { get; set; }
        public bool IsActive { get; set; }
    }
}
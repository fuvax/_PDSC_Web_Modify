using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.Table
{
    public class GSCM_Site
    {
        public string Site { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Town { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string Telephone_Number { get; set; }
        public int Remain_Day { get; set; }
        public string CS_Code { get; set; }
        public string SM_Code { get; set; }
        public decimal Task_Percent { get; set; }
    }
}
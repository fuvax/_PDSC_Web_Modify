using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class ListPEDetailModel
    {
        public string PE_Code { get; set; }
        public string PE_Name { get; set; }
        public string Leader_Code { get; set; }
        public string Leader_Name { get; set; }
        public string DM_Code { get; set; }
        public string DM_Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
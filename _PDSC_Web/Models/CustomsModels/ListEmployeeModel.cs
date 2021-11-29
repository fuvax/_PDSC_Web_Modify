using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class ListEmployeeModel
    {
        public string Employee_Code { get; set; }
        public string Employee_Name { get; set; }
        public string Position_Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
    }
}
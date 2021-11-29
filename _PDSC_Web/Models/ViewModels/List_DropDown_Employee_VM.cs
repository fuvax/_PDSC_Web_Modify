using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ViewModels
{
    public class List_DropDown_Employee_VM
    {
        public string Employee_Code { get; set; }
        public string Employee_Name { get; set; }
        public string Position_Code { get; set; }
        public string Position_Name { get; set; }
        public string Position_Group { get; set; }
    }
}
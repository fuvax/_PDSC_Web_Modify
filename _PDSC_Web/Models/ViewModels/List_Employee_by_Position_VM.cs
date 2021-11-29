using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ViewModels
{
    public class List_Employee_by_Position_VM
    {
        public string Employee_Code { get; set; }
        public string Name { get; set; }
        public string PDSC_Position_Code { get; set; }
        public string Position_Name { get; set; }
        public string Position_Group { get; set; }
    }
}
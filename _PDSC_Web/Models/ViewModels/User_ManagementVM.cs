using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ViewModels
{
    public class User_ManagementVM
    {
        public string Employee_Code { get; set; }
        public string Name { get; set; }
        public string User_Type { get; set; }
        public string Position_Group { get; set; }
        public string Position_Code { get; set; }
        public string Position_Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string Link_Picture { get; set; }
    }
}
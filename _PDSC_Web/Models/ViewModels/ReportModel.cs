using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ViewModels
{
    public class ReportModel
    {
        [Key]
        public string Employee_Code { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string LDAP_ID { get; set; }
        public string Name_Thai { get; set; }
        public string Work_Status { get; set; }
        public string Mobile_no { get; set; }
        public string Email { get; set; }
        public string LineID { get; set; }
        public string Position_Name { get; set; }
        public string Position_Group { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string IsActive { get; set; }
        public string Manager { get; set; }
    }
}
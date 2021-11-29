using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ViewModels
{
    public class Edit_ContactPerson
    {
        public Guid ContactP_Code { get; set; }
        public string Employee { get; set; }
        public string PersonType { get; set; }
        public string Company { get; set; }
        public string ContectName { get; set; }
        public string Position { get; set; }
        public string Phoneh { get; set; }
        public string Emailh { get; set; }
        public string LineID { get; set; }
        public string ContectGroup { get; set; }
        public string note { get; set; }
    }
}
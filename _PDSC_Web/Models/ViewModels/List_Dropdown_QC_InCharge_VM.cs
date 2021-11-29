using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ViewModels
{
    public class List_Dropdown_QC_InCharge_VM
    {
        [Key]
        public string DICP_Code { get; set; }
        public string DICP_Description { get; set; }
    }
}
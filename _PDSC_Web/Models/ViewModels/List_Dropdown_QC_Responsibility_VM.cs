using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ViewModels
{
    public class List_Dropdown_QC_Responsibility_VM
    {
        [Key]
        public string DResp_Code { get; set; }
        public string DResp_Description { get; set; }
    }
}
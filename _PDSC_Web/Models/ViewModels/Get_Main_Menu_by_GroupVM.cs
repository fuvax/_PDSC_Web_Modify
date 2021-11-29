using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ViewModels
{
    public class Get_Main_Menu_by_GroupVM
    {
        [Key]
        public string MNR_Role { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ViewModels
{
    public class Get_User_LoginVM
    {
        [Key]
        public string Username { get; set; }
        public string User_Type { get; set; }
        public string Position_Group { get; set; }
    }
}
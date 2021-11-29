using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ViewModels
{
    public class Get_Role_by_LoginVM
    {
        [Key]
        public string ROLE_Code { get; set; }
    }
}
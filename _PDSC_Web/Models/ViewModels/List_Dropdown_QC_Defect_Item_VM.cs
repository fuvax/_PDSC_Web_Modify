using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ViewModels
{
    public class List_Dropdown_QC_Defect_Item_VM
    {
        //public int Id { get; set; }
        //public string Parent { get; set; }
        //public int Sorting { get; set; }
        public string Item_No { get; set; }
        public string Item_Description { get; set; }
        public string Type_for_Select { get; set; }
        public string Rank { get; set; }
    }
}
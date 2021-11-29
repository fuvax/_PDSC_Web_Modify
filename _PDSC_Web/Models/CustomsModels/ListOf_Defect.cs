using _PDSC_Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class ListOf_Defect
    {
        public int Id { get; set; }
        public string Parent { get; set; }
        public int Sorting { get; set; }
        public string Item_No { get; set; }
        public string Item_Descriptiom { get; set; }
        public string Type_for_Select { get; set; }
        public string Rank { get; set; }
        public List_Dropdown_QC_Defect_Item_VM GroupOfDefect { get; set; }
        public List<List_Dropdown_QC_Defect_Item_VM> child { get; set; }
    }
}
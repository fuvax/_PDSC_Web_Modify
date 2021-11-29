using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class ListAssignPEModel
    {
        public AssignPE_PageModel ListModel { get; set; }
        public List<AssignPE_PageModel> ListMFG { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class ViewPlanReturnModel
    {
        public int StageNo { get; set; }
        public List<List_ViewPlan_Model> ListViewPlan { get; set; }
    }
}
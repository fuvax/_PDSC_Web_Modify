using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class List_EngineerMaster_Model
    {
        public Guid ID { get; set; }
        public string Position_Group { get; set; }
        public string Engineer_Code { get; set; }
        public string Engineer_Name { get; set; }
        public string Leader_Code { get; set; }
        public string Leader_Name { get; set; }
        public string DM_Code { get; set; }
        public string DM_Name { get; set; }
        public string Site_Code { get; set; }
        public string Site_Name { get; set; }
        public int Site_Handle { get; set; }
    }
}
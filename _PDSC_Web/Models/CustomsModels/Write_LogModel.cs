using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class Write_LogModel
    {
        public string Log_Event { get; set; }
        public string Log_Menu { get; set; }
        public string Log_Detail { get; set; }
        public bool Log_IsError { get; set; }
        public string Log_by { get; set; }
        public DateTime Log_Date { get; set; }
        public string Log_Source { get; set; }
    }
}
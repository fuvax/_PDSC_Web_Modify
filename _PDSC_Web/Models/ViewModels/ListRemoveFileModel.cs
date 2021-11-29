using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ViewModels
{
    public class ListRemoveFileModel
    {
        public string ID { get; set; }
        public List<string> List_source { get; set; }
        public List<string> List_name { get; set; }
        public List<string> List_source_text { get; set; }
        public List<string> List_name_text { get; set; }
        public List<string> ListDelete { get; set; }
        public List<string> ListDelete_name { get; set; }

        public List<string> List_ID { get; set; }
    }
}
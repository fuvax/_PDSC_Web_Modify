using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ViewModels
{
    public class MyFiles
    {
        public byte[] file { get; set; }
        public string name { get; set; }
        public string extension { get; set; }
        public string path { get; set; }
    }
}
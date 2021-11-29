using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ParamiterModels
{
    public class CreateUser
    {
        public string emp { get; set; }
        public string usertype { get; set; }
        public string usergroup { get; set; }
        public string position { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string status { get; set; }
        public string linkimage { get; set; }
    }
}
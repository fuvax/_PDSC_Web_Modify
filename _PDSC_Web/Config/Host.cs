using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Config
{
    public class Host
    {        
        public static string HostIP = ConfigurationManager.AppSettings["host_ip"].ToString();
        public static int Fix_Work_Approve = Convert.ToInt32(ConfigurationManager.AppSettings["fix_work_approve"].ToString());
        public static string HostFile = ConfigurationManager.AppSettings["HostFile"].ToString();
        public static string Domain_Ldap = ConfigurationManager.AppSettings["domain_ldap"].ToString();
        // public static string HostIP = "http://10.2.3.162:8071/"; //Dev
        //  public static string HostIP = "http://10.2.3.162:8100/"; //TEST

        public static string ServicePath { get; set; }
    }
}
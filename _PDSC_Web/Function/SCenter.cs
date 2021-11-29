using _PDSC_Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Function
{
    public class SCenter
    {
        private static List<Get_Main_Menu2> _lstGetMainMenu = new List<Get_Main_Menu2>();
        private static List<GetList_Roles> _lstGetRoles = new List<GetList_Roles>();

       public static List<Get_Main_Menu2> lstGetMainMenu
        {
            get { return _lstGetMainMenu; }
            set { _lstGetMainMenu = value; }
        }

        public static List<GetList_Roles> lstGetRoles
        {
            get { return _lstGetRoles; }
            set { _lstGetRoles = value; }
        }

    }
}
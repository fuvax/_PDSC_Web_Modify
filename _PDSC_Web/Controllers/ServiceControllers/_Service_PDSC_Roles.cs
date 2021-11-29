using _PDSC_Web.Function;
using _PDSC_Web.Models.ViewModels;
using _PDSC_Web.Service;
using _PDSC_Web.Service.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Controllers.ServiceControllers
{
    public class _Service_PDSC_Roles
    {
        _PDSC_Roles s_roles = new _PDSC_Roles();
        EncryptionExtensions encryp = new EncryptionExtensions();

        public List<Get_User_LoginVM> Check_User_Login(string username, string passw)
        {
            List<Get_User_LoginVM> result = new List<Get_User_LoginVM>();
            try
            {
                result = s_roles.Call_Get_User_Login(username, encryp.Encrypt(passw)).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex);
            }
            return result;
        }

        public List<Get_Main_Menu_by_GroupVM> GetList_Main_Menu_by_Group(string usergroup, bool isource)
        {
            List<Get_Main_Menu_by_GroupVM> result = new List<Get_Main_Menu_by_GroupVM>();
            try
            {
                result = s_roles.Call_Get_Main_Menu_by_Group(usergroup, isource).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex);
            }
            return result;
        }

        public List<Get_Role_by_LoginVM> Check_Role_by_Login(string usergroup, bool isource)//, string rolecode)
        {
            List<Get_Role_by_LoginVM> result = new List<Get_Role_by_LoginVM>();
            try
            {
                result = s_roles.Call_Get_Role_by_Login(usergroup, isource).Result;//, rolecode).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex);
            }
            return result;
        }

    }
}
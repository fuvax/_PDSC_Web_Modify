using _PDSC_Web.Models.ParamiterModels;
using _PDSC_Web.Models.ViewModels;
using _PDSC_Web.Service.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Controllers.ServiceControllers
{
    public class __UserManagement
    {
        #region  ## New Object ##

        _PDSC_User_Login user_login = new _PDSC_User_Login();
        _GSCM_Employee emp = new _GSCM_Employee();
        _PDSC_Position position = new _PDSC_Position();


        #endregion

        public List<User_ManagementVM> GetList_User_Management() 
        {
            List<User_ManagementVM> result = new List<User_ManagementVM>();

            try 
            {
                result = user_login.Call_GetList_User_Management().Result;
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error Exception :"+ex);
            }

            return result;
        }

        public List<Dropdown_EmployeeVM> User_Dropdown_Employee()
        {
            List<Dropdown_EmployeeVM> result = new List<Dropdown_EmployeeVM>();

            try
            {
                result = emp.Call_User_Dropdown_Employee().Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Exception :" + ex);
            }

            return result;
        }

        public List<Dropdown_UserGroupVM> User_Dropdown_UserGroup()
        {
            List<Dropdown_UserGroupVM> result = new List<Dropdown_UserGroupVM>();

            try
            {
                result = position.Call_User_Dropdown_UserGroup().Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Exception :" + ex);
            }

            return result;
        }

        public List<Dropdown_PositionVM> User_Dropdown_Position(string Position_Group)
        {
            List<Dropdown_PositionVM> result = new List<Dropdown_PositionVM>();

            try
            {
                result = position.Call_User_Dropdown_Position(Position_Group).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Exception :" + ex);
            }

            return result;
        }

        public bool Save_User_Management(Save_User_ManagementModel list)
        {
            bool result = false;

            try
            {
                result = user_login.Call_Save_User_Management(list).Result; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Exception :" + ex);
            }

            return result;
        }

        public List<Dropdown_UserTypeVM> User_Dropdown_UserType() 
        {
            List<Dropdown_UserTypeVM> result = new List<Dropdown_UserTypeVM>();

            try
            {
                result = user_login.Call_User_Dropdown_UserType().Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Exception :" + ex);
            }

            return result;
        }

        public bool Delete_User_Management(EmpolyeeModel list) 
        {
            bool result = false;
            try
            {
                result = user_login.Call_Delete_User_Management(list).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Exception :" + ex);
            }

            return result;
        }

        public bool Check_User_Duplicate(string Username) 
        {
            bool checkStatus = false; 

            try 
            {
                var result = emp.Call_GetEmployee().Result
                                .Where(i => i.Username.Contains(Username)).ToList();

                if (result.Count > 0)
                {
                    checkStatus = true;
                }


            }
            catch (Exception ex) 
            {

            }
            return checkStatus;
        }

    }
}
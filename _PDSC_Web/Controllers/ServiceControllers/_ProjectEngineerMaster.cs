using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Models.ViewModels;
using _PDSC_Web.Service.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Controllers.ServiceControllers
{
    public class _ProjectEngineerMaster
    {
        _GSCM_Employee _employee = new _GSCM_Employee();
        _Engineer_Master _pe = new _Engineer_Master();

        public List<ListAllEmployeeModel> Get_PE()
        {
            List<ListAllEmployeeModel> result = new List<ListAllEmployeeModel>();
            try
            {
                List<ListAllEmployeeModel> list = _employee.Call_GetEmployee().Result;
                result = list.Where(i => i.Position_Code == "130" || i.Position_Code == "230" || i.Position_Code == "330").ToList();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Meassge : " + ex);

            }
            return result;
        }

        public List<ListAllEmployeeModel> Get_Leader()
        {
            List<ListAllEmployeeModel> result = new List<ListAllEmployeeModel>();
            try
            {
                List<ListAllEmployeeModel> list = _employee.Call_GetEmployee().Result;   //120 is leader
                result = list.Where(i => i.Position_Code == "120").ToList();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Meassge : " + ex);

            }
            return result;
        }

        public List<ListAllEmployeeModel> Get_Leader_By_EngineerGroupCode(string Engineer_Code)
        {
            List<ListAllEmployeeModel> result = new List<ListAllEmployeeModel>();
            string Position_Code = "";
            string Position_Code2 = "";
            try
            {
                //find engineer groupCode

                var listEngineer = (_employee.Call_GetEmployee().Result)
                                .Where(i => i.Employee_Code == Engineer_Code)
                                .Select(i => i.Position_Group).FirstOrDefault();

                switch (listEngineer)
                {
                    case "PE": Position_Code = "120"; Position_Code2 = "110"; break;
                    case "Testing": Position_Code = "220"; Position_Code2 = "210"; break;
                    case "QC": Position_Code = "320"; Position_Code2 = "310"; break;
                }

                List<ListAllEmployeeModel> list = _employee.Call_GetEmployee().Result;
                result = list.Where(i => (i.Position_Code == Position_Code || i.Position_Code == Position_Code2) && i.IsActive == "true").ToList();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Meassge : " + ex);

            }
            return result;
        }

        public List<ListAllEmployeeModel> Get_DM_By_EngineerGroupCode(string Engineer_Code)
        {
            List<ListAllEmployeeModel> result = new List<ListAllEmployeeModel>();
            string Position_Code = "";
            try
            {
                //find engineer groupCode

                var listEngineer = (_employee.Call_GetEmployee().Result)
                                .Where(i => i.Employee_Code == Engineer_Code)
                                .Select(i => i.Position_Group).FirstOrDefault();

                switch (listEngineer)
                {
                    case "PE": Position_Code = "110"; break;
                    case "Testing": Position_Code = "210"; break;
                    case "QC": Position_Code = "310"; break;
                }

                List<ListAllEmployeeModel> list = _employee.Call_GetEmployee().Result;
                result = list.Where(i => i.Position_Code == Position_Code && i.IsActive == "true").ToList();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Meassge : " + ex);

            }
            return result;
        }

        public List<ListAllEmployeeModel> Get_DM()
        {
            List<ListAllEmployeeModel> result = new List<ListAllEmployeeModel>();
            try
            {
                List<ListAllEmployeeModel> list = _employee.Call_GetEmployee().Result;   //110 gm project
                result = list.Where(i => i.Position_Code == "110").ToList();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Meassge : " + ex);

            }
            return result;
        }

        public string CheckPE_Master(string PE_Code)
        {
            string status = "";

            try
            {
                status = _pe.Call_CheckProjectEngineerMaster(PE_Code).Result;

                return status;
            }
            catch (Exception ex)
            {
                return ex.ToString(); ;
            }
        }

        public string CreateProjecEngineer(Save_Engineer_Master_Model list)
        {
            string status = "";

            try
            {
                status = _pe.Call_Save_PE_Master_Page(list).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Exception : " + ex);
            }
            return status;
        }

        public string UpdateProjectEngineerMaster(Save_Engineer_Master_Model list)
        {
            string status = "";

            try
            {
                status = _pe.Call_Save_PE_Master_Page(list).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Exception : " + ex);
            }
            return status;
        }

        public List<List_EngineerMaster_Model> Load_PE_MasterPage()
        {
            List<List_EngineerMaster_Model> result = new List<List_EngineerMaster_Model>();
            try
            {
                result = _pe.Call_GetList_For_Engineer_Master_Page().Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Exception : " + ex);
            }
            return result;
        }

        public string UpdateStatusPE(string PE_Code)
        {
            string status = "";

            try
            {
                status = _pe.Call_UpdateStatus(PE_Code).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Exception : " + ex);
            }
            return status;
        }
        public List<List_EngineerAll_VM> GetList_Dropdown_Engineer() 
        {
            List<List_EngineerAll_VM> result = new List<List_EngineerAll_VM>();
            try 
            {
                result = _pe.Call_GetList_Dropdown_Engineer().Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Exception : " + ex);
            }
            return result;
        }

        public List<List_EngineerAll_VM> GetList_Dropdown_Engineer_All()
        {
            List<List_EngineerAll_VM> result = new List<List_EngineerAll_VM>();
            try
            {
                result = _pe.Call_GetList_Dropdown_Engineer_All().Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Exception : " + ex);
            }
            return result;
        }

    }
}
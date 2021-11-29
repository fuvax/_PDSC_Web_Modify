using _PDSC_Web.Config;
using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Models.ParamiterModels;
using _PDSC_Web.Models.Table;
using _PDSC_Web.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace _PDSC_Web.Service.Table
{
    public class _GSCM_Employee
    {
        private HttpClient client = new HttpClient();
        private string ServiceName;
        private string url;


        public async Task<List<ListAllEmployeeModel>> Call_GetEmployee()
        {
            Host.ServicePath = "api/GSCM_Employee/";
            ServiceName = "GetList_All_Employee_Page";

            List<ListAllEmployeeModel> obj = new List<ListAllEmployeeModel>();
            string path = "";

            try
            {
                client.Timeout = TimeSpan.FromSeconds(1000);
                path = Host.HostIP + Host.ServicePath + ServiceName;
                using (HttpResponseMessage response = await new HttpClient().GetAsync(path).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        obj = await response.Content.ReadAsJsonAsync<List<ListAllEmployeeModel>>().ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }

            return obj;
        }

        public async Task<List<ListEmployeeModel>> Call_GetListEmployee(string EmpCode)
        {
            Host.ServicePath = "api/GSCM_Employee/";
            ServiceName = "GetListEmployee";


            string path = "";

            GSCM_Employee list = new GSCM_Employee()
            {
                Employee_Code = EmpCode
            };

            HttpResponseMessage response = null;

            try
            {

                string serialisedMessage = JsonConvert.SerializeObject(list);
                // client.Timeout = TimeSpan.FromSeconds(60);
                path = Host.HostIP + Host.ServicePath + ServiceName;


                var content = new StringContent(serialisedMessage, Encoding.UTF8, "application/json");
                response = await client.PostAsync(path, content).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }


            return JsonConvert.DeserializeObject<List<ListEmployeeModel>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<ListDropDownEmp_VM>> Call_GetList_Dropdown_Employee_Create_CP(string SiteCode)
        {
            Host.ServicePath = "api/GSCM_Employee/";
            ServiceName = "GetList_Dropdown_Employee_Create_CP";


            string path = "";

            SiteModel list = new SiteModel()
            {
                Site = SiteCode
            };

            HttpResponseMessage response = null;

            try
            {

                string serialisedMessage = JsonConvert.SerializeObject(list);
                // client.Timeout = TimeSpan.FromSeconds(60);
                path = Host.HostIP + Host.ServicePath + ServiceName;


                var content = new StringContent(serialisedMessage, Encoding.UTF8, "application/json");
                response = await client.PostAsync(path, content).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }


            return JsonConvert.DeserializeObject<List<ListDropDownEmp_VM>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<List_DropDown_Employee_VM>> Call_Report_DropDown_Employee(string Type)
        {
            Host.ServicePath = "api/GSCM_Employee/";
            ServiceName = "Report_DropDown_Employee";


            string path = "";

            EngineerTypeModel list = new EngineerTypeModel()
            {
               Type = Type
            };

            HttpResponseMessage response = null;

            try
            {

                string serialisedMessage = JsonConvert.SerializeObject(list);
                // client.Timeout = TimeSpan.FromSeconds(60);
                path = Host.HostIP + Host.ServicePath + ServiceName;


                var content = new StringContent(serialisedMessage, Encoding.UTF8, "application/json");
                response = await client.PostAsync(path, content).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }


            return JsonConvert.DeserializeObject<List<List_DropDown_Employee_VM>>(await response.Content.ReadAsStringAsync());
        }
        //
        public async Task<List<Dropdown_EmployeeVM>> Call_User_Dropdown_Employee()
        {
            Host.ServicePath = "api/GSCM_Employee/";
            ServiceName = "User_Dropdown_Employee";

            List<Dropdown_EmployeeVM> obj = new List<Dropdown_EmployeeVM>();
            string path = "";

            try
            {
                client.Timeout = TimeSpan.FromSeconds(1000);
                path = Host.HostIP + Host.ServicePath + ServiceName;
                using (HttpResponseMessage response = await new HttpClient().GetAsync(path).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        obj = await response.Content.ReadAsJsonAsync<List<Dropdown_EmployeeVM>>().ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }

            return obj;
        }
    }
}
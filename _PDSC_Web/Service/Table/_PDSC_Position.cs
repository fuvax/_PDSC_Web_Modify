using _PDSC_Web.Config;
using _PDSC_Web.Models.ParamiterModels;
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
    public class _PDSC_Position
    {
        private HttpClient client = new HttpClient();
        private string ServiceName;
        private string url;


        public async Task<List<List_DropDown_Engineer_Type_VM>> Call_Report_DropDown_Engineer_Type()
        {
            Host.ServicePath = "api/PDSC_Position/";
            ServiceName = "Report_DropDown_Engineer_Type";

            List<List_DropDown_Engineer_Type_VM> obj = new List<List_DropDown_Engineer_Type_VM>();
            string path = "";

            try
            {
                client.Timeout = TimeSpan.FromSeconds(1000);
                path = Host.HostIP + Host.ServicePath + ServiceName;
                using (HttpResponseMessage response = await new HttpClient().GetAsync(path).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        obj = await response.Content.ReadAsJsonAsync<List<List_DropDown_Engineer_Type_VM>>().ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }

            return obj;
        }

        public async Task<List<List_Position_GroupPE_VM>> Call_Report_DropDown_Position_GroupPE()
        {
            Host.ServicePath = "api/PDSC_Position/";
            ServiceName = "Report_DropDown_Position_GroupPE";

            List<List_Position_GroupPE_VM> obj = new List<List_Position_GroupPE_VM>();
            string path = "";

            try
            {
                client.Timeout = TimeSpan.FromSeconds(1000);
                path = Host.HostIP + Host.ServicePath + ServiceName;
                using (HttpResponseMessage response = await new HttpClient().GetAsync(path).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        obj = await response.Content.ReadAsJsonAsync<List<List_Position_GroupPE_VM>>().ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }

            return obj;
        }

        public async Task<List<List_Employee_by_Position_VM>> Call_Report_DropDown_Employee_by_Position(string positionCode)
        {
            Host.ServicePath = "api/PDSC_Position/";
            ServiceName = "Report_DropDown_Employee_by_Position";


            string path = "";

            PositionModel list = new PositionModel()
            {
               Position_Code = positionCode            
            };

            HttpResponseMessage response = null;

            try
            {

                string serialisedMessage = JsonConvert.SerializeObject(list);
                path = Host.HostIP + Host.ServicePath + ServiceName;


                var content = new StringContent(serialisedMessage, Encoding.UTF8, "application/json");
                response = await client.PostAsync(path, content).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }


            return JsonConvert.DeserializeObject<List<List_Employee_by_Position_VM>>(await response.Content.ReadAsStringAsync());
        }
        

        public async Task<List<Dropdown_UserGroupVM>> Call_User_Dropdown_UserGroup()
        {
            Host.ServicePath = "api/PDSC_Position/";
            ServiceName = "User_Dropdown_UserGroup";

            List<Dropdown_UserGroupVM> obj = new List<Dropdown_UserGroupVM>();
            string path = "";

            try
            {
                client.Timeout = TimeSpan.FromSeconds(1000);
                path = Host.HostIP + Host.ServicePath + ServiceName;
                using (HttpResponseMessage response = await new HttpClient().GetAsync(path).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        obj = await response.Content.ReadAsJsonAsync<List<Dropdown_UserGroupVM>>().ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }

            return obj;
        }

        public async Task<List<Dropdown_PositionVM>> Call_User_Dropdown_Position(string PositionGroup)
        {
            Host.ServicePath = "api/PDSC_Position/";
            ServiceName = "User_Dropdown_Position";


            string path = "";

            Position_Group_Model list = new Position_Group_Model()
            {
               Position_Group = PositionGroup
            };

            HttpResponseMessage response = null;

            try
            {

                string serialisedMessage = JsonConvert.SerializeObject(list);
                path = Host.HostIP + Host.ServicePath + ServiceName;


                var content = new StringContent(serialisedMessage, Encoding.UTF8, "application/json");
                response = await client.PostAsync(path, content).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }


            return JsonConvert.DeserializeObject<List<Dropdown_PositionVM>>(await response.Content.ReadAsStringAsync());
        }

    }
}
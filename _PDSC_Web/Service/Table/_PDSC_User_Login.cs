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
    public class _PDSC_User_Login
    {
        private HttpClient client = new HttpClient();
        private string ServiceName;
        private string url;


        public async Task<List<User_ManagementVM>> Call_GetList_User_Management()
        {
            Host.ServicePath = "api/PDSC_User_Login/";
            ServiceName = "GetList_User_Management";

            List<User_ManagementVM> obj = new List<User_ManagementVM>();
            string path = "";

            try
            {
                client.Timeout = TimeSpan.FromSeconds(1000);
                path = Host.HostIP + Host.ServicePath + ServiceName;
                using (HttpResponseMessage response = await new HttpClient().GetAsync(path).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        obj = await response.Content.ReadAsJsonAsync<List<User_ManagementVM>>().ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }

            return obj;
        }
       

        public async Task<bool> Call_Save_User_Management(Save_User_ManagementModel list)
        {
            Host.ServicePath = "api/PDSC_User_Login/";
            ServiceName = "Save_User_Management";


            string path = "";

           

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


            return JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
        }
    
        public async Task<List<Dropdown_UserTypeVM>> Call_User_Dropdown_UserType()
        {
            Host.ServicePath = "api/PDSC_User_Login/";
            ServiceName = "User_Dropdown_UserType";

            List<Dropdown_UserTypeVM> obj = new List<Dropdown_UserTypeVM>();
            string path = "";

            try
            {
                client.Timeout = TimeSpan.FromSeconds(1000);
                path = Host.HostIP + Host.ServicePath + ServiceName;
                using (HttpResponseMessage response = await new HttpClient().GetAsync(path).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        obj = await response.Content.ReadAsJsonAsync<List<Dropdown_UserTypeVM>>().ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }

            return obj;
        }

        public async Task<bool> Call_Delete_User_Management(EmpolyeeModel list)
        {
            Host.ServicePath = "api/PDSC_User_Login/";
            ServiceName = "Delete_User_Management";


            string path = "";



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


            return JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
        }
    }
}
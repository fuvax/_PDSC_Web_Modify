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
    public class _PDSC_Roles
    {
        private HttpClient client = new HttpClient();
        private string ServiceName;
        private string url;
        

        public async Task<List<Get_User_LoginVM>> Call_Get_User_Login(string username, string passw)
        {
            Host.ServicePath = "api/PDSC_Roles/";
            ServiceName = "Get_User_Login";


            string path = "";

            LoginModel list = new LoginModel()
            {
                Username = username,
                pwd = passw//encryp.Encrypt(passw)
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


            return JsonConvert.DeserializeObject<List<Get_User_LoginVM>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<Get_Role_by_LoginVM>> Call_Get_Role_by_Login(string usergroup, bool isource)//, string rolecode)
        {
            Host.ServicePath = "api/PDSC_Roles/";
            ServiceName = "Get_Role_by_Login";


            string path = "";

            CheckRolesModel list = new CheckRolesModel()
            {
                User_Group = usergroup,
                Role_Source = isource
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


            return JsonConvert.DeserializeObject<List<Get_Role_by_LoginVM>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<Get_Main_Menu_by_GroupVM>> Call_Get_Main_Menu_by_Group(string usergroup, bool isource)
        {
            Host.ServicePath = "api/PDSC_Roles/";
            ServiceName = "Get_Main_Menu_by_Group";


            string path = "";

            User_GroupModel list = new User_GroupModel()
            {
                User_Group = usergroup,
                Role_Source = isource
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


            return JsonConvert.DeserializeObject<List<Get_Main_Menu_by_GroupVM>>(await response.Content.ReadAsStringAsync());
        }


    }
}
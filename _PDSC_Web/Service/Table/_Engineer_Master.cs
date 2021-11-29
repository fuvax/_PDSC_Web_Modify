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
    public class _Engineer_Master
    {
        private HttpClient client = new HttpClient();
        private string ServiceName;
        private string url;



        public async Task<string> Call_Save_PE_Master_Page(Save_Engineer_Master_Model list)
        {
            Host.ServicePath = "api/Engineer_Master/";
            ServiceName = "Save_Engineer_Master_Page";


            string path = "";

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


            return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> Call_CheckProjectEngineerMaster(string PE_Code)
        {
            Host.ServicePath = "api/Engineer_Master/";
            ServiceName = "CheckProjectEngineerMaster";


            string path = "";

            HttpResponseMessage response = null;

            Engineer_Master listPE = new Engineer_Master()
            {
                PEM_Engineer_Code = PE_Code
            };

            try
            {

                string serialisedMessage = JsonConvert.SerializeObject(listPE);

                client.Timeout = TimeSpan.FromSeconds(60);
                path = Host.HostIP + Host.ServicePath + ServiceName;


                var content = new StringContent(serialisedMessage, Encoding.UTF8, "application/json");
                response = await client.PostAsync(path, content).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }


            return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> Call_UpdateEngineerMaster(Engineer_Master list)
        {
            Host.ServicePath = "api/Engineer_Master/";
            ServiceName = "UpdateEngineerMaster";


            string path = "";

            HttpResponseMessage response = null;

            try
            {

                string serialisedMessage = JsonConvert.SerializeObject(list);

                client.Timeout = TimeSpan.FromSeconds(60);
                path = Host.HostIP + Host.ServicePath + ServiceName;


                var content = new StringContent(serialisedMessage, Encoding.UTF8, "application/json");
                response = await client.PostAsync(path, content).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }


            return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
        }



        public async Task<string> Call_UpdateStatus(string PE_Code)
        {
            Host.ServicePath = "api/Engineer_Master/";
            ServiceName = "UpdateStatus";


            string path = "";

            HttpResponseMessage response = null;

            Engineer_Master list = new Engineer_Master()
            {
                PEM_Engineer_Code = PE_Code
            };

            try
            {

                string serialisedMessage = JsonConvert.SerializeObject(list);

                client.Timeout = TimeSpan.FromSeconds(60);
                path = Host.HostIP + Host.ServicePath + ServiceName;


                var content = new StringContent(serialisedMessage, Encoding.UTF8, "application/json");
                response = await client.PostAsync(path, content).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }


            return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<ListPEDetailModel>> Call_Get_Engineer_Detail(string PE_Code)
        {
            Host.ServicePath = "api/Engineer_Master/";
            ServiceName = "Get_Engineer_Detail";

            string path = "";

            HttpResponseMessage response = null;

            Engineer_Master list = new Engineer_Master()
            {
                PEM_Engineer_Code = PE_Code
            };

            try
            {

                string serialisedMessage = JsonConvert.SerializeObject(list);

                client.Timeout = TimeSpan.FromSeconds(60);
                path = Host.HostIP + Host.ServicePath + ServiceName;


                var content = new StringContent(serialisedMessage, Encoding.UTF8, "application/json");
                response = await client.PostAsync(path, content).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }


            return JsonConvert.DeserializeObject<List<ListPEDetailModel>>(await response.Content.ReadAsStringAsync());


        }

        public async Task<List<ListPEDetailModel>> Call_GetList_Dropdown_PE(string SiteCode)
        {
            Host.ServicePath = "api/Engineer_Master/";
            ServiceName = "GetList_Dropdown_PE";

           
            string path = "";

            HttpResponseMessage response = null;

            SiteModel list = new SiteModel()
            {
                Site = SiteCode
            };

            try
            {

                string serialisedMessage = JsonConvert.SerializeObject(list);

                client.Timeout = TimeSpan.FromSeconds(60);
                path = Host.HostIP + Host.ServicePath + ServiceName;


                var content = new StringContent(serialisedMessage, Encoding.UTF8, "application/json");
                response = await client.PostAsync(path, content).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }


            return JsonConvert.DeserializeObject<List<ListPEDetailModel>>(await response.Content.ReadAsStringAsync());

        }
       
        public async Task<List<List_EngineerAll_VM>> Call_GetList_Dropdown_Engineer_All()
        {
            Host.ServicePath = "api/Engineer_Master/";
            ServiceName = "GetList_Dropdown_Engineer_All";

            List<List_EngineerAll_VM> obj = new List<List_EngineerAll_VM>();
            string path = "";

            try
            {
                client.Timeout = TimeSpan.FromSeconds(1000);
                path = Host.HostIP + Host.ServicePath + ServiceName;
                using (HttpResponseMessage response = await new HttpClient().GetAsync(path).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        obj = await response.Content.ReadAsJsonAsync<List<List_EngineerAll_VM>>().ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }

            return obj;
        }

        public async Task<List<List_EngineerAll_VM>> Call_GetList_Dropdown_Engineer()
        {
            Host.ServicePath = "api/Engineer_Master/";
            ServiceName = "GetList_Dropdown_Engineer";

            List<List_EngineerAll_VM> obj = new List<List_EngineerAll_VM>();
            string path = "";

            try
            {
                client.Timeout = TimeSpan.FromSeconds(1000);
                path = Host.HostIP + Host.ServicePath + ServiceName;
                using (HttpResponseMessage response = await new HttpClient().GetAsync(path).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        obj = await response.Content.ReadAsJsonAsync<List<List_EngineerAll_VM>>().ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }

            return obj;
        }

        public async Task<List<List_Dropdown_Leader_GroupPE_by_DM_VM>> Call_Report_Dropdown_Leader_GroupPE_by_DM(string DMCode)
        {
            Host.ServicePath = "api/Engineer_Master/";
            ServiceName = "Report_Dropdown_Leader_GroupPE_by_DM";

            string path = "";

            HttpResponseMessage response = null;

            DMModel list = new DMModel()
            {
                DM_Code = DMCode
            };

            try
            {

                string serialisedMessage = JsonConvert.SerializeObject(list);

                client.Timeout = TimeSpan.FromSeconds(60);
                path = Host.HostIP + Host.ServicePath + ServiceName;


                var content = new StringContent(serialisedMessage, Encoding.UTF8, "application/json");
                response = await client.PostAsync(path, content).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }


            return JsonConvert.DeserializeObject<List<List_Dropdown_Leader_GroupPE_by_DM_VM>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<List_Dropdown_DM_GroupPE_VM>> Call_Report_Dropdown_DM_GroupPE()
        {
            Host.ServicePath = "api/Engineer_Master/";
            ServiceName = "Report_Dropdown_DM_GroupPE";

            List<List_Dropdown_DM_GroupPE_VM> obj = new List<List_Dropdown_DM_GroupPE_VM>();
            string path = "";

            try
            {
                client.Timeout = TimeSpan.FromSeconds(1000);
                path = Host.HostIP + Host.ServicePath + ServiceName;
                using (HttpResponseMessage response = await new HttpClient().GetAsync(path).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        obj = await response.Content.ReadAsJsonAsync<List<List_Dropdown_DM_GroupPE_VM>>().ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }

            return obj;
        }



        #region #### Customs Service ###

        public async Task<List<List_EngineerMaster_Model>> Call_GetList_For_Engineer_Master_Page()
        {
            Host.ServicePath = "api/Engineer_Master/";
            ServiceName = "GetList_For_Engineer_Master_Page";

            List<List_EngineerMaster_Model> obj = new List<List_EngineerMaster_Model>();
            string path = "";

            try
            {
                client.Timeout = TimeSpan.FromSeconds(1000);
                path = Host.HostIP + Host.ServicePath + ServiceName;
                using (HttpResponseMessage response = await new HttpClient().GetAsync(path).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        obj = await response.Content.ReadAsJsonAsync<List<List_EngineerMaster_Model>>().ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }

            return obj;
        }

        #endregion
    }
}
using _PDSC_Web.Config;
using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Models.Table;
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
    public class _ContectPerson
    {
        private HttpClient client = new HttpClient();
        private string ServiceName;
        private string url;

        public async Task<string> CallCreate_ContectPerson(Contact_Person list)
        {
            Host.ServicePath = "api/ContectPerson/";
            ServiceName = "CreateContectPerson";


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

        public async Task<List<ContactPersonModels>> Call_GetList_ContactPerson_HET_Page(string SiteCode)
        {
            Host.ServicePath = "api/ContectPerson/";
            ServiceName = "GetList_ContactPerson_HET_Page";


            string path = "";

            GSCM_Site list = new GSCM_Site()
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


            return JsonConvert.DeserializeObject<List<ContactPersonModels>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<ContactPersonModels>> Call_GetList_ContactPerson_Customer_Page(string SiteCode)
        {
            Host.ServicePath = "api/ContectPerson/";
            ServiceName = "GetList_ContactPerson_Customer_Page";


            string path = "";

            GSCM_Site list = new GSCM_Site()
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


            return JsonConvert.DeserializeObject<List<ContactPersonModels>>(await response.Content.ReadAsStringAsync());
        }
        public async Task<List<ContactPersonModels>> Call_GetList_ContactPerson_Supplier_Page(string SiteCode)
        {
            Host.ServicePath = "api/ContectPerson/";
            ServiceName = "GetList_ContactPerson_Supplier_Page";


            string path = "";

            GSCM_Site list = new GSCM_Site()
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


            return JsonConvert.DeserializeObject<List<ContactPersonModels>>(await response.Content.ReadAsStringAsync());
        }
        public async Task<List<ContactPersonModels>> Call_GetList_ContactPerson_SubCon_Page(string SiteCode)
        {
            Host.ServicePath = "api/ContectPerson/";
            ServiceName = "GetList_ContactPerson_SubCon_Page";


            string path = "";

            GSCM_Site list = new GSCM_Site()
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


            return JsonConvert.DeserializeObject<List<ContactPersonModels>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> Call_Delete_ContactPerson_byRow_Page(DeleteContactPersonModels list)
        {
            Host.ServicePath = "api/ContectPerson/";
            ServiceName = "Delete_ContactPerson_byRow_Page";


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

        public async Task<string> Call_Save_ContactPerson_Page(SaveContectPersonModels list)
        {
            Host.ServicePath = "api/ContectPerson/";
            ServiceName = "Save_ContactPerson_Page";


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
    }
}

using _PDSC_Web.Config;
using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Models.ParamiterModels;
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
    public class _Manufacturing
    {
        private HttpClient client = new HttpClient();
        private string ServiceName;
        private string url;

        public async Task<List<Manufacturing_Model>> Call_GetList_Manufacturing_Page(string sitecode)
        {
            Host.ServicePath = "api/Manufacturing/";
            ServiceName = "GetList_Manufacturing_Page";


            string path = "";

            HttpResponseMessage response = null;

            SiteCodeModel site = new SiteCodeModel()
            {
                SiteCode = sitecode
            };

            try
            {

                string serialisedMessage = JsonConvert.SerializeObject(site);

                // client.Timeout = TimeSpan.FromSeconds(60);
                path = Host.HostIP + Host.ServicePath + ServiceName;


                var content = new StringContent(serialisedMessage, Encoding.UTF8, "application/json");
                response = await client.PostAsync(path, content).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }


            return JsonConvert.DeserializeObject<List<Manufacturing_Model>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<Manufacturing>> Call_Get_Manufacturing_List()
        {
            Host.ServicePath = "api/Manufacturing/";
            ServiceName = "Get_Manufacturing_List";

            List<Manufacturing> obj = new List<Manufacturing>();
            string path = "";

            try
            {
                client.Timeout = TimeSpan.FromSeconds(1000);
                path = Host.HostIP + Host.ServicePath + ServiceName;
                using (HttpResponseMessage response = await new HttpClient().GetAsync(path).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        obj = await response.Content.ReadAsJsonAsync<List<Manufacturing>>().ConfigureAwait(false);
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
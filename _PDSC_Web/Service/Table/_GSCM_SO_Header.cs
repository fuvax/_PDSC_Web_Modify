using _PDSC_Web.Config;
using _PDSC_Web.Models.CustomsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace _PDSC_Web.Service.Table
{
    public class _GSCM_SO_Header
    {
        private HttpClient client = new HttpClient();
        private string ServiceName;
        private string url;

        public async Task<List<ProjectHeader_Model>> Call_GetList_ProjectHeader_Page()
        {
            Host.ServicePath = "api/GSCM_SO_Header/";
            ServiceName = "GetList_ProjectHeader_Page";

            List<ProjectHeader_Model> obj = new List<ProjectHeader_Model>();
            string path = "";

            try
            {
                client.Timeout = TimeSpan.FromSeconds(1000);
                path = Host.HostIP + Host.ServicePath + ServiceName;
                using (HttpResponseMessage response = await new HttpClient().GetAsync(path).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        obj = await response.Content.ReadAsJsonAsync<List<ProjectHeader_Model>>().ConfigureAwait(false);
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

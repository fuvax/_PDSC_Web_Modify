using _PDSC_Web.Config;
using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace _PDSC_Web.Service.Table
{
    public class _GSCM_Sub_Con
    {
        private HttpClient client = new HttpClient();
        private string ServiceName;
        private string url;

        public async Task<List<DDCompany_SubConModel>> Call_DropDownCompany_SubCon()
        {
            Host.ServicePath = "api/GSCM_Sub_Con/";
            ServiceName = "DropDownCompany_SubCon";

            List<DDCompany_SubConModel> obj = new List<DDCompany_SubConModel>();
            string path = "";

            try
            {
                client.Timeout = TimeSpan.FromSeconds(1000);
                path = Host.HostIP + Host.ServicePath + ServiceName;
                using (HttpResponseMessage response = await new HttpClient().GetAsync(path).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        obj = await response.Content.ReadAsJsonAsync<List<DDCompany_SubConModel>>().ConfigureAwait(false);
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
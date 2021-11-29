using _PDSC_Web.Config;
using _PDSC_Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace _PDSC_Web.Service.Table
{
    public class _Defect_Rank
    {
        private HttpClient client = new HttpClient();
        private string ServiceName;
        private string url;

        public async Task<List<Dropdown_QC_Defect_Rank_VM>> Call_GetList_Dropdown_QC_Defect_Rank()
        {
            Host.ServicePath = "api/Defect_Rank/";
            ServiceName = "GetList_Dropdown_QC_Defect_Rank";

            List<Dropdown_QC_Defect_Rank_VM> obj = new List<Dropdown_QC_Defect_Rank_VM>();
            string path = "";

            try
            {
                client.Timeout = TimeSpan.FromSeconds(1000);
                path = Host.HostIP + Host.ServicePath + ServiceName;
                using (HttpResponseMessage response = await new HttpClient().GetAsync(path).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        obj = await response.Content.ReadAsJsonAsync<List<Dropdown_QC_Defect_Rank_VM>>().ConfigureAwait(false);
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
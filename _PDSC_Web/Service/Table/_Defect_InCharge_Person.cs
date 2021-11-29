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
    public class _Defect_InCharge_Person
    {
        private HttpClient client = new HttpClient();
        private string ServiceName;
        private string url;


        public async Task<List<List_Dropdown_QC_InCharge_VM>> Call_GetList_Dropdown_QC_InCharge_Person()
        {
            Host.ServicePath = "api/Defect_InCharge_Person/";
            ServiceName = "GetList_Dropdown_QC_InCharge_Person";

            List<List_Dropdown_QC_InCharge_VM> obj = new List<List_Dropdown_QC_InCharge_VM>();
            string path = "";

            try
            {
                client.Timeout = TimeSpan.FromSeconds(1000);
                path = Host.HostIP + Host.ServicePath + ServiceName;
                using (HttpResponseMessage response = await new HttpClient().GetAsync(path).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        obj = await response.Content.ReadAsJsonAsync<List<List_Dropdown_QC_InCharge_VM>>().ConfigureAwait(false);
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
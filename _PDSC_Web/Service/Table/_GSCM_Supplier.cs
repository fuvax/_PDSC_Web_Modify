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
    public class _GSCM_Supplier
    {
        private HttpClient client = new HttpClient();
        private string ServiceName;
        private string url;

        public async Task<List<DDCompany_SupplierModel>> Call_DropDownCompany_Supplier()
        {
            Host.ServicePath = "api/GSCM_Supplier/";
            ServiceName = "DropDownCompany_Supplier";

            List<DDCompany_SupplierModel> obj = new List<DDCompany_SupplierModel>();
            string path = "";

            try
            {
                client.Timeout = TimeSpan.FromSeconds(1000);
                path = Host.HostIP + Host.ServicePath + ServiceName;
                using (HttpResponseMessage response = await new HttpClient().GetAsync(path).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        obj = await response.Content.ReadAsJsonAsync<List<DDCompany_SupplierModel>>().ConfigureAwait(false);
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
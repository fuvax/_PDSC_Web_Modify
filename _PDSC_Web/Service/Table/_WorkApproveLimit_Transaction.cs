using _PDSC_Web.Config;
using _PDSC_Web.Models.CustomsModels;
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
    public class _WorkApproveLimit_Transaction
    {
        private HttpClient client = new HttpClient();
        private string ServiceName;
        private string url;

        public async Task<string> Call_Update_WorkAppLimit(UpdateInsetWorkApproveLimitModel list)
        {
            Host.ServicePath = "api/WorkApproveLimit_Transaction/";
            ServiceName = "Update_WorkAppLimit";


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
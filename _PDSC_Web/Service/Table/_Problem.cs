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
    public class _Problem
    {
        private HttpClient client = new HttpClient();
        private string ServiceName;
        private string url;

        public async Task<List<GetList_Problem_by_TaskModel>> Call_GetList_Problem_by_Task(string TaskCode)
        {
            Host.ServicePath = "api/Problem/";
            ServiceName = "GetList_Problem_by_Task";

            string path = "";

            HttpResponseMessage response = null;

            ListTransactionModel list = new ListTransactionModel()
            {
                Task_Code = TaskCode
            };
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


            return JsonConvert.DeserializeObject<List<GetList_Problem_by_TaskModel>>(await response.Content.ReadAsStringAsync());
        }
    }
}
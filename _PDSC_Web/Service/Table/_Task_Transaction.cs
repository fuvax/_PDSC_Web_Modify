using _PDSC_Web.Config;
using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Models.ParamiterModels;
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
    public class _Task_Transaction
    {
        private HttpClient client = new HttpClient();
        private string ServiceName;
        private string url;

        public async Task<bool> Call_Save_Task_Transaction_by_Task(Save_Task_Transaction_by_TaskModel obj)
        {
            Host.ServicePath = "api/Task_Transaction/";
            ServiceName = "Save_Task_Transaction_by_Task";


            string path = "";

            HttpResponseMessage response = null;


            try
            {

                string serialisedMessage = JsonConvert.SerializeObject(obj);

              
                   path = Host.HostIP + Host.ServicePath + ServiceName;
             



                var content = new StringContent(serialisedMessage, Encoding.UTF8, "application/json");
                response = await client.PostAsync(path, content).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }


            return JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<List_Report_Working_History_VM>> Call_Report_Working_History(Report_Working_HistoryModel obj)
        {
            Host.ServicePath = "api/Task_Transaction/";
            ServiceName = "Report_Working_History";


            string path = "";

            HttpResponseMessage response = null;


            try
            {

                string serialisedMessage = JsonConvert.SerializeObject(obj);

               
                path = Host.HostIP + Host.ServicePath + ServiceName;
              

                var content = new StringContent(serialisedMessage, Encoding.UTF8, "application/json");
                response = await client.PostAsync(path, content).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }


            return JsonConvert.DeserializeObject<List<List_Report_Working_History_VM>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<TaskModels>> Call_Get_Models()
        {
            Host.ServicePath = "api/Task_Transaction/";
            ServiceName = "Get_Task";


            List<TaskModels> obj = new List<TaskModels>();
            string path = "";

            try
            {
                client.Timeout = TimeSpan.FromSeconds(1000);
                path = Host.HostIP + Host.ServicePath + ServiceName;
                using (HttpResponseMessage response = await new HttpClient().GetAsync(path).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        obj = await response.Content.ReadAsJsonAsync<List<TaskModels>>().ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }

            return obj;
        }
        //GetList_Master_File
        public async Task<List<MasterFilesModel>> Call_GetList_Master_File()
        {
            Host.ServicePath = "api/Task_Transaction/";
            ServiceName = "GetList_Master_File";


            List<MasterFilesModel> obj = new List<MasterFilesModel>();
            string path = "";

            try
            {
                client.Timeout = TimeSpan.FromSeconds(1000);
                path = Host.HostIP + Host.ServicePath + ServiceName;
                using (HttpResponseMessage response = await new HttpClient().GetAsync(path).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        obj = await response.Content.ReadAsJsonAsync<List<MasterFilesModel>>().ConfigureAwait(false);
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
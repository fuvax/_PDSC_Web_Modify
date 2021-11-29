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
    public class _Image_Transaction
    {
        private HttpClient client = new HttpClient();
        private string ServiceName;
        private string url;


        public async Task<List<bool>> Call_Delete_Image_Transaction_by_Task(Delete_Image_Transaction_by_TaskModel obj)
        {
            Host.ServicePath = "api/Image_Transaction/";
            ServiceName = "Delete_Image_Transaction_by_Task";


            string path = "";

            HttpResponseMessage response = null;

           

            try
            {

                string serialisedMessage = JsonConvert.SerializeObject(obj);

                // client.Timeout = TimeSpan.FromSeconds(60);
                path = Host.HostIP + Host.ServicePath + ServiceName;


                var content = new StringContent(serialisedMessage, Encoding.UTF8, "application/json");
                response = await client.PostAsync(path, content).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }


            return JsonConvert.DeserializeObject<List<bool>>(await response.Content.ReadAsStringAsync());
        }
       
        public async Task<List<int>> Call_Save_Image_Transaction_by_Task(Save_Image_Transaction_by_TaskModel obj)
        {
            Host.ServicePath = "api/Image_Transaction/";
            ServiceName = "Save_Image_Transaction_by_Task";


            string path = "";

            HttpResponseMessage response = null;

           

            try
            {

                string serialisedMessage = JsonConvert.SerializeObject(obj);

                // client.Timeout = TimeSpan.FromSeconds(60);
                path = Host.HostIP + Host.ServicePath + ServiceName;


                var content = new StringContent(serialisedMessage, Encoding.UTF8, "application/json");
                response = await client.PostAsync(path, content).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }


            return JsonConvert.DeserializeObject<List<int>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<List_Image_Transaction_by_TaskVM>> Call_GetList_Image_Transaction_by_Task(Image_Transaction_by_Task_ParaModel obj)
        {
            Host.ServicePath = "api/Image_Transaction/";
            ServiceName = "GetList_Image_Transaction_by_Task";

            string path = "";

            HttpResponseMessage response = null;
            try
            {
                string serialisedMessage = JsonConvert.SerializeObject(obj);

                // client.Timeout = TimeSpan.FromSeconds(60);
                path = Host.HostIP + Host.ServicePath + ServiceName;

                var content = new StringContent(serialisedMessage, Encoding.UTF8, "application/json");
                response = await client.PostAsync(path, content).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" ### Service Error ### : " + ex);
            }
            return JsonConvert.DeserializeObject<List<List_Image_Transaction_by_TaskVM>>(await response.Content.ReadAsStringAsync());
        }


    }
}
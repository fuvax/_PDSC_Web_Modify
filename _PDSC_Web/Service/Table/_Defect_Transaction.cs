using _PDSC_Web.Config;
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
    public class _Defect_Transaction
    {
        private HttpClient client = new HttpClient();
        private string ServiceName;
        private string url;


        public async Task<List<List_Defect_TransactionVM>> Call_GetList_Defect_Transaction_by_MFG(string mfg)
        {
            Host.ServicePath = "api/Defect_Transaction/";
            ServiceName = "GetList_Defect_Transaction_by_MFG";


            string path = "";

            MFG_Models list = new MFG_Models() 
            {
                MFG = mfg
            };

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


            return JsonConvert.DeserializeObject<List<List_Defect_TransactionVM>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<bool> Call_Save_QC_Defect_Transaction(Save_QC_Defect_TransectionModel list)
        {
            Host.ServicePath = "api/Defect_Transaction/";
            ServiceName = "Save_QC_Defect_Transaction";


            string path = "";

           

            HttpResponseMessage response = null;

            try
            {

                string serialisedMessage = JsonConvert.SerializeObject(list);
             
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

        public async Task<bool> Call_Delete_Defect_Transaction_by_MFG(DefectCodeModel list)
        {
            Host.ServicePath = "api/Defect_Transaction/";
            ServiceName = "Delete_Defect_Transaction_by_MFG";


            string path = "";



            HttpResponseMessage response = null;

            try
            {

                string serialisedMessage = JsonConvert.SerializeObject(list);

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

        public async Task<bool> Call_Save_PE_Plan_Rectify_Finish_Defect_Transaction(Save_PE_Plan_Rectify_Finish_Defect_Transaction_Model list)
        {
            Host.ServicePath = "api/Defect_Transaction/";
            ServiceName = "Save_PE_Plan_Rectify_Finish_Defect_Transaction";


            string path = "";



            HttpResponseMessage response = null;

            try
            {

                string serialisedMessage = JsonConvert.SerializeObject(list);

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

        public async Task<bool> Call_Save_QC_Rectify_Result_Defect_Transaction(Save_QC_Rectify_Result_Defect_Transaction_Model list)
        {
            Host.ServicePath = "api/Defect_Transaction/";
            ServiceName = "Save_QC_Rectify_Result_Defect_Transaction";


            string path = "";



            HttpResponseMessage response = null;

            try
            {

                string serialisedMessage = JsonConvert.SerializeObject(list);

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

    }
}
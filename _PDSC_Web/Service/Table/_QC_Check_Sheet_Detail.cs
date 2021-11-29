using _PDSC_Web.Config;
using _PDSC_Web.Models.Table;
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
    public class _QC_Check_Sheet_Detail
    {
        private HttpClient client = new HttpClient();
        private string ServiceName;
        private string url;

        public async Task<List<List_Dropdown_QC_Defect_Item_VM>> Call_GetList_Dropdown_QC_Defect_Item(string MFG)
        {
            Host.ServicePath = "api/QC_Check_Sheet_Detail/";
            ServiceName = "GetList_Dropdown_QC_Defect_Item";


            string path = "";

            MFG_Models list = new MFG_Models()
            {
                MFG = MFG
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


            return JsonConvert.DeserializeObject<List<List_Dropdown_QC_Defect_Item_VM>>(await response.Content.ReadAsStringAsync());
        }
    }
}
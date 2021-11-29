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
    public class __Defect_Cause
    {
        private HttpClient client = new HttpClient();
        private string ServiceName;
        private string url;


        public async Task<List<List_Dropdown_QC_Cause_VM>> Call_Check_MFG_not_AssignPE(string DResp_Code)
        {
            Host.ServicePath = "api/Defect_Cause/";
            ServiceName = "GetList_Dropdown_QC_Cause";


            string path = "";

            DefectResponsibilityModel list = new DefectResponsibilityModel() 
            {
                    DResp_Code = DResp_Code
            };

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


            return JsonConvert.DeserializeObject<List<List_Dropdown_QC_Cause_VM>>(await response.Content.ReadAsStringAsync());
        }
    }
}
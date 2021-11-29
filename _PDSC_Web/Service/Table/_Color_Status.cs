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
    public class _Color_Status
    {
        private HttpClient client = new HttpClient();
        private string ServiceName;
        private string url;

        public async Task<List<ListProjectOverViewModel>> Call_GetList_ProjectOverView_Page(string emp_Code, string pos_group)
        {
            Host.ServicePath = "api/Color_Status/";
            ServiceName = "GetList_ProjectOverView_Page";

            //List<ListProjectOverViewModel> obj = new List<ListProjectOverViewModel>();
            string path = "";

            ProjectModel list = new ProjectModel()
            {
                Employee_Code = emp_Code,
                Position_Group = pos_group
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

            return JsonConvert.DeserializeObject<List<ListProjectOverViewModel>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<List_Summary_VM>> Call_Report_Summary(string positionCode, string Emp_Code)
        {
            Host.ServicePath = "api/Color_Status/";
            ServiceName = "Report_Summary";


            string path = "";

            Report_SummaryModel list = new Report_SummaryModel()
            {
                Position_Code = positionCode,
                Employee_Code = Emp_Code
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


            return JsonConvert.DeserializeObject<List<List_Summary_VM>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<Get_LableColorModel>> Call_Get_LableColor()
        {
            Host.ServicePath = "api/Color_Status/";
            ServiceName = "Get_LableColor";

            List<Get_LableColorModel> obj = new List<Get_LableColorModel>();
            string path = "";

            try
            {
                client.Timeout = TimeSpan.FromSeconds(1000);
                path = Host.HostIP + Host.ServicePath + ServiceName;
                using (HttpResponseMessage response = await new HttpClient().GetAsync(path).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        obj = await response.Content.ReadAsJsonAsync<List<Get_LableColorModel>>().ConfigureAwait(false);
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
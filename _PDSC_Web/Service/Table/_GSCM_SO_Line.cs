using _PDSC_Web.Config;
using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Models.ParamiterModels;
using _PDSC_Web.Models.Table;
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
    public class _GSCM_SO_Line
    {
        private HttpClient client = new HttpClient();
        private string ServiceName;
        private string url;


        public async Task<List<WorkApproveLimitModel>> Call_Get_ListWorkApp(string sitecode, string saleorder)
        {
            Host.ServicePath = "api/GSCM_SO_Line/";
            ServiceName = "Get_ListWorkApp";


            string path = "";

            HttpResponseMessage response = null;

            SiteSaleOrderModel obj = new SiteSaleOrderModel()
            {
                SaleOrder = saleorder,
                SiteCode = sitecode
            };

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


            return JsonConvert.DeserializeObject<List<WorkApproveLimitModel>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<SaleOrderModel>> Call_Get_ListSaleOrder_By_Site(string sitecode)
        {
            Host.ServicePath = "api/GSCM_SO_Line/";
            ServiceName = "Get_ListSaleOrder_By_Site";


            string path = "";

            HttpResponseMessage response = null;

            SiteModel obj = new SiteModel()
            {
                Site = sitecode
            };

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


            return JsonConvert.DeserializeObject<List<SaleOrderModel>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<List_ReviseHOModel>> Call_GetList_ReviseHO_Page(string sitecode, string saleorder)
        {
            Host.ServicePath = "api/GSCM_SO_Line/";
            ServiceName = "GetList_ReviseHO_Page";


            string path = "";

            HttpResponseMessage response = null;

            SiteSaleOrderModel obj = new SiteSaleOrderModel()
            {
                SaleOrder = saleorder,
                SiteCode = sitecode
            };



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


            return JsonConvert.DeserializeObject<List<List_ReviseHOModel>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> Call_Save_ReviseHO_BySO_Page(Save_ReviseHO_SaleOrder_Model obj)
        {
            Host.ServicePath = "api/GSCM_SO_Line/";
            ServiceName = "Save_ReviseHO_BySO_Page";


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


            return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> Call_Save_ReviseHO_ByMFG_Page(Save_ReiseHO_MFG_Model obj)
        {
            Host.ServicePath = "api/GSCM_SO_Line/";
            ServiceName = "Save_ReviseHO_ByMFG_Page";


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


            return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<List_ContractInfoModel>> Call_GetList_ContractInfo_Page(string sitecode, string emp_Code, string pos_group)
        {
            Host.ServicePath = "api/GSCM_SO_Line/";
            ServiceName = "GetList_ContractInfo_Page";


            string path = "";

            MFG_SiteModel list = new MFG_SiteModel()
            {
                Site_Code = sitecode,
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


            return JsonConvert.DeserializeObject<List<List_ContractInfoModel>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<List_ViewPlan_UpdateModel>> Call_GetList_Plan_UpdateStatus(string sitecode, string emp_Code, string pos_group)
        {
            Host.ServicePath = "api/GSCM_SO_Line/";
            ServiceName = "GetList_Plan_UpdateStatus";


            string path = "";

            ViewPlanModel list = new ViewPlanModel()
            {
                Site_Code = sitecode,
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


            return JsonConvert.DeserializeObject<List<List_ViewPlan_UpdateModel>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<List_UpdateInfoModel>> Call_GetList_MFG_UpdateInfo(string sitecode, string emp_Code, string pos_group)
        {
            Host.ServicePath = "api/GSCM_SO_Line/";
            ServiceName = "GetList_MFG_UpdateInfo";


            string path = "";

            ViewPlanModel list = new ViewPlanModel()
            {
                Site_Code = sitecode,
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


            return JsonConvert.DeserializeObject<List<List_UpdateInfoModel>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<MFGDetail_Model>> Call_Get_MFG_Detail(string MFG_No)
        {
            Host.ServicePath = "api/GSCM_SO_Line/";
            ServiceName = "Get_MFG_Detail";

            MFG list = new MFG()
            {
                MFG_No = MFG_No
            };


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


            return JsonConvert.DeserializeObject<List<MFGDetail_Model>>(await response.Content.ReadAsStringAsync());
        }
    }
}
using _PDSC_Web.Config;
using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Models.ParamiterModels;
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
    public class _MFG
    {
        private HttpClient client = new HttpClient();
        private string ServiceName;
        private string url;


        public async Task<List<CountModel>> Call_Check_MFG_not_AssignPE(string SiteCode)
        {
            Host.ServicePath = "api/MFG/";
            ServiceName = "Check_MFG_not_AssignPE";


            string path = "";

            GSCM_Site list = new GSCM_Site()
            {
                Site = SiteCode
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


            return JsonConvert.DeserializeObject<List<CountModel>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<AssignPE_PageModel>> Call_GetList_AssignPE_Page(string SiteCode)
        {
            Host.ServicePath = "api/MFG/";
            ServiceName = "GetList_AssignPE_Page";


            string path = "";

            GSCM_Site list = new GSCM_Site()
            {
                Site = SiteCode
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


            return JsonConvert.DeserializeObject<List<AssignPE_PageModel>>(await response.Content.ReadAsStringAsync());
        }
        //GetList_Create_Edit_AssignPE_Page

        public async Task<List<GetList_EditAssignPEModel>> Call_GetList_Create_Edit_AssignPE_Page(string SiteCode)
        {
            Host.ServicePath = "api/MFG/";
            ServiceName = "GetList_Create_Edit_AssignPE_Page";


            string path = "";

            GSCM_Site list = new GSCM_Site()
            {
                Site = SiteCode
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


            return JsonConvert.DeserializeObject<List<GetList_EditAssignPEModel>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> Call_Save_AssignPE_Page(SaveAssignPEModel list)
        {
            Host.ServicePath = "api/MFG/";
            ServiceName = "Save_AssignPE_Page";


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

        public async Task<string> Call_Save_Confirm_PO_Delivery_Page(Save_Confirm_PO_DeliveryModel list)
        {
            Host.ServicePath = "api/MFG/";
            ServiceName = "Save_Confirm_PO_Delivery_Page";


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

        public async Task<List<ListConfrim_PODlivery_Model>> Call_GetList_Confirm_PO_Delivery_Page(string SaleOrder, string sitecode)
        {
            Host.ServicePath = "api/MFG/";
            ServiceName = "GetList_Confirm_PO_Delivery_Page";


            string path = "";

            SiteSaleOrderModel list = new SiteSaleOrderModel()
            {
                SaleOrder = SaleOrder,
                SiteCode = sitecode
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


            return JsonConvert.DeserializeObject<List<ListConfrim_PODlivery_Model>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<List_ViewPlan_Model>> Call_GetList_ViewPlan_Page(string SiteCode, int Stage, string emp_Code, string pos_group)
        {
            Host.ServicePath = "api/MFG/";
            ServiceName = "GetList_ViewPlan_Page";


            string path = "";

            ViewPlanModel list = new ViewPlanModel()
            {
                Site_Code = SiteCode,
                Stage = Stage,
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


            return JsonConvert.DeserializeObject<List<List_ViewPlan_Model>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> Call_Save_Manufacturing_Page(Save_ManufacturingModel list)
        {
            Host.ServicePath = "api/MFG/";
            ServiceName = "Save_Manufacturing_Page";


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

        public async Task<List<GetListProjectPersentModel>> Call_GetList_Project(string emp_Code, string pos_group)
        {
            Host.ServicePath = "api/MFG/";
            ServiceName = "GetList_Project";

           // List<GetListProjectPersentModel> obj = new List<GetListProjectPersentModel>();
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

            return JsonConvert.DeserializeObject<List<GetListProjectPersentModel>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> Call_Save_Plan_ByMFG_Page(SavePlanMFGModel list)
        {
            Host.ServicePath = "api/MFG/";
            ServiceName = "Save_Plan_ByMFG_Page";


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

        public async Task<string> Call_Save_Plan_ByField_Page(SavePlanFieldModel list)
        {
            Host.ServicePath = "api/MFG/";
            ServiceName = "Save_Plan_ByField_Page";


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

        public async Task<List<ListTaskByStageModel>> Call_GetList_Task_by_Stage(string MFG_No, string SM_Code)
        {
            Host.ServicePath = "api/MFG/";
            ServiceName = "GetList_Task_by_Stage";


            string path = "";

            PlanByStageModel list = new PlanByStageModel()
            {
                MFG_No = MFG_No,
                SM_Code = SM_Code
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


            return JsonConvert.DeserializeObject<List<ListTaskByStageModel>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<PlantDateInfoModel>> Call_Get_Plan_by_Stage(string MFG_No, string SM_Code)
        {
            Host.ServicePath = "api/MFG/";
            ServiceName = "Get_Plan_by_Stage";


            string path = "";
            PlanByStageModel list = new PlanByStageModel()
            {
                MFG_No = MFG_No,
                SM_Code = SM_Code
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


            return JsonConvert.DeserializeObject<List<PlantDateInfoModel>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<ListTaskTransectionModel>> Call_GetList_Transaction_by_Task(string MFG_No, string TransectionCode)
        {
            Host.ServicePath = "api/MFG/";
            ServiceName = "GetList_Transaction_by_Task";


            string path = "";

            ListTransactionModel list = new ListTransactionModel()
            {
                MFG_No = MFG_No,
                Task_Code = TransectionCode
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


            return JsonConvert.DeserializeObject<List<ListTaskTransectionModel>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<bool> Call_Save_QC_Result_by_MFG(QC_Result_by_MFG_Model list)
        {
            Host.ServicePath = "api/MFG/";
            ServiceName = "Save_QC_Result_by_MFG";


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


            return JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<List_DropDown_Site_VM>> Call_Report_DropDown_Site(DropDownSite_Model list)
        {
            Host.ServicePath = "api/MFG/";
            ServiceName = "Report_DropDown_Site";


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


            return JsonConvert.DeserializeObject<List<List_DropDown_Site_VM>>(await response.Content.ReadAsStringAsync());
        }



    }
}

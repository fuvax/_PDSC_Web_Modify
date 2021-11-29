using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Service.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Controllers.ServiceControllers
{
    public class _HD_WorkApproveLimit
    {
        _GSCM_SO_Line soline = new _GSCM_SO_Line();
        public List<WorkApproveLimitModel> Get_ListWorkApp(string sitecode, string saleorder)
        {


            List<WorkApproveLimitModel> result = new List<WorkApproveLimitModel>();
            try
            {
                result = soline.Call_Get_ListWorkApp(sitecode, saleorder).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex);
            }
            return result;
        }

        public List<SaleOrderModel> Get_listSaleOrderBySite(string sitecode)
        {

            List<SaleOrderModel> result = new List<SaleOrderModel>();
            try
            {
                result = soline.Call_Get_ListSaleOrder_By_Site(sitecode).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Exception : " + ex);
            }
            return result;
        }

        public List<string> Update_WorkAppLimit(List<WorkAppJSModel> list, string update_by, ref string get_status)
        {
            _WorkApproveLimit_Transaction _work = new _WorkApproveLimit_Transaction();

            List<string> Errorlist = new List<string>(); 

            string Status = "";
            try
            {

                if (list.Count > 0)
                {

                    for (int i = 0; i < list.Count ; i++) 
                    {
                        if (Check_Condition_WorkApprove(list[i])) 
                        {
                            UpdateInsetWorkApproveLimitModel mylist = new UpdateInsetWorkApproveLimitModel()
                            {
                                MFG_No = list[i].Id,
                                WAL_Delivery = bool.Parse(list[i].Delivery),
                                WAL_Install = bool.Parse(list[i].Install),
                                WAL_Testing = bool.Parse(list[i].Testing),
                                WAL_HandOver = bool.Parse(list[i].HandOver),
                                WAL_Remark = list[i].WAL_Remark,
                                TWAL_Code = Guid.NewGuid(),
                                Update_by = update_by,
                                Last_Update = DateTime.Now
                            };
                            Status = _work.Call_Update_WorkAppLimit(mylist).Result;
                            get_status = Status;
                        }
                        else 
                        {
                            Errorlist.Add(list[i].Id);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Exception : " + ex);
            }
            return Errorlist;
        }

        #region Function 

            private bool Check_Condition_WorkApprove(WorkAppJSModel list)
            {
                bool Status = false;

                if (bool.Parse(list.Delivery) &&
                    bool.Parse(list.Install) &&
                    bool.Parse(list.Testing) &&
                    bool.Parse(list.HandOver))
                {
                    Status = true;
                }
                else if
                    (bool.Parse(list.Delivery) &&
                    bool.Parse(list.Install) &&
                    bool.Parse(list.Testing) &&
                    !bool.Parse(list.HandOver))
                {
                    Status = true;
                }
                else if
                    (bool.Parse(list.Delivery) &&
                    bool.Parse(list.Install) &&
                    !bool.Parse(list.Testing) &&
                    !bool.Parse(list.HandOver))
                {
                    Status = true;
                }
                else if
                    (bool.Parse(list.Delivery) &&
                    !bool.Parse(list.Install) &&
                   !bool.Parse(list.Testing) &&
                    !bool.Parse(list.HandOver))
                {
                    Status = true;
                }  
                else if 
                    (!bool.Parse(list.Delivery) &&
                     !bool.Parse(list.Install) &&
                     !bool.Parse(list.Testing) &&
                     !bool.Parse(list.HandOver))
                {
                    Status = true;
                }
                else
                {
                    Status = false;
                }

                return Status;
            }

        #endregion

    }
}
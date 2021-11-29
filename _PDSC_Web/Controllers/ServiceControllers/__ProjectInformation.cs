using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Models.ViewModels;
using _PDSC_Web.Service.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Controllers.ServiceControllers
{
    public class __ProjectInformation
    {
        #region New Object
        _Color_Status color = new _Color_Status();
        _MFG mfg = new _MFG();
        _Stage_Master stage = new _Stage_Master();
        #endregion
        public List<ListProjectOverViewModel> GetList_ProjectOverView_Page(string Emp_Code, string Position_Group)
        {
            List<ListProjectOverViewModel> result = new List<ListProjectOverViewModel>();
            try
            {
                result = color.Call_GetList_ProjectOverView_Page(Emp_Code, Position_Group).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            return result;
        }
        public List<GetListProjectPersentModel> GetList_Project(string Emp_Code, string Position_Group)
        {
            List<GetListProjectPersentModel> result = new List<GetListProjectPersentModel>();
            try
            {
                result = mfg.Call_GetList_Project(Emp_Code, Position_Group).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            return result;
        }

        public List<DropDown_Stage_VM> GetList_DropDown_Stage() 
        {
            List<DropDown_Stage_VM> result = new List<DropDown_Stage_VM>();
            try 
            {
                result = stage.Call_GetList_DropDown_Stage().Result;
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Exception : "+ex);
            }
            return result;
        }

        public List<Get_LableColorModel> Get_LableColor()
        {
            List<Get_LableColorModel> result = new List<Get_LableColorModel>();

            try
            {
                result = color.Call_Get_LableColor().Result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
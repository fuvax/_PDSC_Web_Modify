using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Service.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Controllers.ServiceControllers
{
    public class _WriteLog
    {
        _PDSC_Log pdsc_log = new _PDSC_Log();
        public void WriteLog(string _event, string _menu, string _detail, bool _iserror, string _by)
        {
            string result = "";
            
            try
            {
                Write_LogModel list = new Write_LogModel()
                {
                    Log_Event = _event,
                    Log_Menu = _menu,
                    Log_Detail = _detail,
                    Log_IsError = _iserror,
                    Log_by = _by,
                    Log_Date = DateTime.Now,
                    Log_Source = "Web"
                };
                result = pdsc_log.Call_Write_Log(list).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            
        }

    }
}
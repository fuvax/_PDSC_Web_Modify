using _PDSC_Web.Controllers.ServiceControllers;
using _PDSC_Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _PDSC_Web.Function;

namespace _PDSC_Web.Controllers
{
    public class HomeController : Controller
    {
        _Service_PDSC_Roles serv_roles = new _Service_PDSC_Roles();
        List<Get_Main_Menu2> _lstGetMainMenu = new List<Get_Main_Menu2>();
        //List<GetList_Roles> _lstGetRoles = new List<GetList_Roles>();

        // GET: Home
        public ActionResult Welcome()
        {
            //SCenter.lstGetMainMenu.Clear();
            //SCenter.lstGetRoles.Clear();
            var result = serv_roles.GetList_Main_Menu_by_Group(Session["User_Group"] as string, false) ;
                        

            if (result != null && result.Count > 0)
            {

                foreach (var data in result.ToList())
                {
                    Get_Main_Menu2 getmenu = new Get_Main_Menu2()
                    {
                        MNR_Role = data.MNR_Role
                    };
                    // SCenter.lstGetMainMenu.Add(getmenu);
                    _lstGetMainMenu.Add(getmenu);
                }

                ViewBag.ListMNR = _lstGetMainMenu;
                //ViewBag.GetRoles = SCenter.lstGetRoles.Where(a => a.ROLE_Code == "");
                ////return View("welcome");
                return View();

                //var result_roles = serv_roles.Check_Role_by_Login(Session["User_Group"] as string, false);
                //if (result_roles != null && result_roles.Count > 0)
                //{
                //    foreach (var data in result_roles.ToList())
                //    {
                //        GetList_Roles getroles = new GetList_Roles()
                //        {
                //            ROLE_Code = data.ROLE_Code
                //        };
                //        SCenter.lstGetRoles.Add(getroles);
                //    }

                //    ViewBag.ListMNR = SCenter.lstGetMainMenu;
                //    //ViewBag.GetRoles = SCenter.lstGetRoles.Where(a => a.ROLE_Code == "");
                //    ////return View("welcome");
                //    return View();
                //}
                ////    //List<string> listMNR = new List<string>();
                ////    //foreach (var data in result.ToList())
                ////    //{
                ////    //    listMNR.Add(data.MNR_Role);
                ////    //}

                ////    //ViewData["ListMNR"] = listMNR;
                ////    ViewBag.ListMNR = SCenter.lstGetMainMenu;
                //////return View("welcome");
                ////return View();
                //ViewBag.Message = "Please contact to admin!!";
                //return RedirectToAction("Login", "_Architectui_Login");
            }
            else
            {
                ViewBag.Message = "Please contact to admin!!";
                return RedirectToAction("Login", "_Architectui_Login");
            }
                

        }
        
    }
}
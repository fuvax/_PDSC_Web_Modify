using _PDSC_Web.Controllers.ServiceControllers;
using _PDSC_Web.Function;
using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _PDSC_Web.Controllers._Management
{
    public class ProjectEngineerMasterController : Controller
    {
        _ProjectEngineerMaster _pe = new _ProjectEngineerMaster();
        _WriteLog _writelog = new _WriteLog();

        _Service_PDSC_Roles serv_roles = new _Service_PDSC_Roles();
        List<Get_Main_Menu2> _lstGetMainMenu = new List<Get_Main_Menu2>();
        List<GetList_Roles> _lstGetRoles = new List<GetList_Roles>();        
        
        //// GET: ProjectEngineerMaster
        [SessionTimeout]
        public ActionResult Index()
        {
            
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            return View("Index");
        }
                
        [SessionTimeout]
        public ActionResult Create()
        {
            get_roles_fn();

            if (ViewBag.GetRoles != "Role_MM11")
                return RedirectToAction("Logout", "Login");

            return View("Create");
        }
        
        public JsonResult ToEdit(string code)
        {

            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Edit", "ProjectEngineerMaster"
                                , new { Engineer_Code = code })
            });
        }
        [SessionTimeout]
        public ActionResult Edit(string Engineer_Code)
        {
            get_roles_fn();

            if (ViewBag.GetRoles != "Role_MM11")
                return RedirectToAction("Logout", "Login");

            ViewBag.listPE = _pe.GetList_Dropdown_Engineer_All();

            var result = _pe.GetList_Dropdown_Engineer_All();
            var listEngineer = (from data in result
                                where data.Employee_Code == Engineer_Code
                                select data).ToList();
            if (listEngineer.Count > 0)
            {
                ViewBag.Email = listEngineer[0].Email;
                ViewBag.Phone = listEngineer[0].Mobile_no;
            }


            var peMasterList = (from data in (_pe.Load_PE_MasterPage())
                                where data.Engineer_Code == Engineer_Code
                                select data).ToList();

            if (peMasterList.Count > 0)
            {
                ViewBag.DMCode = peMasterList[0].DM_Code;
                ViewBag.Leder = peMasterList[0].Leader_Code;
            }


           //Set DropDown  DM,Leader
            ViewBag.listDM = _pe.Get_DM_By_EngineerGroupCode(Engineer_Code);
            ViewBag.listLeader = _pe.Get_Leader_By_EngineerGroupCode(Engineer_Code);

            //set DropDown PE
            ViewBag.PE_Code = Engineer_Code;
            ViewBag.PE_Name = (from data in peMasterList
                               where data.Engineer_Code == Engineer_Code
                               select data.Engineer_Name).FirstOrDefault();
            ViewBag.PE_TypeGroup = (from data in peMasterList
                               where data.Engineer_Code == Engineer_Code
                               select data.Position_Group).FirstOrDefault();

            ViewBag.TypeName = (from data in peMasterList
                                where data.Engineer_Code == Engineer_Code
                                select data.Position_Group).FirstOrDefault();

            return View("Edit");
        }
        [SessionTimeout]
        public ActionResult Delete(string Engieer_Code)
        {
            get_roles_fn();

            if (ViewBag.GetRoles != "Role_MM11")
                return RedirectToAction("Logout", "Login");

            string Status = _pe.UpdateStatusPE(Engieer_Code);
            if (Status == "Update Status Succes")
            {
                _writelog.WriteLog("Delete", "Engineer Master", Engieer_Code, false, Session["User_EmpName"] as string);
            }
            else
            {
                _writelog.WriteLog("Delete", "Engineer Master", Engieer_Code + " - " + Status, true, Session["User_EmpName"] as string);
            }                

            return RedirectToAction("Index", "ProjectEngineerMaster");
        }


        public JsonResult Load_EngineerMasterPage()
        {
            List<List_ListPE_VM> result = _pe.Load_PE_MasterPage()
                .GroupBy(G => new { G.Engineer_Code }).Select(G => new List_ListPE_VM()
                {
                    PE_Model = G.FirstOrDefault(),
                    list_PE_Model = G.Distinct().ToList()

                })
                .ToList();
            return Json(result);
        }
        public JsonResult Get_Engineer()
        {
            var listPE = _pe.GetList_Dropdown_Engineer();

            return Json(listPE);
        }

        public JsonResult Get_EngineerByCode(string Code)
        {
            var listPE = _pe.GetList_Dropdown_Engineer().Where( i => i.Employee_Code == Code).ToList();

            return Json(listPE);
        }

        public JsonResult Get_Leader(string Position_Code)
        {
            var listLeader = _pe.Get_Leader_By_EngineerGroupCode(Position_Code);
            return Json(listLeader);
        }

        public JsonResult Get_DM(string Position_Code)
        {
            var listDM = _pe.Get_DM_By_EngineerGroupCode(Position_Code);
            return Json(listDM);
        }

        public JsonResult LoadEditPage()
        {
            List<object> result = new List<object>();
            var listPE = _pe.Get_PE();
            var listDM = _pe.Get_DM();
            var listLeader = _pe.Get_Leader();

            result.Add(listPE);
            result.Add(listDM);
            result.Add(listLeader);

            return Json(result);
        }
        [SessionTimeout]
        public ActionResult CreateEngineerMaster(FormCollection form)
        {
            get_roles_fn();

            if (ViewBag.GetRoles != "Role_MM11")
                return RedirectToAction("Logout", "Login");

            _ProjectEngineerMaster pe = new _ProjectEngineerMaster();

            string PE = form["PE"];
            string Leader = form["Leader"];
            string DM = form["DM"];
            string phone = form["phoneh"];
            string mail = form["mailh"];


            Save_Engineer_Master_Model obj = new Save_Engineer_Master_Model()
            {
                Engineer_Code = PE,
                Leader_Code = Leader,
                DM_Code = DM,
                Phone = phone,
                Email = mail,
                Last_Update = DateTime.Now,
                Update_by = Session["User_EmpCode"] as string
            };
            var CreateResult = pe.CreateProjecEngineer(obj);

            if (CreateResult == "True")
            {
                _writelog.WriteLog("Create", "Engineer Master", PE, false, Session["User_EmpName"] as string);
            }
            else
            {
                _writelog.WriteLog("Create", "Engineer Master", PE + " - " + CreateResult, true, Session["User_EmpName"] as string);
            }
            

            return RedirectToAction("Index", "ProjectEngineerMaster");
        }
        [SessionTimeout]
        public ActionResult EditEngineerMaster(FormCollection form)
        {
            get_roles_fn();

            if (ViewBag.GetRoles != "Role_MM11")
                return RedirectToAction("Logout", "Login");

            _ProjectEngineerMaster pe = new _ProjectEngineerMaster();

            string PE = form["PE_Code"];
            string Leader = form["Leader"];
            string DM = form["DM"];
            string phone = form["phoneh"];
            string mail = form["mailh"];


            Save_Engineer_Master_Model obj = new Save_Engineer_Master_Model()
            {
                Engineer_Code = PE,
                Leader_Code = Leader,
                DM_Code = DM,
                Phone = phone,
                Email = mail,
                Last_Update = DateTime.Now,
                Update_by = Session["User_EmpCode"] as string
            };
            var UpdateResult = pe.UpdateProjectEngineerMaster(obj);

            if (UpdateResult == "True")
            {
                _writelog.WriteLog("Edit", "Engineer Master", PE, false, Session["User_EmpName"] as string);
            }
            else
            {
                _writelog.WriteLog("Edit", "Engineer Master", PE + " - " + UpdateResult, true, Session["User_EmpName"] as string);
            }

            return RedirectToAction("Index", "ProjectEngineerMaster");
        }

        #region Roles
        private void set_lstMainMenu()
        {
            var result = serv_roles.GetList_Main_Menu_by_Group(Session["User_Group"] as string, false);


            if (result != null && result.Count > 0)
            {

                foreach (var data in result.ToList())
                {
                    Get_Main_Menu2 getmenu = new Get_Main_Menu2()
                    {
                        MNR_Role = data.MNR_Role
                    };
                    _lstGetMainMenu.Add(getmenu);
                }
            }
        }

        private void set_lstRoles()
        {
            var result_roles = serv_roles.Check_Role_by_Login(Session["User_Group"] as string, false);
            if (result_roles != null && result_roles.Count > 0)
            {
                foreach (var data in result_roles.ToList())
                {
                    GetList_Roles getroles = new GetList_Roles()
                    {
                        ROLE_Code = data.ROLE_Code
                    };
                    _lstGetRoles.Add(getroles);
                }
            }
        }
        private void get_roles_fn()
        {
            set_lstMainMenu();
            ViewBag.ListMNR = _lstGetMainMenu;
            var s_MNRoles = _lstGetMainMenu.Where(a => a.MNR_Role == "PDSCPAGE001").FirstOrDefault();
            if (s_MNRoles != null)
                ViewBag.GetMNRoles = s_MNRoles.MNR_Role;
            else
                ViewBag.GetMNRoles = "";

            set_lstRoles();
            ViewBag.GetHDRoles = _lstGetRoles.Where(a => a.ROLE_Code.StartsWith("Role_HD")).ToList();

            var s_Roles = _lstGetRoles.Where(a => a.ROLE_Code == "Role_MM11" || a.ROLE_Code == "Role_MM12").FirstOrDefault();
            if (s_Roles != null)
                ViewBag.GetRoles = s_Roles.ROLE_Code;
            else
                ViewBag.GetRoles = "";
        }
        #endregion
    }
}
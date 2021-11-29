using _PDSC_Web.Controllers.ServiceControllers;
using _PDSC_Web.Function;
using _PDSC_Web.Models.ParamiterModels;
using _PDSC_Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _PDSC_Web.Controllers._UserManagement
{
    public class UserManagementController : Controller
    {
        // GET: UserManagement

        #region ## New Object ##

        __UserManagement usermanagement = new __UserManagement();
        _WriteLog _writelog = new _WriteLog();

        EncryptionExtensions encry = new EncryptionExtensions();
        _Service_PDSC_Roles serv_roles = new _Service_PDSC_Roles();
        List<Get_Main_Menu2> _lstGetMainMenu = new List<Get_Main_Menu2>();
        List<GetList_Roles> _lstGetRoles = new List<GetList_Roles>();


        #endregion

        #region ++ Rounging ++

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

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            return View("Create");
        }

        [SessionTimeout]
        public ActionResult Edit()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            return View("Edit");
        }

        public JsonResult ToEdit(string EmpCode)
        {
            Session["EmpCode"] = EmpCode;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Edit", "UserManagement")
            });
        }

        #endregion

        
        public JsonResult Get_DropDown_UserType() 
        {
            var result = usermanagement.User_Dropdown_UserType();
            return Json(result);
        }

        public JsonResult Get_DropDown_Status() 
        {
            List<DropDownStatus> result = new List<DropDownStatus>();

            DropDownStatus list1 = new DropDownStatus() 
            {
                ID = false,
                Status_Name = "Inactive"
            };
            DropDownStatus list2 = new DropDownStatus()
            {
                ID = true,
                Status_Name = "Active"
            };

            result.Add(list1);
            result.Add(list2);


            return Json(result);
        }

        public JsonResult Check_Username_Duplicate(string Username) 
        {

            var status = usermanagement.Check_User_Duplicate(Username);

            return Json(status);
        }

        #region ## Create ##

        public JsonResult Render_Table_User()
        {
            var result = usermanagement.GetList_User_Management();

            return Json(result);
        }

        public JsonResult Get_DropDown_Emp()
        {
            var result = usermanagement.User_Dropdown_Employee();

            return Json(result);
        }

        public JsonResult Get_DropDown_UserGroup()
        {
            var result = usermanagement.User_Dropdown_UserGroup();
            return Json(result);
        }

        public JsonResult Get_DropDown_Position(string PositionGroup)
        {

            var result = usermanagement.User_Dropdown_Position(PositionGroup);
            return Json(result);
        }
        [SessionTimeout]
        [HttpPost]        
        public ActionResult Create(CreateUser list) 
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            Save_User_ManagementModel obj = new Save_User_ManagementModel()
            {
               Employee_Code = list.emp,
               User_Type = list.usertype,
               Position_Code = list.position,
              Username = list.username,
              pwd = (list.password == "" || list.password == null) ? "" : encry.Encrypt(list.password),
              Status = bool.Parse(list.status),
              Link_Image = list.linkimage,
              Last_Update = DateTime.Now
            };

            var result = usermanagement.Save_User_Management(obj);

            if (result)
            {
                _writelog.WriteLog("Create", "User Management", list.emp, false, Session["User_EmpName"] as string);
            }
            else
            {
                _writelog.WriteLog("Create", "User Management", list.emp, true, Session["User_EmpName"] as string);
            }

            return RedirectToAction("Index", "UserManagement");
        }



        #endregion

        #region ## Edit ##

         public JsonResult Get_Data() 
        {
            string EmpID = Session["EmpCode"] as string;

            List<User_ManagementVM> listresult = new List<User_ManagementVM>();

            var result = usermanagement.GetList_User_Management()
                                        .Where(i => i.Employee_Code == EmpID).ToList();
            foreach (var obj in result) 
            {
                User_ManagementVM list = new User_ManagementVM()
                {
                      Employee_Code = obj.Employee_Code,
                      Name = obj.Name,
                      Username = obj.Username,
                      Password = obj.Password == "" ? "" : encry.Decrypt(obj.Password),
                      Position_Code = obj.Position_Code,
                      Position_Group = obj.Position_Group,
                      Position_Name = obj.Position_Name,
                      User_Type = obj.User_Type,
                      IsActive = obj.IsActive,
                      Link_Picture = obj.Link_Picture
                };

                listresult.Add(list);
            }

            return Json(listresult);
        }

        [SessionTimeout]
        [HttpPost]        
        public ActionResult Edit(CreateUser list)
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            Save_User_ManagementModel obj = new Save_User_ManagementModel()
            {
                Employee_Code = list.emp,
                User_Type = list.usertype,
                Position_Code = list.position,
                Username = list.username,
                pwd = (list.password == "" || list.password == null) ? "" : encry.Encrypt(list.password),
                Status = bool.Parse(list.status),
                Link_Image = list.linkimage,
                Last_Update = DateTime.Now
            };

            var result = usermanagement.Save_User_Management(obj);

            if (result)
            {
                _writelog.WriteLog("Edit", "User Management", list.emp, false, Session["User_EmpName"] as string);
            }
            else
            {
                _writelog.WriteLog("Edit", "User Management", list.emp, true, Session["User_EmpName"] as string);
            }

            return RedirectToAction("Index", "UserManagement");
        }

        #endregion

        #region ## Delete ##

        [SessionTimeout]
        public ActionResult Delete_Emp(string Emp) 
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            EmpolyeeModel list = new EmpolyeeModel() 
            {
                Employee_Code = Emp
            };

            var result = usermanagement.Delete_User_Management(list);

            if (result)
            {
                _writelog.WriteLog("Delete", "User Management", list.Employee_Code, false, Session["User_EmpName"] as string);
            }
            else
            {
                _writelog.WriteLog("Delete", "User Management", list.Employee_Code, true, Session["User_EmpName"] as string);
            }

            return RedirectToAction("Index", "UserManagement");
        }

        #endregion

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
            var s_MNRoles = _lstGetMainMenu.Where(a => a.MNR_Role == "PDSCPAGE006").FirstOrDefault();
            if (s_MNRoles != null)
                ViewBag.GetMNRoles = s_MNRoles.MNR_Role;
            else
                ViewBag.GetMNRoles = "";

            set_lstRoles();
            var s_Roles = _lstGetRoles.Where(a => a.ROLE_Code == "Role_UM11").FirstOrDefault();
            if (s_Roles != null)
                ViewBag.GetRoles = s_Roles.ROLE_Code;
            else
                ViewBag.GetRoles = "";
        }
        
        #endregion
    }
}
using _PDSC_Web.Controllers.ServiceControllers;
using _PDSC_Web.Function;
using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _PDSC_Web.Controllers._ProjectHeader
{
    
        // GET: HD_ContactPerson
        public class HD_ContactPersonController : Controller
        {
            // GET: HD_ContactPerson
            _HD_ContectPersonControllers service = new _HD_ContectPersonControllers();
            __HD_Manufacturing manf = new __HD_Manufacturing();
            _WriteLog _writelog = new _WriteLog();

            _Service_PDSC_Roles serv_roles = new _Service_PDSC_Roles();
            List<Get_Main_Menu2> _lstGetMainMenu = new List<Get_Main_Menu2>();
            List<GetList_Roles> _lstGetRoles = new List<GetList_Roles>();

        [SessionTimeout]
        public ActionResult Index()
        {
            ViewBag.PageName = "Contact Person";
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            if (Session["PersonType"] == null)
                {
                    Session["PersonType"] = "";
                }

            string SiteCode = Session["SiteCode"] as string;

            ViewBag.SiteCode = SiteCode;

            var listSite = (from data in (manf.Get_ListSite())
                            where data.Site == SiteCode
                            select data).ToList();

            if (listSite.Count > 0)
            {
                foreach (var obj in listSite)
                {
                    Session["SiteName"] = obj.Name;
                    Session["Address"] = obj.Address;
                }
            }

            return View("Index", "_Architectui_Header_Layout");
        }

        
        public JsonResult ToCreate(string Page) 
            {
               Session["ContactType"] = Page;       // click Create button from Tab ?
               
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("CreatePage", "HD_ContactPerson"
                                    , new { Tab_Page = Page })
            });
        }

        #region ** Index Page **
       
        public JsonResult Load_Table_HET()
            {

                string sitecode = Session["SiteCode"].ToString();
                var result = service.GetList_ContactPerson_HET_Page(sitecode);
                return Json(result);
            }

        
        public JsonResult Load_Table_Customer()
            {
                string sitecode = Session["SiteCode"].ToString();
                var result = service.GetList_ContactPerson_Customer_Page(sitecode);
                return Json(result);
            }

    
        public JsonResult Load_Table_Supplier()
            {
                string sitecode = Session["SiteCode"].ToString();
                var result = service.GetList_ContactPerson_Supplier_Page(sitecode);
                return Json(result);
            }

       
        public JsonResult Load_Table_Sub_Con()
            {

                string sitecode = Session["SiteCode"].ToString();
                var result = service.GetList_ContactPerson_SubCon_Page(sitecode);
                return Json(result);
            }

            public JsonResult GoEdit(string ConP, string Type)
            {
                
                return Json(new
                    {
                        result = "Redirect",
                        url = Url.Action("EditPage", "HD_ContactPerson"
                                        , new { ContectP = ConP, Type_Code = Type })
                    });

            }

        
        public JsonResult Delete(string type, string positioncode, string conP_code)
            {
                if (Session["Login"] == null)
                {
                    return Json(new { code = 1 });
                }

                DeleteContactPersonModels list = new DeleteContactPersonModels()
                {
                    Site_Code = Session["SiteCode"].ToString(),
                    PType_Code = type,
                    Position_Code = positioncode,
                    ContactP_Code = Guid.Parse(conP_code),
                    Update_by = Session["User_EmpCode"] as string,
                    Last_Update = DateTime.Now

                };

                var result = service.Delete_ContactPerson_byRow_Page(list);
                Session["PersonType"] = type;

                if (result == "True")
                {
                    //_writelog.WriteLog("Edit", "HD Contact Person", "[" + Session["SiteCode"] as string + "] " + Employee + Company, false, Session["User_EmpName"] as string);
                    _writelog.WriteLog("Delete", "HD Contact Person", "[" + Session["SiteCode"] as string + "] => " + conP_code, false, Session["User_EmpName"] as string);
                }
                else
                {
                    _writelog.WriteLog("Delete", "HD Contact Person", "[" + Session["SiteCode"] as string + "] => " + conP_code + " => " + result, true, Session["User_EmpName"] as string);
                }

            return Json(new
                {
                    result = "Redirect",
                    url = Url.Action("Index", "HD_ContactPerson")

                });
            }

        #endregion

       
        public JsonResult ListData_HET(string ConP)
            {
                string sitecode = Session["SiteCode"].ToString();
                var result = service.GetList_ContactPerson_HET_PageByConP(sitecode, Guid.Parse(ConP));
                return Json(result);
            }

     
        public JsonResult ListData_Customer(string ConP)
            {
                string sitecode = Session["SiteCode"].ToString();
                var result = service.GetList_ContactPerson_Customer_PageByConP(sitecode, Guid.Parse(ConP));
                return Json(result);
            }

      
        public JsonResult ListData_Subplier(string ConP)
            {
                string sitecode = Session["SiteCode"].ToString();
                var result = service.GetList_ContactPerson_Supplier_PageByConP(sitecode, Guid.Parse(ConP));
                return Json(result);
            }

       
        public JsonResult ListData_SubCon(string ConP)
            {
                string sitecode = Session["SiteCode"].ToString();
                var result = service.GetList_ContactPerson_SubCon_PageByConP(sitecode, Guid.Parse(ConP));
                return Json(result);
            }

            [SessionTimeout]
            public ActionResult EditPage(string ContectP, string Type_Code)
            {
                get_roles_fn();

                if (ViewBag.GetRoles != "Role_HD17")
                    return RedirectToAction("Logout", "Login");

                ViewBag.ContectP = ContectP;
                ViewBag.Type_Code = Type_Code;
                Session["PersonType"] = Type_Code;
               

                return View("EditPage", "_Architectui_Header_Layout");
            }


        [SessionTimeout]
        public ActionResult CreatePage(string Tab_Page)
            {
                get_roles_fn();

                if (ViewBag.GetRoles != "Role_HD17")
                    return RedirectToAction("Logout", "Login");

                ViewBag.PageName = "Contact Person";
                Session["PersonType"] = Tab_Page;
                
            // ViewBag.listType = service.Logi_GetContectPersonType();

                return View("CreatePage", "_Architectui_Header_Layout");
            }

            public JsonResult LoadPage()
            {
                var list = service.Logi_GetContectPersonType();
                return Json(list);
            }

        [SessionTimeout]
        public ActionResult CreatePerson(FormCollection from)
            {
                get_roles_fn();

                if (ViewBag.GetRoles != "Role_HD17")
                    return RedirectToAction("Logout", "Login");

                string PersonType = from["PersonType"];
                string Employee = from["Employee"];
                string Company = from["Company"];
                string ContectName = from["ContectName"];
                string Position = from["Position"];
                string Phone = from["Phoneh"];
                string Email = from["Emailh"];
                string LineID = from["LineID"];
                string ContectGroup = from["ContectGroup"];
                string note = from["note"];

                
                SaveContectPersonModels list = new SaveContectPersonModels()
                {
                    ContactP_Code = Guid.NewGuid(),
                    Site_Code = Session["SiteCode"].ToString(),
                    PType_Code = PersonType,
                    Employee_Code = Employee,
                    Company_Code = Company,
                    Contact_Name = ContectName,
                    Position_Code = Position,
                    Phone = Phone,
                    Email = Email,
                    LineID = LineID,
                    CG_Code = ContectGroup,
                    Note = note,
                    Update_by = Session["User_EmpCode"] as string,
                    Last_Update = DateTime.Now
                };

                ViewBag.Staus = service.Save_ContactPerson_Page(list).ToString();
            
                if (ViewBag.Staus == "True")
                {
                    //_writelog.WriteLog("Create", "HD Contact Person", "[" + Session["SiteCode"] as string + "] " + Employee + Company, false, Session["User_EmpName"] as string);
                    _writelog.WriteLog("Create", "HD Contact Person", "[" + Session["SiteCode"] as string + "] => " + list.ContactP_Code, false, Session["User_EmpName"] as string);
                }
                else
                {
                    _writelog.WriteLog("Create", "HD Contact Person", "[" + Session["SiteCode"] as string + "] => " + list.ContactP_Code + " => " +  ViewBag.Staus, true, Session["User_EmpName"] as string);
                }

                Session["PersonType"] = PersonType;
                return RedirectToAction("Index", "HD_ContactPerson");
            }
        //EditPerson

        //Create_ContactPerson
        [HttpPost]
        [SessionTimeout]
        public ActionResult EditPerson(Edit_ContactPerson data)
            {
                get_roles_fn();

                if (ViewBag.GetRoles != "Role_HD17")
                    return RedirectToAction("Logout", "Login");

                Guid ContactP_Code = data.ContactP_Code;
                string PersonType = data.PersonType;
                string Employee = data.Employee;
                string Company = data.Company;
                string ContectName = data.ContectName;
                string Position = data.Position;
                string Phone = data.Phoneh;
                string Email = data.Emailh;
                string LineID = data.LineID;
                string ContectGroup = data.ContectGroup;
                string note = data.note;

                SaveContectPersonModels list = new SaveContectPersonModels()
                {
                    ContactP_Code = ContactP_Code,
                    Site_Code = Session["SiteCode"].ToString(),
                    PType_Code = PersonType,
                    Employee_Code = Employee,
                    Company_Code = Company,
                    Contact_Name = ContectName,
                    Position_Code = Position,
                    Phone = Phone,
                    Email = Email,
                    LineID = LineID,
                    CG_Code = ContectGroup,
                    Note = note,
                    Update_by = Session["User_EmpCode"] as string,
                    Last_Update = DateTime.Now
                };

                ViewBag.Staus = service.Save_ContactPerson_Page(list).ToString();

                if (ViewBag.Staus == "True")
                {
                    _writelog.WriteLog("Edit", "HD Contact Person", "[" + Session["SiteCode"] as string + "] => " + ContactP_Code, false, Session["User_EmpName"] as string);
                }
                else
                {
                    _writelog.WriteLog("Edit", "HD Contact Person", "[" + Session["SiteCode"] as string + "] => " + ContactP_Code + " => " + ViewBag.Staus, true, Session["User_EmpName"] as string);
                }

                Session["PersonType"] = PersonType;
                return RedirectToAction("Index", "HD_ContactPerson");
            }


            public JsonResult Select_HET()
            {
                //get position **read**
                return Json("");
            }

       
        public JsonResult Select_Employee()
            {
                if (Session["Login"] == null)
                {
                    return Json(new { code = 1 });
                }

                string SiteCode = Session["SiteCode"].ToString();
                var list = service.GetList_Dropdown_Employee_Create_CP(SiteCode);
                return Json(list);
            }

            public JsonResult Select_EmployeeForEdit() 
            {
                var list = service.Logi_GetEmployee();
                return Json(list);
            }

    
        public JsonResult GetListEmployeeByEmpCode(string EMPCode)
            {
                if (Session["Login"] == null)
                {
                    return Json(new { code = 1 });
                }

                string SiteCode = Session["SiteCode"].ToString();
                var list = service.GetList_Dropdown_Employee_Create_CP(SiteCode).Where(x => x.Employee_Code == EMPCode).ToList();
                return Json(list);
        }

            public JsonResult list_Customer()
            {

                    var list = service.DropDown_Company_Customer();
                    return Json(list);
            
            }

            public JsonResult list_ConteactGroup()
            {
                var list = service.Logi_GetContact_Group();
                return Json(list);
            }

            public JsonResult list_ConteactGroup_Suplier()
            {
                var list = (from data in (service.Logi_GetContact_Group())
                            where data.PType_Code == "PType_003"
                            select data).ToList();
                return Json(list);
            }

            public JsonResult list_ConteactGroup_SubCon()
            {
                var list = (from data in (service.Logi_GetContact_Group())
                            where data.PType_Code == "PType_004"
                            select data).ToList();
                return Json(list);
            }
            public JsonResult Select_Supplier()
            {
                var list = service.DropDownCompany_Supplier();
                return Json(list);
            }
            public JsonResult Select_Sub_Con()
            {
                var list = service.DropDownCompany_SubCon();
                return Json(list);
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
            var s_MNRoles = _lstGetMainMenu.Where(a => a.MNR_Role == "PDSCPAGE002").FirstOrDefault();
            if (s_MNRoles != null)
                ViewBag.GetMNRoles = s_MNRoles.MNR_Role;
            else
                ViewBag.GetMNRoles = "";

            set_lstRoles();
            ViewBag.GetHDRoles = _lstGetRoles.Where(a => a.ROLE_Code.StartsWith("Role_HD")).ToList();

            var s_Roles = _lstGetRoles.Where(a => a.ROLE_Code == "Role_HD17" || a.ROLE_Code == "Role_HD18").FirstOrDefault();
            if (s_Roles != null)
                ViewBag.GetRoles = s_Roles.ROLE_Code;
            else
                ViewBag.GetRoles = "";
        }
                
        #endregion
    }
}

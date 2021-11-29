using _PDSC_Web.Config;
using _PDSC_Web.Controllers.ServiceControllers;
using _PDSC_Web.Function;
using _PDSC_Web.Service.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _PDSC_Web.Controllers._AboutUser
{
    public class LoginController : Controller
    {

        _Service_PDSC_Roles serv_roles = new _Service_PDSC_Roles();
        _GSCM_Employee emp = new _GSCM_Employee();        

        // GET: Login

        //[HttpGet, ActionName("Login")]
        public ActionResult Login()
        {
            ViewBag.Status = true;
            return View("Login", "_Architectui_Login");
        }

        
        public ActionResult Logining(FormCollection form)
        {
            //Get data from view 
            string Username = form["Username"];
            string Password = form["Password"];

            //Check User Login

            if (ModelState.IsValid)
            {
                //SCenter.lstGetMainMenu.Clear();
                //SCenter.lstGetRoles.Clear();
                if (Username != null || Username != "")
                {
                    
                    var check_login = serv_roles.Check_User_Login(Username, Password);

                    if (check_login != null && check_login.Count > 0)
                    {
                        var getdetail = (from data in check_login
                                            select data).FirstOrDefault();

                        Session["Login"] = getdetail.Username;
                        Session["User_Group"] = getdetail.Position_Group;

                        string usertype = getdetail.User_Type;

                        var _getemp = emp.Call_GetEmployee().Result
                           .Where(i => i.Username == getdetail.Username).FirstOrDefault();//.ToList();


                        if (_getemp != null)
                        {
                            Session["User_EmpName"] = _getemp.Name;
                            Session["User_EmpCode"] = _getemp.Employee_Code;
                            Session["User_Position"] = _getemp.Position_Code;
                        }


                        //foreach (var obj in Listemp) 
                        //{
                        //    Session["User_EmpName"] = obj.Name;
                        //    Session["User_EmpCode"] = obj.Employee_Code;
                        //}

                       
                        //var result = serv_roles.GetList_Main_Menu_by_Group(Session["User_Group"].ToString());

                        //if (result != null && result.Count > 0)
                        //{
                        //    List<string> listMNR = new List<string>();
                        //    foreach(var data in result.ToList())
                        //    {
                        //        listMNR.Add(data.MNR_Role);
                        //    }
                            
                        //    ViewData["ListMNR"] = listMNR;
                        //    //ViewBag.ListMNR = result.ToList();
                        //}

                        if (usertype == "AD") //must to send for check in AD of Hitachi (LDAP)
                        {
                            
                            //Check from LDAP
                            int port = 389;
                            bool isValid = new LdapManagement(Host.Domain_Ldap, port).Valid(Username, Password);
                                
                            if (isValid) //true
                            {
                                ViewBag.Status = true;
                                //return View("Welcome", "Home");
                                return RedirectToAction("Welcome", "Home");
                            }
                            else
                            {
                                Session.Clear();
                                Session.RemoveAll();
                                ViewBag.Status = false;
                                ViewBag.Message = "Username Or Password Invalid !!";
                                return View("Login", "_Architectui_Login");
                            }
                           
                        }
                        else if (usertype == "No AD")
                        {
                            ViewBag.Status = true;
                            //return View("Welcome", "Home");
                            return RedirectToAction("Welcome", "Home");
                        }
                        else
                        {
                            Session.Clear();
                            Session.RemoveAll();
                            ViewBag.Status = false;
                            ViewBag.Message = "Please contact admin!!";
                            return View("Login", "_Architectui_Login");
                        }

                        
                    }
                    else
                    {
                        ViewBag.Message = "Username Or Password Invalid !!";
                        ViewBag.Status = false;
                        return View("Login", "_Architectui_Login");
                    }
                    
                }
                    
                else
                {
                    ViewBag.Message = "Username Or Password Invalid !!";
                    ViewBag.Status = false;
                    return View("Login", "_Architectui_Login");
                }
                    
            }
            return View("Login", "_Architectui_Login");

            /* LoginServiceControllers login = new LoginServiceControllers();
             bool status = login.CheckLogin(Username, Password);

             if (status)
             {*/
            //ViewBag.Status = true;
            //return RedirectToAction("Welcome", "Home");
            /*  }
              else
              {
                  ViewBag.Status = false;
              }*/

            // return View("Login", "_Architectui_Login");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.RemoveAll();
            //SCenter.lstGetMainMenu.Clear();
            //SCenter.lstGetRoles.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}
using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Models.Table;
using _PDSC_Web.Models.ViewModels;
using _PDSC_Web.Service.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Controllers.ServiceControllers
{
    public class _HD_ContectPersonControllers
    {
        #region ### New Object ###
        _ContectPerson _contect = new _ContectPerson();
        _GSCM_Customer _customer = new _GSCM_Customer();
        _GSCM_Sub_Con _subcon = new _GSCM_Sub_Con();
        _GSCM_Supplier _supplier = new _GSCM_Supplier();
        _GSCM_Employee _employee = new _GSCM_Employee();
        _Contact_Group _congroup = new _Contact_Group();
        _Person_Type _Person = new _Person_Type();
        #endregion

        public bool Logi_ContectPerson(Contact_Person list)
        {
            bool Status = false;
            Contact_Person obj = new Contact_Person();

            try
            {
                string Msg = _contect.CallCreate_ContectPerson(list).Result;

                if (Msg == "Succes")
                {
                    Status = true;
                }
            }
            catch (Exception ex)
            {

            }
            return Status;
        }

        public List<DDCompany_CustomerModel> DropDown_Company_Customer()
        {
            List<DDCompany_CustomerModel> result = new List<DDCompany_CustomerModel>();
            try
            {
                result = _customer.Call_DropDown_Company_Customer().Result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<DDCompany_SubConModel> DropDownCompany_SubCon()
        {
            List<DDCompany_SubConModel> result = new List<DDCompany_SubConModel>();
            try
            {
                result = _subcon.Call_DropDownCompany_SubCon().Result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<DDCompany_SupplierModel> DropDownCompany_Supplier()
        {
            List<DDCompany_SupplierModel> result = new List<DDCompany_SupplierModel>();
            try
            {
                result = _supplier.Call_DropDownCompany_Supplier().Result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<Person_Type> Logi_GetContectPersonType()
        {
            List<Person_Type> result = new List<Person_Type>();
            try
            {
                result = _Person.Call_GetContectPersonType().Result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<Contact_Group> Logi_GetContact_Group()
        {
            List<Contact_Group> result = new List<Contact_Group>();
            try
            {
                result = _congroup.Call_GetContact_Group().Result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<ListAllEmployeeModel> Logi_GetEmployee()
        {
            List<ListAllEmployeeModel> result = new List<ListAllEmployeeModel>();
            try
            {
                result = (from data in (_employee.Call_GetEmployee().Result)
                          where data.Position_Code != "130"
                          select data).ToList();
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<ContactPersonModels> GetList_ContactPerson_SubCon_Page(string sitecode)
        {
            List<ContactPersonModels> result = new List<ContactPersonModels>();
            try
            {
                result = _contect.Call_GetList_ContactPerson_SubCon_Page(sitecode).Result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<ContactPersonModels> GetList_ContactPerson_Supplier_Page(string sitecode)
        {
            List<ContactPersonModels> result = new List<ContactPersonModels>();
            try
            {
                result = _contect.Call_GetList_ContactPerson_Supplier_Page(sitecode).Result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<ContactPersonModels> GetList_ContactPerson_Customer_Page(string sitecode)
        {
            List<ContactPersonModels> result = new List<ContactPersonModels>();
            try
            {
                result = _contect.Call_GetList_ContactPerson_Customer_Page(sitecode).Result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<ContactPersonModels> GetList_ContactPerson_HET_Page(string sitecode)
        {
            List<ContactPersonModels> result = new List<ContactPersonModels>();
            try
            {
                result = _contect.Call_GetList_ContactPerson_HET_Page(sitecode).Result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        //
        public List<ContactPersonModels> GetList_ContactPerson_HET_PageByConP(string sitecode, Guid ConP)
        {
            List<ContactPersonModels> result = new List<ContactPersonModels>();
            try
            {
                result = (from data in (_contect.Call_GetList_ContactPerson_HET_Page(sitecode).Result)
                          where data.ContactP_Code == ConP
                          select data).ToList();
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<ContactPersonModels> GetList_ContactPerson_SubCon_PageByConP(string sitecode, Guid ConP)
        {
            List<ContactPersonModels> result = new List<ContactPersonModels>();
            try
            {
                result = (from data in (_contect.Call_GetList_ContactPerson_SubCon_Page(sitecode).Result)
                          where data.ContactP_Code == ConP
                          select data).ToList();
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<ContactPersonModels> GetList_ContactPerson_Supplier_PageByConP(string sitecode, Guid ConP)
        {
            List<ContactPersonModels> result = new List<ContactPersonModels>();
            try
            {
                result = (from data in (_contect.Call_GetList_ContactPerson_Supplier_Page(sitecode).Result)
                          where data.ContactP_Code == ConP
                          select data).ToList();
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<ContactPersonModels> GetList_ContactPerson_Customer_PageByConP(string sitecode, Guid ConP)
        {
            List<ContactPersonModels> result = new List<ContactPersonModels>();
            try
            {
                result = (from data in (_contect.Call_GetList_ContactPerson_Customer_Page(sitecode).Result)
                          where data.ContactP_Code == ConP
                          select data).ToList();
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        //

        public List<ListEmployeeModel> GetListEmployee(string EmpCode)
        {
            List<ListEmployeeModel> result = new List<ListEmployeeModel>();
            try
            {
                result = _employee.Call_GetListEmployee(EmpCode).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            return result;
        }

        public string Delete_ContactPerson_byRow_Page(DeleteContactPersonModels list)
        {
            string msg = "";
            try
            {
                msg = _contect.Call_Delete_ContactPerson_byRow_Page(list).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  : " + ex);
            }
            return msg;
        }

        public string Save_ContactPerson_Page(SaveContectPersonModels list)
        {
            string msg = "";
            try
            {
                msg = _contect.Call_Save_ContactPerson_Page(list).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  : " + ex);
            }
            return msg;
        }

        public List<ListDropDownEmp_VM> GetList_Dropdown_Employee_Create_CP(string SiteCode)
        {
            List<ListDropDownEmp_VM> result = new List<ListDropDownEmp_VM>();
            try
            {
                result = _employee.Call_GetList_Dropdown_Employee_Create_CP(SiteCode).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            return result;
        }

    }
}
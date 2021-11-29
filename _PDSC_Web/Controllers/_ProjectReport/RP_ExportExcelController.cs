using _PDSC_Web.Controllers.ServiceControllers;
using _PDSC_Web.Function;
using _PDSC_Web.Models.ViewModels;
using _PDSC_Web.Service.Table;
using java.nio.file;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _PDSC_Web.Controllers._ProjectReport
{
    public class RP_ExportExcelController : Controller
    {
        // GET: RP_ExportExcel
        _GSCM_Employee emp = new _GSCM_Employee();
        _RP_ExportExcel exportexcel = new _RP_ExportExcel();
        _Service_PDSC_Roles serv_roles = new _Service_PDSC_Roles();
        List<Get_Main_Menu2> _lstGetMainMenu = new List<Get_Main_Menu2>();
        List<GetList_Roles> _lstGetRoles = new List<GetList_Roles>();

        [SessionTimeout]
        public ActionResult Index()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.ReportPage = "RP_Master_File";

            return View("Index", "_Architectui_Report");
        }

        public JsonResult Export_Excel()
        {

            bool status = false;
            List<string> resp = new List<string>();

           // ExcelPackage.LicenseContext = LicenseContext.Commercial;

            var result = exportexcel.GetList_Master_File();
            var head_result = exportexcel.Get_Task();

            


            string[] header = new string[]
            {
              "MFG.NO.", //1   
              "COM.",    //2
              "SO No.",  //3
              "WORK APPROVAL", //4  
              "CONTRACT TIME FRAME", //5   
              "CLOSED PROJECT"    //6             
            };


          

            int index_site_info_end = header.Length + 7;
            int index_person_in_end = index_site_info_end + 8;

            try
            {
                DateTime mydate = DateTime.Now;

                // string rootFolder = @"\MasterFileReport";
                string mypath = System.Web.Hosting.HostingEnvironment.MapPath("~/MasterFileReport");
                //  string FileName = $"{Guid.NewGuid()}_My_Reports_{DateTime.Now.ToString("yyyy_MM_dd")}";
                string FileName = "Master_File_" + mydate.ToString("ddMMMyyyy_HHmmss");
                string FileNameSent = $"My_Reports_{DateTime.Now.ToString("yyyy_MM_dd")}";
                string FileExtension = ".xlsx";
                string FullPath = mypath + FileName + FileExtension;

                /* Check path folder*/               

                // string mypath = System.Web.Hosting.HostingEnvironment.MapPath("~/MasterFileReport");

                if (!Directory.Exists(mypath))
                {
                    Directory.CreateDirectory(mypath);
                }
                else
                {
                    
                }

                // string mypath = System.Web.Hosting.HostingEnvironment.MapPath("~/Test");

                /* End Check path folder*/

                FileInfo file = new FileInfo(System.IO.Path.Combine(mypath, FileName + FileExtension));
                if (System.IO.File.Exists(mypath + FileName + FileExtension).Equals(true))// Check for duplicate files
                {
                    try
                    {
                        System.IO.File.Delete(FullPath);
                    }
                    catch
                    {
                        return null;
                    }
                }

                using (ExcelPackage package = new ExcelPackage(file))
                {
                    ExcelWorksheet ws = package.Workbook.Worksheets.Add("MasterFileReport");
                    if (result.Count > 0)
                    {
                        ws.Cells[5, 1].LoadFromCollection(result, false);
                     
                    }
                     var rows = result.Count + 4;
                  

                    #region formate
                    ws.Cells[5, 22, rows, 22].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 23, rows, 23].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 24, rows, 24].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 25, rows, 25].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 36, rows, 36].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 37, rows, 37].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 41, rows, 41].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 45, rows, 45].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 49, rows, 49].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 53, rows, 53].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 57, rows, 57].Style.Numberformat.Format = "dd/MM/yyyy";

                    ws.Cells[5, 61, rows, 61].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 65, rows, 65].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 69, rows, 69].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 73, rows, 73].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 74, rows,74 ].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 75, rows, 75].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 79, rows, 79].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 83, rows, 83].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 87, rows, 87].Style.Numberformat.Format = "dd/MM/yyyy";

                    ws.Cells[5, 91, rows, 91].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 92, rows, 92].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 93, rows, 93].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 97, rows, 97].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 101, rows, 101].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 105, rows,105 ].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 109, rows, 109].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 113, rows, 113].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 117, rows, 117].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 121, rows, 121].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 125, rows, 125].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 129, rows, 129].Style.Numberformat.Format = "dd/MM/yyyy";  //DY

                    ws.Cells[5, 134, rows,134 ].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 138, rows, 138].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 142, rows, 142].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 146, rows, 146].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 150, rows,150 ].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 154, rows,154 ].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 158, rows, 158].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5,162 , rows,162 ].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 166, rows,166 ].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 170, rows,170 ].Style.Numberformat.Format = "dd/MM/yyyy";

                    ws.Cells[5, 175, rows, 175].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 176, rows, 176].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 177, rows, 177].Style.Numberformat.Format = "dd/MM/yyyy";  //FU

                    ws.Cells[5, 181, rows, 181].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 182, rows, 182].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 186, rows, 186].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 190, rows,190 ].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 195, rows, 195].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5,196 , rows, 196].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 197, rows,197 ].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 201, rows, 201].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 205, rows, 205].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 209, rows,209 ].Style.Numberformat.Format = "dd/MM/yyyy"; //HA

                    ws.Cells[5, 214, rows, 214].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 218, rows, 218].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 222, rows, 222].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 226, rows, 226].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 230, rows, 230].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 234, rows, 234].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 238, rows,238 ].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 242, rows,242 ].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 246, rows,246 ].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 250, rows,250 ].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 254, rows, 254].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 258, rows,258 ].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 262, rows,262 ].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 266, rows, 266].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 270, rows, 270].Style.Numberformat.Format = "dd/MM/yyyy"; //JF

                    ws.Cells[5, 289, rows, 289].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 290, rows,290 ].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 291, rows, 291].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[5, 294, rows, 294].Style.Numberformat.Format = "dd/MM/yyyy";
                    #endregion

                    #region   cell 

                    ws.Cells[1, 1].Value = "MFG.NO.";
                    ws.Cells[1, 1].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, 1, 4, 1].Merge = true;
                    ws.Cells[1, 1, 4, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, 1, 4, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    ws.Cells[1, 2].Value = "COM.";
                    ws.Cells[1, 2].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, 2, 4, 2].Merge = true;
                    ws.Cells[1, 2, 4, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, 2, 4, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    ws.Cells[1, 3].Value = "SO No.";
                    ws.Cells[1, 3].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, 3, 4, 3].Merge = true;
                    ws.Cells[1, 3, 4, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, 3, 4, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    ws.Cells[1, 4].Value = "WORK APPROVAL";
                    ws.Cells[1, 4].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, 4, 4, 4].Merge = true;
                    ws.Cells[1, 4, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, 4, 4, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    ws.Cells[1, 5].Value = "CONTRACT TIME FRAME";
                    ws.Cells[1, 5].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, 5, 4, 5].Merge = true;
                    ws.Cells[1, 5, 4, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, 5, 4, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    ws.Cells[1, 6].Value = "CLOSED PROJECT";
                    ws.Cells[1, 6].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, 6, 4, 6].Merge = true;
                    ws.Cells[1, 6, 4, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, 6, 4, 6].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                    #endregion

                    #region cells SITE INFORMATION
                    // site information
                    ws.Cells[1, header.Length + 1].Value = "SITE INFORMATION";
                    ws.Cells[1, header.Length + 1].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, header.Length + 1, 3, header.Length + 7].Merge = true;
                    ws.Cells[1, header.Length + 1, 3, header.Length + 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, header.Length + 1, 3, header.Length + 7].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub site information 
                    ws.Cells[4, header.Length + 1].Value = "SITE No.";
                    ws.Cells[4, header.Length + 1].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells[4, header.Length + 2].Value = "SITE NAME";
                    ws.Cells[4, header.Length + 2].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells[4, header.Length + 3].Value = "EQ No.";
                    ws.Cells[4, header.Length + 3].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells[4, header.Length + 4].Value = "EL";
                    ws.Cells[4, header.Length + 4].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells[4, header.Length + 5].Value = "ES";
                    ws.Cells[4, header.Length + 5].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells[4, header.Length + 6].Value = "MSW";
                    ws.Cells[4, header.Length + 6].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells[4, header.Length + 7].Value = "EQ";
                    ws.Cells[4, header.Length + 7].Style.Font.Color.SetColor(System.Drawing.Color.Green);
                    ws.Cells[4, header.Length + 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    #endregion

                    #region cells PERSON IN CHARGE
                    Color colFromHex_personInCharge = System.Drawing.ColorTranslator.FromHtml("#1CE4E7");
                    //person in charge
                    ws.Cells[1, index_site_info_end + 1].Value = "PERSON IN CHARGE";
                    ws.Cells[1, index_site_info_end + 1].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, index_site_info_end + 1, 3, index_site_info_end + 8].Merge = true;
                    ws.Cells[1, index_site_info_end + 1, 3, index_site_info_end + 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[1, index_site_info_end + 1, 3, index_site_info_end + 8].Style.Fill.BackgroundColor.SetColor(colFromHex_personInCharge);
                    ws.Cells[1, index_site_info_end + 1, 3, index_site_info_end + 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, index_site_info_end + 1, 3, index_site_info_end + 8].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub person in charge
                    ws.Cells[4, index_site_info_end + 1].Value = "DM PROJECT";                   
                    ws.Cells[4, index_site_info_end + 1].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, index_site_info_end + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, index_site_info_end + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, index_site_info_end + 1].Style.Fill.BackgroundColor.SetColor(colFromHex_personInCharge);

                    ws.Cells[4, index_site_info_end + 2].Value = "LEADER";
                    ws.Cells[4, index_site_info_end + 2].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, index_site_info_end + 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, index_site_info_end + 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, index_site_info_end + 2].Style.Fill.BackgroundColor.SetColor(colFromHex_personInCharge);

                    ws.Cells[4, index_site_info_end + 3].Value = "PE";
                    ws.Cells[4, index_site_info_end + 3].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, index_site_info_end + 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, index_site_info_end + 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, index_site_info_end + 3].Style.Fill.BackgroundColor.SetColor(colFromHex_personInCharge);

                    ws.Cells[4, index_site_info_end + 4].Value = "INST MP";
                    ws.Cells[4, index_site_info_end + 4].Style.Font.Color.SetColor(System.Drawing.Color.Green);
                    ws.Cells[4, index_site_info_end + 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, index_site_info_end + 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, index_site_info_end + 4].Style.Fill.BackgroundColor.SetColor(colFromHex_personInCharge);

                    ws.Cells[4, index_site_info_end + 5].Value = "PO. NO SUBCONTACT";
                    ws.Cells[4, index_site_info_end + 5].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, index_site_info_end + 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, index_site_info_end + 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, index_site_info_end + 5].Style.Fill.BackgroundColor.SetColor(colFromHex_personInCharge);

                    ws.Cells[4, index_site_info_end + 6].Value = "TEST MP";
                    ws.Cells[4, index_site_info_end + 6].Style.Font.Color.SetColor(System.Drawing.Color.Green);
                    ws.Cells[4, index_site_info_end + 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, index_site_info_end + 6].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, index_site_info_end + 6].Style.Fill.BackgroundColor.SetColor(colFromHex_personInCharge);

                    ws.Cells[4, index_site_info_end + 7].Value = "SM QC";
                    ws.Cells[4, index_site_info_end + 7].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, index_site_info_end + 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, index_site_info_end + 7].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, index_site_info_end + 7].Style.Fill.BackgroundColor.SetColor(colFromHex_personInCharge);

                    ws.Cells[4, index_site_info_end + 8].Value = "SALESMAN";
                    ws.Cells[4, index_site_info_end + 8].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, index_site_info_end + 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, index_site_info_end + 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, index_site_info_end + 8].Style.Fill.BackgroundColor.SetColor(colFromHex_personInCharge);
                    #endregion

                    #region cells CONTRACT
                    Color colFromHex_Contract = System.Drawing.ColorTranslator.FromHtml("#1C85E7");
                     // Contract
                    ws.Cells[1, index_person_in_end+1].Value = "CONTRACT";
                    ws.Cells[1, index_person_in_end + 1].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, index_person_in_end + 1, 3, index_person_in_end + 4].Merge = true;
                    ws.Cells[1, index_person_in_end + 1, 3, index_person_in_end + 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[1, index_person_in_end + 1, 3, index_person_in_end + 4].Style.Fill.BackgroundColor.SetColor(colFromHex_Contract);
                    ws.Cells[1, index_person_in_end + 1, 3, index_person_in_end + 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, index_person_in_end + 1, 3, index_person_in_end + 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub contract

                    ws.Cells[4, index_person_in_end + 1].Value = "REV.";
                    ws.Cells[4, index_person_in_end + 1].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, index_person_in_end + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, index_person_in_end + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, index_person_in_end + 1].Style.Fill.BackgroundColor.SetColor(colFromHex_Contract);

                    ws.Cells[4, index_person_in_end + 2].Value = "DELIVER";
                    ws.Cells[4, index_person_in_end + 2].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, index_person_in_end + 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, index_person_in_end + 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, index_person_in_end + 2].Style.Fill.BackgroundColor.SetColor(colFromHex_Contract);

                    ws.Cells[4, index_person_in_end + 3].Value = "H/O";
                    ws.Cells[4, index_person_in_end + 3].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, index_person_in_end + 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, index_person_in_end + 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, index_person_in_end + 3].Style.Fill.BackgroundColor.SetColor(colFromHex_Contract);

                    ws.Cells[4, index_person_in_end + 4].Value = "REVISED H/O";
                    ws.Cells[4, index_person_in_end + 4].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    ws.Cells[4, index_person_in_end + 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, index_person_in_end + 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, index_person_in_end + 4].Style.Fill.BackgroundColor.SetColor(colFromHex_Contract);


                    #endregion

                    #region EQ INFORMATION

                   
                    // EQ INFORMATION
                    ws.Cells[1, header.Length + 20].Value = "EQ INFORMATION";
                    ws.Cells[1, header.Length + 20].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, header.Length + 20, 3, header.Length + 29].Merge = true;                 
                    ws.Cells[1, header.Length + 20, 3, header.Length + 29].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, header.Length + 20, 3, header.Length + 29].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    // sub EQ

                    ws.Cells[4, header.Length + 20].Value = "SPECIFICATION";
                    ws.Cells[4, header.Length + 20].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells[4, header.Length + 21].Value = "TYPE";
                    ws.Cells[4, header.Length + 21].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 21].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells[4, header.Length + 22].Value = "CAPACITY";
                    ws.Cells[4, header.Length + 22].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells[4, header.Length + 23].Value = "SPEED";
                    ws.Cells[4, header.Length + 23].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 23].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells[4, header.Length + 24].Value = "S";
                    ws.Cells[4, header.Length + 24].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 24].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells[4, header.Length + 25].Value = "F";
                    ws.Cells[4, header.Length + 25].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 25].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells[4, header.Length + 26].Value = "Rise(mm.)";
                    ws.Cells[4, header.Length + 26].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 26].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells[4, header.Length + 27].Value = "PRICE";
                    ws.Cells[4, header.Length + 27].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 27].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells[4, header.Length + 28].Value = "PROVINCE";
                    ws.Cells[4, header.Length + 28].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells[4, header.Length + 29].Value = "LOCATION";
                    ws.Cells[4, header.Length + 29].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 29].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



                    #endregion

                    #region  preapre stage
                    //cells prepare header
                    Color colFromHex_y = System.Drawing.ColorTranslator.FromHtml("#E8F37D");
                    
                    Color colFromHex_b = System.Drawing.ColorTranslator.FromHtml("#7DAAF3");
                    Color colFromHex_g = System.Drawing.ColorTranslator.FromHtml("#7DF384");
                    Color colFromHex_hevy_g = System.Drawing.ColorTranslator.FromHtml("#088607");

                    ws.Cells[1, header.Length + 30].Value = "Prepare Stage";
                    ws.Cells[1, header.Length + 30].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, header.Length + 30, 1, header.Length + 66].Merge = true;
                    ws.Cells[1, header.Length + 30, 1, header.Length + 66].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[1, header.Length + 30, 1, header.Length + 66].Style.Fill.BackgroundColor.SetColor(colFromHex_y);
                    ws.Cells[1, header.Length + 30, 1, header.Length + 66].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, header.Length + 30, 1, header.Length + 66].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //plan start date
                    ws.Cells[2, header.Length + 30].Value = "Plan Start Date";
                    ws.Cells[2, header.Length + 30].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 30, 4, header.Length + 30].Merge = true;
                    ws.Cells[2, header.Length + 30, 4, header.Length + 30].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 30, 4, header.Length + 30].Style.Fill.BackgroundColor.SetColor(colFromHex_y);
                    ws.Cells[2, header.Length + 30, 4, header.Length + 30].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 30, 4, header.Length + 30].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    // cells 1
                    ws.Cells[2, header.Length + 31].Value = head_result.Where(x => x.Task_Code == "T0001").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 31].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 31, 3, header.Length + 34].Merge = true;
                    ws.Cells[2, header.Length + 31, 3, header.Length + 34].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 31, 3, header.Length + 34].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[2, header.Length + 31, 3, header.Length + 34].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 31, 3, header.Length + 34].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells 1
                    ws.Cells[4, header.Length + 31].Value = "Working Date";
                    ws.Cells[4, header.Length + 31].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 31].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 31].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 31].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 32].Value = "Result";
                    ws.Cells[4, header.Length + 32].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 32].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 32].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 32].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 33].Value = "Problem";
                    ws.Cells[4, header.Length + 33].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 32].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 33].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 33].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 34].Value = "Problem Note";
                    ws.Cells[4, header.Length + 34].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 34].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 34].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 34].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    // cells 2
                    ws.Cells[2, header.Length + 35].Value = head_result.Where(x => x.Task_Code == "T0002").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 35].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 35, 3, header.Length + 38].Merge = true;
                    ws.Cells[2, header.Length + 35, 3, header.Length + 38].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 35, 3, header.Length + 38].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[2, header.Length + 35, 3, header.Length + 38].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 35, 3, header.Length + 38].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells 2
                    ws.Cells[4, header.Length + 35].Value = "Working Date";
                    ws.Cells[4, header.Length + 35].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 35].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 35].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 35].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 36].Value = "Result";
                    ws.Cells[4, header.Length + 36].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 36].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 36].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 36].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 37].Value = "Problem";
                    ws.Cells[4, header.Length + 37].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 37].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 37].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 37].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 38].Value = "Problem Note";
                    ws.Cells[4, header.Length + 38].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 38].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 38].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 38].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    // cells 3
                    ws.Cells[2, header.Length + 39].Value = head_result.Where(x => x.Task_Code == "T0003").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 39].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 39, 3, header.Length + 42].Merge = true;
                    ws.Cells[2, header.Length + 39, 3, header.Length + 42].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 39, 3, header.Length + 42].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[2, header.Length + 39, 3, header.Length + 42].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 39, 3, header.Length + 42].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells 3
                    ws.Cells[4, header.Length + 39].Value = "Working Date";
                    ws.Cells[4, header.Length + 39].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 39].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 39].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 39].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 40].Value = "Result";
                    ws.Cells[4, header.Length + 40].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 40].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 40].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 40].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 41].Value = "Problem";
                    ws.Cells[4, header.Length + 41].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 41].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 41].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 41].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 42].Value = "Problem Note";
                    ws.Cells[4, header.Length + 42].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 42].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 42].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 42].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    // cells 4
                    ws.Cells[2, header.Length + 43].Value = head_result.Where(x => x.Task_Code == "T0004").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 43].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 43, 3, header.Length + 46].Merge = true;
                    ws.Cells[2, header.Length + 43, 3, header.Length + 46].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 43, 3, header.Length + 46].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[2, header.Length + 43, 3, header.Length + 46].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 43, 3, header.Length + 46].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells 4
                    ws.Cells[4, header.Length + 43].Value = "Working Date";
                    ws.Cells[4, header.Length + 43].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 43].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 43].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 43].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 44].Value = "Result";
                    ws.Cells[4, header.Length + 44].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 44].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 44].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 44].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 45].Value = "Problem";
                    ws.Cells[4, header.Length + 45].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 45].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 45].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 45].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 46].Value = "Problem Note";
                    ws.Cells[4, header.Length + 46].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 46].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 46].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 46].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    // cells 5
                    ws.Cells[2, header.Length + 47].Value = head_result.Where(x => x.Task_Code == "T0005").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 47].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 47, 3, header.Length + 50].Merge = true;
                    ws.Cells[2, header.Length + 47, 3, header.Length + 50].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 47, 3, header.Length + 50].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[2, header.Length + 47, 3, header.Length + 50].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 47, 3, header.Length + 50].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells 5
                    ws.Cells[4, header.Length + 47].Value = "Working Date";
                    ws.Cells[4, header.Length + 47].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 47].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 47].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 47].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 48].Value = "Result";
                    ws.Cells[4, header.Length + 48].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 48].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 48].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 48].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 49].Value = "Problem";
                    ws.Cells[4, header.Length + 49].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 49].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 49].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 49].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 50].Value = "Problem Note";
                    ws.Cells[4, header.Length + 50].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 50].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 50].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 50].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ////
                    
                    // cells b 1
                    ws.Cells[2, header.Length + 51].Value = head_result.Where(x => x.Task_Code == "T0048").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 51].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 51, 3, header.Length + 54].Merge = true;
                    ws.Cells[2, header.Length + 51, 3, header.Length + 54].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 51, 3, header.Length + 54].Style.Fill.BackgroundColor.SetColor(colFromHex_b);
                    ws.Cells[2, header.Length + 51, 3, header.Length + 54].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 51, 3, header.Length + 54].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells b 1
                    ws.Cells[4, header.Length + 51].Value = "Working Date";
                    ws.Cells[4, header.Length + 51].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 51].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 51].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 51].Style.Fill.BackgroundColor.SetColor(colFromHex_b);

                    ws.Cells[4, header.Length + 52].Value = "Result";
                    ws.Cells[4, header.Length + 52].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 52].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 52].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 52].Style.Fill.BackgroundColor.SetColor(colFromHex_b);

                    ws.Cells[4, header.Length + 53].Value = "Problem";
                    ws.Cells[4, header.Length + 53].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 53].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 53].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 53].Style.Fill.BackgroundColor.SetColor(colFromHex_b);

                    ws.Cells[4, header.Length + 54].Value = "Problem Note";
                    ws.Cells[4, header.Length + 54].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 54].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 54].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 54].Style.Fill.BackgroundColor.SetColor(colFromHex_b);


                    // cells b 2
                    ws.Cells[2, header.Length + 55].Value = head_result.Where(x => x.Task_Code == "T0049").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 55].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 55, 3, header.Length + 58].Merge = true;
                    ws.Cells[2, header.Length + 55, 3, header.Length + 58].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 55, 3, header.Length + 58].Style.Fill.BackgroundColor.SetColor(colFromHex_b);
                    ws.Cells[2, header.Length + 55, 3, header.Length + 58].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 55, 3, header.Length + 58].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells b 2
                    ws.Cells[4, header.Length + 55].Value = "Working Date";
                    ws.Cells[4, header.Length + 55].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 55].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 55].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 55].Style.Fill.BackgroundColor.SetColor(colFromHex_b);

                    ws.Cells[4, header.Length + 56].Value = "Result";
                    ws.Cells[4, header.Length + 56].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 56].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 56].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 56].Style.Fill.BackgroundColor.SetColor(colFromHex_b);

                    ws.Cells[4, header.Length + 57].Value = "Problem";
                    ws.Cells[4, header.Length + 57].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 57].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 57].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 57].Style.Fill.BackgroundColor.SetColor(colFromHex_b);

                    ws.Cells[4, header.Length + 58].Value = "Problem Note";
                    ws.Cells[4, header.Length + 58].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 58].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 58].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 58].Style.Fill.BackgroundColor.SetColor(colFromHex_b);

                    // cells b 3
                    ws.Cells[2, header.Length + 59].Value = head_result.Where(x => x.Task_Code == "T0050").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 59].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 59, 3, header.Length + 62].Merge = true;
                    ws.Cells[2, header.Length + 59, 3, header.Length + 62].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 59, 3, header.Length + 62].Style.Fill.BackgroundColor.SetColor(colFromHex_b);
                    ws.Cells[2, header.Length + 59, 3, header.Length + 62].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 59, 3, header.Length + 62].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells b 3
                    ws.Cells[4, header.Length + 59].Value = "Working Date";
                    ws.Cells[4, header.Length + 59].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 59].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 59].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 59].Style.Fill.BackgroundColor.SetColor(colFromHex_b);

                    ws.Cells[4, header.Length + 60].Value = "Result";
                    ws.Cells[4, header.Length + 60].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 60].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 60].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 60].Style.Fill.BackgroundColor.SetColor(colFromHex_b);

                    ws.Cells[4, header.Length + 61].Value = "Problem";
                    ws.Cells[4, header.Length + 61].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 61].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 61].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 61].Style.Fill.BackgroundColor.SetColor(colFromHex_b);

                    ws.Cells[4, header.Length + 62].Value = "Problem Note";
                    ws.Cells[4, header.Length + 62].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 62].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 62].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 62].Style.Fill.BackgroundColor.SetColor(colFromHex_b);

                    // cells b 4
                    ws.Cells[2, header.Length + 63].Value = head_result.Where(x => x.Task_Code == "T0051").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 63].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 63, 3, header.Length + 66].Merge = true;
                    ws.Cells[2, header.Length + 63, 3, header.Length + 66].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 63, 3, header.Length + 66].Style.Fill.BackgroundColor.SetColor(colFromHex_b);
                    ws.Cells[2, header.Length + 63, 3, header.Length + 66].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 63, 3, header.Length + 66].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells b 4
                    ws.Cells[4, header.Length + 63].Value = "Working Date";
                    ws.Cells[4, header.Length + 63].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 63].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 63].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 63].Style.Fill.BackgroundColor.SetColor(colFromHex_b);

                    ws.Cells[4, header.Length + 64].Value = "Result";
                    ws.Cells[4, header.Length + 64].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 64].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 64].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 64].Style.Fill.BackgroundColor.SetColor(colFromHex_b);

                    ws.Cells[4, header.Length + 65].Value = "Problem";
                    ws.Cells[4, header.Length + 65].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 65].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 65].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 65].Style.Fill.BackgroundColor.SetColor(colFromHex_b);

                    ws.Cells[4, header.Length + 66].Value = "Problem Note";
                    ws.Cells[4, header.Length + 66].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 66].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 66].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 66].Style.Fill.BackgroundColor.SetColor(colFromHex_b);




                    #endregion

                    #region delivery stage

                    //cells delivery header

                    ws.Cells[1, header.Length + 67].Value = "Delivery Stage";
                    ws.Cells[1, header.Length + 67].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, header.Length + 67, 1, header.Length + 84].Merge = true;
                    ws.Cells[1, header.Length + 67, 1, header.Length + 84].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[1, header.Length + 67, 1, header.Length + 84].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[1, header.Length + 67, 1, header.Length + 84].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, header.Length + 67, 1, header.Length + 84].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //plan start date
                    ws.Cells[2, header.Length + 67].Value = "Plan Start Date";
                    ws.Cells[2, header.Length + 67].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 67, 4, header.Length + 67].Merge = true;
                    ws.Cells[2, header.Length + 67, 4, header.Length + 67].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 67, 4, header.Length + 67].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[2, header.Length + 67, 4, header.Length + 67].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 67, 4, header.Length + 67].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //plan finish date
                    ws.Cells[2, header.Length + 68].Value = "Plan Finish Date";
                    ws.Cells[2, header.Length + 68].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 68, 4, header.Length + 68].Merge = true;
                    ws.Cells[2, header.Length + 68, 4, header.Length + 68].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 68, 4, header.Length + 68].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[2, header.Length + 68, 4, header.Length + 68].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 68, 4, header.Length + 68].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                    //cell 1
                    ws.Cells[2, header.Length + 69].Value = head_result.Where(x => x.Task_Code == "T0006").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 69].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 69, 3, header.Length + 72].Merge = true;
                    ws.Cells[2, header.Length + 69, 3, header.Length + 72].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 69, 3, header.Length + 72].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[2, header.Length + 69, 3, header.Length + 72].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 69, 3, header.Length + 72].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells 1
                    ws.Cells[4, header.Length + 69].Value = "Working Date";
                    ws.Cells[4, header.Length + 69].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 69].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 69].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 69].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 70].Value = "Result";
                    ws.Cells[4, header.Length + 70].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 70].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 70].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 70].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 71].Value = "Problem";
                    ws.Cells[4, header.Length + 71].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 71].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 71].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 71].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 72].Value = "Problem Note";
                    ws.Cells[4, header.Length + 72].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 72].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 72].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 72].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    //cell 2
                    ws.Cells[2, header.Length + 73].Value = head_result.Where(x => x.Task_Code == "T0007").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 73].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 73, 3, header.Length + 76].Merge = true;
                    ws.Cells[2, header.Length + 73, 3, header.Length + 76].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 73, 3, header.Length + 76].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[2, header.Length + 73, 3, header.Length + 76].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 73, 3, header.Length + 76].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells 2
                    ws.Cells[4, header.Length + 73].Value = "Working Date";
                    ws.Cells[4, header.Length + 73].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 73].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 73].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 73].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 74].Value = "Result";
                    ws.Cells[4, header.Length + 74].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 74].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 74].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 74].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 75].Value = "Problem";
                    ws.Cells[4, header.Length + 75].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 75].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 75].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 75].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 76].Value = "Problem Note";
                    ws.Cells[4, header.Length + 76].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 76].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 76].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 76].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    //cell 3
                    ws.Cells[2, header.Length + 77].Value = head_result.Where(x => x.Task_Code == "T0008").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 77].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 77, 3, header.Length + 80].Merge = true;
                    ws.Cells[2, header.Length + 77, 3, header.Length + 80].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 77, 3, header.Length + 80].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[2, header.Length + 77, 3, header.Length + 80].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 77, 3, header.Length + 80].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells 3
                    ws.Cells[4, header.Length + 77].Value = "Working Date";
                    ws.Cells[4, header.Length + 77].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 77].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 77].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 77].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 78].Value = "Result";
                    ws.Cells[4, header.Length + 78].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 78].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 78].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 78].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 79].Value = "Problem";
                    ws.Cells[4, header.Length + 79].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 79].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 79].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 79].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 80].Value = "Problem Note";
                    ws.Cells[4, header.Length + 80].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 80].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 80].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 80].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    //cell 4
                    ws.Cells[2, header.Length + 81].Value = head_result.Where(x => x.Task_Code == "T0009").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 81].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 81, 3, header.Length + 84].Merge = true;
                    ws.Cells[2, header.Length + 81, 3, header.Length + 84].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 81, 3, header.Length + 84].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[2, header.Length + 81, 3, header.Length + 84].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 81, 3, header.Length + 84].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells 4
                    ws.Cells[4, header.Length + 81].Value = "Working Date";
                    ws.Cells[4, header.Length + 81].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 81].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 81].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 81].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 82].Value = "Result";
                    ws.Cells[4, header.Length + 82].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 82].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 82].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 82].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 83].Value = "Problem";
                    ws.Cells[4, header.Length + 83].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 83].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 83].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 83].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 84].Value = "Problem Note";
                    ws.Cells[4, header.Length + 84].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 84].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 84].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 84].Style.Fill.BackgroundColor.SetColor(colFromHex_g);



                    #endregion

                    #region Install stage

                    Color colFromHex_grey = System.Drawing.ColorTranslator.FromHtml("#E2F0E1");


                    //cells Install header

                    ws.Cells[1, header.Length + 85].Value = "Install Stage";
                    ws.Cells[1, header.Length + 85].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, header.Length + 85, 1, header.Length + 168].Merge = true;
                    ws.Cells[1, header.Length + 85, 1, header.Length + 168].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[1, header.Length + 85, 1, header.Length + 168].Style.Fill.BackgroundColor.SetColor(colFromHex_grey);
                    ws.Cells[1, header.Length + 85, 1, header.Length + 168].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, header.Length + 85, 1, header.Length + 168].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //plan start date
                    ws.Cells[2, header.Length + 85].Value = "Plan Start Date";
                    ws.Cells[2, header.Length + 85].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 85, 4, header.Length + 85].Merge = true;
                    ws.Cells[2, header.Length + 85, 4, header.Length + 85].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 85, 4, header.Length + 85].Style.Fill.BackgroundColor.SetColor(colFromHex_grey);
                    ws.Cells[2, header.Length + 85, 4, header.Length + 85].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 85, 4, header.Length + 85].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //plan finish date
                    ws.Cells[2, header.Length + 86].Value = "Plan Finish Date";
                    ws.Cells[2, header.Length + 86].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 86, 4, header.Length + 86].Merge = true;
                    ws.Cells[2, header.Length + 86, 4, header.Length + 86].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 86, 4, header.Length + 86].Style.Fill.BackgroundColor.SetColor(colFromHex_grey);
                    ws.Cells[2, header.Length + 86, 4, header.Length + 86].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 86, 4, header.Length + 86].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                    //cell 1
                    ws.Cells[2, header.Length + 87].Value = head_result.Where(x => x.Task_Code == "T0011").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 87].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 87, 2, header.Length + 90].Merge = true;
                    ws.Cells[2, header.Length + 87, 2, header.Length + 90].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 87, 2, header.Length + 90].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[2, header.Length + 87, 2, header.Length + 90].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 87, 2, header.Length + 90].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cell 1 %

                    ws.Cells[3, header.Length + 87].Value = head_result.Where(x => x.Task_Code == "T0011").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                    ws.Cells[3, header.Length + 87].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 87, 3, header.Length + 90].Merge = true;
                    ws.Cells[3, header.Length + 87, 3, header.Length + 90].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 87, 3, header.Length + 90].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[3, header.Length + 87, 3, header.Length + 90].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 87, 3, header.Length + 90].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells 1
                    ws.Cells[4, header.Length + 87].Value = "Working Date";
                    ws.Cells[4, header.Length + 87].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 87].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 87].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 87].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 88].Value = "Result";
                    ws.Cells[4, header.Length + 88].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 88].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 88].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 88].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 89].Value = "Problem";
                    ws.Cells[4, header.Length + 89].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 89].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 89].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 89].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 90].Value = "Problem Note";
                    ws.Cells[4, header.Length + 90].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 90].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 90].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 90].Style.Fill.BackgroundColor.SetColor(colFromHex_g);


                    //cell 2
                    ws.Cells[2, header.Length + 91].Value = head_result.Where(x => x.Task_Code == "T0012").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 91].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 91, 2, header.Length + 94].Merge = true;
                    ws.Cells[2, header.Length + 91, 2, header.Length + 94].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 91, 2, header.Length + 94].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[2, header.Length + 91, 2, header.Length + 94].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 91, 2, header.Length + 94].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cell 2 %

                    ws.Cells[3, header.Length + 91].Value = head_result.Where(x => x.Task_Code == "T0012").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                    ws.Cells[3, header.Length + 91].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 91, 3, header.Length + 94].Merge = true;
                    ws.Cells[3, header.Length + 91, 3, header.Length + 94].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 91, 3, header.Length + 94].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[3, header.Length + 91, 3, header.Length + 94].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 91, 3, header.Length + 94].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells 2
                    ws.Cells[4, header.Length + 91].Value = "Working Date";
                    ws.Cells[4, header.Length + 91].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 91].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 91].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 91].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 92].Value = "Result";
                    ws.Cells[4, header.Length + 92].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 92].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 92].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 92].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 93].Value = "Problem";
                    ws.Cells[4, header.Length + 93].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 93].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 93].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 93].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 94].Value = "Problem Note";
                    ws.Cells[4, header.Length + 94].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 94].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 94].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 94].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    //cell 3
                    ws.Cells[2, header.Length + 95].Value = head_result.Where(x => x.Task_Code == "T0013").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 95].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 95, 2, header.Length + 98].Merge = true;
                    ws.Cells[2, header.Length + 95, 2, header.Length + 98].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 95, 2, header.Length + 98].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[2, header.Length + 95, 2, header.Length + 98].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 95, 2, header.Length + 98].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cell 3 %

                    ws.Cells[3, header.Length + 95].Value = head_result.Where(x => x.Task_Code == "T0013").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                    ws.Cells[3, header.Length + 95].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 95, 3, header.Length + 98].Merge = true;
                    ws.Cells[3, header.Length + 95, 3, header.Length + 98].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 95, 3, header.Length + 98].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[3, header.Length + 95, 3, header.Length + 98].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 95, 3, header.Length + 98].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells 3
                    ws.Cells[4, header.Length + 95].Value = "Working Date";
                    ws.Cells[4, header.Length + 95].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 95].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 95].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 95].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 96].Value = "Result";
                    ws.Cells[4, header.Length + 96].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 96].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 96].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 96].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 97].Value = "Problem";
                    ws.Cells[4, header.Length + 97].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 97].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 97].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 97].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 98].Value = "Problem Note";
                    ws.Cells[4, header.Length + 98].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 98].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 98].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 98].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    //cell 4
                    ws.Cells[2, header.Length + 99].Value = head_result.Where(x => x.Task_Code == "T0014").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 99].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 99, 2, header.Length + 102].Merge = true;
                    ws.Cells[2, header.Length + 99, 2, header.Length + 102].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 99, 2, header.Length + 102].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[2, header.Length + 99, 2, header.Length + 102].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 99, 2, header.Length + 102].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cell 4 %

                    ws.Cells[3, header.Length + 99].Value = head_result.Where(x => x.Task_Code == "T0014").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                    ws.Cells[3, header.Length + 99].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 99, 3, header.Length + 102].Merge = true;
                    ws.Cells[3, header.Length + 99, 3, header.Length + 102].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 99, 3, header.Length + 102].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[3, header.Length + 99, 3, header.Length + 102].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 99, 3, header.Length + 102].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells 4
                    ws.Cells[4, header.Length + 99].Value = "Working Date";
                    ws.Cells[4, header.Length + 99].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 99].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 99].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 99].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 100].Value = "Result";
                    ws.Cells[4, header.Length + 100].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 100].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 100].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 100].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 101].Value = "Problem";
                    ws.Cells[4, header.Length + 101].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 101].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 101].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 101].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 102].Value = "Problem Note";
                    ws.Cells[4, header.Length + 102].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 102].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 102].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 102].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    //cell 5
                    ws.Cells[2, header.Length + 103].Value = head_result.Where(x => x.Task_Code == "T0015").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 103].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 103, 2, header.Length + 106].Merge = true;
                    ws.Cells[2, header.Length + 103, 2, header.Length + 106].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 103, 2, header.Length + 106].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[2, header.Length + 103, 2, header.Length + 106].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 103, 2, header.Length + 106].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cell 5 %

                    ws.Cells[3, header.Length + 103].Value = head_result.Where(x => x.Task_Code == "T0015").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                    ws.Cells[3, header.Length + 103].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 103, 3, header.Length + 106].Merge = true;
                    ws.Cells[3, header.Length + 103, 3, header.Length + 106].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 103, 3, header.Length + 106].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[3, header.Length + 103, 3, header.Length + 106].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 103, 3, header.Length + 106].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells 5
                    ws.Cells[4, header.Length + 103].Value = "Working Date";
                    ws.Cells[4, header.Length + 103].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 103].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 103].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 103].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 104].Value = "Result";
                    ws.Cells[4, header.Length + 104].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 104].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 104].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 104].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 105].Value = "Problem";
                    ws.Cells[4, header.Length + 105].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 105].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 105].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 105].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 106].Value = "Problem Note";
                    ws.Cells[4, header.Length + 106].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 106].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 106].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 106].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    //cell 6
                    ws.Cells[2, header.Length + 107].Value = head_result.Where(x => x.Task_Code == "T0016").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 107].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 107, 2, header.Length + 110].Merge = true;
                    ws.Cells[2, header.Length + 107, 2, header.Length + 110].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 107, 2, header.Length + 110].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[2, header.Length + 107, 2, header.Length + 110].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 107, 2, header.Length + 110].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cell 6 %

                    ws.Cells[3, header.Length + 107].Value = head_result.Where(x => x.Task_Code == "T0016").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                    ws.Cells[3, header.Length + 107].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 107, 3, header.Length + 110].Merge = true;
                    ws.Cells[3, header.Length + 107, 3, header.Length + 110].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 107, 3, header.Length + 110].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[3, header.Length + 107, 3, header.Length + 110].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 107, 3, header.Length + 110].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells 6
                    ws.Cells[4, header.Length + 107].Value = "Working Date";
                    ws.Cells[4, header.Length + 107].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 107].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 107].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 107].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 108].Value = "Result";
                    ws.Cells[4, header.Length + 108].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 108].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 108].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 108].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 109].Value = "Problem";
                    ws.Cells[4, header.Length + 109].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 109].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 109].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 109].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 110].Value = "Problem Note";
                    ws.Cells[4, header.Length + 110].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 110].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 110].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 110].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    //cell 7
                    ws.Cells[2, header.Length + 111].Value = head_result.Where(x => x.Task_Code == "T0017").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 111].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 111, 2, header.Length + 114].Merge = true;
                    ws.Cells[2, header.Length + 111, 2, header.Length + 114].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 111, 2, header.Length + 114].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[2, header.Length + 111, 2, header.Length + 114].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 111, 2, header.Length + 114].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cell 7 %

                    ws.Cells[3, header.Length + 111].Value = head_result.Where(x => x.Task_Code == "T0017").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                    ws.Cells[3, header.Length + 111].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 111, 3, header.Length + 114].Merge = true;
                    ws.Cells[3, header.Length + 111, 3, header.Length + 114].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 111, 3, header.Length + 114].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[3, header.Length + 111, 3, header.Length + 114].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 111, 3, header.Length + 114].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells 7
                    ws.Cells[4, header.Length + 111].Value = "Working Date";
                    ws.Cells[4, header.Length + 111].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 111].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 111].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 111].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 112].Value = "Result";
                    ws.Cells[4, header.Length + 112].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 112].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 112].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 112].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 113].Value = "Problem";
                    ws.Cells[4, header.Length + 113].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 113].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 113].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 113].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 114].Value = "Problem Note";
                    ws.Cells[4, header.Length + 114].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 114].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 114].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 114].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    //cell 8
                    ws.Cells[2, header.Length + 115].Value = head_result.Where(x => x.Task_Code == "T0018").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 115].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 115, 2, header.Length + 118].Merge = true;
                    ws.Cells[2, header.Length + 115, 2, header.Length + 118].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 115, 2, header.Length + 118].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[2, header.Length + 115, 2, header.Length + 118].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 115, 2, header.Length + 118].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cell 8 %

                    ws.Cells[3, header.Length + 115].Value = head_result.Where(x => x.Task_Code == "T0018").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                    ws.Cells[3, header.Length + 115].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 115, 3, header.Length + 118].Merge = true;
                    ws.Cells[3, header.Length + 115, 3, header.Length + 118].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 115, 3, header.Length + 118].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[3, header.Length + 115, 3, header.Length + 118].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 115, 3, header.Length + 118].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells 8
                    ws.Cells[4, header.Length + 115].Value = "Working Date";
                    ws.Cells[4, header.Length + 115].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 115].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 115].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 115].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 116].Value = "Result";
                    ws.Cells[4, header.Length + 116].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 116].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 116].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 116].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 117].Value = "Problem";
                    ws.Cells[4, header.Length + 117].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 117].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 117].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 117].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 118].Value = "Problem Note";
                    ws.Cells[4, header.Length + 118].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 118].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 118].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 118].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    //cell 9
                    ws.Cells[2, header.Length + 119].Value = head_result.Where(x => x.Task_Code == "T0019").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 119].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 119, 2, header.Length + 122].Merge = true;
                    ws.Cells[2, header.Length + 119, 2, header.Length + 122].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 119, 2, header.Length + 122].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[2, header.Length + 119, 2, header.Length + 122].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 119, 2, header.Length + 122].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cell 9 %

                    ws.Cells[3, header.Length + 119].Value = head_result.Where(x => x.Task_Code == "T0019").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                    ws.Cells[3, header.Length + 119].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 119, 3, header.Length + 122].Merge = true;
                    ws.Cells[3, header.Length + 119, 3, header.Length + 122].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 119, 3, header.Length + 122].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[3, header.Length + 119, 3, header.Length + 122].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 119, 3, header.Length + 122].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells 9
                    ws.Cells[4, header.Length + 119].Value = "Working Date";
                    ws.Cells[4, header.Length + 119].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 119].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 119].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 119].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 120].Value = "Result";
                    ws.Cells[4, header.Length + 120].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 120].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 120].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 120].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 121].Value = "Problem";
                    ws.Cells[4, header.Length + 121].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 121].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 121].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 121].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 122].Value = "Problem Note";
                    ws.Cells[4, header.Length + 122].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 122].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 122].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 122].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    //cell 10
                    ws.Cells[2, header.Length + 123].Value = head_result.Where(x => x.Task_Code == "T0020").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 123].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 123, 2, header.Length + 126].Merge = true;
                    ws.Cells[2, header.Length + 123, 2, header.Length + 126].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 123, 2, header.Length + 126].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[2, header.Length + 123, 2, header.Length + 126].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 123, 2, header.Length + 126].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cell 10 %

                    ws.Cells[3, header.Length + 123].Value = head_result.Where(x => x.Task_Code == "T0020").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                    ws.Cells[3, header.Length + 123].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 123, 3, header.Length + 126].Merge = true;
                    ws.Cells[3, header.Length + 123, 3, header.Length + 126].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 123, 3, header.Length + 126].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[3, header.Length + 123, 3, header.Length + 126].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 123, 3, header.Length + 126].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells 10
                    ws.Cells[4, header.Length + 123].Value = "Working Date";
                    ws.Cells[4, header.Length + 123].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 123].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 123].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 123].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 124].Value = "Result";
                    ws.Cells[4, header.Length + 124].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 124].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 124].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 124].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 125].Value = "Problem";
                    ws.Cells[4, header.Length + 125].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 125].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 125].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 125].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[4, header.Length + 126].Value = "Problem Note";
                    ws.Cells[4, header.Length + 126].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 126].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 126].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 126].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    ws.Cells[2, header.Length + 127].Value = "Progress(EL)";
                    ws.Cells[2, header.Length + 127].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 127, 2, header.Length + 127].Merge = true;
                    ws.Cells[2, header.Length + 127, 2, header.Length + 127].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 127, 2, header.Length + 127].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[2, header.Length + 127, 2, header.Length + 127].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 127, 2, header.Length + 127].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    ws.Cells[3, header.Length + 127].Value = "100%";
                    ws.Cells[3, header.Length + 127].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 127, 3, header.Length + 127].Merge = true;
                    ws.Cells[3, header.Length + 127, 3, header.Length + 127].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 127, 3, header.Length + 127].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[3, header.Length + 127, 3, header.Length + 127].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 127, 3, header.Length + 127].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    ws.Cells[4, header.Length + 127].Value = "";
                    ws.Cells[4, header.Length + 127].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 127].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 127].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 127].Style.Fill.BackgroundColor.SetColor(colFromHex_g);

                    //////////////////////////////////////
                    //cells b 1

                    ws.Cells[2, header.Length + 128].Value = head_result.Where(x => x.Task_Code == "T0057").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 128].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 128, 2, header.Length + 131].Merge = true;
                    ws.Cells[2, header.Length + 128, 2, header.Length + 131].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 128, 2, header.Length + 131].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[2, header.Length + 128, 2, header.Length + 131].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 128, 2, header.Length + 131].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cells % b  1

                    ws.Cells[3, header.Length + 128].Value = head_result.Where(x => x.Task_Code == "T0057").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                    ws.Cells[3, header.Length + 128].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 128, 3, header.Length + 131].Merge = true;
                    ws.Cells[3, header.Length + 128, 3, header.Length + 131].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 128, 3, header.Length + 131].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[3, header.Length + 128, 3, header.Length + 131].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 128, 3, header.Length + 131].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells b 1

                    ws.Cells[4, header.Length + 128].Value = "Working Date";
                    ws.Cells[4, header.Length + 128].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 128].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 128].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 128].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 129].Value = "Result";
                    ws.Cells[4, header.Length + 129].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 129].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 129].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 129].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 130].Value = "Problem";
                    ws.Cells[4, header.Length + 130].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 130].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 130].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 130].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 131].Value = "Problem Note";
                    ws.Cells[4, header.Length + 131].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 131].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 131].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 131].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    //cells b 2

                    ws.Cells[2, header.Length + 132].Value = head_result.Where(x => x.Task_Code == "T0058").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 132].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 132, 2, header.Length + 135].Merge = true;
                    ws.Cells[2, header.Length + 132, 2, header.Length + 135].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 132, 2, header.Length + 135].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[2, header.Length + 132, 2, header.Length + 135].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 132, 2, header.Length + 135].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cells % b  2

                    ws.Cells[3, header.Length + 132].Value = head_result.Where(x => x.Task_Code == "T0058").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                    ws.Cells[3, header.Length + 132].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 132, 3, header.Length + 135].Merge = true;
                    ws.Cells[3, header.Length + 132, 3, header.Length + 135].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 132, 3, header.Length + 135].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[3, header.Length + 132, 3, header.Length + 135].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 132, 3, header.Length + 135].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells b 2

                    ws.Cells[4, header.Length + 132].Value = "Working Date";
                    ws.Cells[4, header.Length + 132].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 132].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 132].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 132].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 133].Value = "Result";
                    ws.Cells[4, header.Length + 133].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 133].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 133].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 133].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 134].Value = "Problem";
                    ws.Cells[4, header.Length + 134].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 134].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 134].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 134].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 135].Value = "Problem Note";
                    ws.Cells[4, header.Length + 135].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 135].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 135].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 135].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    //cells b 3

                    ws.Cells[2, header.Length + 136].Value = head_result.Where(x => x.Task_Code == "T0059").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 136].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 136, 2, header.Length + 139].Merge = true;
                    ws.Cells[2, header.Length + 136, 2, header.Length + 139].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 136, 2, header.Length + 139].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[2, header.Length + 136, 2, header.Length + 139].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 136, 2, header.Length + 139].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cells % b  3

                    ws.Cells[3, header.Length + 136].Value = head_result.Where(x => x.Task_Code == "T0059").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                    ws.Cells[3, header.Length + 136].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 136, 3, header.Length + 139].Merge = true;
                    ws.Cells[3, header.Length + 136, 3, header.Length + 139].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 136, 3, header.Length + 139].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[3, header.Length + 136, 3, header.Length + 139].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 136, 3, header.Length + 139].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells b 3

                    ws.Cells[4, header.Length + 136].Value = "Working Date";
                    ws.Cells[4, header.Length + 136].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 136].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 136].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 136].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 137].Value = "Result";
                    ws.Cells[4, header.Length + 137].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 137].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 137].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 137].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 138].Value = "Problem";
                    ws.Cells[4, header.Length + 138].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 138].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 138].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 138].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 139].Value = "Problem Note";
                    ws.Cells[4, header.Length + 139].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 139].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 139].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 139].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    //cells b 4

                    ws.Cells[2, header.Length + 140].Value = head_result.Where(x => x.Task_Code == "T0060").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 140].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 140, 2, header.Length + 143].Merge = true;
                    ws.Cells[2, header.Length + 140, 2, header.Length + 143].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 140, 2, header.Length + 143].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[2, header.Length + 140, 2, header.Length + 143].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 140, 2, header.Length + 143].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cells % b  4

                    ws.Cells[3, header.Length + 140].Value = head_result.Where(x => x.Task_Code == "T0060").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                    ws.Cells[3, header.Length + 140].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 140, 3, header.Length + 143].Merge = true;
                    ws.Cells[3, header.Length + 140, 3, header.Length + 143].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 140, 3, header.Length + 143].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[3, header.Length + 140, 3, header.Length + 143].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 140, 3, header.Length + 143].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells b 4

                    ws.Cells[4, header.Length + 140].Value = "Working Date";
                    ws.Cells[4, header.Length + 140].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 140].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 140].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 140].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 141].Value = "Result";
                    ws.Cells[4, header.Length + 141].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 141].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 141].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 141].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 142].Value = "Problem";
                    ws.Cells[4, header.Length + 142].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 142].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 142].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 142].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 143].Value = "Problem Note";
                    ws.Cells[4, header.Length + 143].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 143].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 143].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 143].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    //cells b 5

                    ws.Cells[2, header.Length + 144].Value = head_result.Where(x => x.Task_Code == "T0061").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 144].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 144, 2, header.Length + 147].Merge = true;
                    ws.Cells[2, header.Length + 144, 2, header.Length + 147].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 144, 2, header.Length + 147].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[2, header.Length + 144, 2, header.Length + 147].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 144, 2, header.Length + 147].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cells % b  5

                    ws.Cells[3, header.Length + 144].Value = head_result.Where(x => x.Task_Code == "T0061").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                    ws.Cells[3, header.Length + 144].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 144, 3, header.Length + 147].Merge = true;
                    ws.Cells[3, header.Length + 144, 3, header.Length + 147].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 144, 3, header.Length + 147].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[3, header.Length + 144, 3, header.Length + 147].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 144, 3, header.Length + 147].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells b 5

                    ws.Cells[4, header.Length + 144].Value = "Working Date";
                    ws.Cells[4, header.Length + 144].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 144].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 144].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 144].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 145].Value = "Result";
                    ws.Cells[4, header.Length + 145].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 145].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 145].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 145].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 146].Value = "Problem";
                    ws.Cells[4, header.Length + 146].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 146].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 146].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 146].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 147].Value = "Problem Note";
                    ws.Cells[4, header.Length + 147].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 147].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 147].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 147].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    //cells b 6

                    ws.Cells[2, header.Length + 148].Value = head_result.Where(x => x.Task_Code == "T0062").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 148].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 148, 2, header.Length + 151].Merge = true;
                    ws.Cells[2, header.Length + 148, 2, header.Length + 151].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 148, 2, header.Length + 151].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[2, header.Length + 148, 2, header.Length + 151].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 148, 2, header.Length + 151].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cells % b  6

                    ws.Cells[3, header.Length + 148].Value = head_result.Where(x => x.Task_Code == "T0062").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                    ws.Cells[3, header.Length + 148].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 148, 3, header.Length + 151].Merge = true;
                    ws.Cells[3, header.Length + 148, 3, header.Length + 151].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 148, 3, header.Length + 151].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[3, header.Length + 148, 3, header.Length + 151].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 148, 3, header.Length + 151].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells b 6

                    ws.Cells[4, header.Length + 148].Value = "Working Date";
                    ws.Cells[4, header.Length + 148].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 148].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 148].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 148].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 149].Value = "Result";
                    ws.Cells[4, header.Length + 149].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 149].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 149].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 149].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 150].Value = "Problem";
                    ws.Cells[4, header.Length + 150].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 150].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 150].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 150].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 151].Value = "Problem Note";
                    ws.Cells[4, header.Length + 151].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 151].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 151].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 151].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    //cells b 7

                    ws.Cells[2, header.Length + 152].Value = head_result.Where(x => x.Task_Code == "T0063").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 152].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 152, 2, header.Length + 155].Merge = true;
                    ws.Cells[2, header.Length + 152, 2, header.Length + 155].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 152, 2, header.Length + 155].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[2, header.Length + 152, 2, header.Length + 155].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 152, 2, header.Length + 155].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cells % b  7

                    ws.Cells[3, header.Length + 152].Value = head_result.Where(x => x.Task_Code == "T0063").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                    ws.Cells[3, header.Length + 152].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 152, 3, header.Length + 155].Merge = true;
                    ws.Cells[3, header.Length + 152, 3, header.Length + 155].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 152, 3, header.Length + 155].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[3, header.Length + 152, 3, header.Length + 155].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 152, 3, header.Length + 155].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells b 7

                    ws.Cells[4, header.Length + 152].Value = "Working Date";
                    ws.Cells[4, header.Length + 152].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 152].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 152].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 152].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 153].Value = "Result";
                    ws.Cells[4, header.Length + 153].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 153].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 153].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 153].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 154].Value = "Problem";
                    ws.Cells[4, header.Length + 154].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 154].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 154].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 154].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 155].Value = "Problem Note";
                    ws.Cells[4, header.Length + 155].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 155].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 155].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 155].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    //cells b 8

                    ws.Cells[2, header.Length + 156].Value = head_result.Where(x => x.Task_Code == "T0064").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 156].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 156, 2, header.Length + 159].Merge = true;
                    ws.Cells[2, header.Length + 156, 2, header.Length + 159].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 156, 2, header.Length + 159].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[2, header.Length + 156, 2, header.Length + 159].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 156, 2, header.Length + 159].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cells % b  8

                    ws.Cells[3, header.Length + 156].Value = head_result.Where(x => x.Task_Code == "T0064").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                    ws.Cells[3, header.Length + 156].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 156, 3, header.Length + 159].Merge = true;
                    ws.Cells[3, header.Length + 156, 3, header.Length + 159].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 156, 3, header.Length + 159].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[3, header.Length + 156, 3, header.Length + 159].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 156, 3, header.Length + 159].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells b 8

                    ws.Cells[4, header.Length + 156].Value = "Working Date";
                    ws.Cells[4, header.Length + 156].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 156].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 156].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 156].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 157].Value = "Result";
                    ws.Cells[4, header.Length + 157].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 157].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 157].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 157].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 158].Value = "Problem";
                    ws.Cells[4, header.Length + 158].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 158].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 158].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 158].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 159].Value = "Problem Note";
                    ws.Cells[4, header.Length + 159].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 159].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 159].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 159].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    //cells b 9

                    ws.Cells[2, header.Length + 160].Value = head_result.Where(x => x.Task_Code == "T0065").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 160].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 160, 2, header.Length + 163].Merge = true;
                    ws.Cells[2, header.Length + 160, 2, header.Length + 163].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 160, 2, header.Length + 163].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[2, header.Length + 160, 2, header.Length + 163].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 160, 2, header.Length + 163].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cells % b  9

                    ws.Cells[3, header.Length + 160].Value = head_result.Where(x => x.Task_Code == "T0065").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                    ws.Cells[3, header.Length + 160].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 160, 3, header.Length + 163].Merge = true;
                    ws.Cells[3, header.Length + 160, 3, header.Length + 163].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 160, 3, header.Length + 163].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[3, header.Length + 160, 3, header.Length + 163].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 160, 3, header.Length + 163].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells b 9

                    ws.Cells[4, header.Length + 160].Value = "Working Date";
                    ws.Cells[4, header.Length + 160].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 160].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 160].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 160].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 161].Value = "Result";
                    ws.Cells[4, header.Length + 161].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 161].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 161].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 161].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 162].Value = "Problem";
                    ws.Cells[4, header.Length + 162].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 162].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 162].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 162].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 163].Value = "Problem Note";
                    ws.Cells[4, header.Length + 163].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 163].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 163].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 163].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    //cells b 10

                    ws.Cells[2, header.Length + 164].Value = head_result.Where(x => x.Task_Code == "T0066").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 164].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 164, 2, header.Length + 167].Merge = true;
                    ws.Cells[2, header.Length + 164, 2, header.Length + 167].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 164, 2, header.Length + 167].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[2, header.Length + 164, 2, header.Length + 167].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 164, 2, header.Length + 167].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cells % b  10

                    ws.Cells[3, header.Length + 164].Value = head_result.Where(x => x.Task_Code == "T0066").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                    ws.Cells[3, header.Length + 164].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 164, 3, header.Length + 167].Merge = true;
                    ws.Cells[3, header.Length + 164, 3, header.Length + 167].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 164, 3, header.Length + 167].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[3, header.Length + 164, 3, header.Length + 167].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 164, 3, header.Length + 167].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells b 10

                    ws.Cells[4, header.Length + 164].Value = "Working Date";
                    ws.Cells[4, header.Length + 164].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 164].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 164].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 164].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 165].Value = "Result";
                    ws.Cells[4, header.Length + 165].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 165].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 165].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 165].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 166].Value = "Problem";
                    ws.Cells[4, header.Length + 166].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 166].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 166].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 166].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 167].Value = "Problem Note";
                    ws.Cells[4, header.Length + 167].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 167].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 167].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 167].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[2, header.Length + 168].Value = "Progress(EL)";
                    ws.Cells[2, header.Length + 168].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 168, 2, header.Length + 168].Merge = true;
                    ws.Cells[2, header.Length + 168, 2, header.Length + 168].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 168, 2, header.Length + 168].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[2, header.Length + 168, 2, header.Length + 168].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 168, 2, header.Length + 168].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    ws.Cells[3, header.Length + 168].Value = "100%";
                    ws.Cells[3, header.Length + 168].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 168, 3, header.Length + 168].Merge = true;
                    ws.Cells[3, header.Length + 168, 3, header.Length + 168].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 168, 3, header.Length + 168].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[3, header.Length + 168, 3, header.Length + 168].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 168, 3, header.Length + 168].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    ws.Cells[4, header.Length + 168].Value = "";
                    ws.Cells[4, header.Length + 168].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 168].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 168].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 168].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);


                    #endregion

                    #region Power Supply Stage

                    //168

                    Color colFromHex_pink = System.Drawing.ColorTranslator.FromHtml("#C40894");
                    Color colFromHex_hevy_pink = System.Drawing.ColorTranslator.FromHtml("#F672D4");


                    //cells Install header

                    ws.Cells[1, header.Length + 169].Value = "Power Supply Stage";
                    ws.Cells[1, header.Length + 169].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, header.Length + 169, 1, header.Length + 174].Merge = true;
                    ws.Cells[1, header.Length + 169, 1, header.Length + 174].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[1, header.Length + 169, 1, header.Length + 174].Style.Fill.BackgroundColor.SetColor(colFromHex_pink);
                    ws.Cells[1, header.Length + 169, 1, header.Length + 174].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, header.Length + 169, 1, header.Length + 174].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //plan start date
                    ws.Cells[2, header.Length + 169].Value = "Plan Start Date";
                    ws.Cells[2, header.Length + 169].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 169, 4, header.Length + 169].Merge = true;
                    ws.Cells[2, header.Length + 169, 4, header.Length + 169].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 169, 4, header.Length + 169].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);
                    ws.Cells[2, header.Length + 169, 4, header.Length + 169].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 169, 4, header.Length + 169].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //plan finish date
                    ws.Cells[2, header.Length + 170].Value = "Plan Finish Date";
                    ws.Cells[2, header.Length + 170].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 170, 4, header.Length + 170].Merge = true;
                    ws.Cells[2, header.Length + 170, 4, header.Length + 170].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 170, 4, header.Length + 170].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);
                    ws.Cells[2, header.Length + 170, 4, header.Length + 170].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 170, 4, header.Length + 170].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                    //cell 1
                    ws.Cells[2, header.Length + 171].Value = "Power Supply";
                    ws.Cells[2, header.Length + 171].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 171, 3, header.Length + 174].Merge = true;
                    ws.Cells[2, header.Length + 171, 3, header.Length + 174].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 171, 3, header.Length + 174].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);
                    ws.Cells[2, header.Length + 171, 3, header.Length + 174].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 171, 3, header.Length + 174].Style.VerticalAlignment = ExcelVerticalAlignment.Center;



                    //sub cells 1
                    ws.Cells[4, header.Length + 171].Value = "Working Date";
                    ws.Cells[4, header.Length + 171].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 171].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 171].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 171].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 172].Value = "Result";
                    ws.Cells[4, header.Length + 172].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 172].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 172].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 172].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 173].Value = "Problem";
                    ws.Cells[4, header.Length + 173].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 173].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 173].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 173].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 174].Value = "Problem Note";
                    ws.Cells[4, header.Length + 174].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 174].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 174].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 174].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    #endregion

                    #region Testing Stage

                    //cells Install header   

                    ws.Cells[1, header.Length + 175].Value = "Testing Stage";
                    ws.Cells[1, header.Length + 175].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, header.Length + 175, 1, header.Length + 188].Merge = true;
                    ws.Cells[1, header.Length + 175, 1, header.Length + 188].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[1, header.Length + 175, 1, header.Length + 188].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[1, header.Length + 175, 1, header.Length + 188].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, header.Length + 175, 1, header.Length + 188].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //plan start date
                    ws.Cells[2, header.Length + 175].Value = "Plan Start Date";
                    ws.Cells[2, header.Length + 175].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 175, 4, header.Length + 175].Merge = true;
                    ws.Cells[2, header.Length + 175, 4, header.Length + 175].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 175, 4, header.Length + 175].Style.Fill.BackgroundColor.SetColor(colFromHex_g);
                    ws.Cells[2, header.Length + 175, 4, header.Length + 175].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 175, 4, header.Length + 175].Style.VerticalAlignment = ExcelVerticalAlignment.Center;



                    //cell 1
                    ws.Cells[2, header.Length + 176].Value = head_result.Where(x => x.Task_Code == "T0022").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 176].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 176, 2, header.Length + 179].Merge = true;
                    ws.Cells[2, header.Length + 176, 2, header.Length + 179].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 176, 2, header.Length + 179].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[2, header.Length + 176, 2, header.Length + 179].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 176, 2, header.Length + 179].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cell % 1
                    ws.Cells[3, header.Length + 176].Value = head_result.Where(x => x.Task_Code == "T0022").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                    ws.Cells[3, header.Length + 176].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 176, 3, header.Length + 179].Merge = true;
                    ws.Cells[3, header.Length + 176, 3, header.Length + 179].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 176, 3, header.Length + 179].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[3, header.Length + 176, 3, header.Length + 179].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 176, 3, header.Length + 179].Style.VerticalAlignment = ExcelVerticalAlignment.Center;



                    //sub cells 1
                    ws.Cells[4, header.Length + 176].Value = "Working Date";
                    ws.Cells[4, header.Length + 176].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 176].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 176].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 176].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 177].Value = "Result";
                    ws.Cells[4, header.Length + 177].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 177].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 177].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 177].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 178].Value = "Problem";
                    ws.Cells[4, header.Length + 178].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 178].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 178].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 178].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 179].Value = "Problem Note";
                    ws.Cells[4, header.Length + 179].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 179].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 179].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 179].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    //cell 2
                    ws.Cells[2, header.Length + 180].Value = head_result.Where(x => x.Task_Code == "T0023").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 180].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 180, 2, header.Length + 183].Merge = true;
                    ws.Cells[2, header.Length + 180, 2, header.Length + 183].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 180, 2, header.Length + 183].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[2, header.Length + 180, 2, header.Length + 183].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 180, 2, header.Length + 183].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cell % 2
                    ws.Cells[3, header.Length + 180].Value = head_result.Where(x => x.Task_Code == "T0023").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                    ws.Cells[3, header.Length + 180].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 180, 3, header.Length + 183].Merge = true;
                    ws.Cells[3, header.Length + 180, 3, header.Length + 183].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 180, 3, header.Length + 183].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[3, header.Length + 180, 3, header.Length + 183].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 180, 3, header.Length + 183].Style.VerticalAlignment = ExcelVerticalAlignment.Center;



                    //sub cells 2
                    ws.Cells[4, header.Length + 180].Value = "Working Date";
                    ws.Cells[4, header.Length + 180].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 180].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 180].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 180].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 181].Value = "Result";
                    ws.Cells[4, header.Length + 181].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 181].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 181].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 181].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 182].Value = "Problem";
                    ws.Cells[4, header.Length + 182].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 182].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 182].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 182].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 183].Value = "Problem Note";
                    ws.Cells[4, header.Length + 183].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 183].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 183].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 183].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    //cell 3
                    ws.Cells[2, header.Length + 184].Value = head_result.Where(x => x.Task_Code == "T0024").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 184].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 184, 2, header.Length + 187].Merge = true;
                    ws.Cells[2, header.Length + 184, 2, header.Length + 187].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 184, 2, header.Length + 187].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[2, header.Length + 184, 2, header.Length + 187].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 184, 2, header.Length + 187].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cell % 3
                    ws.Cells[3, header.Length + 184].Value = head_result.Where(x => x.Task_Code == "T0024").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                    ws.Cells[3, header.Length + 184].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 184, 3, header.Length + 187].Merge = true;
                    ws.Cells[3, header.Length + 184, 3, header.Length + 187].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 184, 3, header.Length + 187].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[3, header.Length + 184, 3, header.Length + 187].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 184, 3, header.Length + 187].Style.VerticalAlignment = ExcelVerticalAlignment.Center;



                    //sub cells 3
                    ws.Cells[4, header.Length + 184].Value = "Working Date";
                    ws.Cells[4, header.Length + 184].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 184].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 184].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 184].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 185].Value = "Result";
                    ws.Cells[4, header.Length + 185].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 185].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 185].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 185].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 186].Value = "Problem";
                    ws.Cells[4, header.Length + 186].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 186].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 186].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 186].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    ws.Cells[4, header.Length + 187].Value = "Problem Note";
                    ws.Cells[4, header.Length + 187].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 187].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 187].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 187].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                    //progrss
                    ws.Cells[2, header.Length + 188].Value = "Progress";
                    ws.Cells[2, header.Length + 188].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 188, 2, header.Length + 188].Merge = true;
                    ws.Cells[2, header.Length + 188, 2, header.Length + 188].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 188, 2, header.Length + 188].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[2, header.Length + 188, 2, header.Length + 188].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 188, 2, header.Length + 188].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cell % 
                    ws.Cells[3, header.Length + 188].Value = "100%";
                    ws.Cells[3, header.Length + 188].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[3, header.Length + 188, 3, header.Length + 188].Merge = true;
                    ws.Cells[3, header.Length + 188, 3, header.Length + 188].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[3, header.Length + 188, 3, header.Length + 188].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);
                    ws.Cells[3, header.Length + 188, 3, header.Length + 188].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, header.Length + 188, 3, header.Length + 188].Style.VerticalAlignment = ExcelVerticalAlignment.Center;



                    //
                    ws.Cells[4, header.Length + 188].Value = "";
                    ws.Cells[4, header.Length + 188].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 188].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 188].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 188].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_g);

                   


                    #endregion

                    #region  QC Stage

                      Color colFromHex_org = System.Drawing.ColorTranslator.FromHtml("#EC9E50");
                      Color colFromHex_hevy_org = System.Drawing.ColorTranslator.FromHtml("#DC852D");


                      //cells Install header

                      ws.Cells[1, header.Length + 189].Value = "QC Stage";
                      ws.Cells[1, header.Length + 189].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[1, header.Length + 189, 1, header.Length + 207].Merge = true;
                      ws.Cells[1, header.Length + 189, 1, header.Length + 207].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[1, header.Length + 189, 1, header.Length + 207].Style.Fill.BackgroundColor.SetColor(colFromHex_org);
                      ws.Cells[1, header.Length + 189, 1, header.Length + 207].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[1, header.Length + 189, 1, header.Length + 207].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                      //plan start date
                      ws.Cells[2, header.Length + 189].Value = "Plan Start Date";
                      ws.Cells[2, header.Length + 189].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[2, header.Length + 189, 4, header.Length + 189].Merge = true;
                      ws.Cells[2, header.Length + 189, 4, header.Length + 189].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[2, header.Length + 189, 4, header.Length + 189].Style.Fill.BackgroundColor.SetColor(colFromHex_org);
                      ws.Cells[2, header.Length + 189, 4, header.Length + 189].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[2, header.Length + 189, 4, header.Length + 189].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                      //plan finish date
                      ws.Cells[2, header.Length + 190].Value = "Plan Finish Date";
                      ws.Cells[2, header.Length + 190].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[2, header.Length + 190, 4, header.Length + 190].Merge = true;
                      ws.Cells[2, header.Length + 190, 4, header.Length + 190].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[2, header.Length + 190, 4, header.Length + 190].Style.Fill.BackgroundColor.SetColor(colFromHex_org);
                      ws.Cells[2, header.Length + 190, 4, header.Length + 190].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[2, header.Length + 190, 4, header.Length + 190].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                      //cell 1
                      ws.Cells[2, header.Length + 191].Value = head_result.Where(x => x.Task_Code == "T0026").Select(x => x.Task_Name).FirstOrDefault();
                      ws.Cells[2, header.Length + 191].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[2, header.Length + 191, 2, header.Length + 194].Merge = true;
                      ws.Cells[2, header.Length + 191, 2, header.Length + 194].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[2, header.Length + 191, 2, header.Length + 194].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);
                      ws.Cells[2, header.Length + 191, 2, header.Length + 194].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[2, header.Length + 191, 2, header.Length + 194].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                      //cell 1 %

                      ws.Cells[3, header.Length + 191].Value = head_result.Where(x => x.Task_Code == "T0026").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                      ws.Cells[3, header.Length + 191].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[3, header.Length + 191, 3, header.Length + 194].Merge = true;
                      ws.Cells[3, header.Length + 191, 3, header.Length + 194].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[3, header.Length + 191, 3, header.Length + 194].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);
                      ws.Cells[3, header.Length + 191, 3, header.Length + 194].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[3, header.Length + 191, 3, header.Length + 194].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                      //sub cells 1
                      ws.Cells[4, header.Length + 191].Value = "Working Date";
                      ws.Cells[4, header.Length + 191].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[4, header.Length + 191].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[4, header.Length + 191].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[4, header.Length + 191].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);

                      ws.Cells[4, header.Length + 192].Value = "Result";
                      ws.Cells[4, header.Length + 192].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[4, header.Length + 192].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[4, header.Length + 192].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[4, header.Length + 192].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);

                      ws.Cells[4, header.Length + 193].Value = "Problem";
                      ws.Cells[4, header.Length + 193].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[4, header.Length + 193].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[4, header.Length + 193].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[4, header.Length + 193].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);

                      ws.Cells[4, header.Length + 194].Value = "Problem Note";
                      ws.Cells[4, header.Length + 194].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[4, header.Length + 194].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[4, header.Length + 194].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[4, header.Length + 194].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);

                      //cell 2
                      ws.Cells[2, header.Length + 195].Value = head_result.Where(x => x.Task_Code == "T0027").Select(x => x.Task_Name).FirstOrDefault();
                      ws.Cells[2, header.Length + 195].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[2, header.Length + 195, 2, header.Length + 198].Merge = true;
                      ws.Cells[2, header.Length + 195, 2, header.Length + 198].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[2, header.Length + 195, 2, header.Length + 198].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);
                      ws.Cells[2, header.Length + 195, 2, header.Length + 198].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[2, header.Length + 195, 2, header.Length + 198].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                      //cell 2 %

                      ws.Cells[3, header.Length + 195].Value = head_result.Where(x => x.Task_Code == "T0027").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                      ws.Cells[3, header.Length + 195].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[3, header.Length + 195, 3, header.Length + 198].Merge = true;
                      ws.Cells[3, header.Length + 195, 3, header.Length + 198].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[3, header.Length + 195, 3, header.Length + 198].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);
                      ws.Cells[3, header.Length + 195, 3, header.Length + 198].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[3, header.Length + 195, 3, header.Length + 198].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                      //sub cells 2
                      ws.Cells[4, header.Length + 195].Value = "Working Date";
                      ws.Cells[4, header.Length + 195].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[4, header.Length + 195].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[4, header.Length + 195].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[4, header.Length + 195].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);

                      ws.Cells[4, header.Length + 196].Value = "Result";
                      ws.Cells[4, header.Length + 196].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[4, header.Length + 196].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[4, header.Length + 196].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[4, header.Length + 196].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);

                      ws.Cells[4, header.Length + 197].Value = "Problem";
                      ws.Cells[4, header.Length + 197].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[4, header.Length + 197].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[4, header.Length + 197].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[4, header.Length + 197].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);

                      ws.Cells[4, header.Length + 198].Value = "Problem Note";
                      ws.Cells[4, header.Length + 198].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[4, header.Length + 198].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[4, header.Length + 198].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[4, header.Length + 198].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);

                      //cell 3
                      ws.Cells[2, header.Length + 199].Value = head_result.Where(x => x.Task_Code == "T0028").Select(x => x.Task_Name).FirstOrDefault();
                      ws.Cells[2, header.Length + 199].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[2, header.Length + 199, 2, header.Length + 202].Merge = true;
                      ws.Cells[2, header.Length + 199, 2, header.Length + 202].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[2, header.Length + 199, 2, header.Length + 202].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);
                      ws.Cells[2, header.Length + 199, 2, header.Length + 202].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[2, header.Length + 199, 2, header.Length + 202].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                      //cell 3 %

                      ws.Cells[3, header.Length + 199].Value = head_result.Where(x => x.Task_Code == "T0028").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                      ws.Cells[3, header.Length + 199].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[3, header.Length + 199, 3, header.Length + 202].Merge = true;
                      ws.Cells[3, header.Length + 199, 3, header.Length + 202].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[3, header.Length + 199, 3, header.Length + 202].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);
                      ws.Cells[3, header.Length + 199, 3, header.Length + 202].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[3, header.Length + 199, 3, header.Length + 202].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                      //sub cells 3
                      ws.Cells[4, header.Length + 199].Value = "Working Date";
                      ws.Cells[4, header.Length + 199].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[4, header.Length + 199].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[4, header.Length + 199].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[4, header.Length + 199].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);

                      ws.Cells[4, header.Length + 200].Value = "Result";
                      ws.Cells[4, header.Length + 200].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[4, header.Length + 200].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[4, header.Length + 200].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[4, header.Length + 200].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);

                      ws.Cells[4, header.Length + 201].Value = "Problem";
                      ws.Cells[4, header.Length + 201].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[4, header.Length + 201].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[4, header.Length + 201].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[4, header.Length + 201].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);

                      ws.Cells[4, header.Length + 202].Value = "Problem Note";
                      ws.Cells[4, header.Length + 202].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[4, header.Length + 202].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[4, header.Length + 202].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[4, header.Length + 202].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);

                      //cell 4
                      ws.Cells[2, header.Length + 203].Value = head_result.Where(x => x.Task_Code == "T0029").Select(x => x.Task_Name).FirstOrDefault();
                         ws.Cells[2, header.Length + 203].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[2, header.Length + 203, 2, header.Length + 206].Merge = true;
                      ws.Cells[2, header.Length + 203, 2, header.Length + 206].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[2, header.Length + 203, 2, header.Length + 206].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);
                      ws.Cells[2, header.Length + 203, 2, header.Length + 206].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[2, header.Length + 203, 2, header.Length + 206].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                      //cell 4 %

                      ws.Cells[3, header.Length + 203].Value = head_result.Where(x => x.Task_Code == "T0029").Select(x => x.Task_Percent).FirstOrDefault() + "%";
                      ws.Cells[3, header.Length + 203].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[3, header.Length + 203, 3, header.Length + 206].Merge = true;
                      ws.Cells[3, header.Length + 203, 3, header.Length + 206].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[3, header.Length + 203, 3, header.Length + 206].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);
                      ws.Cells[3, header.Length + 203, 3, header.Length + 206].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[3, header.Length + 203, 3, header.Length + 206].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                      //sub cells 4
                      ws.Cells[4, header.Length + 203].Value = "Working Date";
                      ws.Cells[4, header.Length + 203].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[4, header.Length + 203].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[4, header.Length + 203].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[4, header.Length + 203].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);

                      ws.Cells[4, header.Length + 204].Value = "Result";
                      ws.Cells[4, header.Length + 204].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[4, header.Length + 204].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[4, header.Length + 204].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[4, header.Length + 204].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);

                      ws.Cells[4, header.Length + 205].Value = "Problem";
                      ws.Cells[4, header.Length + 205].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[4, header.Length + 205].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[4, header.Length + 205].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[4, header.Length + 205].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);

                      ws.Cells[4, header.Length + 206].Value = "Problem Note";
                      ws.Cells[4, header.Length + 206].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[4, header.Length + 206].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[4, header.Length + 206].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[4, header.Length + 206].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);


                      //cell progress
                      ws.Cells[2, header.Length + 207].Value = "Progress";
                      ws.Cells[2, header.Length + 207].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[2, header.Length + 207, 2, header.Length + 207].Merge = true;
                      ws.Cells[2, header.Length + 207, 2, header.Length + 207].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[2, header.Length + 207, 2, header.Length + 207].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);
                      ws.Cells[2, header.Length + 207, 2, header.Length + 207].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[2, header.Length + 207, 2, header.Length + 207].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                      //cell progress %

                      ws.Cells[3, header.Length + 207].Value = "100%";
                      ws.Cells[3, header.Length + 207].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[3, header.Length + 207, 3, header.Length + 207].Merge = true;
                      ws.Cells[3, header.Length + 207, 3, header.Length + 207].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[3, header.Length + 207, 3, header.Length + 207].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);
                      ws.Cells[3, header.Length + 207, 3, header.Length + 207].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[3, header.Length + 207, 3, header.Length + 207].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                      //sub progress 4
                      ws.Cells[4, header.Length + 207].Value = "";
                      ws.Cells[4, header.Length + 207].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                      ws.Cells[4, header.Length + 207].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                      ws.Cells[4, header.Length + 207].Style.Fill.PatternType = ExcelFillStyle.Solid;
                      ws.Cells[4, header.Length + 207].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org);




                    #endregion

                    #region Hand Over Stage

                    Color colFromHex_org2 = System.Drawing.ColorTranslator.FromHtml("#8D653B");
                    Color colFromHex_hevy_org2 = System.Drawing.ColorTranslator.FromHtml("#DB9143");


                    //cells Install header

                    ws.Cells[1, header.Length + 208].Value = "QC Hand Over Stage";
                    ws.Cells[1, header.Length + 208].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, header.Length + 208, 1, header.Length + 215].Merge = true;
                    ws.Cells[1, header.Length + 208, 1, header.Length + 215].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[1, header.Length + 208, 1, header.Length + 215].Style.Fill.BackgroundColor.SetColor(colFromHex_org2);
                    ws.Cells[1, header.Length + 208, 1, header.Length + 215].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, header.Length + 208, 1, header.Length + 215].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cells 1

                    ws.Cells[2, header.Length + 208].Value = head_result.Where(x => x.Task_Code == "T0042").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 208].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 208, 3, header.Length + 211].Merge = true;
                    ws.Cells[2, header.Length + 208, 3, header.Length + 211].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 208, 3, header.Length + 211].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org2);
                    ws.Cells[2, header.Length + 208, 3, header.Length + 211].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 208, 3, header.Length + 211].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                    //sub cells 1
                    ws.Cells[4, header.Length + 208].Value = "Working Date";
                    ws.Cells[4, header.Length + 208].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 208].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 208].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 208].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org2);

                    ws.Cells[4, header.Length + 209].Value = "Result";
                    ws.Cells[4, header.Length + 209].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 209].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 209].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 209].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org2);

                    ws.Cells[4, header.Length + 210].Value = "Problem";
                    ws.Cells[4, header.Length + 210].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 210].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 210].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 210].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org2);

                    ws.Cells[4, header.Length + 211].Value = "Problem Note";
                    ws.Cells[4, header.Length + 211].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 211].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 211].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 211].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org2);

                    //cells 2

                    ws.Cells[2, header.Length + 212].Value = head_result.Where(x => x.Task_Code == "T0043").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 212].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 212, 3, header.Length + 215].Merge = true;
                    ws.Cells[2, header.Length + 212, 3, header.Length + 215].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 212, 3, header.Length + 215].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org2);
                    ws.Cells[2, header.Length + 212, 3, header.Length + 215].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 212, 3, header.Length + 215].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                    //sub cells 2
                    ws.Cells[4, header.Length + 212].Value = "Working Date";
                    ws.Cells[4, header.Length + 212].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 212].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 212].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 212].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org2);

                    ws.Cells[4, header.Length + 213].Value = "Result";
                    ws.Cells[4, header.Length + 213].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 213].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 213].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 213].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org2);

                    ws.Cells[4, header.Length + 214].Value = "Problem";
                    ws.Cells[4, header.Length + 214].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 214].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 214].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 214].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org2);

                    ws.Cells[4, header.Length + 215].Value = "Problem Note";
                    ws.Cells[4, header.Length + 215].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 215].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 215].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 215].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_org2);

                    #endregion

                    #region  submit to service Stage


                    //cells  submit to service Stage

                    ws.Cells[1, header.Length + 216].Value = "Submit to service Stage";
                    ws.Cells[1, header.Length + 216].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, header.Length + 216, 1, header.Length + 255].Merge = true;
                    ws.Cells[1, header.Length + 216, 1, header.Length + 255].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[1, header.Length + 216, 1, header.Length + 255].Style.Fill.BackgroundColor.SetColor(colFromHex_pink);
                    ws.Cells[1, header.Length + 216, 1, header.Length + 255].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, header.Length + 216, 1, header.Length + 255].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cells 1

                    ws.Cells[2, header.Length + 216].Value = head_result.Where(x => x.Task_Code == "T0092").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 216].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 216, 3, header.Length + 219].Merge = true;
                    ws.Cells[2, header.Length + 216, 3, header.Length + 219].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 216, 3, header.Length + 219].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);
                    ws.Cells[2, header.Length + 216, 3, header.Length + 219].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 216, 3, header.Length + 219].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                    //sub cells 1
                    ws.Cells[4, header.Length + 216].Value = "Working Date";
                    ws.Cells[4, header.Length + 216].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 216].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 216].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 216].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 217].Value = "Result";
                    ws.Cells[4, header.Length + 217].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 217].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 217].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 217].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 218].Value = "Problem";
                    ws.Cells[4, header.Length + 218].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 218].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 218].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 218].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 219].Value = "Problem Note";
                    ws.Cells[4, header.Length + 219].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 219].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 219].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 219].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    //cells 2

                    ws.Cells[2, header.Length + 220].Value = head_result.Where(x => x.Task_Code == "T0093").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 220].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 220, 3, header.Length + 223].Merge = true;
                    ws.Cells[2, header.Length + 220, 3, header.Length + 223].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 220, 3, header.Length + 223].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);
                    ws.Cells[2, header.Length + 220, 3, header.Length + 223].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 220, 3, header.Length + 223].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                    //sub cells 2
                    ws.Cells[4, header.Length + 220].Value = "Working Date";
                    ws.Cells[4, header.Length + 220].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 220].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 220].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 220].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 221].Value = "Result";
                    ws.Cells[4, header.Length + 221].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 221].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 221].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 221].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 222].Value = "Problem";
                    ws.Cells[4, header.Length + 222].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 222].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 222].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 222].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 223].Value = "Problem Note";
                    ws.Cells[4, header.Length + 223].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 223].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 223].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 223].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    //cells 3

                    ws.Cells[2, header.Length + 224].Value = head_result.Where(x => x.Task_Code == "T0094").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 224].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 224, 3, header.Length + 227].Merge = true;
                    ws.Cells[2, header.Length + 224, 3, header.Length + 227].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 224, 3, header.Length + 227].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);
                    ws.Cells[2, header.Length + 224, 3, header.Length + 227].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 224, 3, header.Length + 227].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                    //sub cells 3
                    ws.Cells[4, header.Length + 224].Value = "Working Date";
                    ws.Cells[4, header.Length + 224].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 224].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 224].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 224].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 225].Value = "Result";
                    ws.Cells[4, header.Length + 225].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 225].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 225].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 225].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 226].Value = "Problem";
                    ws.Cells[4, header.Length + 226].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 226].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 226].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 226].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 227].Value = "Problem Note";
                    ws.Cells[4, header.Length + 227].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 227].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 227].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 227].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    //cells 4

                    ws.Cells[2, header.Length + 228].Value = head_result.Where(x => x.Task_Code == "T0095").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 228].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 228, 3, header.Length + 231].Merge = true;
                    ws.Cells[2, header.Length + 228, 3, header.Length + 231].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 228, 3, header.Length + 231].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);
                    ws.Cells[2, header.Length + 228, 3, header.Length + 231].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 228, 3, header.Length + 231].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                    //sub cells 4
                    ws.Cells[4, header.Length + 228].Value = "Working Date";
                    ws.Cells[4, header.Length + 228].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 228].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 228].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 228].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 229].Value = "Result";
                    ws.Cells[4, header.Length + 229].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 229].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 229].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 229].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 230].Value = "Problem";
                    ws.Cells[4, header.Length + 230].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 230].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 230].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 230].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 231].Value = "Problem Note";
                    ws.Cells[4, header.Length + 231].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 231].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 231].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 231].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    //cells 5

                    ws.Cells[2, header.Length + 232].Value = head_result.Where(x => x.Task_Code == "T0096").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 232].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 232, 3, header.Length + 235].Merge = true;
                    ws.Cells[2, header.Length + 232, 3, header.Length + 235].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 232, 3, header.Length + 235].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);
                    ws.Cells[2, header.Length + 232, 3, header.Length + 235].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 232, 3, header.Length + 235].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                    //sub cells 5
                    ws.Cells[4, header.Length + 232].Value = "Working Date";
                    ws.Cells[4, header.Length + 232].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 232].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 232].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 232].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 233].Value = "Result";
                    ws.Cells[4, header.Length + 233].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 233].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 233].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 233].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 234].Value = "Problem";
                    ws.Cells[4, header.Length + 234].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 234].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 234].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 234].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 235].Value = "Problem Note";
                    ws.Cells[4, header.Length + 235].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 235].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 235].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 235].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    //cells 6

                    ws.Cells[2, header.Length + 236].Value = head_result.Where(x => x.Task_Code == "T0097").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 236].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 236, 3, header.Length + 239].Merge = true;
                    ws.Cells[2, header.Length + 236, 3, header.Length + 239].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 236, 3, header.Length + 239].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);
                    ws.Cells[2, header.Length + 236, 3, header.Length + 239].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 236, 3, header.Length + 239].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                    //sub cells 6
                    ws.Cells[4, header.Length + 236].Value = "Working Date";
                    ws.Cells[4, header.Length + 236].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 236].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 236].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 236].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 237].Value = "Result";
                    ws.Cells[4, header.Length + 237].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 237].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 237].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 237].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 238].Value = "Problem";
                    ws.Cells[4, header.Length + 238].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 238].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 238].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 238].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 239].Value = "Problem Note";
                    ws.Cells[4, header.Length + 239].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 239].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 239].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 239].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    //cells 7

                    ws.Cells[2, header.Length + 240].Value = head_result.Where(x => x.Task_Code == "T0010").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 240].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 240, 3, header.Length + 243].Merge = true;
                    ws.Cells[2, header.Length + 240, 3, header.Length + 243].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 240, 3, header.Length + 243].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);
                    ws.Cells[2, header.Length + 240, 3, header.Length + 243].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 240, 3, header.Length + 243].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                    //sub cells 7
                    ws.Cells[4, header.Length + 240].Value = "Working Date";
                    ws.Cells[4, header.Length + 240].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 240].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 240].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 240].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 241].Value = "Result";
                    ws.Cells[4, header.Length + 241].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 241].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 241].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 241].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 242].Value = "Problem";
                    ws.Cells[4, header.Length + 242].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 242].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 242].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 242].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 243].Value = "Problem Note";
                    ws.Cells[4, header.Length + 243].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 243].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 243].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 243].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    //cells 8

                    ws.Cells[2, header.Length + 244].Value = head_result.Where(x => x.Task_Code == "T0098").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 244].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 244, 3, header.Length + 247].Merge = true;
                    ws.Cells[2, header.Length + 244, 3, header.Length + 247].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 244, 3, header.Length + 247].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);
                    ws.Cells[2, header.Length + 244, 3, header.Length + 247].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 244, 3, header.Length + 247].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                    //sub cells 8
                    ws.Cells[4, header.Length + 244].Value = "Working Date";
                    ws.Cells[4, header.Length + 244].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 244].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 244].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 244].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 245].Value = "Result";
                    ws.Cells[4, header.Length + 245].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 245].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 245].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 245].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 246].Value = "Problem";
                    ws.Cells[4, header.Length + 246].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 246].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 246].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 246].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 247].Value = "Problem Note";
                    ws.Cells[4, header.Length + 247].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 247].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 247].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 247].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    //cells 9

                    ws.Cells[2, header.Length + 248].Value = head_result.Where(x => x.Task_Code == "T0099").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 248].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 248, 3, header.Length + 251].Merge = true;
                    ws.Cells[2, header.Length + 248, 3, header.Length + 251].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 248, 3, header.Length + 251].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);
                    ws.Cells[2, header.Length + 248, 3, header.Length + 251].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 248, 3, header.Length + 251].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                    //sub cells 9
                    ws.Cells[4, header.Length + 248].Value = "Working Date";
                    ws.Cells[4, header.Length + 248].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 248].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 248].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 248].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 249].Value = "Result";
                    ws.Cells[4, header.Length + 249].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 249].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 249].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 249].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 250].Value = "Problem";
                    ws.Cells[4, header.Length + 250].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 250].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 250].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 250].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 251].Value = "Problem Note";
                    ws.Cells[4, header.Length + 251].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 251].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 251].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 251].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    //cells 10

                    ws.Cells[2, header.Length + 252].Value = head_result.Where(x => x.Task_Code == "T0044").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 252].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 252, 3, header.Length + 255].Merge = true;
                    ws.Cells[2, header.Length + 252, 3, header.Length + 255].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 252, 3, header.Length + 255].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);
                    ws.Cells[2, header.Length + 252, 3, header.Length + 255].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 252, 3, header.Length + 255].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                    //sub cells 10
                    ws.Cells[4, header.Length + 252].Value = "Working Date";
                    ws.Cells[4, header.Length + 252].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 252].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 252].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 252].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 253].Value = "Result";
                    ws.Cells[4, header.Length + 253].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 253].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 253].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 253].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 254].Value = "Problem";
                    ws.Cells[4, header.Length + 254].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 254].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 254].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 254].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    ws.Cells[4, header.Length + 255].Value = "Problem Note";
                    ws.Cells[4, header.Length + 255].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 255].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 255].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 255].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_pink);

                    #endregion

                    #region Close Project Stage

                    Color colFromHex_red = System.Drawing.ColorTranslator.FromHtml("#F56751");
                    Color colFromHex_hevy_red = System.Drawing.ColorTranslator.FromHtml("#CE2308");

                    //cells close project

                    ws.Cells[1, header.Length + 256].Value = "Close Project Stage";
                    ws.Cells[1, header.Length + 256].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, header.Length + 256, 1, header.Length + 267].Merge = true;
                    ws.Cells[1, header.Length + 256, 1, header.Length + 267].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[1, header.Length + 256, 1, header.Length + 267].Style.Fill.BackgroundColor.SetColor(colFromHex_red);
                    ws.Cells[1, header.Length + 256, 1, header.Length + 267].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, header.Length + 256, 1, header.Length + 267].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //cells 1

                    ws.Cells[2, header.Length + 256].Value = head_result.Where(x => x.Task_Code == "T0045").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 256].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 256, 3, header.Length + 259].Merge = true;
                    ws.Cells[2, header.Length + 256, 3, header.Length + 259].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 256, 3, header.Length + 259].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_red);
                    ws.Cells[2, header.Length + 256, 3, header.Length + 259].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 256, 3, header.Length + 259].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                    //sub cells 1
                    ws.Cells[4, header.Length + 256].Value = "Working Date";
                    ws.Cells[4, header.Length + 256].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 256].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 256].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 256].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_red);

                    ws.Cells[4, header.Length + 257].Value = "Result";
                    ws.Cells[4, header.Length + 257].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 257].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 257].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 257].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_red);

                    ws.Cells[4, header.Length + 258].Value = "Problem";
                    ws.Cells[4, header.Length + 258].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 258].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 258].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 258].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_red);

                    ws.Cells[4, header.Length + 259].Value = "Problem Note";
                    ws.Cells[4, header.Length + 259].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 259].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 259].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 259].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_red);

                    //cells 2

                    ws.Cells[2, header.Length + 260].Value = head_result.Where(x => x.Task_Code == "T0046").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 260].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 260, 3, header.Length + 263].Merge = true;
                    ws.Cells[2, header.Length + 260, 3, header.Length + 263].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 260, 3, header.Length + 263].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_red);
                    ws.Cells[2, header.Length + 260, 3, header.Length + 263].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 260, 3, header.Length + 263].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                    //sub cells 2
                    ws.Cells[4, header.Length + 260].Value = "Working Date";
                    ws.Cells[4, header.Length + 260].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 260].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 260].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 260].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_red);

                    ws.Cells[4, header.Length + 261].Value = "Result";
                    ws.Cells[4, header.Length + 261].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 261].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 261].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 261].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_red);

                    ws.Cells[4, header.Length + 262].Value = "Problem";
                    ws.Cells[4, header.Length + 262].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 262].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 262].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 262].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_red);

                    ws.Cells[4, header.Length + 263].Value = "Problem Note";
                    ws.Cells[4, header.Length + 263].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 263].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 263].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 263].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_red);

                    //cells 3

                    ws.Cells[2, header.Length + 264].Value = head_result.Where(x => x.Task_Code == "T0047").Select(x => x.Task_Name).FirstOrDefault();
                    ws.Cells[2, header.Length + 264].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 264, 3, header.Length + 267].Merge = true;
                    ws.Cells[2, header.Length + 264, 3, header.Length + 267].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[2, header.Length + 264, 3, header.Length + 267].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_red);
                    ws.Cells[2, header.Length + 264, 3, header.Length + 267].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[2, header.Length + 264, 3, header.Length + 267].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                    //sub cells 3
                    ws.Cells[4, header.Length + 264].Value = "Working Date";
                    ws.Cells[4, header.Length + 264].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 264].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 264].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 264].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_red);

                    ws.Cells[4, header.Length + 265].Value = "Result";
                    ws.Cells[4, header.Length + 265].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 265].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 265].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 265].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_red);

                    ws.Cells[4, header.Length + 266].Value = "Problem";
                    ws.Cells[4, header.Length + 266].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 266].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 266].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 266].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_red);

                    ws.Cells[4, header.Length + 267].Value = "Problem Note";
                    ws.Cells[4, header.Length + 267].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 267].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 267].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 267].Style.Fill.BackgroundColor.SetColor(colFromHex_hevy_red);



                    #endregion

                    #region total usage

                    //cells 

                    ws.Cells[1, header.Length + 268].Value = "TOTAL USAGE";
                    ws.Cells[1, header.Length + 268].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, header.Length + 268, 1, header.Length + 272].Merge = true;
                    ws.Cells[1, header.Length + 268, 1, header.Length + 272].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, header.Length + 268, 1, header.Length + 272].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells 
                    ws.Cells[2, header.Length + 268].Value = "I";
                    ws.Cells[2, header.Length + 268].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 268, 4, header.Length + 268].Merge = true;
                    ws.Cells[2, header.Length + 268, 4, header.Length + 268].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells[2, header.Length + 269].Value = "T";
                    ws.Cells[2, header.Length + 269].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 269, 4, header.Length + 269].Merge = true;
                    ws.Cells[2, header.Length + 269, 4, header.Length + 269].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells[2, header.Length + 270].Value = "QC-I";
                    ws.Cells[2, header.Length + 270].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 270, 4, header.Length + 270].Merge = true;
                    ws.Cells[2, header.Length + 270, 4, header.Length + 270].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells[2, header.Length + 271].Value = "QC-F";
                    ws.Cells[2, header.Length + 271].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 271, 4, header.Length + 271].Merge = true;
                    ws.Cells[2, header.Length + 271, 4, header.Length + 271].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells[2, header.Length + 272].Value = "TOTAL";
                    ws.Cells[2, header.Length + 272].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 272, 4, header.Length + 272].Merge = true;
                    ws.Cells[2, header.Length + 272, 4, header.Length + 272].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                    #endregion

                    #region remaining usage

                    //cells close project

                    ws.Cells[1, header.Length + 273].Value = "REAINING USAGE";
                    ws.Cells[1, header.Length + 273].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, header.Length + 273, 1, header.Length + 277].Merge = true;
                    ws.Cells[1, header.Length + 273, 1, header.Length + 277].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, header.Length + 273, 1, header.Length + 277].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //sub cells 
                    ws.Cells[2, header.Length + 273].Value = "I";
                    ws.Cells[2, header.Length + 273].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 273, 4, header.Length + 273].Merge = true;
                    ws.Cells[2, header.Length + 273, 4, header.Length + 273].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells[2, header.Length + 274].Value = "T";
                    ws.Cells[2, header.Length + 274].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 274, 4, header.Length + 274].Merge = true;
                    ws.Cells[2, header.Length + 274, 4, header.Length + 274].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells[2, header.Length + 275].Value = "QC-I";
                    ws.Cells[2, header.Length + 275].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 275, 4, header.Length + 275].Merge = true;
                    ws.Cells[2, header.Length + 275, 4, header.Length + 275].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells[2, header.Length + 276].Value = "QC-F";
                    ws.Cells[2, header.Length + 276].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 276, 4, header.Length + 276].Merge = true;
                    ws.Cells[2, header.Length + 276, 4, header.Length + 276].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells[2, header.Length + 277].Value = "TOTAL";
                    ws.Cells[2, header.Length + 277].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[2, header.Length + 277, 4, header.Length + 277].Merge = true;
                    ws.Cells[2, header.Length + 277, 4, header.Length + 277].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    #endregion

                    #region other

                    ws.Cells[1, header.Length + 278].Value = "% COMPLTETE";
                    ws.Cells[1, header.Length + 278].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, header.Length + 278, 4, header.Length + 278].Merge = true;
                    ws.Cells[1, header.Length + 278, 4, header.Length + 278].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells[1, header.Length + 279].Value = "PROGRESS INDICATOR";
                    ws.Cells[1, header.Length + 279].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, header.Length + 279, 4, header.Length + 279].Merge = true;
                    ws.Cells[1, header.Length + 279, 4, header.Length + 279].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    #endregion

                    #region Purchase order information


                    ws.Cells[1, header.Length + 280].Value = "MANUFACTURING";
                    ws.Cells[1, header.Length + 280].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, header.Length + 280, 4, header.Length + 280].Merge = true;
                    ws.Cells[1, header.Length + 280, 4, header.Length + 280].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[1, header.Length + 280, 4, header.Length + 280].Style.Fill.BackgroundColor.SetColor(colFromHex_personInCharge);
                    ws.Cells[1, header.Length + 280, 4, header.Length + 280].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, header.Length + 280, 4, header.Length + 280].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    ws.Cells[1, header.Length + 281].Value = "PURCHASE ORDER INFORMATION";
                    ws.Cells[1, header.Length + 281].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, header.Length + 281, 3, header.Length + 286].Merge = true;
                    ws.Cells[1, header.Length + 281, 3, header.Length + 286].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[1, header.Length + 281, 3, header.Length + 286].Style.Fill.BackgroundColor.SetColor(colFromHex_b);
                    ws.Cells[1, header.Length + 281, 3, header.Length + 286].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, header.Length + 281, 3, header.Length + 286].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                    ws.Cells[4, header.Length + 281].Value = "P/O. No. SUBCONTRACT";
                    ws.Cells[4, header.Length + 281].Style.Font.Color.SetColor(System.Drawing.Color.Black);                   
                    ws.Cells[4, header.Length + 281, 4, header.Length + 281].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 281, 4, header.Length + 281].Style.Fill.BackgroundColor.SetColor(colFromHex_b);
                    ws.Cells[4, header.Length + 281, 4, header.Length + 281].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 281, 4, header.Length + 281].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    ws.Cells[4, header.Length + 282].Value = "P/O. No. EQ";
                    ws.Cells[4, header.Length + 282].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 282, 4, header.Length + 282].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 282, 4, header.Length + 282].Style.Fill.BackgroundColor.SetColor(colFromHex_b);
                    ws.Cells[4, header.Length + 282, 4, header.Length + 282].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 282, 4, header.Length + 282].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    ws.Cells[4, header.Length + 283].Value = "P/O. SHIPMENT DATE";
                    ws.Cells[4, header.Length + 283].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 283, 4, header.Length + 283].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 283, 4, header.Length + 283].Style.Fill.BackgroundColor.SetColor(colFromHex_b);
                    ws.Cells[4, header.Length + 283, 4, header.Length + 283].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 283, 4, header.Length + 283].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    ws.Cells[4, header.Length + 284].Value = "CONFIRM DSCR DATE";
                    ws.Cells[4, header.Length + 284].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 284, 4, header.Length + 284].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 284, 4, header.Length + 284].Style.Fill.BackgroundColor.SetColor(colFromHex_b);
                    ws.Cells[4, header.Length + 284, 4, header.Length + 284].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 284, 4, header.Length + 284].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    ws.Cells[4, header.Length + 285].Value = "PARTIAL DATE";
                    ws.Cells[4, header.Length + 285].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 285, 4, header.Length + 285].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 285, 4, header.Length + 285].Style.Fill.BackgroundColor.SetColor(colFromHex_b);
                    ws.Cells[4, header.Length + 285, 4, header.Length + 285].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 285, 4, header.Length + 285].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    ws.Cells[4, header.Length + 286].Value = "PARTIAL ITEM";
                    ws.Cells[4, header.Length + 286].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 286, 4, header.Length + 286].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 286, 4, header.Length + 286].Style.Fill.BackgroundColor.SetColor(colFromHex_b);
                    ws.Cells[4, header.Length + 286, 4, header.Length + 286].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 286, 4, header.Length + 286].Style.VerticalAlignment = ExcelVerticalAlignment.Center;



                    ws.Cells[1, header.Length + 287].Value = "D/O";
                    ws.Cells[1, header.Length + 287].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, header.Length + 287, 3, header.Length + 288].Merge = true;
                    ws.Cells[1, header.Length + 287, 3, header.Length + 288].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[1, header.Length + 287, 3, header.Length + 288].Style.Fill.BackgroundColor.SetColor(colFromHex_b);
                    ws.Cells[1, header.Length + 287, 3, header.Length + 288].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, header.Length + 287, 3, header.Length + 288].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    ws.Cells[4, header.Length + 287].Value = "No.";
                    ws.Cells[4, header.Length + 287].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 287, 4, header.Length + 287].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 287, 4, header.Length + 287].Style.Fill.BackgroundColor.SetColor(colFromHex_b);
                    ws.Cells[4, header.Length + 287, 4, header.Length + 287].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 287, 4, header.Length + 287].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    ws.Cells[4, header.Length + 288].Value = "DATE";
                    ws.Cells[4, header.Length + 288].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[4, header.Length + 288, 4, header.Length + 288].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[4, header.Length + 288, 4, header.Length + 288].Style.Fill.BackgroundColor.SetColor(colFromHex_b);
                    ws.Cells[4, header.Length + 288, 4, header.Length + 288].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[4, header.Length + 288, 4, header.Length + 288].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                  

                    ws.Cells[1, header.Length + 289].Value = "QC RESULT";
                    ws.Cells[1, header.Length + 289].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    ws.Cells[1, header.Length + 289, 4, header.Length + 289].Merge = true;
                    ws.Cells[1, header.Length + 289, 4, header.Length + 289].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[1, header.Length + 289, 4, header.Length + 289].Style.Fill.BackgroundColor.SetColor(colFromHex_b);
                    ws.Cells[1, header.Length + 289, 4, header.Length + 289].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, header.Length + 289, 4, header.Length + 289].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                    #endregion

                    #region  ** Set Border Style  **

                    var modelTable = ws.Cells[1, 1, 4, header.Length + 289];
                    //ws.Cells[start_row, start_col, end_row, end_column]
                    modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    #endregion




                    ws.Cells.AutoFitColumns();

                

                    ws.View.FreezePanes(5, 1);
                    
                 

                    package.Save();

                    var fileResult = new MyFiles
                    {
                        file = package.GetAsByteArray(),
                        name = FileNameSent,
                        extension = FileExtension,
                    };

                    status = true;

                   
                    Download(FileName);
                }

                

                resp.Add(status.ToString());
                resp.Add(FileName);

            }
            catch (Exception ex)
            {
                throw ex;
                
            }

           



            return Json(resp);
        }


        public FileResult Download(string FileName)
        {
            // var FileVirtualPath = "~/MasterFileReport/" + FileName+".xlsx";
            var FileVirtualPath = System.Web.Hosting.HostingEnvironment.MapPath("~/MasterFileReport/" + FileName + ".xlsx");
            return File(FileVirtualPath, "application/force-download", System.IO.Path.GetFileName(FileVirtualPath));
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
            var s_MNRoles = _lstGetMainMenu.Where(a => a.MNR_Role == "PDSCPAGE005").FirstOrDefault();
            if (s_MNRoles != null)
                ViewBag.GetMNRoles = s_MNRoles.MNR_Role;
            else
                ViewBag.GetMNRoles = "";

            set_lstRoles();
            var s_Roles = _lstGetRoles.Where(a => a.ROLE_Code == "Role_RP11").FirstOrDefault();
            if (s_Roles != null)
                ViewBag.GetRoles = s_Roles.ROLE_Code;
            else
                ViewBag.GetRoles = "";
        }

        #endregion
    }
}
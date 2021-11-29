using GemBox.Spreadsheet;
using Microsoft.Office.Interop.Excel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _PDSC_Web.Controllers._ProjectReport
{
    public class RP_ReportExcelController : Controller
    {
        // GET: RP_ReportExcel
        public ActionResult Index()
        {
            return View("Index", "_Architectui_Report");
        }

        public JsonResult Export_Excel()
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            // Create test DataSet with five DataTables
            DataSet dataSet = new DataSet();
            for (int i = 0; i < 5; i++)
            {
                System.Data.DataTable dataTable = new System.Data.DataTable("Table " + (i + 1));
                dataTable.Columns.Add("ID", typeof(int));
                dataTable.Columns.Add("FirstName", typeof(string));
                dataTable.Columns.Add("LastName", typeof(string));

                dataTable.Rows.Add(new object[] { 100, "John", "Doe" });
                dataTable.Rows.Add(new object[] { 101, "Fred", "Nurk" });
                dataTable.Rows.Add(new object[] { 103, "Hans", "Meier" });
                dataTable.Rows.Add(new object[] { 104, "Ivan", "Horvat" });
                dataTable.Rows.Add(new object[] { 105, "Jean", "Dupont" });
                dataTable.Rows.Add(new object[] { 106, "Mario", "Rossi" });

                dataSet.Tables.Add(dataTable);
            }

            // Create and fill a sheet for every DataTable in a DataSet
            var workbook = new ExcelFile();
            foreach (System.Data.DataTable dataTable in dataSet.Tables)
            {
                ExcelWorksheet worksheet = workbook.Worksheets.Add(dataTable.TableName);

                // Insert DataTable to an Excel worksheet.
                worksheet.InsertDataTable(dataTable,
                    new InsertDataTableOptions()
                    {
                        ColumnHeaders = true
                    });
            }

            workbook.Save("DataSet to Excel file.xlsx");

            return Json("");
        }
    }

}
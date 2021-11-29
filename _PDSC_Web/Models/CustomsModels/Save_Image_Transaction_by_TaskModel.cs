using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class Save_Image_Transaction_by_TaskModel
    {
        public Guid Transaction_Code { get; set; }
        public string ImgT_FileData { get; set; }
        public bool ImgT_File_IsDefect { get; set; }
        public string ImgT_FileName { get; set; }
        public string ImgT_FileType { get; set; }
        public DateTime ImgT_Create_Date { get; set; }
    }
}
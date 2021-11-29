using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ViewModels
{
    public class List_Image_Transaction_by_TaskVM
    {
        public Guid ImgT_Code { get; set; }
        public string ImgT_FileData { get; set; }
        public bool ImgT_File_IsDefect { get; set; }
        public string ImgT_FileName { get; set; }
        public string ImgT_FileType { get; set; }
    }
}
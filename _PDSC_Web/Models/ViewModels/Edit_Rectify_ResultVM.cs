using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ViewModels
{
    public class Edit_Rectify_ResultVM
    {
        public Guid DT_Code { get; set; }
        public string DefectItem { get; set; }
        public string RectifyResult { get; set; }
        public DateTime RetifyDate { get; set; }
        public string NoteRectify { get; set; }
        public string img_file_0 { get; set; }
        public string img_file_1 { get; set; }
        public string img_file_2 { get; set; }
        public string img_file_3 { get; set; }
        public string img_file_4 { get; set; }
        public string img_delete_0 { get; set; }
        public string img_delete_1 { get; set; }
        public string img_delete_2 { get; set; }
        public string img_delete_3 { get; set; }
        public string img_delete_4 { get; set; }

        #region variable for  file 

        public string file_0 { get; set; }
        public string filename_0 { get; set; }
        public string file_1 { get; set; }
        public string filename_1 { get; set; }
        public string file_2 { get; set; }
        public string filename_2 { get; set; }
        public string file_3 { get; set; }
        public string filename_3 { get; set; }
        public string file_4 { get; set; }
        public string filename_4 { get; set; }

        public string filedelete_0 { get; set; }
        public string filedelete_1 { get; set; }
        public string filedelete_2 { get; set; }
        public string filedelete_3 { get; set; }
        public string filedelete_4 { get; set; }

        public string filedeletename_0 { get; set; }
        public string filedeletename_1 { get; set; }
        public string filedeletename_2 { get; set; }
        public string filedeletename_3 { get; set; }
        public string filedeletename_4 { get; set; }

        #endregion
    }
}
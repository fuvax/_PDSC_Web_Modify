﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class DeleteContactPersonModels
    {
        public Guid ContactP_Code { get; set; }
        public string Site_Code { get; set; }
        public string PType_Code { get; set; }
        public string Position_Code { get; set; }
        public string Update_by { get; set; }
        public DateTime Last_Update { get; set; }
    }
}
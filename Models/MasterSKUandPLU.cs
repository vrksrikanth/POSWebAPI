using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace POS.Models
{
    public class MasterSKUandPLU
    {
        public string Authorization { get; set; }
        public string LocCode { get; set; }
        public string DeviceCode { get; set; }
        public List<MasterSKUMaster> SkuMaster { get; set; }
        public List<MasterPluMaster> PluMaster { get; set; }
    }
}
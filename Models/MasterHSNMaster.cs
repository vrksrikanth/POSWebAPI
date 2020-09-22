using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class MasterHSNMaster
    {
        public string HSNCode { get; set; }
        public string HSNName { get; set; }
        public string TaxCode { get; set; }
        public Nullable<decimal> SGST { get; set; }
        public Nullable<decimal> CGST { get; set; }
        public Nullable<decimal> IGST { get; set; }
        public Nullable<decimal> Cess { get; set; }
    }
}
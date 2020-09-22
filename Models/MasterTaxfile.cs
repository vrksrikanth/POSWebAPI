using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class MasterTaxfile
    {
        public string TaxCode { get; set; }
        public string TaxDesc { get; set; }
        public Nullable<decimal> TaxPerc { get; set; }
        public string CalcSur { get; set; }
    }
}
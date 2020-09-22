using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class MasterCurrencyFile
    {
        public string Country { get; set; }
        public string SwiftCode { get; set; }
        public string CurrCode { get; set; }
        public Nullable<decimal> XRate { get; set; }
        public Nullable<System.DateTime> EdtDt { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class MasterBrand
    {
        public string BrandCode { get; set; }
        public string BrandDesc { get; set; }
        public Nullable<decimal> DiscPerc { get; set; }
    }
}
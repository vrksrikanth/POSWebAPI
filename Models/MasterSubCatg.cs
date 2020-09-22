using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class MasterSubCatg
    {
        public string SubCatgCode { get; set; }
        public string SubCatgDesc { get; set; }
        public Nullable<decimal> Commission { get; set; }
    }
}
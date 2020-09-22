using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class MasterPluMaster
    {
        public string SkuCode { get; set; }
        public string PluCode { get; set; }
        public Nullable<float> PluQty { get; set; }
        public Nullable<decimal> CostPrice { get; set; }
        public Nullable<decimal> MRP { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
        public Nullable<int> ExpiryMonth { get; set; }
        public Nullable<int> ExpiryYear { get; set; }
        public string EanCode { get; set; }
        public Nullable<int> Priority { get; set; }
        public Nullable<decimal> ACP { get; set; }
        public Nullable<System.DateTime> LUpdatedDate { get; set; }
        public Nullable<decimal> WSPrice { get; set; }
        public string PluShade { get; set; }
        public string ColorCode { get; set; }
        public string SizeCode { get; set; }
        public Nullable<float> PluMBQ { get; set; }
        public string RackNo { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<decimal> ExtraPrice { get; set; }
    }
}
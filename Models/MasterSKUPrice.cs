using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class MasterSKUPrice
    {
        public string LocCode { get; set; }
        public string SkuCode { get; set; }
        public string PluCode { get; set; }
        public string EanCode { get; set; }
        public Nullable<decimal> CostPrice { get; set; }
        public Nullable<decimal> MRP { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
        public Nullable<int> Priority { get; set; }
        public string TaxCode { get; set; }
        public Nullable<bool> OpenRate { get; set; }
        public Nullable<bool> Discountable { get; set; }
        public Nullable<bool> InActive { get; set; }
        public Nullable<bool> NonInventory { get; set; }
    }
}
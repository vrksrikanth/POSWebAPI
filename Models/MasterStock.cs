using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class MasterStock
    {
        public System.DateTime StockDate { get; set; }
        public string LocCode { get; set; }
        public string SkuCode { get; set; }
        public string PluCode { get; set; }
        public Nullable<float> Purchase { get; set; }
        public Nullable<float> TransferIn { get; set; }
        public Nullable<float> TransferOut { get; set; }
        public Nullable<float> StockTake { get; set; }
        public Nullable<float> StockWriteOff { get; set; }
        public Nullable<float> Sales { get; set; }
        public Nullable<float> PurchaseReturn { get; set; }
        public Nullable<float> QOH { get; set; }
        public Nullable<float> Variance { get; set; }
        public Nullable<float> OldQty { get; set; }
        public Nullable<float> Refund { get; set; }
        public Nullable<decimal> SalesValue { get; set; }
        public Nullable<decimal> Gst { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<int> DiscCount { get; set; }
        public Nullable<float> FreeQty { get; set; }
        public Nullable<float> FreeSales { get; set; }
        public Nullable<float> OB { get; set; }
        public Nullable<float> CB { get; set; }
        public Nullable<float> ApprOut { get; set; }
        public Nullable<float> ApprIn { get; set; }
        public Nullable<decimal> CostValue { get; set; }
        public Nullable<decimal> SurchargeAmt { get; set; }
    }
}
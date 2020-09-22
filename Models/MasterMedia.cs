using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class MasterMedia
    {
        public string LocCode { get; set; }
        public System.DateTime MediaDate { get; set; }
        public string PaymentCode { get; set; }
        public string PaymentName { get; set; }
        public string CurrCode { get; set; }
        public Nullable<decimal> BuyRate { get; set; }
        public Nullable<decimal> SellRate { get; set; }
        public Nullable<decimal> DrawerAmount { get; set; }
        public Nullable<decimal> DrawerAmountByUser { get; set; }
        public Nullable<decimal> EquivalentAmount { get; set; }
    }
}
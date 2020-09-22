using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class MasterSupplier
    {
        public string SuppCode { get; set; }
        public string SuppName { get; set; }
        public string Contact { get; set; }
        public string Area { get; set; }
        public string Town { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phones { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Zip { get; set; }
        public string URL { get; set; }
        public string GST { get; set; }
        public string CST { get; set; }
        public string MfgCode { get; set; }
        public Nullable<decimal> DiscPer { get; set; }
        public Nullable<decimal> TaxPer { get; set; }
        public Nullable<int> CashCheque { get; set; }
        public Nullable<int> CreditDays { get; set; }
        public string FGL { get; set; }
        public string DrugLic { get; set; }
        public string TIN { get; set; }
        public string OutsideState { get; set; }
        public string NonVatDealer { get; set; }
    }
}
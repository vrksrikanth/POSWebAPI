//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POS
{
    using System;
    using System.Collections.Generic;
    
    public partial class PaymentMode
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string CurrCode { get; set; }
        public Nullable<decimal> MaxAmt { get; set; }
        public string IPFrom { get; set; }
        public bool OpenDrawer { get; set; }
        public bool PopUpFx { get; set; }
        public bool Change { get; set; }
        public bool ApprCode { get; set; }
        public bool OverTender { get; set; }
        public bool Validate { get; set; }
        public string PayCatg { get; set; }
        public Nullable<decimal> PayAmt { get; set; }
        public string PayGroup { get; set; }
        public string ChangeCode { get; set; }
        public bool Smart { get; set; }
        public bool Credit { get; set; }
        public bool Denomination { get; set; }
    }
}
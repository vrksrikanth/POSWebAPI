using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class MasterVIPMaster
    {
        public string VipCode { get; set; }
        public string VipSurName { get; set; }
        public string VipName { get; set; }
        public string IcPassportNo { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string TelephoneHome { get; set; }
        public string TelephoneOther { get; set; }
        public string Email { get; set; }
        public string Race { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public string Occupation { get; set; }
        public Nullable<System.DateTime> CustomerSince { get; set; }
        public Nullable<System.DateTime> LastPurchDate { get; set; }
        public Nullable<decimal> LastPurchAmt { get; set; }
        public Nullable<decimal> YTDPurch { get; set; }
        public Nullable<int> YTDNoOfPurch { get; set; }
        public string SpouseName { get; set; }
        public Nullable<System.DateTime> SpouseDob { get; set; }
        public Nullable<System.DateTime> AnniDate { get; set; }
        public string Child1 { get; set; }
        public Nullable<System.DateTime> Child1Dob { get; set; }
        public string Child2 { get; set; }
        public Nullable<System.DateTime> Child2Dob { get; set; }
        public string Child3 { get; set; }
        public Nullable<System.DateTime> Child3Dob { get; set; }
        public string Child4 { get; set; }
        public Nullable<System.DateTime> Child4Dob { get; set; }
        public string Child5 { get; set; }
        public Nullable<System.DateTime> Child5Dob { get; set; }
        public string CustType { get; set; }
        public Nullable<decimal> CreditLimit { get; set; }
        public Nullable<decimal> OSAmount { get; set; }
        public Nullable<int> NoOfTrans { get; set; }
        public Nullable<decimal> TotDisc { get; set; }
        public Nullable<decimal> TotTax { get; set; }
        public Nullable<decimal> TotValue { get; set; }
        public Nullable<float> TotPointsAcc { get; set; }
        public Nullable<float> TotPointsRedeem { get; set; }
        public bool Vip { get; set; }
        public bool Credit { get; set; }
        public bool Corporate { get; set; }
        public Nullable<float> DisPerc { get; set; }
        public string LocCode { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
    }
}
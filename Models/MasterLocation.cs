using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class MasterLocation
    {
        public string LocCode { get; set; }
        public string LocName { get; set; }
        public string ContactPerson { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string Add3 { get; set; }
        public string Phone { get; set; }
        public string Zip { get; set; }
        public Nullable<float> MarkUP { get; set; }
        public string SalesUpdate { get; set; }
        public string Franchisee { get; set; }
        public string OutsideState { get; set; }
        public string WHCode { get; set; }
        public string WHName { get; set; }
        public string TinNo { get; set; }
        public string ZoneCode { get; set; }
    }
}
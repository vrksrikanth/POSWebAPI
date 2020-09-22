using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class MasterDepartment
    {
        public string DeptCode { get; set; }
        public string DeptDesc { get; set; }
        public Nullable<decimal> DiscPerc { get; set; }
        public bool Comm { get; set; }
        public Nullable<float> Threshold { get; set; }
    }
}
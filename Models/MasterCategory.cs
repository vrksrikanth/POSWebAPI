using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace POS.Models
{
    public class MasterCategory
    {
        [Required]
        public string CatgCode { get; set; }
        public string CatgDesc { get; set; }
        public string DeptCode { get; set; }
        public Nullable<decimal> DiscPer { get; set; }
    }
}
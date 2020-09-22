using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POS.Models;
using System.Data.Entity.Infrastructure;

namespace POS.Controllers
{
    public class MasterPluMasterController : ApiController
    {
        public RetailManagerDBEntities entity = new RetailManagerDBEntities();

        [HttpGet]
        [Route("api/MasterPluMaster/GetData")]
        public List<MasterPluMaster> GetData()
        {
            var listCatagories = entity.plumasters
                .Select(u => new MasterPluMaster
                {
                    ACP = u.ACP,
                    ColorCode = u.ColorCode,
                    CostPrice = u.CostPrice,
                    DateCreated = u.DateCreated,
                    EanCode = u.EanCode,
                    ExpiryDate = u.ExpiryDate,
                    ExpiryMonth = u.ExpiryMonth,
                    ExpiryYear = u.ExpiryYear,
                    ExtraPrice = u.ExtraPrice,
                    LUpdatedDate = u.LUpdatedDate,
                    MRP = u.MRP,
                    PluCode = u.PluCode,
                    PluMBQ = u.PluMBQ,
                    PluQty = u.PluQty,
                    PluShade = u.PluShade,
                    Priority = u.Priority,
                    RackNo = u.RackNo,
                    SalePrice = u.SalePrice,
                    SizeCode = u.SizeCode,
                    SkuCode = u.SkuCode,
                    WSPrice = u.WSPrice
                }
            ).ToList();
            return listCatagories;

        }

        [HttpPost]
        [Route("api/MasterPluMaster/SaveLookUpValue")]
        public IHttpActionResult SaveLookUpValue(MasterPluMaster u)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            entity.plumasters.Add(new plumaster
            {
                ACP = u.ACP,
                ColorCode = u.ColorCode,
                CostPrice = u.CostPrice,
                DateCreated = u.DateCreated,
                EanCode = u.EanCode,
                ExpiryDate = u.ExpiryDate,
                ExpiryMonth = u.ExpiryMonth,
                ExpiryYear = u.ExpiryYear,
                ExtraPrice = u.ExtraPrice,
                LUpdatedDate = u.LUpdatedDate,
                MRP = u.MRP,
                PluCode = u.PluCode,
                PluMBQ = u.PluMBQ,
                PluQty = u.PluQty,
                PluShade = u.PluShade,
                Priority = u.Priority,
                RackNo = u.RackNo,
                SalePrice = u.SalePrice,
                SizeCode = u.SizeCode,
                SkuCode = u.SkuCode,
                WSPrice = u.WSPrice
            });
            entity.SaveChanges();

            return Ok(u);
        }

        [HttpPost]
        [Route("api/MasterPluMaster/DeleteLookUpValue")]
        public IHttpActionResult DeleteLookUpValue(MasterPluMaster data)
        {

            var record = entity.plumasters.Where(x => x.PluCode == data.PluCode).First();
            if (record == null)
            {
                return NotFound();
            }

            entity.plumasters.Remove(record);
            entity.SaveChanges();

            return Ok(record);
        }

        [HttpPost]
        [Route("api/MasterPluMaster/UpdateLookUpValue")]
        public IHttpActionResult UpdateLookUpValue(MasterPluMaster data)
        {
            if (data != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var record = entity.plumasters.Where(x => x.PluCode == data.PluCode).First();
                record.ACP = data.ACP;
               record.ColorCode = data.ColorCode;
                record.CostPrice = data.CostPrice;
                record.DateCreated = data.DateCreated;
                record.EanCode = data.EanCode;
                record.ExpiryDate = data.ExpiryDate;
                record.ExpiryMonth = data.ExpiryMonth;
                record.ExpiryYear = data.ExpiryYear;
                record.ExtraPrice = data.ExtraPrice;
                record.LUpdatedDate = data.LUpdatedDate;
                record.MRP = data.MRP;

                record.PluMBQ = data.PluMBQ;
                record.PluQty = data.PluQty;
                record.PluShade = data.PluShade;
                record.Priority = data.Priority;
                record.RackNo = data.RackNo;
                record.SalePrice = data.SalePrice;
                record.SizeCode = data.SizeCode;
                record.SkuCode = data.SkuCode;
                record.WSPrice = data.WSPrice;

                try
                {
                    entity.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }


            }
            return Ok(data);

        }
    }
}

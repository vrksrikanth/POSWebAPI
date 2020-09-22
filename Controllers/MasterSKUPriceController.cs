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
    public class MasterSKUPriceController : ApiController
    {
        public RetailManagerDBEntities entity = new RetailManagerDBEntities();

        [HttpGet]
        [Route("api/MasterSKUPrice/GetData")]
        public List<MasterSKUPrice> GetData()
        {
            var listCatagories = entity.SkuPrices
                .Select(u => new MasterSKUPrice
                {
                    NonInventory = u.NonInventory,
                    LocCode = u.LocCode,
                    SkuCode = u.SkuCode,
                    CostPrice = u.CostPrice,
                    Discountable = u.Discountable,
                    EanCode = u.EanCode,
                    InActive = u.InActive,
                    MRP = u.MRP,
                    OpenRate = u.OpenRate,
                    PluCode = u.PluCode,
                    Priority = u.Priority,
                    SalePrice = u.SalePrice,
                    TaxCode = u.TaxCode
                }
            ).ToList();
            return listCatagories;

        }

        [HttpPost]
        [Route("api/MasterSKUPrice/SaveLookUpValue")]
        public IHttpActionResult SaveLookUpValue(MasterSKUPrice data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            entity.SkuPrices.Add(new SkuPrice
            {
                NonInventory = data.NonInventory,
                LocCode = data.LocCode,
                SkuCode = data.SkuCode,
                CostPrice = data.CostPrice,
                Discountable = data.Discountable,
                EanCode = data.EanCode,
                InActive = data.InActive,
                MRP = data.MRP,
                OpenRate = data.OpenRate,
                PluCode = data.PluCode,
                Priority = data.Priority,
                SalePrice = data.SalePrice,
                TaxCode = data.TaxCode
            });
            entity.SaveChanges();

            return Ok(data);
        }

        [HttpPost]
        [Route("api/MasterSKUPrice/DeleteLookUpValue")]
        public IHttpActionResult DeleteLookUpValue(MasterSKUPrice data)
        {

            var record = entity.SkuPrices.Where(x => x.SkuCode == data.SkuCode).First();
            if (record == null)
            {
                return NotFound();
            }

            entity.SkuPrices.Remove(record);
            entity.SaveChanges();

            return Ok(record);
        }

        [HttpPost]
        [Route("api/MasterSKUPrice/UpdateLookUpValue")]
        public IHttpActionResult UpdateLookUpValue(MasterSKUPrice data)
        {
            if (data != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var record = entity.SkuPrices.Where(x => x.SkuCode == data.SkuCode).First();
                record.NonInventory = data.NonInventory;
                record.LocCode = data.LocCode;

                record.CostPrice = data.CostPrice;
                record.Discountable = data.Discountable;
                record.EanCode = data.EanCode;
                record.InActive = data.InActive;
                record.MRP = data.MRP;
                record.OpenRate = data.OpenRate;
                record.PluCode = data.PluCode;
                record.Priority = data.Priority;
                record.SalePrice = data.SalePrice;
                record.TaxCode = data.TaxCode;

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

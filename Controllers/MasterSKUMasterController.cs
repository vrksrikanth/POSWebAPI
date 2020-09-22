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
    public class MasterSKUMasterController : ApiController
    {

        public RetailManagerDBEntities entity = new RetailManagerDBEntities();

        [HttpGet]
        [Route("api/MasterSKUMaster/GetData")]
        public List<MasterSKUMaster> GetData()
        {
            var listData = entity.SkuMasters
                .Select(u => new MasterSKUMaster
                {
                    AllowDecimals = u.AllowDecimals,
                    AvgCost = u.AvgCost,
                    BestBefore = u.BestBefore,
                    BrandCode = u.BrandCode,
                    CatgCode = u.CatgCode,
                    ColorCode = u.ColorCode,
                    Consignment = u.Consignment,
                    CostPrice = u.CostPrice,
                    CreatedDate = u.CreatedDate,
                    CSTTaxCode = u.CSTTaxCode,
                    Disc1 = u.Disc1,
                    Disc2 = u.Disc2,
                    Discountable = u.Discountable,
                    DtPromFrom = u.DtPromFrom,
                    DtPromTo = u.DtPromTo,
                    EanCode = u.EanCode,
                    EanNumber = u.EanNumber,
                    EffectiveDate = u.EffectiveDate,
                    ExpiryYear = u.ExpiryYear,
                    ExpiryMonth = u.ExpiryMonth,
                    FirstCP = u.FirstCP,
                    FrTaxCode = u.FrTaxCode,
                    HSNCode = u.HSNCode,
                    Inactive = u.Inactive,
                    Indent = u.Indent,
                    Kit = u.Kit,
                    Lastcost = u.Lastcost,
                    LastUpdated = u.LastUpdated,
                    MarkDown = u.MarkDown,
                    Markup = u.Markup,
                    Matrix = u.Matrix,
                    MaxBQ = u.MaxBQ,
                    MBQ = u.MBQ,
                    MfgCode = u.MfgCode,
                    MinPrice = u.MinPrice,
                    MRP = u.MRP,
                    NewPrice = u.NewPrice,
                    OnOrder = u.OnOrder,
                    OpenRate = u.OpenRate,
                    PackSize = u.PackSize,
                    PatternCode = u.PatternCode,
                    Price = u.Price,
                    PromPrice = u.PromPrice,
                    Qoh = u.Qoh,
                    RackNo = u.RackNo,
                    Remarks = u.Remarks,
                    Rol = u.Rol,
                    Roq = u.Roq,
                    RunningPluNo = u.RunningPluNo,
                    ShortDesc = u.ShortDesc,
                    SizeCode = u.SizeCode,
                    SkuCode = u.SkuCode,
                    SkuDesc = u.SkuDesc,
                    SplCess = u.SplCess,
                    SubCatgCode = u.SubCatgCode,
                    SupplierCode = u.SupplierCode,
                    TaxCode = u.TaxCode,
                    ToAllLocations = u.ToAllLocations,
                    UOM = u.UOM,
                    UserId = u.UserId,
                    WebSKU = u.WebSKU,
                    WSPrice = u.WSPrice
                }
            ).ToList();
            return listData;

        }

        [HttpPost]
        [Route("api/MasterSKUMaster/SaveLookUpValue")]
        public IHttpActionResult SaveLookUpValue(MasterSKUMaster u)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            entity.SkuMasters.Add(new SkuMaster
            {
                AllowDecimals = u.AllowDecimals,
                AvgCost = u.AvgCost,
                BestBefore = u.BestBefore,
                BrandCode = u.BrandCode,
                CatgCode = u.CatgCode,
                ColorCode = u.ColorCode,
                Consignment = u.Consignment,
                CostPrice = u.CostPrice,
                CreatedDate = u.CreatedDate,
                CSTTaxCode = u.CSTTaxCode,
                Disc1 = u.Disc1,
                Disc2 = u.Disc2,
                Discountable = u.Discountable,
                DtPromFrom = u.DtPromFrom,
                DtPromTo = u.DtPromTo,
                EanCode = u.EanCode,
                EanNumber = u.EanNumber,
                EffectiveDate = u.EffectiveDate,
                ExpiryYear = u.ExpiryYear,
                ExpiryMonth = u.ExpiryMonth,
                FirstCP = u.FirstCP,
                FrTaxCode = u.FrTaxCode,
                HSNCode = u.HSNCode,
                Inactive = u.Inactive,
                Indent = u.Indent,
                Kit = u.Kit,
                Lastcost = u.Lastcost,
                LastUpdated = u.LastUpdated,
                MarkDown = u.MarkDown,
                Markup = u.Markup,
                Matrix = u.Matrix,
                MaxBQ = u.MaxBQ,
                MBQ = u.MBQ,
                MfgCode = u.MfgCode,
                MinPrice = u.MinPrice,
                MRP = u.MRP,
                NewPrice = u.NewPrice,
                OnOrder = u.OnOrder,
                OpenRate = u.OpenRate,
                PackSize = u.PackSize,
                PatternCode = u.PatternCode,
                Price = u.Price,
                PromPrice = u.PromPrice,
                Qoh = u.Qoh,
                RackNo = u.RackNo,
                Remarks = u.Remarks,
                Rol = u.Rol,
                Roq = u.Roq,
                RunningPluNo = u.RunningPluNo,
                ShortDesc = u.ShortDesc,
                SizeCode = u.SizeCode,
                SkuCode = u.SkuCode,
                SkuDesc = u.SkuDesc,
                SplCess = u.SplCess,
                SubCatgCode = u.SubCatgCode,
                SupplierCode = u.SupplierCode,
                TaxCode = u.TaxCode,
                ToAllLocations = u.ToAllLocations,
                UOM = u.UOM,
                UserId = u.UserId,
                WebSKU = u.WebSKU,
                WSPrice = u.WSPrice
            });
            entity.SaveChanges();

            return Ok(u);
        }

        [HttpPost]
        [Route("api/MasterSKUMaster/DeleteLookUpValue")]
        public IHttpActionResult DeleteLookUpValue(MasterSKUMaster data)
        {

            var record = entity.SkuMasters.Where(x => x.SkuCode == data.SkuCode).First();
            if (record == null)
            {
                return NotFound();
            }

            entity.SkuMasters.Remove(record);
            entity.SaveChanges();

            return Ok(record);
        }

        [HttpPost]
        [Route("api/MasterSKUMaster/UpdateLookUpValue")]
        public IHttpActionResult UpdateLookUpValue(MasterSKUMaster u)
        {
            if (u != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var record = entity.SkuMasters.Where(x => x.SkuCode == u.SkuCode).First();
                record.AllowDecimals = u.AllowDecimals;
                record.AvgCost = u.AvgCost;
                record.BestBefore = u.BestBefore;
                record.BrandCode = u.BrandCode;
                record.CatgCode = u.CatgCode;
                record.ColorCode = u.ColorCode;
                record.Consignment = u.Consignment;
                record.CostPrice = u.CostPrice;
                record.CreatedDate = u.CreatedDate;
                record.CSTTaxCode = u.CSTTaxCode;
                record.Disc1 = u.Disc1;
                record.Disc2 = u.Disc2;
                record.Discountable = u.Discountable;
                record.DtPromFrom = u.DtPromFrom;
                record.DtPromTo = u.DtPromTo;
                record.EanCode = u.EanCode;
                record.EanNumber = u.EanNumber;
                record.EffectiveDate = u.EffectiveDate;
                record.ExpiryYear = u.ExpiryYear;
                record.ExpiryMonth = u.ExpiryMonth;
                record.FirstCP = u.FirstCP;
                record.FrTaxCode = u.FrTaxCode;
                record.HSNCode = u.HSNCode;
                record.Inactive = u.Inactive;
                record.Indent = u.Indent;
                record.Kit = u.Kit;
                record.Lastcost = u.Lastcost;
                record.LastUpdated = u.LastUpdated;
                record.MarkDown = u.MarkDown;
                record.Markup = u.Markup;
                record.Matrix = u.Matrix;
                record.MaxBQ = u.MaxBQ;
                record.MBQ = u.MBQ;
                record.MfgCode = u.MfgCode;
                record.MinPrice = u.MinPrice;
                record.MRP = u.MRP;
                record.NewPrice = u.NewPrice;
                record.OnOrder = u.OnOrder;
                record.OpenRate = u.OpenRate;
                record.PackSize = u.PackSize;
                record.PatternCode = u.PatternCode;
                record.Price = u.Price;
                record.PromPrice = u.PromPrice;
                record.Qoh = u.Qoh;
                record.RackNo = u.RackNo;
                record.Remarks = u.Remarks;
                record.Rol = u.Rol;
                record.Roq = u.Roq;
                record.RunningPluNo = u.RunningPluNo;
                record.ShortDesc = u.ShortDesc;
                record.SizeCode = u.SizeCode;

                record.SkuDesc = u.SkuDesc;
                record.SplCess = u.SplCess;
                record.SubCatgCode = u.SubCatgCode;
                record.SupplierCode = u.SupplierCode;
                record.TaxCode = u.TaxCode;
                record.ToAllLocations = u.ToAllLocations;
                record.UOM = u.UOM;
                record.UserId = u.UserId;
                record.WebSKU = u.WebSKU;
                record.WSPrice = u.WSPrice;

                try
                {
                    entity.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }


            }
            return Ok(u);

        }
    }
}

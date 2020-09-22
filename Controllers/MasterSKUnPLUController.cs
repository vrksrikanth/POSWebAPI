using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POS.Models;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace POS.Controllers
{
    public class MasterSKUnPLUController : ApiController
    {

        public RetailManagerDBEntities entity = new RetailManagerDBEntities();


        [HttpPost]
        [Route("api/MasterSKUnPLUMaster/SaveLookUpValue")]
        public IHttpActionResult SaveLookUpValue(MasterSKUandPLU data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                using (DbContextTransaction transaction = entity.Database.BeginTransaction())
                {
                    try
                    {
                        if (data.SkuMaster.Count > 0)
                        {
                            entity.SkuMasters.AddRange(from u in data.SkuMaster
                                                       select new SkuMaster
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

                                        );
                        }

                        if (data.PluMaster.Count > 0)
                        {
                            //entity.plumasters.AddRange(data.PluMaster);

                            entity.plumasters.AddRange(from u in data.PluMaster
                                                       select new plumaster
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
                                                           PluMBQ = u.PluMBQ,
                                                           PluQty = u.PluQty,
                                                           PluShade = u.PluShade,
                                                           Priority = u.Priority,
                                                           RackNo = u.RackNo,
                                                           SalePrice = u.SalePrice,
                                                           SizeCode = u.SizeCode,
                                                           SkuCode = u.SkuCode,
                                                           WSPrice = u.WSPrice,
                                                           PluCode = u.PluCode
                                                       }

                                        );

                        }
                        entity.SaveChanges();
                        transaction.Commit();
                    }

                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        if (transaction != null)
                        { transaction.Dispose(); }
                    }
                }
            }
            catch
            {
                throw;
            }


            return Ok(data);
        }

        [HttpPost]
        [Route("api/MasterSKUnPLUMaster/UpdateLookUpValue")]
        public IHttpActionResult UpdateLookUpValue(MasterSKUandPLU data)
        {
            if (data != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                using (DbContextTransaction transaction = entity.Database.BeginTransaction())
                {
                    if (data.SkuMaster.Count > 1)
                    {
                        updateSKU(data.SkuMaster);
                    }

                    if (data.PluMaster.Count > 1)
                    {
                        updatePLU(data.PluMaster);
                    }
                    entity.SaveChanges();
                    transaction.Commit();

                }

                try
                {
                    entity.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }


            }
            return Ok();

        }

        private bool updateSKU(List<MasterSKUMaster> listSKUMaster)
        {
            bool status = false;

            foreach (var u in listSKUMaster)
            {
                var record = entity.SkuMasters.Where(x => x.SkuCode == u.SkuCode).First();
                if (record != null)
                {
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
                }

            }

            //entity.SaveChanges();


            return status;
        }

        private bool updatePLU(List<MasterPluMaster> listPLUMaster)
        {
            bool status = false;

            foreach (var data in listPLUMaster)
            {
                var record = entity.plumasters.Where(x => x.SkuCode == data.SkuCode && x.PluCode == data.PluCode).First();
                if (record != null)
                {
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
                }

            }

            //entity.SaveChanges();


            return status;
        }
    }
}

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
    public class MasterStockController : ApiController
    {
        public RetailManagerDBEntities entity = new RetailManagerDBEntities();

        [HttpGet]
        [Route("api/MasterStock/GetData")]
        public List<MasterStock> GetData()
        {
            var listData = entity.Stocks
                .Select(u => new MasterStock
                {
                    SkuCode = u.SkuCode,
                    ApprIn = u.ApprIn,
                    ApprOut = u.ApprOut,
                    CB = u.CB,
                    CostValue = u.CostValue,
                    DiscCount = u.DiscCount,
                    Discount = u.Discount,
                    FreeQty = u.FreeQty,
                    FreeSales = u.FreeSales,
                    Gst = u.Gst,
                    LocCode = u.LocCode,
                    OB = u.OB,
                    OldQty = u.OldQty,
                    PluCode = u.PluCode,
                    Purchase = u.Purchase,
                    PurchaseReturn = u.Purchase,
                    QOH = u.QOH,
                    Refund = u.Refund,
                    Sales = u.Sales,
                    SalesValue = u.SalesValue,
                    StockDate = u.StockDate,
                    StockTake = u.StockTake,
                    StockWriteOff = u.StockWriteOff,
                    SurchargeAmt = u.SurchargeAmt,
                    TransferIn = u.TransferIn,
                    TransferOut = u.TransferOut,
                    Variance = u.Variance
                }
            ).ToList();
            return listData;

        }

        [HttpPost]
        [Route("api/MasterStock/SaveLookUpValue")]
        public IHttpActionResult SaveLookUpValue(MasterStock data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            entity.Stocks.Add(new Stock
            {
                SkuCode = data.SkuCode,
                ApprIn = data.ApprIn,
                ApprOut = data.ApprOut,
                CB = data.CB,
                CostValue = data.CostValue,
                DiscCount = data.DiscCount,
                Discount = data.Discount,
                FreeQty = data.FreeQty,
                FreeSales = data.FreeSales,
                Gst = data.Gst,
                LocCode = data.LocCode,
                OB = data.OB,
                OldQty = data.OldQty,
                PluCode = data.PluCode,
                Purchase = data.Purchase,
                PurchaseReturn = data.Purchase,
                QOH = data.QOH,
                Refund = data.Refund,
                Sales = data.Sales,
                SalesValue = data.SalesValue,
                StockDate = data.StockDate,
                StockTake = data.StockTake,
                StockWriteOff = data.StockWriteOff,
                SurchargeAmt = data.SurchargeAmt,
                TransferIn = data.TransferIn,
                TransferOut = data.TransferOut,
                Variance = data.Variance
            });
            entity.SaveChanges();

            return Ok(data);
        }

        [HttpPost]
        [Route("api/MasterStock/DeleteLookUpValue")]
        public IHttpActionResult DeleteLookUpValue(MasterStock data)
        {

            var record = entity.Stocks.Where(x => x.StockDate == data.StockDate && x.LocCode == data.LocCode
                    && x.SkuCode == data.SkuCode && x.PluCode == data.PluCode).First();
            if (record == null)
            {
                return NotFound();
            }

            entity.Stocks.Remove(record);
            entity.SaveChanges();

            return Ok(record);
        }

        [HttpPost]
        [Route("api/MasterStock/UpdateLookUpValue")]
        public IHttpActionResult UpdateLookUpValue(MasterStock data)
        {
            if (data != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var record = entity.Stocks.Where(x => x.StockDate == data.StockDate && x.LocCode == data.LocCode
                    && x.SkuCode == data.SkuCode && x.PluCode == data.PluCode).First();
                record.SkuCode = data.SkuCode;
                record.ApprIn = data.ApprIn;
                record.ApprOut = data.ApprOut;
                record.CB = data.CB;
                record.CostValue = data.CostValue;
                record.DiscCount = data.DiscCount;
                record.Discount = data.Discount;
                record.FreeQty = data.FreeQty;
                record.FreeSales = data.FreeSales;
                record.Gst = data.Gst;
                //record.LocCode = data.LocCode;
                record.OB = data.OB;
                record.OldQty = data.OldQty;
                //record.PluCode = data.PluCode;
                record.Purchase = data.Purchase;
                record.PurchaseReturn = data.Purchase;
                record.QOH = data.QOH;
                record.Refund = data.Refund;
                record.Sales = data.Sales;
                record.SalesValue = data.SalesValue;
                // record.StockDate = data.StockDate;
                record.StockTake = data.StockTake;
                record.StockWriteOff = data.StockWriteOff;
                record.SurchargeAmt = data.SurchargeAmt;
                record.TransferIn = data.TransferIn;
                record.TransferOut = data.TransferOut;
                record.Variance = data.Variance;

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

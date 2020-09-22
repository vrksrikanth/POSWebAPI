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
    public class MasterMediaController : ApiController
    {
        public RetailManagerDBEntities entity = new RetailManagerDBEntities();

        [HttpGet]
        [Route("api/MasterMedia/GetData")]
        public List<POS.Models.MasterMedia> GetData()
        {
            var listCatagories = entity.Media
                .Select(u => new MasterMedia
                {
                    BuyRate = u.BuyRate,
                    CurrCode = u.CurrCode,
                    DrawerAmount = u.DrawerAmount,
                    DrawerAmountByUser = u.DrawerAmountByUser,
                    EquivalentAmount = u.EquivalentAmount,
                    LocCode = u.LocCode,
                    MediaDate = u.MediaDate,
                    PaymentCode = u.PaymentCode,
                    PaymentName = u.PaymentName,
                    SellRate = u.SellRate
                }
            ).ToList();
            return listCatagories;
        }

        [HttpPost]
        [Route("api/MasterMedia/SaveLookUpValue")]
        public IHttpActionResult SaveLookUpValue(MasterMedia data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            entity.Media.Add(new Medium
            {
                BuyRate = data.BuyRate,
                CurrCode = data.CurrCode,
                DrawerAmount = data.DrawerAmount,
                DrawerAmountByUser = data.DrawerAmountByUser,
                EquivalentAmount = data.EquivalentAmount,
                LocCode = data.LocCode,
                MediaDate = data.MediaDate,
                PaymentCode = data.PaymentCode,
                PaymentName = data.PaymentName,
                SellRate = data.SellRate
            });
            entity.SaveChanges();

            return Ok(data);
        }

        [HttpPost]
        [Route("api/MasterMedia/DeleteLookUpValue")]
        public IHttpActionResult DeleteLookUpValue(MasterMedia data)
        {

            var record = entity.Media.Where(x => x.LocCode == data.LocCode && x.MediaDate == data.MediaDate
                && x.PaymentCode == data.PaymentCode && x.PaymentName == data.PaymentName).First();
            if (record == null)
            {
                return NotFound();
            }

            entity.Media.Remove(record);
            entity.SaveChanges();

            return Ok(record);
        }

        [HttpPost]
        [Route("api/MasterMedia/UpdateLookUpValue")]
        public IHttpActionResult UpdateLookUpValue(MasterMedia data)
        {
            if (data != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var record = entity.Media.Where(x => x.LocCode == data.LocCode && x.MediaDate == data.MediaDate
                        && x.PaymentCode == data.PaymentCode && x.PaymentName == data.PaymentName).First();

                record.BuyRate = data.BuyRate;
                record.CurrCode = data.CurrCode;
                record.DrawerAmount = data.DrawerAmount;
                record.DrawerAmountByUser = data.DrawerAmountByUser;
                record.EquivalentAmount = data.EquivalentAmount;
                record.SellRate = data.SellRate;

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

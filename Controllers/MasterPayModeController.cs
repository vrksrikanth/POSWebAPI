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
    public class MasterPayModeController : ApiController
    {
        public RetailManagerDBEntities entity = new RetailManagerDBEntities();

        [HttpGet]
        [Route("api/MasterPayMode/GetData")]
        public List<POS.Models.MasterPaymentMode> GetData()
        {
            var listData = entity.PaymentModes
                .Select(u => new MasterPaymentMode
                {
                    ApprCode = u.ApprCode,
                    Change = u.Change,
                    ChangeCode = u.ChangeCode,
                    Credit = u.Credit,
                    Code = u.Code,
                    CurrCode = u.CurrCode,
                    Denomination = u.Denomination,
                    IPFrom = u.IPFrom,
                    MaxAmt = u.MaxAmt,
                    Name = u.Name,
                    OpenDrawer = u.OpenDrawer,
                    OverTender = u.OverTender,
                    PayAmt = u.PayAmt,
                    PayCatg = u.PayCatg,
                    PayGroup = u.PayGroup,
                    PopUpFx = u.PopUpFx,
                    Smart = u.Smart,
                    Validate = u.Validate
                }
            ).ToList();
            return listData;

        }

        [HttpPost]
        [Route("api/MasterPayMode/SaveLookUpValue")]
        public IHttpActionResult SaveLookUpValue(MasterPaymentMode data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            entity.PaymentModes.Add(new PaymentMode
            {
                ApprCode = data.ApprCode,
                Change = data.Change,
                ChangeCode = data.ChangeCode,
                Credit = data.Credit,
                Code = data.Code,
                CurrCode = data.CurrCode,
                Denomination = data.Denomination,
                IPFrom = data.IPFrom,
                MaxAmt = data.MaxAmt,
                Name = data.Name,
                OpenDrawer = data.OpenDrawer,
                OverTender = data.OverTender,
                PayAmt = data.PayAmt,
                PayCatg = data.PayCatg,
                PayGroup = data.PayGroup,
                PopUpFx = data.PopUpFx,
                Smart = data.Smart,
                Validate = data.Validate
            });
            entity.SaveChanges();

            return Ok(data);
        }

        [HttpPost]
        [Route("api/MasterPayMode/DeleteLookUpValue")]
        public IHttpActionResult DeleteLookUpValue(MasterPaymentMode data)
        {

            var record = entity.PaymentModes.Where(x => x.Code == data.Code).First();
            if (record == null)
            {
                return NotFound();
            }

            entity.PaymentModes.Remove(record);
            entity.SaveChanges();

            return Ok(record);
        }

        [HttpPost]
        [Route("api/MasterPayMode/UpdateLookUpValue")]
        public IHttpActionResult UpdateLookUpValue(MasterPaymentMode data)
        {
            if (data != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var record = entity.PaymentModes.Where(x => x.Code == data.Code).First();
                record.ApprCode = data.ApprCode;
                record.Change = data.Change;
                record.ChangeCode = data.ChangeCode;
                record.Credit = data.Credit;
               
                record.CurrCode = data.CurrCode;
                record.Denomination = data.Denomination;
                record.IPFrom = data.IPFrom;
                record.MaxAmt = data.MaxAmt;
                record.Name = data.Name;
                record.OpenDrawer = data.OpenDrawer;
                record.OverTender = data.OverTender;
                record.PayAmt = data.PayAmt;
                record.PayCatg = data.PayCatg;
                record.PayGroup = data.PayGroup;
                record.PopUpFx = data.PopUpFx;

                record.Smart = data.Smart;
                record.Validate = data.Validate;

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

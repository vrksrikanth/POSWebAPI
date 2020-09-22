using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POS.Models;
using System.Data.Entity.Infrastructure;

namespace POS.Models
{
    public class MasterCurrencyFileController : ApiController
    {
        public RetailManagerDBEntities entity = new RetailManagerDBEntities();

        [HttpGet]
        [Route("api/MasterCurrencyFile/GetData")]
        public List<POS.Models.MasterCurrencyFile> GetData()
        {
            var listCatagories = entity.CurrencyFiles
                .Select(u => new MasterCurrencyFile
                {
                    Country = u.Country,
                    SwiftCode = u.SwiftCode,
                    CurrCode = u.CurrCode,
                    XRate = u.XRate,
                    EdtDt = u.EdtDt
                }
            ).ToList();
            return listCatagories;

        }

        [HttpPost]
        [Route("api/MasterCurrencyFile/SaveLookUpValue")]
        public IHttpActionResult SaveLookUpValue(MasterCurrencyFile data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            entity.CurrencyFiles.Add(new CurrencyFile { Country = data.Country, SwiftCode = data.SwiftCode, CurrCode = data.CurrCode, XRate = data.XRate, EdtDt = data.EdtDt });
            entity.SaveChanges();

            return Ok(data);
        }

        [HttpPost]
        [Route("api/MasterCurrencyFile/DeleteLookUpValue")]
        public IHttpActionResult DeleteLookUpValue(MasterCurrencyFile data)
        {

            var record = entity.CurrencyFiles.Where(x => x.CurrCode == data.CurrCode).First();
            if (record == null)
            {
                return NotFound();
            }

            entity.CurrencyFiles.Remove(record);
            entity.SaveChanges();

            return Ok(record);
        }

        [HttpPost]
        [Route("api/MasterCurrencyFile/UpdateLookUpValue")]
        public IHttpActionResult UpdateLookUpValue(MasterCurrencyFile data)
        {
            if (data != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var record = entity.CurrencyFiles.Where(x => x.CurrCode == data.CurrCode).First();
                record.Country = data.Country;
                record.SwiftCode = data.SwiftCode;
                record.XRate = data.XRate;
                record.EdtDt = data.EdtDt;

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

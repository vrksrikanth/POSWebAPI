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
    public class MasterTaxFileController : ApiController
    {
        public RetailManagerDBEntities entity = new RetailManagerDBEntities();

        [HttpGet]
        [Route("api/MasterTaxfile/GetData")]
        public List<POS.Models.MasterTaxfile> GetData()
        {
            var listCatagories = entity.TaxFiles
                .Select(u => new MasterTaxfile
                {
                    TaxCode = u.TaxCode,
                    CalcSur = u.CalcSur,
                    TaxDesc = u.TaxDesc,
                    TaxPerc = u.TaxPerc
                }
            ).ToList();
            return listCatagories;

        }

        [HttpPost]
        [Route("api/MasterTaxfile/SaveLookUpValue")]
        public IHttpActionResult SaveLookUpValue(MasterTaxfile data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            entity.TaxFiles.Add(new TaxFile
            {
                TaxCode = data.TaxCode,
                CalcSur = data.CalcSur,
                TaxDesc = data.TaxDesc,
                TaxPerc = data.TaxPerc
            });
            entity.SaveChanges();

            return Ok(data);
        }

        [HttpPost]
        [Route("api/MasterTaxfile/DeleteLookUpValue")]
        public IHttpActionResult DeleteLookUpValue(MasterTaxfile data)
        {

            var record = entity.TaxFiles.Where(x => x.TaxCode == data.TaxCode).First();
            if (record == null)
            {
                return NotFound();
            }

            entity.TaxFiles.Remove(record);
            entity.SaveChanges();

            return Ok(record);
        }

        [HttpPost]
        [Route("api/MasterTaxfile/UpdateLookUpValue")]
        public IHttpActionResult UpdateLookUpValue(MasterTaxfile data)
        {
            if (data != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var record = entity.TaxFiles.Where(x => x.TaxCode == data.TaxCode).First();
                record.CalcSur = data.CalcSur;
                record.TaxDesc = data.TaxDesc;
                record.TaxPerc = data.TaxPerc;

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

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
    public class MasterHSNMController : ApiController
    {

        public RetailManagerDBEntities entity = new RetailManagerDBEntities();

        [HttpGet]
        [Route("api/MasterHSNM/GetData")]
        public List<MasterHSNMaster> GetData()
        {
            var listCatagories = entity.HSNMasters
                .Select(u => new MasterHSNMaster
                {
                    Cess = u.Cess,
                    CGST = u.CGST,
                    HSNCode = u.HSNCode,
                    HSNName = u.HSNName,
                    IGST = u.IGST,
                    SGST = u.SGST,
                    TaxCode = u.TaxCode
                }
            ).ToList();
            return listCatagories;

        }

        [HttpPost]
        [Route("api/MasterHSNM/SaveLookUpValue")]
        public IHttpActionResult SaveLookUpValue(MasterHSNMaster data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            entity.HSNMasters.Add(new HSNMaster { Cess = data.Cess, CGST = data.CGST, HSNCode = data.HSNCode, HSNName = data.HSNName, IGST = data.IGST, SGST = data.SGST, TaxCode = data.TaxCode });
            entity.SaveChanges();

            return Ok(data);
        }

        [HttpPost]
        [Route("api/MasterHSNM/DeleteLookUpValue")]
        public IHttpActionResult DeleteLookUpValue(MasterHSNMaster data)
        {

            var record = entity.HSNMasters.Where(x => x.HSNCode == data.HSNCode).First();
            if (record == null)
            {
                return NotFound();
            }

            entity.HSNMasters.Remove(record);
            entity.SaveChanges();

            return Ok(record);
        }

        [HttpPost]
        [Route("api/MasterHSNM/UpdateLookUpValue")]
        public IHttpActionResult UpdateLookUpValue(MasterHSNMaster data)
        {
            if (data != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var record = entity.HSNMasters.Where(x => x.HSNCode == data.HSNCode).First();
                record.Cess = data.Cess;
                record.CGST = data.CGST;
                record.HSNName = data.HSNName;
                record.IGST = data.IGST;
                record.SGST = data.SGST;
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

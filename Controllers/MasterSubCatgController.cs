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
    public class MasterSubCatgController : ApiController
    {
        public RetailManagerDBEntities entity = new RetailManagerDBEntities();

        [HttpGet]
        [Route("api/MasterSubCatg/GetData")]
        public List<POS.Models.MasterSubCatg> GetData()
        {
            var listCatagories = entity.SubCatgs
                .Select(u => new MasterSubCatg
                {
                    Commission=u.Commission,
                    SubCatgCode=u.SubCatgCode,
                    SubCatgDesc=u.SubCatgDesc
                }
            ).ToList();
            return listCatagories;

        }

        [HttpPost]
        [Route("api/MasterSubCatg/SaveLookUpValue")]
        public IHttpActionResult SaveLookUpValue(MasterSubCatg data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            entity.SubCatgs.Add(new SubCatg {
                Commission = data.Commission,
                SubCatgCode = data.SubCatgCode,
                SubCatgDesc = data.SubCatgDesc
            });
            entity.SaveChanges();

            return Ok(data);
        }

        [HttpPost]
        [Route("api/MasterSubCatg/DeleteLookUpValue")]
        public IHttpActionResult DeleteLookUpValue(MasterSubCatg data)
        {

            var record = entity.SubCatgs.Where(x => x.SubCatgCode == data.SubCatgCode).First();
            if (record == null)
            {
                return NotFound();
            }

            entity.SubCatgs.Remove(record);
            entity.SaveChanges();

            return Ok(record);
        }

        [HttpPost]
        [Route("api/MasterSubCatg/UpdateLookUpValue")]
        public IHttpActionResult UpdateLookUpValue(MasterSubCatg data)
        {
            if (data != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var record = entity.SubCatgs.Where(x => x.SubCatgCode == data.SubCatgCode).First();
                record.SubCatgDesc = data.SubCatgDesc;
                record.Commission = data.Commission;

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

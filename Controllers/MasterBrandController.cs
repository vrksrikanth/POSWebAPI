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
    public class MasterBrandController : ApiController
    {

        public RetailManagerDBEntities entity = new RetailManagerDBEntities();

        [HttpGet]
        [Route("api/MasterBrand/GetData")]
        public List<POS.Models.MasterBrand> GetData()
        {
            var listCatagories = entity.Brands
                .Select(u => new MasterBrand
                {
                    BrandCode = u.BrandCode,
                    BrandDesc = u.BrandDesc,
                    DiscPerc = u.DiscPerc
                }
            ).ToList();
            return listCatagories;

        }

        [HttpPost]
        [Route("api/MasterBrand/SaveLookUpValue")]
        public IHttpActionResult SaveLookUpValue(MasterBrand data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            entity.Brands.Add(new Brand { BrandCode = data.BrandCode, BrandDesc = data.BrandDesc, DiscPerc = data.DiscPerc });
            entity.SaveChanges();

            return Ok(data);
        }

        [HttpPost]
        [Route("api/MasterBrand/DeleteLookUpValue")]
        public IHttpActionResult DeleteLookUpValue(MasterBrand data)
        {

            var record = entity.Brands.Where(x => x.BrandCode == data.BrandCode).First();
            if (record == null)
            {
                return NotFound();
            }

            entity.Brands.Remove(record);
            entity.SaveChanges();

            return Ok(record);
        }

        [HttpPost]
        [Route("api/MasterBrand/UpdateLookUpValue")]
        public IHttpActionResult UpdateLookUpValue(MasterBrand data)
        {
            if (data != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var record = entity.Brands.Where(x => x.BrandCode == data.BrandCode).First();
                record.BrandDesc = data.BrandDesc;
                record.DiscPerc = data.DiscPerc;               

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

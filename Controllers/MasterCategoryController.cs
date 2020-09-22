using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POS.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace POS.Controllers
{

    public class MasterCategoryController : ApiController
    {
        public RetailManagerDBEntities entity = new RetailManagerDBEntities();


        [HttpGet]
        [Route("api/MasterCategory/GetData")]
        public List<POS.Models.MasterCategory> GetData()
        {
            var listCatagories = entity.Categories
                .Select(u => new MasterCategory
                {
                    CatgCode = u.CatgCode,
                    CatgDesc = u.CatgDesc,
                    DeptCode = u.DeptCode,
                    DiscPer = u.DiscPer
                }
            ).ToList();
            return listCatagories;

        }

        [HttpPost]
        [Route("api/MasterCategory/SaveLookUpValue")]
        public IHttpActionResult SaveLookUpValue(MasterCategory data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            entity.Categories.Add(new Category { CatgCode = data.CatgCode, CatgDesc = data.CatgDesc, DeptCode = data.DeptCode, DiscPer = data.DiscPer });
            entity.SaveChanges();

            return Ok(data);
        }

        [HttpPost]
        [Route("api/MasterCategory/DeleteLookUpValue")]
        public IHttpActionResult DeleteLookUpValue(MasterCategory data)
        {

            var record = entity.Categories.Where(x => x.CatgCode == data.CatgCode).First();
            if (record == null)
            {
                return NotFound();
            }

            entity.Categories.Remove(record);
            entity.SaveChanges();

            return Ok(record);
        }

        [HttpPost]
        [Route("api/MasterCategory/UpdateLookUpValue")]
        public IHttpActionResult UpdateLookUpValue(MasterCategory data)
        {
            if (data != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var record = entity.Categories.Where(x => x.CatgCode == data.CatgCode).First();
                record.CatgDesc = data.CatgDesc;
                record.CatgCode = data.CatgCode;
                record.DeptCode = data.DeptCode;
                record.DiscPer = data.DiscPer;

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

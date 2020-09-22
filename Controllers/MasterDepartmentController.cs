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
    public class MasterDepartmentController : ApiController
    {

        public RetailManagerDBEntities entity = new RetailManagerDBEntities();

        [HttpGet]
        [Route("api/MasterDepartment/GetData")]
        public List<MasterDepartment> GetData()
        {
            var listCatagories = entity.Departments
                .Select(u => new MasterDepartment
                {
                    DeptCode = u.DeptCode,
                    DeptDesc = u.DeptDesc,
                    Comm = u.Comm,
                    DiscPerc = u.DiscPerc,
                    Threshold = u.Threshold
                }
            ).ToList();
            return listCatagories;

        }

        [HttpPost]
        [Route("api/MasterDepartment/SaveLookUpValue")]
        public IHttpActionResult SaveLookUpValue(MasterDepartment data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            entity.Departments.Add(new Department
            {
                DeptCode = data.DeptCode,
                DeptDesc = data.DeptDesc,
                Comm = data.Comm,
                DiscPerc = data.DiscPerc,
                Threshold = data.Threshold
            });
            entity.SaveChanges();

            return Ok(data);
        }

        [HttpPost]
        [Route("api/MasterDepartment/DeleteLookUpValue")]
        public IHttpActionResult DeleteLookUpValue(MasterDepartment data)
        {

            var record = entity.Departments.Where(x => x.DeptCode == data.DeptCode).First();
            if (record == null)
            {
                return NotFound();
            }

            entity.Departments.Remove(record);
            entity.SaveChanges();

            return Ok(record);
        }

        [HttpPost]
        [Route("api/MasterDepartment/UpdateLookUpValue")]
        public IHttpActionResult UpdateLookUpValue(MasterDepartment data)
        {
            if (data != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var record = entity.Departments.Where(x => x.DeptCode == data.DeptCode).First();
                record.DeptDesc = data.DeptDesc;
                record.Comm = data.Comm;
                record.DiscPerc = data.DiscPerc;
                record.Threshold = data.Threshold;

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

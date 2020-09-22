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
    public class MasterLocationController : ApiController
    {
        public RetailManagerDBEntities entity = new RetailManagerDBEntities();

        [HttpGet]
        [Route("api/MasterLocation/GetData")]
        public List<MasterLocation> GetData()
        {
            var listCatagories = entity.Locations
                .Select(u => new MasterLocation
                {
                    LocCode = u.LocCode,
                    Add1 = u.Add1,
                    Add2 = u.Add2,
                    Add3 = u.Add3,
                    ContactPerson = u.ContactPerson,
                    Franchisee = u.Franchisee,
                    LocName = u.LocName,
                    MarkUP = u.MarkUP,
                    OutsideState = u.OutsideState,
                    Phone = u.Phone,
                    SalesUpdate = u.SalesUpdate,
                    TinNo = u.TinNo,
                    WHCode = u.WHCode,
                    WHName = u.WHName,
                    Zip = u.Zip,
                    ZoneCode = u.ZoneCode
                }
            ).ToList();
            return listCatagories;

        }

        [HttpPost]
        [Route("api/MasterLocation/SaveLookUpValue")]
        public IHttpActionResult SaveLookUpValue(MasterLocation data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            entity.Locations.Add(new Location
            {
                LocCode = data.LocCode,
                Add1 = data.Add1,
                Add2 = data.Add2,
                Add3 = data.Add3,
                ContactPerson = data.ContactPerson,
                Franchisee = data.Franchisee,
                LocName = data.LocName,
                MarkUP = data.MarkUP,
                OutsideState = data.OutsideState,
                Phone = data.Phone,
                SalesUpdate = data.SalesUpdate,
                TinNo = data.TinNo,
                WHCode = data.WHCode,
                WHName = data.WHName,
                Zip = data.Zip,
                ZoneCode = data.ZoneCode
            });
            entity.SaveChanges();

            return Ok(data);
        }

        [HttpPost]
        [Route("api/MasterLocation/DeleteLookUpValue")]
        public IHttpActionResult DeleteLookUpValue(MasterLocation data)
        {

            var record = entity.Locations.Where(x => x.LocCode == data.LocCode).First();
            if (record == null)
            {
                return NotFound();
            }

            entity.Locations.Remove(record);
            entity.SaveChanges();

            return Ok(record);
        }

        [HttpPost]
        [Route("api/MasterLocation/UpdateLookUpValue")]
        public IHttpActionResult UpdateLookUpValue(MasterLocation data)
        {
            if (data != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var record = entity.Locations.Where(x => x.LocCode == data.LocCode).First();
                record.Add1 = data.Add1;
                record.Add2 = data.Add2;
                record.Add3 = data.Add3;
                record.ContactPerson = data.ContactPerson;
                record.Franchisee = data.Franchisee;
                record.LocName = data.LocName;
                record.MarkUP = data.MarkUP;
                record.OutsideState = data.OutsideState;
                record.Phone = data.Phone;
                record.SalesUpdate = data.SalesUpdate;
                record.TinNo = data.TinNo;
                record.WHCode = data.WHCode;
                record.WHName = data.WHName;
                record.Zip = data.Zip;
                record.ZoneCode = data.ZoneCode;

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

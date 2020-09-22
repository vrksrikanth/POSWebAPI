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
    public class MasterSupplierController : ApiController
    {
        public RetailManagerDBEntities entity = new RetailManagerDBEntities();

        [HttpGet]
        [Route("api/MasterSupplier/GetData")]
        public List<MasterSupplier> GetData()
        {
            var listCatagories = entity.Suppliers
                .Select(u => new MasterSupplier
                {
                    Area = u.Area,
                    CashCheque = u.CashCheque,
                    Contact = u.Contact,
                    Country = u.Country,
                    CreditDays = u.CreditDays,
                    CST = u.CST,
                    DiscPer = u.DiscPer,
                    DrugLic = u.DrugLic,
                    Email = u.Email,
                    Fax = u.Fax,
                    FGL = u.FGL,
                    GST = u.GST,
                    MfgCode = u.MfgCode,
                    Mobile = u.Mobile,
                    NonVatDealer = u.NonVatDealer,
                    OutsideState = u.OutsideState,
                    Phones = u.Phones,
                    State = u.State,
                    SuppCode = u.SuppCode,
                    SuppName = u.SuppName,
                    TaxPer = u.TaxPer,
                    TIN = u.TIN,
                    Town = u.Town,
                    URL = u.URL,
                    Zip = u.Zip
                }
            ).ToList();
            return listCatagories;

        }

        [HttpPost]
        [Route("api/MasterSupplier/SaveLookUpValue")]
        public IHttpActionResult SaveLookUpValue(MasterSupplier data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            entity.Suppliers.Add(new Supplier
            {
                Area = data.Area,
                CashCheque = data.CashCheque,
                Contact = data.Contact,
                Country = data.Country,
                CreditDays = data.CreditDays,
                CST = data.CST,
                DiscPer = data.DiscPer,
                DrugLic = data.DrugLic,
                Email = data.Email,
                Fax = data.Fax,
                FGL = data.FGL,
                GST = data.GST,
                MfgCode = data.MfgCode,
                Mobile = data.Mobile,
                NonVatDealer = data.NonVatDealer,
                OutsideState = data.OutsideState,
                Phones = data.Phones,
                State = data.State,
                SuppCode = data.SuppCode,
                SuppName = data.SuppName,
                TaxPer = data.TaxPer,
                TIN = data.TIN,
                Town = data.Town,
                URL = data.URL,
                Zip = data.Zip
            });
            entity.SaveChanges();

            return Ok(data);
        }

        [HttpPost]
        [Route("api/MasterSupplier/DeleteLookUpValue")]
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
        [Route("api/MasterSupplier/UpdateLookUpValue")]
        public IHttpActionResult UpdateLookUpValue(MasterSupplier data)
        {
            if (data != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var record = entity.Suppliers.Where(x => x.SuppCode == data.SuppCode).First();
                record.Area = data.Area;
                record.CashCheque = data.CashCheque;
                record.Contact = data.Contact;
                record.Country = data.Country;
                record.CreditDays = data.CreditDays;
                record.CST = data.CST;
                record.DiscPer = data.DiscPer;
                record.DrugLic = data.DrugLic;
                record.Email = data.Email;
                record.Fax = data.Fax;
                record.FGL = data.FGL;
                record.GST = data.GST;
                record.MfgCode = data.MfgCode;
                record.Mobile = data.Mobile;
                record.NonVatDealer = data.NonVatDealer;
                record.OutsideState = data.OutsideState;
                record.Phones = data.Phones;
                record.State = data.State;

                record.SuppName = data.SuppName;
                record.TaxPer = data.TaxPer;
                record.TIN = data.TIN;
                record.Town = data.Town;
                record.URL = data.URL;
                record.Zip = data.Zip;

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

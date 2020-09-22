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
    public class MasterVIPMasterController : ApiController
    {
        public RetailManagerDBEntities entity = new RetailManagerDBEntities();

        [HttpGet]
        [Route("api/MasterVIPMaster/GetData")]
        public List<MasterVIPMaster> GetData()
        {
            var listCatagories = entity.vipmasters
                .Select(u => new MasterVIPMaster
                {
                    Address1 = u.Address1,
                    Address2 = u.Address2,
                    Address3 = u.Address3,
                    Address4 = u.Address4,
                    AnniDate = u.AnniDate,
                    Child1 = u.Child1,
                    Child1Dob = u.Child1Dob,
                    Child2 = u.Child2,
                    Child2Dob = u.Child2Dob,
                    Child3 = u.Child3,
                    Child3Dob = u.Child3Dob,
                    Child4 = u.Child4,
                    Child4Dob = u.Child4Dob,
                    Child5 = u.Child5,
                    Child5Dob = u.Child5Dob,
                    City = u.City,
                    Corporate = u.Corporate,
                    Country = u.Country,
                    Credit = u.Credit,
                    CreditLimit = u.CreditLimit,
                    CustomerSince = u.CustomerSince,
                    CustType = u.CustType,
                    DateOfBirth = u.DateOfBirth,
                    DisPerc = u.DisPerc,
                    Email = u.Email,
                    ExpiryDate = u.ExpiryDate,
                    IcPassportNo = u.IcPassportNo,
                    LastPurchAmt = u.LastPurchAmt,
                    LastPurchDate = u.LastPurchDate,
                    LocCode = u.LocCode,
                    NoOfTrans = u.NoOfTrans,
                    Occupation = u.Occupation,
                    OSAmount = u.OSAmount,
                    PostCode = u.PostCode,
                    Race = u.Race,
                    Sex = u.Sex,
                    SpouseDob = u.SpouseDob,
                    SpouseName = u.SpouseName,
                    State = u.State,
                    TelephoneHome = u.TelephoneHome,
                    TelephoneOther = u.TelephoneOther,
                    TotDisc = u.TotDisc,
                    TotPointsAcc = u.TotPointsAcc,
                    TotPointsRedeem = u.TotPointsRedeem,
                    TotTax = u.TotTax,
                    TotValue = u.TotValue,
                    Vip = u.Vip,
                    VipCode = u.VipCode,
                    VipName = u.VipName,
                    VipSurName = u.VipSurName,
                    YTDNoOfPurch = u.YTDNoOfPurch,
                    YTDPurch = u.YTDPurch
                }
            ).ToList();
            return listCatagories;

        }

        [HttpPost]
        [Route("api/MasterVIPMaster/SaveLookUpValue")]
        public IHttpActionResult SaveLookUpValue(MasterVIPMaster data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            entity.vipmasters.Add(new vipmaster
            {
                Address1 = data.Address1,
                Address2 = data.Address2,
                Address3 = data.Address3,
                Address4 = data.Address4,
                AnniDate = data.AnniDate,
                Child1 = data.Child1,
                Child1Dob = data.Child1Dob,
                Child2 = data.Child2,
                Child2Dob = data.Child2Dob,
                Child3 = data.Child3,
                Child3Dob = data.Child3Dob,
                Child4 = data.Child4,
                Child4Dob = data.Child4Dob,
                Child5 = data.Child5,
                Child5Dob = data.Child5Dob,
                City = data.City,
                Corporate = data.Corporate,
                Country = data.Country,
                Credit = data.Credit,
                CreditLimit = data.CreditLimit,
                CustomerSince = data.CustomerSince,
                CustType = data.CustType,
                DateOfBirth = data.DateOfBirth,
                DisPerc = data.DisPerc,
                Email = data.Email,
                ExpiryDate = data.ExpiryDate,
                IcPassportNo = data.IcPassportNo,
                LastPurchAmt = data.LastPurchAmt,
                LastPurchDate = data.LastPurchDate,
                LocCode = data.LocCode,
                NoOfTrans = data.NoOfTrans,
                Occupation = data.Occupation,
                OSAmount = data.OSAmount,
                PostCode = data.PostCode,
                Race = data.Race,
                Sex = data.Sex,
                SpouseDob = data.SpouseDob,
                SpouseName = data.SpouseName,
                State = data.State,
                TelephoneHome = data.TelephoneHome,
                TelephoneOther = data.TelephoneOther,
                TotDisc = data.TotDisc,
                TotPointsAcc = data.TotPointsAcc,
                TotPointsRedeem = data.TotPointsRedeem,
                TotTax = data.TotTax,
                TotValue = data.TotValue,
                Vip = data.Vip,
                VipCode = data.VipCode,
                VipName = data.VipName,
                VipSurName = data.VipSurName,
                YTDNoOfPurch = data.YTDNoOfPurch,
                YTDPurch = data.YTDPurch
            });
            entity.SaveChanges();

            return Ok(data);
        }

        [HttpPost]
        [Route("api/MasterVIPMaster/DeleteLookUpValue")]
        public IHttpActionResult DeleteLookUpValue(MasterVIPMaster data)
        {

            var record = entity.vipmasters.Where(x => x.VipCode == data.VipCode).First();
            if (record == null)
            {
                return NotFound();
            }

            entity.vipmasters.Remove(record);
            entity.SaveChanges();

            return Ok(record);
        }

        [HttpPost]
        [Route("api/MasterVIPMaster/UpdateLookUpValue")]
        public IHttpActionResult UpdateLookUpValue(MasterVIPMaster data)
        {
            if (data != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var record = entity.vipmasters.Where(x => x.VipCode == data.VipCode).First();
                record.Address1 = data.Address1;
                record.Address2 = data.Address2;
                record.Address3 = data.Address3;
                record.Address4 = data.Address4;
                record.AnniDate = data.AnniDate;
                record.Child1 = data.Child1;
                record.Child1Dob = data.Child1Dob;
                record.Child2 = data.Child2;
                record.Child2Dob = data.Child2Dob;
                record.Child3 = data.Child3;
                record.Child3Dob = data.Child3Dob;
                record.Child4 = data.Child4;
                record.Child4Dob = data.Child4Dob;
                record.Child5 = data.Child5;
                record.Child5Dob = data.Child5Dob;
                record.City = data.City;
                record.Corporate = data.Corporate;
                record.Country = data.Country;
                record.Credit = data.Credit;
                record.CreditLimit = data.CreditLimit;
                record.CustomerSince = data.CustomerSince;
                record.CustType = data.CustType;
                record.DateOfBirth = data.DateOfBirth;
                record.DisPerc = data.DisPerc;
                record.Email = data.Email;
                record.ExpiryDate = data.ExpiryDate;
                record.IcPassportNo = data.IcPassportNo;
                record.LastPurchAmt = data.LastPurchAmt;
                record.LastPurchDate = data.LastPurchDate;
                record.LocCode = data.LocCode;
                record.NoOfTrans = data.NoOfTrans;
                record.Occupation = data.Occupation;
                record.OSAmount = data.OSAmount;
                record.PostCode = data.PostCode;
                record.Race = data.Race;
                record.Sex = data.Sex;
                record.SpouseDob = data.SpouseDob;
                record.SpouseName = data.SpouseName;
                record.State = data.State;
                record.TelephoneHome = data.TelephoneHome;
                record.TelephoneOther = data.TelephoneOther;
                record.TotDisc = data.TotDisc;
                record.TotPointsAcc = data.TotPointsAcc;
                record.TotPointsRedeem = data.TotPointsRedeem;
                record.TotTax = data.TotTax;
                record.TotValue = data.TotValue;
                record.Vip = data.Vip;

                record.VipName = data.VipName;
                record.VipSurName = data.VipSurName;
                record.YTDNoOfPurch = data.YTDNoOfPurch;
                record.YTDPurch = data.YTDPurch;

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

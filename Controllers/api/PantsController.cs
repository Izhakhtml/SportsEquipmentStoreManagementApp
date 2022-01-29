using SportsEquipmentStoreManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SportsEquipmentStoreManagementApp.Controllers.api
{
    public class PantsController : ApiController
    {
        // GET: api/Pants
        DataClassesDataContext dataContext = new DataClassesDataContext();
        public IHttpActionResult Get()
        {
            try
            {
                var pants = (from item in dataContext.Dressings
                             where item.TypeOfGarment == "pants"
                             select item).ToList();
                return Ok(new { pants });
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/Pants/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var pants = (from item in dataContext.Dressings
                             where item.TypeOfGarment == "pants"
                             select item).ToList();
                return Ok(new { byId = pants.First(item => item.Id == id) });
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // POST: api/Pants
        public IHttpActionResult Post([FromBody] Dressing newPants)
        {
            try 
            { 
                dataContext.Dressings.InsertOnSubmit(newPants);
                dataContext.SubmitChanges();
                return Ok("Added Successfully");
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // PUT: api/Pants/5
        public IHttpActionResult Put(int id, [FromBody] Dressing updatePants)
        {
            try
            {
                var pants = (from item in dataContext.Dressings
                             where item.TypeOfGarment == "pants"
                             select item).ToList();
                var GetById = pants.First(item => item.Id == id);
                GetById.TypeOfGarment = updatePants.TypeOfGarment;
                GetById.Gender = updatePants.Gender;
                GetById.Company = updatePants.Company;
                GetById.Model = updatePants.Model;
                GetById.Price = updatePants.Price;
                GetById.Amount = updatePants.Amount;
                GetById.IfIsShort = updatePants.IfIsShort;
                GetById.IfIsDrifit = updatePants.IfIsDrifit;
                GetById.LinkToImage = updatePants.LinkToImage;
                dataContext.SubmitChanges();
                return Ok("Updatesd successfully");
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // DELETE: api/Pants/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var pants = (from item in dataContext.Dressings
                             where item.TypeOfGarment == "pants"
                             select item).ToList();
                pants.First(item => item.Id == id);
                dataContext.SubmitChanges();
                return Ok("Dleted successfully");
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

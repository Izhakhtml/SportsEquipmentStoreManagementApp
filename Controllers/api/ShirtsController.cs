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
    public class ShirtsController : ApiController
    {
        // GET: api/Shirts
        DataClassesDataContext dataContext = new DataClassesDataContext();
        public IHttpActionResult Get()
        {
            try
            {
                var shirt = (from item in dataContext.Dressings
                             where item.TypeOfGarment == "shirt"
                             select item).ToList();
                return Ok(new { shirt });
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
        // GET: api/Shirts/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var shirt = (from item in dataContext.Dressings
                             where item.TypeOfGarment == "shirt"
                             select item).ToList();
                return Ok(new { byId = shirt.First(item => item.Id == id) });
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
        // POST: api/Shirts
        public IHttpActionResult Post([FromBody] Dressing newShirt)
        {
            try
            {
                dataContext.Dressings.InsertOnSubmit(newShirt);
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
        // PUT: api/Shirts/5
        public IHttpActionResult Put(int id, [FromBody] Dressing updateShirt)
        {
            try
            {
                var shirt = (from item in dataContext.Dressings
                             where item.TypeOfGarment == "shirt"
                             select item).ToList();
                var GetById = shirt.First(item => item.Id == id);
                GetById.TypeOfGarment = updateShirt.TypeOfGarment;
                GetById.Gender = updateShirt.Gender;
                GetById.Company = updateShirt.Company;
                GetById.Model = updateShirt.Model;
                GetById.Price = updateShirt.Price;
                GetById.Amount = updateShirt.Amount;
                GetById.IfIsShort = updateShirt.IfIsShort;
                GetById.IfIsDrifit = updateShirt.IfIsDrifit;
                GetById.LinkToImage = updateShirt.LinkToImage;
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
        // DELETE: api/Shirts/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var shirt = (from item in dataContext.Dressings
                             where item.TypeOfGarment == "shirt"
                             select item).ToList();
                shirt.First(item => item.Id == id);
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

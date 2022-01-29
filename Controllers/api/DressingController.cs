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
    public class DressingController : ApiController
    {
        DataClassesDataContext dataContext = new DataClassesDataContext();
        // GET: api/Dressing
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new { dataContext.Dressings });
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
        // GET: api/Dressing/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(new { byID = dataContext.Dressings.First(item => item.Id == id) });
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
        // POST: api/Dressing
        public IHttpActionResult Post([FromBody] Dressing newDressing)
        {
            try
            {
                dataContext.Dressings.InsertOnSubmit(newDressing);
                dataContext.SubmitChanges();
                return Ok("AddedSuccessfully");
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
        // PUT: api/Dressing/5
        public IHttpActionResult Put(int id, [FromBody] Dressing updateDressing)
        {
            try
            {
                var GetById = dataContext.Dressings.First(item => item.Id == id);
                GetById.TypeOfGarment = updateDressing.TypeOfGarment;
                GetById.Gender = updateDressing.Gender;
                GetById.Company = updateDressing.Company;
                GetById.Model = updateDressing.Model;
                GetById.Price = updateDressing.Price;
                GetById.Amount = updateDressing.Amount;
                GetById.IfIsShort = updateDressing.IfIsShort;
                GetById.IfIsDrifit = updateDressing.IfIsDrifit;
                GetById.LinkToImage = updateDressing.LinkToImage;
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
        // DELETE: api/Dressing/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var DeleteObject = dataContext.Dressings.First(item => item.Id == id);
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

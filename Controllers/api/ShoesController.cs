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
    public class ShoesController : ApiController
    {
        // GET: api/Shoes
        DataClassesDataContext dataContext = new DataClassesDataContext();
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new { dataContext.Shoes });
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

        // GET: api/Shoes/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(new { byId = dataContext.Shoes.First(item => item.Id == id) });
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
        // POST: api/Shoes
        public IHttpActionResult Post([FromBody] Shoe newShoes)
        {
            try
            {
                dataContext.Shoes.InsertOnSubmit(newShoes);
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
        // PUT: api/Shoes/5
        public IHttpActionResult Put(int id, [FromBody] Shoe updateShoes)
        {
            try
            {
                var GetById = dataContext.Shoes.First(item => item.Id == id);
                GetById.ShoeType = updateShoes.ShoeType;
                GetById.Company = updateShoes.Company;
                GetById.Model = updateShoes.Model;
                GetById.Price = updateShoes.Price;
                GetById.Amount = updateShoes.Amount;
                GetById.IfDiscount = updateShoes.IfDiscount;
                GetById.LinkImage = updateShoes.LinkImage;
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
        // DELETE: api/Shoes/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var DeleteObject = dataContext.Shoes.First(item => item.Id == id);
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

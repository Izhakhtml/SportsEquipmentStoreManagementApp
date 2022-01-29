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
    public class SportEController : ApiController
    {
        // GET: api/SportE
        DataClassesDataContext dataContext = new DataClassesDataContext();
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new {dataContext.SportsEquipments});
            }
            catch(SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/SportE/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(new { byId = dataContext.SportsEquipments.First(item => item.Id == id) });
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
        // POST: api/SportE
        public IHttpActionResult Post([FromBody] SportsEquipment newSportsEquipment)
        {
            try
            {
                dataContext.SportsEquipments.InsertOnSubmit(newSportsEquipment);
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
        // PUT: api/SportE/5
        public IHttpActionResult Put(int id, [FromBody] SportsEquipment updateSportsEquipment)
        {
            try
            {
                var GetById = dataContext.SportsEquipments.First(item => item.Id == id);
                GetById.SportType = updateSportsEquipment.SportType;
                GetById.ProductName = updateSportsEquipment.ProductName;
                GetById.Company = updateSportsEquipment.Company;
                GetById.Price = updateSportsEquipment.Price;
                GetById.Amount = updateSportsEquipment.Amount;
                GetById.LinkToImage = updateSportsEquipment.LinkToImage;
                GetById.TeamID = updateSportsEquipment.TeamID;
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
        // DELETE: api/SportE/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var DeleteObject = dataContext.SportsEquipments.First(item => item.Id == id);
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

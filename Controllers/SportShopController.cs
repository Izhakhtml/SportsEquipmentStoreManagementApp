using SportsEquipmentStoreManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsEquipmentStoreManagementApp.Controllers
{
    public class SportShopController : Controller
    {
        // GET: SportShop
        DataClassesDataContext dataContext = new DataClassesDataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Shoes()
        {
            try
            {
                return View(dataContext.Shoes.ToList());
            }
            catch (SqlException sql)
            {
                return View(sql.Message);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        public ActionResult ViewManager()
        {
            try
            {
                return View(dataContext.Shoes.ToList());
            }
            catch (SqlException sql)
            {
                return View(sql.Message);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        public ActionResult OnlyDiscount()
        {
            try
            {
                return View(dataContext.Shoes.ToList());
            }
            catch (SqlException sql)
            {
                return View(sql.Message);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        public ActionResult FilteringByFields()
        {
            try
            {
                return View(dataContext.Shoes.ToList());
            }
            catch (SqlException sql)
            {
                return View(sql.Message);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

    }
}
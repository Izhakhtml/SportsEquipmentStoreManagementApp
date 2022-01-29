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

                  /// SHOES \\\
        public ActionResult Shoes(string value)
        {
            try
            {
                var Shoes = (from item in dataContext.Shoes
                            select item).ToList();
                ViewBag.context = Shoes;

                switch (value)
                {
                    case "1":
                        return RedirectToAction("SortByPriceShoes", "SportShop");      // sort
                    case "2":
                        return RedirectToAction("SortByAmountShoes", "SportShop");     // sort
                    case "3":
                        return RedirectToAction("OnlyDiscountShoes", "SportShop");        // filter
                    case "4":
                        return RedirectToAction("WalkType", "SportShop");         // filter
                    case "5":
                        return RedirectToAction("RunningType", "SportShop");      // filter
                    default:
                        return View(Shoes);
                }
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
                var ShoesTable = (from item in dataContext.Shoes
                             select item).ToList();
                return View(ShoesTable);

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
        public ActionResult SortByPriceShoes() 
        {
            try 
            { 
            var price = (from item in dataContext.Shoes
                         orderby item.Price
                         select item).ToList();
            ViewBag.ByPrice = price;
            return View();            
            }
            catch(SqlException sql)
            {
                return View(sql.Message);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }


        }   // sort chellenge price
        public ActionResult SortByAmountShoes()
        {
            try
            {
            var price = (from item in dataContext.Shoes
                         orderby item.Amount
                         select item).ToList();
            ViewBag.ByAmount = price;
            return View();
            }
            catch (SqlException sql)
            {
                return View(sql.Message);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }


        }   // sort chellenge amount
        public ActionResult OnlyDiscountShoes()
        {
            try
            {
                var DiscountShoes = (from item in dataContext.Shoes
                             where item.IfDiscount == true
                             select item).ToList();
                return View(DiscountShoes);
            }
            catch (SqlException sql)
            {
                return View(sql.Message);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }   // filter chellenge
        public ActionResult RunningType()
        {
            try
            {
                    var RunningShoes = (from item in dataContext.Shoes
                                 where item.ShoeType == "running"
                                 select item).ToList();
                    ViewBag.list = RunningShoes;
                return View(ViewBag.list);
            }
            catch (SqlException sql)
            {
                return View(sql.Message);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }         // filter chellenge
        public ActionResult WalkType()
        {
            try
            {
                var WalkShoes = (from item in dataContext.Shoes
                                 where item.ShoeType == "walk"
                             select item).ToList();
                ViewBag.list = WalkShoes;
                return View(ViewBag.list);
            }
            catch (SqlException sql)
            {
                return View(sql.Message);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }            // filter chellenge

                    /// SHIRTS \\\
        public ActionResult Shirts(string value)
        {
            try
            {
                var shirt = (from item in dataContext.Dressings
                            where item.TypeOfGarment == "shirt"
                            select item).ToList();

                switch (value)
                {
                    case "1":
                        return RedirectToAction("SortByPriceShirts", "SportShop");      // sort
                    case "2":
                        return RedirectToAction("SortByAmountShirts", "SportShop");     // sort
                    case "3":
                        return RedirectToAction("OnlyLongShirts", "SportShop");        // filter
                    case "4":
                        return RedirectToAction("OnlyShortShirts", "SportShop");       // filter
                    case "5":
                        return RedirectToAction("OnlyDrifitShirts", "SportShop"); // filter
                    default:
                        return View(shirt);
                }

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
        public ActionResult ViewManagerShirt()
        {
            try
            {
                var shirtTable = (from item in dataContext.Dressings
                             where item.TypeOfGarment == "shirt"
                             select item).ToList();
                return View(shirtTable);
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
        public ActionResult OnlyLongShirts()
        {
            try
            {
                var LongShirts = (from item in dataContext.Dressings
                                 where item.TypeOfGarment == "shirt" && item.IfIsShort == false
                                 select item).ToList();
                return View(LongShirts);
            }
            catch (SqlException sql)
            {
                return View(sql.Message);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }      // filter chellenge
        public ActionResult OnlyShortShirts()
        {
            try
            {
                var ShortShirts = (from item in dataContext.Dressings
                                 where item.TypeOfGarment == "shirt" && item.IfIsShort == true
                                 select item).ToList();
                return View(ShortShirts);
            }
            catch (SqlException sql)
            {
                return View(sql.Message);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }     // filter chellenge
        public ActionResult OnlyDrifitShirts()
        {
            try
            {
                var DrifitShirts = (from item in dataContext.Dressings
                                  where item.TypeOfGarment == "shirt" && item.IfIsDrifit == true
                                  select item).ToList();
                return View(DrifitShirts);
            }
            catch (SqlException sql)
            {
                return View(sql.Message);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }    // filter chellenge
        public ActionResult SortByPriceShirts()
        {
            try
            {
                var SortPrices = (from item in dataContext.Dressings
                                  where item.TypeOfGarment == "shirt"
                                  orderby item.Price
                                  select item).ToList();
                return View(SortPrices);
            }
            catch (SqlException sql)
            {
                return View(sql.Message);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }   // sort chellenge price
        public ActionResult SortByAmountShirts()
        {
            try
            {
                var SortPrices = (from item in dataContext.Dressings
                                  where item.TypeOfGarment == "shirt"
                                  orderby item.Amount
                                  select item).ToList();
                return View(SortPrices);
            }
            catch (SqlException sql)
            {
                return View(sql.Message);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }  // sort chellenge amount

         
                    /// PANTS \\\
        public ActionResult Pants(string value)
        {
            try
            {
                var pants = from item in dataContext.Dressings.ToList()
                           where item.TypeOfGarment == "pants"
                           select item;
                switch (value)
                {
                    case "1":
                        return RedirectToAction("SortByPricePants", "SportShop");      // sort
                    case "2":
                        return RedirectToAction("SortByAmountPants", "SportShop");     // sort
                    case "3":
                        return RedirectToAction("OnlyShortPants", "SportShop");        // filter
                    case "4":
                        return RedirectToAction("OnlyLongPants", "SportShop");         // filter
                    case "5":
                        return RedirectToAction("OnlytDrifitPants", "SportShop");      // filter
                    default:
                        return View(pants);
                }
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
        public ActionResult ViewManagerPants()
        {
            try
            {
                var PantsTable = from item in dataContext.Dressings.ToList()
                           where item.TypeOfGarment == "pants"
                           select item;
                return View(PantsTable);
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
        public ActionResult OnlyShortPants()
        {
            try
            {
                var ShortPants = (from item in dataContext.Dressings
                           where item.TypeOfGarment == "pants" && item.IfIsShort == true
                           select item).ToList();
                return View(ShortPants);
            }
            catch (SqlException sql)
            {
                return View(sql.Message);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }     // filter chellenge
        public ActionResult OnlyLongPants()
        {
            try
            {
                var LongPants = (from item in dataContext.Dressings
                           where item.TypeOfGarment == "pants" && item.IfIsShort == false
                           select item).ToList();
                return View(LongPants);
            }
            catch (SqlException sql)
            {
                return View(sql.Message);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }      // filter chellenge
        public ActionResult OnlytDrifitPants()
        {
            try
            {
                var DrifitPants = (from item in dataContext.Dressings
                           where item.TypeOfGarment == "pants" && item.IfIsDrifit == true
                           select item).ToList();
                return View(DrifitPants);
            }
            catch (SqlException sql)
            {
                return View(sql.Message);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }   // filter chellenge
        public ActionResult SortByPricePants()
        {
            try
            {
                var SortPricePants = from item in dataContext.Dressings.ToList()
                           where item.TypeOfGarment == "pants"
                           orderby item.Price
                           select item;
                return View(SortPricePants);
            }
            catch (SqlException sql)
            {
                return View(sql.Message);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }   // sort chellenge price
        public ActionResult SortByAmountPants()
        {
            try
            {
                var SortPricePants = from item in dataContext.Dressings.ToList()
                                     where item.TypeOfGarment == "pants"
                                     orderby item.Amount
                                     select item;
                return View(SortPricePants);
            }
            catch (SqlException sql)
            {
                return View(sql.Message);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }  // sort chellenge amount


                 /// SPORT EQUIPMENT \\\
        public ActionResult SportEquipment(string value)
        {
            try
            {
                var SportEquipment = (from item in dataContext.SportsEquipments
                            select item).ToList();
                switch (value)
                {
                    case "1":
                        return RedirectToAction("SortByPriceShirts", "SportShop");      // sort
                    case "2":
                        return RedirectToAction("SortByAmountShirts", "SportShop");     // sort
                    case "3":
                        return RedirectToAction("OnlyFootball", "SportShop");        // filter
                    case "4":
                        return RedirectToAction("OnlyBasketball", "SportShop");       // filter
                    default:
                        return View(SportEquipment);
                }
                //if (value == "1")
                //{
                //    return RedirectToAction("SortByPriceSE", "SportShop");
                //}
                //else if (value == "2")
                //{
                //    return RedirectToAction("SortByAmountSE", "SportShop");
                //}
                //return View(SportEquipment);
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
        public ActionResult ViewManagerSE()
        {
            try
            {
                var SportEquipmentTable = (from item in dataContext.SportsEquipments
                                      select item).ToList();
                return View(SportEquipmentTable);
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
        public ActionResult OnlyFootball()
        {
            try
            {
                var OnlyFootball = (from item in dataContext.SportsEquipments
                                   where item.SportType == "Football"
                                   select item).ToList();
                return View(OnlyFootball);
            }
            catch (SqlException sql)
            {
                return View(sql.Message);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }      // filter chellenge
        public ActionResult OnlyBasketball()
        {
            try
            {
                var OnlyBasketball = (from item in dataContext.SportsEquipments
                                   where item.SportType == "Basketball"
                                   select item).ToList();
                return View(OnlyBasketball);
            }
            catch (SqlException sql)
            {
                return View(sql.Message);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }    // filter chellenge
        public ActionResult SortByPriceSE()
        {
            try
            {
                var Sort = (from item in dataContext.SportsEquipments
                                     orderby item.Price
                                     select item).ToList();
                return View(Sort);
            }
            catch (SqlException sql)
            {
                return View(sql.Message);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }     // sort chellenge price 
        public ActionResult SortByAmountSE()
        {
            try
            {
                var Sort = (from item in dataContext.SportsEquipments
                            orderby item.Amount
                            select item).ToList();
                return View(Sort);
            }
            catch (SqlException sql)
            {
                return View(sql.Message);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }    // sort chellenge amount


    }
}
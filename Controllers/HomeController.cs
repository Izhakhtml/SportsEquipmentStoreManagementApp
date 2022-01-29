using SportsEquipmentStoreManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsEquipmentStoreManagementApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult TestFun(Buttons buttonsModel)
        {
            int PersonId = buttonsModel.PersonId;
            string FirstName = buttonsModel.FirstName;
            int Age = buttonsModel.Age;
            string Gender = buttonsModel.Gender;
            return View();
        }
        public ActionResult Index3(string fname_name, string lname_name)
        {
            string fname = fname_name;
            string lname = lname_name;
            if (fname == "izhak" && lname == "lijalem")
            {
                Response.Write("Your Full name is= " + fname + " " + lname);
                Response.Write("lkljk");
                return View("Contact");
            }
            else
            {
                Response.Write("try again");
                return View();
             }
     //public ActionResult TestFun2(string buttonsModel)
    //{
    //    //int PersonId = buttonsModel.PersonId;
    //    //string FirstName = buttonsModel.FirstName;
    //    //int Age = buttonsModel.Age;
    //    string str = buttonsModel;
    //    return View();
}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team5Project.Models;

namespace Team5Project.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Customer()
        {
            Customer_Profile c = new Customer_Profile();
            return View();

        }
        public ActionResult AddCustomer(Customer_Profile c)
        {

            c.Status = "Pending";
            ViewBag.msg = DBOperations.InsertCustomer(c);


            return View("Customer");




        }
        public ActionResult BranchAdmin()
        {
            Branch_Admin b = new Branch_Admin();
            return View();
        }
        public ActionResult AddBranchAdmin(Branch_Admin b)
        {

            b.Status = "Pending";
            ViewBag.msg = DBOperations.InsertBranchAdmin(b);
            return View("BranchAdmin");
        }
        public ActionResult VehicleSearch()
        {
            return View();
        }



    }
}

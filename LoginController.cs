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
        List<Branch_Admin> blist = null;
        List<Customer_Profile> clist = null;
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult AdminLogin(string username,string password)
        {
            User_Registration l = DBOperations.CheckRegistration(username, password);
            if (l != null)
            {
                Session["username"] = l.Username;
                if (l.Role_Type == "admin" && l.Status == "Approved")
                {
                    return RedirectToAction("SuccessfulAdmin");
                }
                else if(l.Role_Type=="Customer" && l.Status=="Approved")
                {
                    return RedirectToAction("SuccessfulCustomer");
                }
                else if(l.Role_Type=="ba" && l.Status=="Approved")
                {
                    return RedirectToAction("SuccessfulBA");
                }
                else
                {
                    return View("WrongLogin");
                }
               
            }
            else
            {
                return View("WrongLogin");
            }

        }
        public ActionResult SuccessfulAdmin()
        {
            clist = DBOperations.GetAll();
            ViewBag.clist = clist;

            blist = DBOperations.GetallB();
            ViewBag.blist = blist;
            return View();

        }
        
        public ActionResult WrongLogin()
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
        public ActionResult SuccessfulCustomer()
        {

            return View();

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

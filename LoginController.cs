using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team5Project.Models;
using static Team5Project.Models.DBOperations;

namespace Team5Project.Controllers
{
    
    public class LoginController : Controller
    {
        // GET: Login
        List<Branch_Admin> blist = null;
        List<Customer_Profile> clist = null;
        static List<VehicleSearch> vd = null;
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult AdminLogin(string username, string password)
        {
            User_Registration l = DBOperations.CheckRegistration(username, password);
            if (l != null)
            {
                Session["username"] = l.Username;
                if (l.Role_Type == "admin" && l.Status == "Approved")
                {
                    return RedirectToAction("SuccessfulAdmin");
                }
                else if (l.Role_Type == "Customer" && l.Status == "Approved")
                {
                    return RedirectToAction("SuccessfulCustomer");
                }
                else if (l.Role_Type == "ba" && l.Status == "Approved")
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
        public ActionResult SuccessfulAdminInsert()
        {
            var cid = Request.Form.Get("chckbox");
            var bid = Request.Form.Get("chckbox1");
            //var status= Request.Form.GetValues("Status");
            List<User_Registration> ulist = new List<User_Registration>();
            User_Registration U = null;
            clist = DBOperations.GetAll();
            blist = DBOperations.GetallB();
                foreach (var c in clist)
                {
                    if (cid.Contains(c.Customer_id.ToString()))
                    {
                        U = new User_Registration();
                        U.Username = c.Customer_id;
                        U.Password = c.Password;
                        U.Role_Type = c.Role_Type;
                        U.Status = "Approved";
                         U.Create_date = DateTime.Today;
                        ulist.Add(U);
                    }
                }
               
            foreach (var b in blist)
            {
                if (bid.Contains(b.Branch_id.ToString()))
                {
                    U = new User_Registration();
                    U.Username = b.Branch_id;
                    U.Password = b.Password;
                    U.Status = "Approved";
                    U.Role_Type = b.Role_Type;
                    U.Create_date = DateTime.Today;
                    ulist.Add(U);
                }
            }
            string mesg = DBOperations.UserRegistration(ulist);
            ViewBag.message = mesg;
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
            vd = DBOperations.VW_Search();
            ViewBag.l = vd;
            return View();
        }
        public ActionResult GetPriceRange()
        {
            vd = DBOperations.VW_Search();
            ViewBag.l = vd;
            if (Request.Form["Manufactures_name"].ToString().Length != 0)
            {
                string mname = Request.Form["Manufactures_name"];
                ViewBag.L = DBOperations.VW_Searchname(mname);
            }
            if (Request.Form["Vehicle_Code"].ToString().Length != 0)
            {
                string vcode = Request.Form["Vehicle_Code"];
                ViewBag.L = DBOperations.VW_Searchvcode(vcode);
            }
            if (Request.Form["Branch_Location"].ToString().Length != 0)
            {
                string bl = Request.Form["Branch_Location"];
                ViewBag.L = DBOperations.VW_Searchloc(bl);
            }
            int num1 = 0, num2 = 0;
            if (int.TryParse(Request.Form["MinPrice"], out num1) && int.TryParse(Request.Form["MaxPrice"], out num2))
            {
                int min = int.Parse(Request.Form["MinPrice"]);
                int max = int.Parse(Request.Form["MaxPrice"]);
                ViewBag.L = DBOperations.Search(min, max);
            }
            if (Request.Form["Color"].ToString().Length != 0)
            {
                string color = Request.Form["Color"];
                ViewBag.L = DBOperations.VW_Searchcolor(color);
            }
            int num = 0;
            if (int.TryParse(Request.Form["Seating_Capacity"], out num))
            {
                int sc = int.Parse(Request.Form["Seating_Capacity"]);
                ViewBag.L = DBOperations.Searchsc(sc);
            }
           ViewBag.msg = "Contact System Administrator for further assistance";   
            return View();
        }
        public ActionResult VehicleBooking(string[] chk)
        {          
            return View(DBOperations.getvehiclelist(chk));
        }



    }
}

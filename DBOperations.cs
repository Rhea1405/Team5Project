using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team5Project.Models
{
    public class DBOperations
    {


        static OnlineVehicleBookingEntities1 v = new OnlineVehicleBookingEntities1();

        public static string InsertCustomer(Customer_Profile c)
        {

            v.Customer_Profile.Add(c);
            v.SaveChanges();

            return "Thank you for registering with us!You can login after your approval.";
        }
        public static string InsertBranchAdmin(Branch_Admin b)
        {
            v.Branch_Admin.Add(b);
            v.SaveChanges();

            return "Thank you for registering with us!You can login after your approval.";
        }
    }
}
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
        public static User_Registration CheckRegistration(string username,string password)
        {
            
            User_Registration u = new User_Registration();
            var l = from v in v.User_Registration
                    where v.Username == username && v.Password == password
                    select v;

            return l.First();

        }
        public static List<Customer_Profile> GetAll()
        {
            var c = from cl in v.Customer_Profile
                    select cl;

            return c.ToList();

        }
        public static List<Branch_Admin> GetallB()
        {

            var b = from bl in v.Branch_Admin
                    select bl;

            return b.ToList();
        }
    }
}
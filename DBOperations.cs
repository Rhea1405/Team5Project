using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team5Project.Models
{
    
    public class DBOperations
    {


        static Team5ProjectEntities v = new Team5ProjectEntities();

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
        public static User_Registration CheckRegistration(string username, string password)
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
        public static string UserRegistration(List<User_Registration> U)
        {
            if (U != null)
            {
                foreach (var row in U)
                {
                    if (row.Status != "Rejected" && row.Status != "Pending")
                        v.User_Registration.Add(row);
                }
                v.SaveChanges();
                return "Submitted Successfully";
            }
            else
                return "Unsucessful";

        }
         public static List<VehicleSearch> Search(int min, int max)
        {
            var list = from l in v.VehicleSearches
                       where l.PriceRange >= min && l.PriceRange <= max
                       select l;
            return list.ToList();
        }
        public static List<VehicleSearch> Searchsc(int scapacity)
        {
            var list = from l in v.VehicleSearches
                       where l.Seating_Capacity == scapacity 
                       select l;
            return list.ToList();
        }
        public static List<VehicleSearch> VW_Search()
        {
            var list = from l in v.VehicleSearches
                       select l;
            return list.ToList();
        }
        public static List<VehicleSearch> VW_Searchloc(string loc)
        {
            var list = from l in v.VehicleSearches
                       where l.Branch_Location == loc
                       select l;
            return list.ToList();
        }
        public static List<VehicleSearch> VW_Searchname(string name)
        {
            var list = from l in v.VehicleSearches
                       where l.Manufactures_name == name 
                       select l;
            return list.ToList();
        }
        public static List<VehicleSearch> VW_Searchcolor(string col)
        {
            var list = from l in v.VehicleSearches
                       where l.Color == col 
                       select l;
            return list.ToList();
        }
        public static List<VehicleSearch> VW_Searchvcode(string vcode)
        {
            var list = from l in v.VehicleSearches
                       where l.Vehicle_Code == vcode
                       select l;
            return list.ToList();
        }
        public static List<VehicleSearch> getvehiclelist(string[] id)
        {
            var e = from l in v.VehicleSearches
                    where id.Contains(l.Vehicle_Code) == true
                    select l;
            return e.ToList();
        }
    }
}

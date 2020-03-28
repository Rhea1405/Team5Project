using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team5Project.Models
{
    public class ViewModel
    {
        public IEnumerable<Customer_Profile> CustomerProfile { get; set; }
        public IEnumerable<Branch_Admin> BranchAdmin { get; set; }
    }
}
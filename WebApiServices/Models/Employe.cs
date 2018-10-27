using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class Employe
    {
        public int EmployeID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Street { get; set; }

        public string NumberApp { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string CodePostal { get; set; }

        public string TypeEmp { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Statut { get; set; }
    }

}
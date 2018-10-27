using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiServices.Dao;
using WebApiServices.Models;
using static WebApiServices.WebApiConfig;

namespace WebApiServices.Controllers
{
    public class EmployeController : ApiController
    {
        //Etablir la connexion
        static SqlConnection myConnection = BDConnection.GetSqlConnection();
        List<Employe> listeEmployes = new List<Employe>();

        // GET:   
        [HttpGet]
        public Employe VerifierLogin([FromUri]string email, string password)
        {
            return EmployeDAO.VerifierLogin(email, password, myConnection);
        }

        // GET:   
        [HttpGet]
        public IEnumerable<Employe> GetAllEmployes()
        {
            listeEmployes = EmployeDAO.List(myConnection);
            return listeEmployes;
        }

        // GET:   
        [HttpGet]
        public Employe GetEmploye(string email)
        {
            listeEmployes = EmployeDAO.List(myConnection);
            var empSearch = listeEmployes.Where(e => e.Email == email).FirstOrDefault(); ;
            return empSearch;
        }

        [HttpPost]
        public bool InsertEmploye([FromBody]Employe employe)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                if (EmployeDAO.InsertEmploye(employe, myConnection) > 0)
                    status = true;
            }
            return status;
        }

        [HttpPut]
        public bool UpdateEmploye([FromBody]Employe employe)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                if(EmployeDAO.UpdateEmploye(employe, myConnection) > 0)
                    status = true;
            }
            return status;
        }

        [HttpPut]
        public bool Activeremploye([FromBody]Employe employe)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                if (EmployeDAO.Activeremploye(employe, myConnection) > 0)
                    status = true;
            }
            return status;
        }
        

        [HttpDelete]
        public bool DeleteEmploye([FromBody]Employe employe)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                if (EmployeDAO.DeleteEmploye(employe, myConnection) > 0)
                    status = true;
            }
            return status;
        }


    }
}

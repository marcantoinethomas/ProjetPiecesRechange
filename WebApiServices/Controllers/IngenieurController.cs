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
    public class IngenieurController : ApiController
    {
        static SqlConnection myConnection = BDConnection.GetSqlConnection();

        [HttpPost]
        public bool AddParts([FromBody]Piece piece)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                if (IngenieurDAO.AddPart(piece, myConnection) > 0)
                    status = true;
            }
            return status;
        }

        [HttpPost]
        public bool AddMachine([FromBody]Machine machine)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                if (IngenieurDAO.AddMachine(machine, myConnection) > 0)
                    status = true;
            }
            return status;
        }

        [HttpPost]
        public bool CreateDemande([FromBody]Demande demande)
        {

            bool status = false;
            if (ModelState.IsValid)
            {
                if (IngenieurDAO.AddDemande(demande, myConnection) > 0)
                    status = true;
            }
            return status;
        }

    }
}

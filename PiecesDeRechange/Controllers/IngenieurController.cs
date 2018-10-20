using PiecesDeRechange.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PiecesDeRechange.Startup;

namespace PiecesDeRechange.Controllers
{

    public class IngenieurController : Controller
    {

        static SqlConnection myConnection = BDConnection.GetSqlConnection();

        public ActionResult Index()
        {
            return Redirect("/Home/Index");
        }
        // GET: Ingenieur
        public ActionResult AddParts()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddParts(FormCollection collection)
        {
            IngenieurDAO.AddPart(collection);

            ViewBag.Message = "Added";

            return View();
        }


        public ActionResult AddMachine() {
           
            //add here viewbac with list of category and list of parts 
            return View();

        }
        [HttpPost]
        public ActionResult AddMachine(FormCollection collection)
        {
            return View();
        }

        //CreateDemande

        public ActionResult CreateDemande()
        {

            return View();

        }
        [HttpPost]
        public ActionResult CreateDemande(FormCollection collection)
        {
            return View();
        }




    }
}

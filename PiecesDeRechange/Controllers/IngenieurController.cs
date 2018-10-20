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
            IngenieurDAO.AddPart(collection, myConnection);

            ViewBag.Message = "Part Added";

            return View();
        }


        public ActionResult AddMachine() {
         
            return View();

        }
        [HttpPost]
        public ActionResult AddMachine(FormCollection collection)
        {

            IngenieurDAO.AddMachine(collection, myConnection);

            ViewBag.Message = "Machine Added";
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

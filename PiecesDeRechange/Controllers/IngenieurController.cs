using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiecesDeRechange.Controllers
{
    public class IngenieurController : Controller
    {
        // GET: Ingenieur
        public ActionResult AddParts()
        {
            return View();
        }
        public ActionResult Index()
        {
            return Redirect("/Home/Index");
        }
        public ActionResult AddMachine() {

            return View();

        }




    }
}

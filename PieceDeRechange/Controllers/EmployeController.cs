using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using PieceDeRechange.Dao;
using PieceDeRechange.Models;
using PieceDeRechange.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static PieceDeRechange.App_Start.AuthConfig;

namespace PieceDeRechange.Controllers
{
    [Authorize]
    public class EmployeController : Controller
    {
        //Etablir la connexion
        static SqlConnection myConnection = BDConnection.GetSqlConnection();
        //Entite Service HTTP
        static ServiceRepository serviceObj = new ServiceRepository();

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            Employe employe = new Employe();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (!ValidateUser(model, employe))
            {
                ModelState.AddModelError(string.Empty, "Le nom d'utilisateur ou le mot de passe est incorrect.");
                return View(model);
            }
            // L'authentification est réussie, 
            // injecter l'identifiant utilisateur dans le cookie d'authentification :
            var emailClaim = new Claim(ClaimTypes.NameIdentifier, model.Email);
            var claimsIdentity = new ClaimsIdentity(new[] { emailClaim }, DefaultAuthenticationTypes.ApplicationCookie);
            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignIn(claimsIdentity);

            // Rediriger vers l'URL d'origine :
            if (Url.IsLocalUrl(ViewBag.ReturnUrl))
                return Redirect(ViewBag.ReturnUrl);
            // Par défaut, rediriger vers la page d'accueil :
            return RedirectToAction("Index", "Home");   
        }

        private bool ValidateUser(Login model, Employe employe)
        {
            //Sending request to find web api REST service resource GetAllEmployees using HttpClient
            HttpResponseMessage Res = serviceObj.GetResponse("api/employe/VerifierLogin?email=" + model.Email + "&password=" + model.Password);
            //Checking the response is successful or not which is sent using HttpClient  
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Employee list  
                employe = JsonConvert.DeserializeObject<Employe>(EmpResponse);
            }

            if (!employe.Email.Equals("none"))
            {
                //Ajout dans la Session de l'utilisateur
                Session["Id"] = employe.EmployeID;
                Session["Name"] = employe.FirstName + " " + employe.LastName;
                Session["Groupe"] = employe.TypeEmp;
            }

            return !employe.Email.Equals("none") ? true : false;
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Employe employe)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = serviceObj.PostResponse("api/employe/insertemploye", employe);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index", "Home");
            }

            // Si nous sommes arrivés là, un échec s’est produit. Réafficher le formulaire
            return View(employe);
        }


        public ActionResult Index()
        {
            //Sending request to find web api REST service resource GetAllEmployees using HttpClient
            HttpResponseMessage Res = serviceObj.GetResponse("api/employe/getallemployes");

            //Checking the response is successful or not which is sent using HttpClient  
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  
                List<Employe> EmpList = JsonConvert.DeserializeObject<List<Employe>>(EmpResponse);
                var EmpInfos = EmpList.Where(e => e.Statut.Equals("EN ATTENTE")).ToList() ;
                //returning the employee list to view  
                return View(EmpInfos);
            }
            return View();
        }


        //GET
        //GET: /Admin/Edit
        [HttpGet]
        public ActionResult ActiverEmploye(int id)
        {
            //Sending request to find web api REST service resource GetAllEmployees using HttpClient
            HttpResponseMessage Res = serviceObj.GetResponse("api/employe/getEmploye/"+id);
            //Checking the response is successful or not which is sent using HttpClient  
            if (Res.IsSuccessStatusCode)
            {
                ViewBag.TypeEmp = serviceObj.ListeType;
                ViewBag.Statut = serviceObj.ListeStatut;
                //Storing the response details recieved from web api
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Employee list  
                Employe EmpEdit = JsonConvert.DeserializeObject<Employe>(EmpResponse);

                return View(EmpEdit);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActiverEmploye(Employe employe)
        {
            HttpResponseMessage response = serviceObj.PutResponse("api/employe/activeremploye", employe);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        //GET
        //GET: /Employe/UpdateEmploye
        [HttpGet]
        public ActionResult UpdateEmploye(int id)
        {
            //Sending request to find web api REST service resource GetAllEmployees using HttpClient
            HttpResponseMessage Res = serviceObj.GetResponse("api/employe/getEmploye/" + id);
            //Checking the response is successful or not which is sent using HttpClient  
            if (Res.IsSuccessStatusCode)
            {
                ViewBag.TypeEmp = serviceObj.ListeType;
                ViewBag.Statut = serviceObj.ListeStatut;
                //Storing the response details recieved from web api
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Employee list  
                Employe EmpEdit = JsonConvert.DeserializeObject<Employe>(EmpResponse);

                return View(EmpEdit);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateEmploye(Employe employe)
        {
            HttpResponseMessage response = serviceObj.PutResponse("api/employe/updateemploye", employe);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index", "Home");
        }

        //GET
        //GET: /Admin/Edit
        [HttpGet]
        public ActionResult Details(int id)
        {
            //Sending request to find web api REST service resource GetAllEmployees using HttpClient
            HttpResponseMessage Res = serviceObj.GetResponse("api/employe/getEmploye/" + id);
            //Checking the response is successful or not which is sent using HttpClient  
            if (Res.IsSuccessStatusCode)
            {
                ViewBag.TypeEmp = serviceObj.ListeType;
                ViewBag.Statut = serviceObj.ListeStatut;
                //Storing the response details recieved from web api
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Employee list  
                Employe EmpEdit = JsonConvert.DeserializeObject<Employe>(EmpResponse);

                return View(EmpEdit);
            }
            return View();
        }



        [HttpPost]
        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignOut();

            // Rediriger vers la page d'accueil :
            return RedirectToAction("Index", "Home");
        }

    }
}
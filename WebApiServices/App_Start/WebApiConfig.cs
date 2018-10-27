using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;

namespace WebApiServices
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{acion}/{email}/{password}",
                defaults: new { email = RouteParameter.Optional, password = RouteParameter.Optional }
            );
        }
    
        public static class BDConnection
        {
            private static SqlConnection myConnection;
            public static SqlConnection GetSqlConnection()
            {
                if (myConnection != null)
                {
                    return myConnection;
                }
                else
                {
                    myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                    return myConnection;
                }

            }
        }
    }
}

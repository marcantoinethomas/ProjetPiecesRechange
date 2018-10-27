using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Configuration;
using System.Data.SqlClient;

[assembly: OwinStartup(typeof(PieceDeRechange.App_Start.AuthConfig))]
namespace PieceDeRechange.App_Start
{
    public class AuthConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Employe/Login")
            });
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
using PieceDeRechange.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PieceDeRechange.Dao
{
    public class LoginDAO
    {
        public static Employe Login(Login model, SqlConnection myConnection)
        {
            Employe employe = new Employe();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "VerifierLogin";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = myConnection;
                cmd.Parameters.Add(new SqlParameter("@Email", model.Email));
                cmd.Parameters.Add(new SqlParameter("@Password", model.Password));
                myConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    employe.EmployeID = Int32.Parse(reader["EmployeID"].ToString());
                    employe.LastName = reader["LastName"].ToString();
                    employe.FirstName = reader["FirstName"].ToString();
                    employe.Street = reader["Street"].ToString();
                    employe.NumberApp = reader["NumberApp"].ToString();
                    employe.City = reader["City"].ToString();
                    employe.Province = reader["Province"].ToString();
                    employe.CodePostal = reader["CodePostal"].ToString();
                    employe.TypeEmp = reader["TypeEmp"].ToString();
                    employe.Email = reader["Email"].ToString();
                    employe.Password = reader["Password"].ToString();
                    employe.Statut = reader["Statut"].ToString();
                }
                else
                {
                    employe.Email = "none";
                }
            }
            catch (SqlException)
            {

            }
            finally
            {
                myConnection.Close();
            }

            return employe;
        }
    }
}
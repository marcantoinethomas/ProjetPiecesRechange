using PiecesDeRechange.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PiecesDeRechange.DAO
{
    public class EmployeDAO
    {
        public static List<Employe> List(SqlConnection myConnection)
        {
            List<Employe> myList = new List<Employe>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "GetListeEmployes";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = myConnection;
                myConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employe employe = new Employe();
                    employe.ID = Int32.Parse(reader["employeID"].ToString());
                    employe.LastName = reader["nomEmp"].ToString();
                    employe.FirstName = reader["prenomEmp"].ToString();
                    employe.Street =reader["rue"].ToString();
                    employe.NumberApp = reader["noApp"].ToString();
                    employe.City = reader["ville"].ToString();
                    employe.Province = reader["province"].ToString();
                    employe.CodePostal = reader["codePostal"].ToString();
                    employe.TypeEmp = Int32.Parse(reader["typeEmpID"].ToString());
                    employe.DescripType = reader["descripType"].ToString();
                    employe.Email = reader["courriel"].ToString();
                    employe.Password = reader["motDePasse"].ToString();
                    employe.Statut = reader["statut"].ToString();
                    employe.DescripStatut = reader["descripStatut"].ToString();
                    myList.Add(employe);
                }
            }
            catch (SqlException)
            {

            }
            finally
            {
                myConnection.Close();
            }
            return myList;
        }
        public static int Create(RegisterViewModel model, SqlConnection myConnection)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "CreerEmploye";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = myConnection;
                cmd.Parameters.Add(new SqlParameter("@nomEmp", model.LastName));
                cmd.Parameters.Add(new SqlParameter("@prenomEmp", model.FirstName));
                cmd.Parameters.Add(new SqlParameter("@rue", model.Street));
                cmd.Parameters.Add(new SqlParameter("@noApp", model.NoApp));
                cmd.Parameters.Add(new SqlParameter("@ville", model.City));
                cmd.Parameters.Add(new SqlParameter("@province", model.Province));
                cmd.Parameters.Add(new SqlParameter("@codePostal", model.CodePostal));
                cmd.Parameters.Add(new SqlParameter("@courriel", model.Email));
                cmd.Parameters.Add(new SqlParameter("@motDePasse", model.Password));
                myConnection.Open();
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (SqlException)
            {

            }
            finally
            {
                myConnection.Close();
            }

            return result;
        }

    }
}
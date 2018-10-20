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

    }
}
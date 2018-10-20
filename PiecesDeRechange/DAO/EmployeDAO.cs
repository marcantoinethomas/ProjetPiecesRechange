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
                cmd.CommandText = "GetListeFrais";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = myConnection;
                myConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employe employe = new Employe();
                    employe.ID = Int32.Parse(reader["employeID"].ToString());
                    employe.Nom = reader["nomEmp"].ToString();
                    employe.Prenom = reader["prenomEmp"].ToString();
                    employe.Rue =reader["rue"].ToString();
                    employe.NoApp = reader["noApp"].ToString();
                    employe.Ville = reader["ville"].ToString();
                    employe.Province = reader["province"].ToString();
                    employe.CodePostal = reader["codePostal"].ToString();
                    employe.Type = reader["typeEmp"].ToString();
                    employe.Courriel = reader["courriel"].ToString();
                    employe.Statut = reader["statut"].ToString();
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
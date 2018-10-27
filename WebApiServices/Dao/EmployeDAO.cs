using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiServices.Models;

namespace WebApiServices.Dao
{
    public class EmployeDAO
    {

        public static int InsertEmploye(Employe model, SqlConnection myConnection)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "CreerEmploye";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = myConnection;
                cmd.Parameters.Add(new SqlParameter("@LastName", model.LastName));
                cmd.Parameters.Add(new SqlParameter("@FirstName", model.FirstName));
                cmd.Parameters.Add(new SqlParameter("@Street", model.Street));
                cmd.Parameters.Add(new SqlParameter("@NumberApp", model.NumberApp));
                cmd.Parameters.Add(new SqlParameter("@City", model.City));
                cmd.Parameters.Add(new SqlParameter("@Province", model.Province));
                cmd.Parameters.Add(new SqlParameter("@CodePostal", model.CodePostal));
                cmd.Parameters.Add(new SqlParameter("@Email", model.Email));
                cmd.Parameters.Add(new SqlParameter("@Password", model.Password));
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


        public static int UpdateEmploye(Employe model, SqlConnection myConnection)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UpdateEmploye";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = myConnection;
                cmd.Parameters.Add(new SqlParameter("@LastName", model.LastName));
                cmd.Parameters.Add(new SqlParameter("@FirstName", model.FirstName));
                cmd.Parameters.Add(new SqlParameter("@Street", model.Street));
                cmd.Parameters.Add(new SqlParameter("@NumberApp", model.NumberApp));
                cmd.Parameters.Add(new SqlParameter("@City", model.City));
                cmd.Parameters.Add(new SqlParameter("@Province", model.Province));
                cmd.Parameters.Add(new SqlParameter("@CodePostal", model.CodePostal));
                cmd.Parameters.Add(new SqlParameter("@Email", model.Email));
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

        public static int DeleteEmploye(Employe model, SqlConnection myConnection)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DeleteEmploye";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = myConnection;
                cmd.Parameters.Add(new SqlParameter("@Email", model.Email));
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

        public static int Activeremploye(Employe model, SqlConnection myConnection)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Activeremploye";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = myConnection;
                cmd.Parameters.Add(new SqlParameter("@Email", model.Email));
                cmd.Parameters.Add(new SqlParameter("@Statut", model.Statut));
                cmd.Parameters.Add(new SqlParameter("@TypeEmp", model.TypeEmp));
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

        public static Employe VerifierLogin(string email, string pwd, SqlConnection myConnection)
        {
            Employe employe = new Employe();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "VerifierLogin";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = myConnection;
                cmd.Parameters.Add(new SqlParameter("@Email", email));
                cmd.Parameters.Add(new SqlParameter("@Password", pwd));
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
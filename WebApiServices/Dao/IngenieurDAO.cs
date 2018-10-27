using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiServices.Models;

namespace WebApiServices.Dao
{
    public class IngenieurDAO
    {


        public static int AddPart(Piece piece, SqlConnection myConnection)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "InsertPart";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = myConnection;
                cmd.Parameters.Add(new SqlParameter("@NamePart", piece.NamePart));
                cmd.Parameters.Add(new SqlParameter("@PricePart", piece.PricePart));
                cmd.Parameters.Add(new SqlParameter("@Photo", piece.Photo));

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
            return result; ;
        }

        public static int AddMachine(Machine machine, SqlConnection myConnection)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "InsertMachine";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = myConnection;
                cmd.Parameters.Add(new SqlParameter("@param1", machine.MachineName));
                cmd.Parameters.Add(new SqlParameter("@param2", machine.Categorie));

      
                myConnection.Open();

                result = cmd.ExecuteNonQuery();

            }
            catch (SqlException s)
            {
            }
            finally
            {
                myConnection.Close();
            }
            return result;
        }

        public static int AddDemande(Demande demande, SqlConnection myConnection)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "InsertDemande";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = myConnection;
                cmd.Parameters.Add(new SqlParameter("@param1", demande.EmployeeId));
                cmd.Parameters.Add(new SqlParameter("@param2", demande.PartId));
                cmd.Parameters.Add(new SqlParameter("@param3", demande.MachineId));
                cmd.Parameters.Add(new SqlParameter("@param4", demande.QtyPiece));
                cmd.Parameters.Add(new SqlParameter("@param5", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@param6", "New"));

                myConnection.Open();

                result = cmd.ExecuteNonQuery();

            }
            catch (SqlException s)
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
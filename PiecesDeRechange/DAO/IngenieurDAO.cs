using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiecesDeRechange.DAO
{
    public class IngenieurDAO
    {
     

        internal static void AddPart(FormCollection collection, SqlConnection myConnection)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "InsertPart";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = myConnection;
                cmd.Parameters.Add(new SqlParameter("@NamePart", collection["NamePart"]));
                cmd.Parameters.Add(new SqlParameter("@PricePart", collection["PricePart"]));
                cmd.Parameters.Add(new SqlParameter("@Photo", collection["Photo"]));


                myConnection.Open();

               int x =  cmd.ExecuteNonQuery();
               
            }
            catch (SqlException)
            {

            }
            finally
            {
                myConnection.Close();
            }

        }
        internal static void AddMachine(FormCollection collection, SqlConnection myConnection)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "InsertMachine";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = myConnection;
                cmd.Parameters.Add(new SqlParameter("@param1", collection["MachineName"]));
                cmd.Parameters.Add(new SqlParameter("@param2", collection["Categorie"]));


                myConnection.Open();

                int x = cmd.ExecuteNonQuery();

            }
            catch (SqlException s)
            {
            }
            finally
            {
                myConnection.Close();
            }

        }

        internal static void AddDemande(FormCollection collection, SqlConnection myConnection)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "InsertDemande";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = myConnection;
                cmd.Parameters.Add(new SqlParameter("@param1", collection["EmployeeId"]));
                cmd.Parameters.Add(new SqlParameter("@param2", collection["PartId"]));
                cmd.Parameters.Add(new SqlParameter("@param3", collection["MachineId"]));
                cmd.Parameters.Add(new SqlParameter("@param4", collection["QtyPiece"]));
                cmd.Parameters.Add(new SqlParameter("@param5", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@param6", "New"));






                myConnection.Open();

                int x = cmd.ExecuteNonQuery();

            }
            catch (SqlException s)
            {
            }
            finally
            {
                myConnection.Close();
            }


        }
    }
}
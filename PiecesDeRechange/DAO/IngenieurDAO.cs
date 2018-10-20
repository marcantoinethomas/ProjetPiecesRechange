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
                cmd.Parameters.Add(new SqlParameter("@NamePart", collection.GetValue("NamePart")));
                cmd.Parameters.Add(new SqlParameter("@PricePart", collection.GetValue("PricePart")));
                cmd.Parameters.Add(new SqlParameter("@Photo", collection.GetValue("Photo")));


                myConnection.Open();

                cmd.ExecuteNonQuery();
               
            }
            catch (SqlException)
            {

            }
            finally
            {
                myConnection.Close();
            }

        }
    }
}
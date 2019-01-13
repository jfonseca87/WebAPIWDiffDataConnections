using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TestDAL
{
    public class ClientDAL
    {
        public DataTable GetClients()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ADOConnection"].ConnectionString);
            DataTable dt = new DataTable();

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetClients", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}

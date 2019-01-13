using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TestDAL
{
    public class ClientDAL
    {
        private SqlConnection conn = null;

        public ClientDAL()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ADOConnection"].ConnectionString);
        }

        public DataTable GetClients()
        {
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

        public DataTable GetClientsChecksDetails()
        {
            DataTable dt = new DataTable();

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetDataClienteFacturaDetalle", conn);

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

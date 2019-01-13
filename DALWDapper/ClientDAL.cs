using Dapper;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Data;

namespace DALWDapper
{
    public class ClientDAL
    {
        private SqlConnection conn = null;

        public ClientDAL()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ADOConnection"].ConnectionString);
        }

        public object GetClients()
        {
            string sql = "GetClients";

            try
            {
                conn.Open();
                var clients = conn.Query(sql).ToList();

                return clients;
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

        public object GetClientsChecksDetails()
        {
            string sql = "GetDataClienteFacturaDetalle";

            try
            {
                conn.Open();
                var list = conn.Query(sql).ToList();

                return list;
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

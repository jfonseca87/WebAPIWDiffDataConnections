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
        public object GetClients()
        {
            string sql = "GetClients";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ADOConnection"].ConnectionString);

            try
            {
                conn.Open();
                //var clients = conn.Execute(sql,null, null, null, commandType: CommandType.StoredProcedure);
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
    }
}

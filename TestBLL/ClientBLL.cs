using System.Data;
using TestDAL;

namespace TestBLL
{
    public class ClientBLL
    {
        public DataTable GetClients()
        {
            ClientDAL clientDAL = new ClientDAL();
            return clientDAL.GetClients();
        }

        public DataTable GetClientsChecksDetails()
        {
            ClientDAL clientDAL = new ClientDAL();
            return clientDAL.GetClientsChecksDetails();
        }
    }
}

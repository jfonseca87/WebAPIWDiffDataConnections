using DALWDapper;
using DALWEF6;
using DALWEFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TestBLL;

namespace ClientAPI.Controllers
{
    public class ClientController : ApiController
    {
        [HttpGet]
        [Route("api/GetClientsADO")]
        public IHttpActionResult GetClientsADO()
        {
            ClientBLL clientBLL = new ClientBLL();

            return Ok(clientBLL.GetClients());
        }

        [HttpGet]
        [Route("api/GetClientsEF6")]
        public IHttpActionResult GetClientsEF6()
        {
            using (TestEntities db = new TestEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return Ok(db.Cliente.ToList());
            }
        }

        [HttpGet]
        [Route("api/GetClientsEFCore")]
        public IHttpActionResult GetClientsEFCore()
        {
            using (TestContext db = new TestContext())
            {
                return Ok(db.Cliente.ToList());
            }
        }

        [HttpGet]
        [Route("api/GetClientsDapper")]
        public IHttpActionResult GetClientsDapper()
        {
            ClientDAL clientDAL = new ClientDAL();
            var asd = clientDAL.GetClients();

            return Ok(asd);
        }
    }
}

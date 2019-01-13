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
        [Route("api/GetClientsChecksDetailsADO")]
        public IHttpActionResult GetClientsChecksDetailsADO()
        {
            ClientBLL clientBLL = new ClientBLL();

            return Ok(clientBLL.GetClientsChecksDetails());
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
        [Route("api/GetClientsChecksDetailsEF6")]
        public IHttpActionResult GetClientsChecksDetailsEF6()
        {
            using (TestEntities db = new TestEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var list = (from c in db.Cliente
                            join f in db.Factura
                            on c.IdCliente equals f.IdCliente
                            join df in db.DetalleFactura
                            on f.IdFactura equals df.IdFactura
                            select new
                            {
                                c.IdCliente,
                                c.NomCliente,
                                c.EmailCliente,
                                f.IdFactura,
                                f.NumFactura,
                                f.TotalFactura,
                                df.Item,
                                df.ValorItem,
                                df.CantidadItem,
                                df.ValorItems
                            }).ToList();

                return Ok(list);
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
        [Route("api/GetClientsChecksDetailsEFCore")]
        public IHttpActionResult GetClientsChecksDetailsEFCore()
        {
            using (TestContext db = new TestContext())
            {
                var list = (from c in db.Cliente
                            join f in db.Factura
                            on c.IdCliente equals f.IdCliente
                            join df in db.DetalleFactura
                            on f.IdFactura equals df.IdFactura
                            select new
                            {
                                c.IdCliente,
                                c.NomCliente,
                                c.EmailCliente,
                                f.IdFactura,
                                f.NumFactura,
                                f.TotalFactura,
                                df.Item,
                                df.ValorItem,
                                df.CantidadItem,
                                df.ValorItems
                            }).ToList();

                return Ok(list);
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

        [HttpGet]
        [Route("api/GetClientsChecksDetailsDapper")]
        public IHttpActionResult GetClientsChecksDetailsDapper()
        {
            ClientDAL clientDAL = new ClientDAL();
            return Ok(clientDAL.GetClientsChecksDetails());
        }
    }
}

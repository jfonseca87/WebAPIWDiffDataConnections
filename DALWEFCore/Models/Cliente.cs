using System;
using System.Collections.Generic;

namespace DALWEFCore.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Factura = new HashSet<Factura>();
        }

        public int IdCliente { get; set; }
        public string NomCliente { get; set; }
        public string EmailCliente { get; set; }

        public virtual ICollection<Factura> Factura { get; set; }
    }
}

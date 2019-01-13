using System;
using System.Collections.Generic;

namespace DALWEFCore.Models
{
    public partial class DetalleFactura
    {
        public int IdDetalleFactura { get; set; }
        public string Item { get; set; }
        public decimal? ValorItem { get; set; }
        public int? CantidadItem { get; set; }
        public decimal? ValorItems { get; set; }
        public int? IdFactura { get; set; }

        public virtual Factura IdFacturaNavigation { get; set; }
    }
}

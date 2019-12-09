using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrograWebHHK.Models
{
    public class SaleModel
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public int IdDetalle { get; set; }

        public DateTime FechaVenta { get; set; }

        public decimal Subtotal { get; set; }


        public decimal Total { get; set; }

        public int Sku { get; set; }

        public int Cantidad { get; set; }

        public int ModoPago { get; set; }


    }
}
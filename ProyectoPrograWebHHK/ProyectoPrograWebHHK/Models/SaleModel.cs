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

        public void GetVentas()
        {
            var listaVentas = new List<SaleModel>();
            using (var context = new HHKDBEntities2())
            {
                try
                {
                    foreach (var item in context.Venta.ToList())
                    {
                        listaVentas.Add(new SaleModel
                        {
                              IdCliente = item.IdCliente,
                              
                        });
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }

    public class DetalleModel
    {

    }
}
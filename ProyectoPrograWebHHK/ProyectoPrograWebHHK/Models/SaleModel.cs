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

        public DateTime FechaVenta { get; set; }

        public decimal Subtotal { get; set; }

        public decimal Total { get; set; }

        public List<DetalleModel> Detalles { get; set; }

        public int ModoPago { get; set; }

        public List<SaleModel> GetVentas()
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
                            IdVenta = item.IdVenta,
                            FechaVenta = item.Fecha,
                            ModoPago = item.IdMp,
                            Subtotal = item.subtotal,
                            Total = item.Total,
                            Detalles = DetalleModel.GetDetalles(item.IdVenta)
                        });
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return listaVentas;
        }
    }

    public class DetalleModel
    {
        public int IdVenta { get; set; }
        public int IdDetalle { get; set; }
        public int Sku { get; set; }
        public decimal Costo { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }

        public static List<DetalleModel> GetDetalles(int idVenta)
        {
            var listaDetalle = new List<DetalleModel>();
            using (var context = new HHKDBEntities2())
            {
                foreach (var item in context.Detalle.Where(a => a.IdVenta == idVenta).ToList())
                {
                    listaDetalle.Add(new DetalleModel
                    {
                        IdDetalle = item.IdDetalle,
                        IdVenta = item.IdVenta,
                        Sku = item.Sku,
                        Costo = item.Costo,
                        Cantidad = item.Cantidad,
                        Total = item.Total
                    });
                }
            }

            return listaDetalle;
        }
    }
}
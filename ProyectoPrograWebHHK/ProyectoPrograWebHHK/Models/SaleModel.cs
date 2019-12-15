using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

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
            using (var context = new HHKDBEntities())
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

        public static bool AddSale(int idCliente)
        {
            using (var context = new HHKDBEntities())
            {
                var carritoCliente = context.CarritoCompras.Where(a => a.IdCliente == idCliente).ToList();

                //calcular total de la venta
                decimal subtotal = 0;

                foreach (var item in carritoCliente)
                {
                    subtotal += (item.Costo * item.Cantidad);
                }

                context.Venta.Add(new Venta
                {
                    IdCliente = idCliente,
                    Fecha = DateTime.Now,
                    IdMp = 1,
                    subtotal = subtotal,
                    Total = (subtotal * Convert.ToDecimal(1.16))
                });

                if (context.SaveChanges() > 0)
                {
                    int count = 1;
                    foreach (var item in carritoCliente)
                    {
                        
                        context.Detalle.Add(new Detalle
                        {
                            NumeroDetalle = count,
                            IdVenta = GetLastIdVenta(),
                            Sku = item.Sku,
                            Costo = item.Costo,
                            Cantidad = item.Cantidad,
                            Total = (item.Cantidad * item.Costo)
                        });
                        count += 1;

                    }

                    foreach (var item in context.CarritoCompras.ToList().Where(a => a.IdCliente == idCliente && a.estaActivo))
                    {
                        item.Ventido = true;
                    }

                    context.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        public static int GetLastIdVenta()
        {
            using (var context = new HHKDBEntities())
            {
                var lastId = context.Venta.ToList().OrderByDescending(a => a.IdVenta).Select(b => b.IdVenta);
                if (!context.Venta.Any())
                {
                    return 0;
                }

                return lastId.First();
            }
        }
    }

    public class DetalleModel
    {
        public int IdVenta { get; set; }
        public int? IdDetalle { get; set; }
        public int Sku { get; set; }
        public decimal Costo { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }

        public List<DetalleModel> ListDetalles { get; set; }

        public static List<DetalleModel> GetDetalles(int idVenta)
        {
            var listaDetalle = new List<DetalleModel>();
            using (var context = new HHKDBEntities())
            {
                foreach (var item in context.Detalle.Where(a => a.IdVenta == idVenta).ToList())
                {
                    listaDetalle.Add(new DetalleModel
                    {
                        IdDetalle = item.NumeroDetalle,
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
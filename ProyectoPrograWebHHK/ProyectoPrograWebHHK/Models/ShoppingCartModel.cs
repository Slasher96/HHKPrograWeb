using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrograWebHHK.Models
{
    public class ShoppingCartModel
    {
        #region constantes y propiedades
        public int Idcarrito { get; set; }

        public int IdCliente { get; set; }

        public int Sku { get; set; }

        public int Cantidad { get; set; }

        public decimal CostoUnitario { get; set; }

        public decimal CostoTotal { get; set; }

        public int IdMp { get; set; }

        public bool Vendido { get; set; }

        public bool EstaActivo { get; set; }

        public bool HayInventario { get; set; }

        public string RutaImagen { get; set; }

        public int Departamento { get; set; }

        public List<ShoppingCartModel> ShoppingCarts { get; set; }

        #endregion

        #region Metodos
        public List<ShoppingCartModel> GetProductInCartByClient(int idCliente)
        {
            var productsInCart = new List<ShoppingCartModel>();
            using (var context = new HHKDBEntities2())
            {
                if (context.Cliente.Any(a => a.IdCliente == idCliente))
                {
                    foreach (var item in context.CarritoCompras.Where(a => a.IdCliente == idCliente && a.Ventido == false).ToList())
                    {
                        var image = context.Productos.Where(a => a.Sku == item.Sku).First();
                        productsInCart.Add(new ShoppingCartModel
                        {
                            Idcarrito = item.IdCarrito,
                            IdCliente = item.IdCliente,
                            Cantidad = item.Cantidad,
                            CostoUnitario = item.Costo,
                            EstaActivo = item.estaActivo,
                            IdMp = item.IdMp,
                            Sku = item.Sku,
                            Vendido = item.Ventido,
                            RutaImagen = image.RutaImagen,
                            Departamento = image.IdDepartamento
                        });
                    }
                }
            }

            return productsInCart;
        }

        public bool AddPRoductToCar(int sku, int idCliente)
        {
            using (var context = new HHKDBEntities2())
            {
                if (idCliente != 0 && sku != 0)
                {

                    var product = context.Productos.Where(a => a.Sku == sku).First();
                    var client = context.Cliente.Where(a => a.IdCliente == idCliente).First();
                    var model = new ShoppingCartModel
                    {
                        IdCliente = client.IdCliente,
                        Sku = product.Sku,
                        Cantidad = 1,
                        CostoUnitario = (decimal)product.Costo,
                    };

                    if (!context.CarritoCompras.Any(a => a.IdCliente == model.IdCliente && a.Sku == model.Sku && a.estaActivo))
                    {
                        context.CarritoCompras.Add(new CarritoCompras
                        {
                            IdCliente = model.IdCliente,
                            Cantidad = model.Cantidad,
                            Costo = model.CostoUnitario,
                            estaActivo = true,
                            Sku = model.Sku,
                            Ventido = false,
                            IdMp = 1
                        });

                        if (context.SaveChanges() > 0) // rehacer la tabla carritoCompras para que hacepte idMp nulo
                        {
                            return true;
                        }
                    }
                    else
                    {
                        context.CarritoCompras.First(a => a.IdCliente == model.IdCliente && a.Sku == model.Sku && EstaActivo).Cantidad += 1;
                        if (context.SaveChanges() > 0)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool DeleteProductInCart(int idProduct, int client)
        {
            using (var context = new HHKDBEntities2())
            {
                try
                {
                    context.CarritoCompras.First(a => a.Sku == idProduct && a.IdCliente == client).estaActivo = false;
                }
                catch (Exception)
                {
                    return false;
                }

                if (context.SaveChanges() > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Inventario(int sku)
        {
            using (var context = new HHKDBEntities2())
            {
                return context.Productos.Any(a => a.estaActivo && a.Sku == sku && a.Inventario > 0);
            }
        }
        #endregion

    }
}
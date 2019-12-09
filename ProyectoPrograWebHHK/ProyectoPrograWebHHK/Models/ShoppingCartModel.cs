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
                        productsInCart.Add(new ShoppingCartModel
                        {
                            Idcarrito = item.IdCarrito,
                            IdCliente = item.IdCliente,
                            Cantidad = item.Cantidad,
                            CostoUnitario = item.Costo,
                            EstaActivo = item.estaActivo,
                            IdMp = item.IdMp,
                            Sku = item.Sku,
                            Vendido = item.Ventido
                        });
                    }
                }
            }

            return productsInCart;
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
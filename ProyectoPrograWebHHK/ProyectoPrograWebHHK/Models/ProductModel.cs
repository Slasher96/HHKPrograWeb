using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrograWebHHK.Models
{
    public class ProductModel
    {
        public int Sku { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string RutaImagen { get; set; }

        public decimal Costo { get; set; }

        public int Inventario { get; set; }

        public int IdDepartamento { get; set; }

        public bool EstaActivo { get; set; }

        public List<ProductModel> ListaProductos { get; set; }

        public List<ProductModel> GetProductos()
        {
            var ListaProductos = new List<ProductModel>();

            return ListaProductos;
        }

        public List<ProductModel> GetMotos()
        {
            var ListaProductos = new List<ProductModel>();
            using (var context = new HHKDBEntities1())
            {
                foreach (var item in context.Productos.Where(a=>a.estaActivo).ToList())
                {

                }
            }

            return ListaProductos;
        }

        public List<ProductModel> GetRefacciones()
        {
            var ListaProductos = new List<ProductModel>();

            return ListaProductos;
        }

        public void AddProduct(ProductModel product)
        {

        }

        public void DeleteProduct(int sku)
        {

        }

        public void UpdateProduct(ProductModel product)
        {

        }
    }
}
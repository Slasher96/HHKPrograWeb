using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrograWebHHK.Models
{
    public class ProductModel
    {
        #region Propiedades y constantes
        private const int idDepartamentoMotos = 1;

        private const int idDepartamentoRefacciones = 2;

        public int Sku { get; set; }
        public string Nombre { get; set; }


        public string Descripcion { get; set; }


        public string DescripcionSecundaria { get; set; }

        public string RutaImagen { get; set; }

        public double Costo { get; set; }

        public int? Inventario { get; set; }

        public int IdDepartamento { get; set; }

        public bool EstaActivo { get; set; }

        public List<ProductModel> ListaProductos { get; set; }

        public List<ProductModel> ListaMotocicletas { get; set; }

        public List<ProductModel> ListaRefacciones { get; set; }
        #endregion

        public List<ProductModel> GetProductos()
        {
            var ListaProductos = new List<ProductModel>();
            using (var context = new HHKDBEntities2())
            {
                foreach (var item in context.Productos.ToList())
                {
                    ListaProductos.Add(new ProductModel
                    {
                        IdDepartamento = item.IdDepartamento,
                        Nombre = item.Nombre,
                        Descripcion = item.Descripcion,
                        RutaImagen = item.RutaImagen,
                        Costo = item.Costo,
                        Sku = item.Sku,
                        DescripcionSecundaria = item.DescripcionSecundaria,
                        Inventario = item.Inventario,
                        EstaActivo = item.estaActivo
                    });
                }
            }
            return ListaProductos;
        }

        public List<ProductModel> GetMotos()
        {
            var ListaProductos = new List<ProductModel>();
            using (var context = new HHKDBEntities2())
            {
                foreach (var item in context.Productos.Where(a => a.estaActivo && a.IdDepartamento == idDepartamentoMotos).ToList())
                {
                    ListaProductos.Add(new ProductModel
                    {
                        IdDepartamento = item.IdDepartamento,
                        Nombre = item.Nombre,
                        Descripcion = item.Descripcion,
                        RutaImagen = item.RutaImagen,
                        Costo = item.Costo,
                        Sku = item.Sku,
                        DescripcionSecundaria = item.DescripcionSecundaria,
                        Inventario = item.Inventario
                    });
                }
            }

            return ListaProductos;
        }

        public List<ProductModel> GetRefacciones()
        {
            var ListaProductos = new List<ProductModel>();
            using (var context = new HHKDBEntities2())
            {
                foreach (var item in context.Productos.Where(a => a.estaActivo && a.IdDepartamento == idDepartamentoRefacciones).ToList())
                {
                    ListaProductos.Add(new ProductModel
                    {
                        IdDepartamento = item.IdDepartamento,
                        Nombre = item.Nombre,
                        Descripcion = item.Descripcion,
                        RutaImagen = item.RutaImagen,
                        Costo = item.Costo,
                        Sku = item.Sku,
                        DescripcionSecundaria = item.DescripcionSecundaria,
                        Inventario = item.Inventario
                    });
                }
            }

            return ListaProductos;
        }

        public bool AddProduct(ProductModel product)
        {
            using (var context = new HHKDBEntities2())
            {
                try
                {
                    context.Productos.Add(new Productos
                    {
                        Nombre = product.Nombre,
                        Descripcion = product.Descripcion,
                        DescripcionSecundaria = product.DescripcionSecundaria,
                        Costo = product.Costo,
                        estaActivo = true,
                        IdDepartamento = product.IdDepartamento,
                        //RutaImagen = validar como extraer el nombre de la imagen y guardarla en el servidor
                        Inventario = product.Inventario,
                    });

                    if (context.SaveChanges() > 0)
                    {
                        return true;
                    }
                }
                catch (Exception )
                {
                    return false;
                }

                return false;
            }
        }

        public bool DeleteProduct(int sku)
        {
            using (var context = new HHKDBEntities2())
            {
                if (context.Productos.Any(a => a.Sku == sku))
                {
                    context.Productos.First(a => a.Sku == sku).estaActivo = false;

                    if (context.SaveChanges() > 0)
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }

                return false;
            }
        }

        public bool UpdateProduct(ProductModel product)
        {
            using (var context = new HHKDBEntities2())
            {
                if (context.Productos.Any(a => a.Sku == product.Sku))
                {
                    var obj = context.Productos.First(a => a.Sku == product.Sku);
                    obj.Nombre = product.Nombre;
                    obj.Descripcion = product.Descripcion;
                    obj.DescripcionSecundaria = product.DescripcionSecundaria;
                    obj.estaActivo = product.EstaActivo;
                    obj.Inventario = product.Inventario;
                    obj.RutaImagen = product.RutaImagen; // validar con el metodo de guardar imagen para obtener solamente el nombre de la imagen con su extención
                    obj.Costo = product.Costo;
                    obj.IdDepartamento = product.IdDepartamento;

                    if (context.SaveChanges() > 0)
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }

                return false;
            }
        }
    }
}
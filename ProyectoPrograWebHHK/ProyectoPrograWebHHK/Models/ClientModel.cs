using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoPrograWebHHK.Models
{
    public class ClientModel
    {

        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su nombre")]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el primer apellido")]
        [DisplayName("Primer Apellido")]
        public string PrimerApellido { get; set; }


        [DisplayName("Segundo Apellido")]
        public string SegundoApellido { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su Dirección")]
        [DisplayName("Dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su contraseña")]
        [DisplayName("Contraseña")]
        [PasswordPropertyText]
        public string Contrasena { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su contraseña")]
        [DisplayName("Repetir Contraseña")]
        [PasswordPropertyText]
        public string RepetirContrasena { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su Correo Electrónico")]
        [DisplayName("Correo Electrónico")]
        [EmailAddress]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su Número Telefónico")]
        [DisplayName("Número Telefónico")]
        [Phone]
        public string Telefono { get; set; }

        public bool EstaActivo { get; set; }

        public bool EsEmpleado { get; set; }

        public List<ClientModel> ClientList { get; set; }


        public bool AddClient(ClientModel model)
        {
            using (var context = new HHKDBEntities2())
            {
                if (!context.Cliente.Any(a => a.Correo == model.CorreoElectronico))
                {

                    context.Cliente.Add(new Cliente
                    {
                        Nombre = model.Nombre,
                        PrimerApellido = model.PrimerApellido,
                        segundoApellido = model.SegundoApellido,
                        Direccion = model.Direccion,
                        Telefono = model.Telefono,
                        Contrasena = model.Contrasena,
                        Correo = model.CorreoElectronico,
                        estaActivo = true
                    });

                    if (context.SaveChanges() > 0)
                    {
                        return true;
                    }

                    return false;
                }
                else
                {
                    return false;
                }
            }
        }

        public int GetIdClientByEmail(AccountModel model)
        {
            using (var context = new HHKDBEntities2())
            {
                try
                {
                    return context.Cliente.Where(a => a.Correo == model.CorreoElectronico).First().IdCliente;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public List<ClientModel> GetClients()
        {
            var clientList = new List<ClientModel>();
            using (var context = new HHKDBEntities2())
            {
                try
                {
                    foreach (var model in context.Cliente.ToList())
                    {
                        clientList.Add(new ClientModel
                        {
                            Nombre = model.Nombre,
                            PrimerApellido = model.PrimerApellido,
                            SegundoApellido = model.segundoApellido,
                            Direccion = model.Direccion,
                            Telefono = model.Telefono,
                            Contrasena = model.Contrasena,
                            CorreoElectronico = model.Correo,
                            EstaActivo = model.estaActivo,
                            EsEmpleado = model.EsEmpleado,
                            IdCliente = model.IdCliente,
                        });
                    } 
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return clientList;
        }
    }
}
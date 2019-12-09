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


        public void AddClient(ClientModel model)
        {
            using (var context = new HHKDBEntities1())
            {
                context.Cliente.Add(new Cliente
                {
                    Nombre = model.Nombre,
                    PrimerApellido = model.PrimerApellido,
                    segundoApellido = model.SegundoApellido,
                    Direccion = model.Direccion,
                    Telefono = model.Telefono,
                    Contrasena=model.Contrasena,
                    Correo = model.CorreoElectronico,
                    estaActivo = true
                });
                context.SaveChanges();
            }
        }
    }
}
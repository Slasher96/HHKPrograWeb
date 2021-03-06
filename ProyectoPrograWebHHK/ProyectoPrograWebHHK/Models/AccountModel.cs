﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoPrograWebHHK.Models
{
    public class AccountModel
    {
        [Required(ErrorMessage = "Por favor ingrese su contraseña")]
        [DisplayName("Contraseña")]
        public string Contrasena { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su Correo Electrónico")]
        [DisplayName("Correo Electrónico")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        public string CorreoElectronico { get; set; }

        public bool LogIn(AccountModel model)
        {
            using (var context = new HHKDBEntities1())
            {
                if (context.Cliente.Any(c => c.estaActivo && c.Contrasena == model.Contrasena && CorreoElectronico == model.CorreoElectronico))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
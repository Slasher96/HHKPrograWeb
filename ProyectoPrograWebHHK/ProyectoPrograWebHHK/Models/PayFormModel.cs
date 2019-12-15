using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoPrograWebHHK.Models
{
    public class PayFormModel
    {
        [Required (ErrorMessage ="Ingrese el número de la tarjeta")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten números.")]
        public string NumeroTarjeta { get; set; }

        [Required(ErrorMessage = "Ingrese el mes de la tarjeta")]
        [Range(01, 12, ErrorMessage = "El Campo debe ser un numero entre 01 y 12")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten números.")]
        public string MM { get; set; }

        [Required(ErrorMessage = "Ingrese el año de la tarjeta")]
        [Range(19, 99, ErrorMessage = "Tarjeta vencida")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten números.")]
        public string YY { get; set; }

        [Required(ErrorMessage = "ingrese el CVV de la tarjeta")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten números.")]
        public string CVV { get; set; }

        [Required(ErrorMessage = "ingrese el nombre en la tarjeta")]
        public string Name { get; set; }
    }
}
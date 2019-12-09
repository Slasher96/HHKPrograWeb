using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrograWebHHK.Models
{
    public class ModoPagoModel
    {

        public int IdMp { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public bool EstaActivo { get; set; }

    }
}
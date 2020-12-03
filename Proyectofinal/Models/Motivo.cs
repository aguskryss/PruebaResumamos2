using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyectofinal.Models
{
    public class Motivo
    {
      
        public int IdMotivo { get; set; }
        public string Moti { get; set; }
        public Motivo(int idMotivo, string moti)
        {
            IdMotivo = idMotivo;
            Moti = moti;
        }

        public Motivo()
        {
            IdMotivo = -1;
            Moti = "";
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyectofinal.Models
{
    public class TipoDeDenuncia
    {
        public int IdTipo { get; set; }
        public string Tipo { get; set; }

        public TipoDeDenuncia()
        {
            IdTipo = -1;
            Tipo = "";

        }
        public TipoDeDenuncia(int i, string t)
        {
            IdTipo = i;
            Tipo = t;
        }
    }
}
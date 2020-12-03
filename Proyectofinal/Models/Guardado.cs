using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyectofinal.Models
{
    public class Guardado
    {
        

        public int fkRes { get; set; }
        public int fkUsu { get; set; }

        public Guardado(int fkRes, int fkUsu)
        {
            this.fkRes = fkRes;
            this.fkUsu = fkUsu;
        }

        public Guardado()
        {
            fkRes = -1;
            fkUsu = -1;
        }
    }
}
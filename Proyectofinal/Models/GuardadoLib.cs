using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyectofinal.Models
{
    public class GuardadoLib
    {
        public int fkLib { get; set; }
        public int fkUsu { get; set; }

        public GuardadoLib(int fkLib, int fkUsu)
        {
            this.fkLib = fkLib;
            this.fkUsu = fkUsu;
        }

        public GuardadoLib()
        {
            fkLib = -1;
            fkUsu = -1;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyectofinal.Models
{
    public class Inicio
    {
        public int FkUsuario { get; set; }
        public DateTime Hora { get; set; }
        public Boolean Admin { get; set; }

        public Inicio(int fkUsuario, DateTime hora, Boolean a)
        {
            FkUsuario = fkUsuario;
            Hora = hora;
            Admin = a;
        }

        public Inicio()
        {
            FkUsuario = -1;
            Hora = new DateTime();
            Admin = false;
        }
    }
}
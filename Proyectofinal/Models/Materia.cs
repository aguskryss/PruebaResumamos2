using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyectofinal.Models
{
    public class Materia
    {
        public int IdMateria { get; set; }
        public string NombreMateria { get; set; }

        public Materia(int id, string mat)
        {
            IdMateria = id;
            NombreMateria = mat;
        }
        public Materia()
        {
            IdMateria = -1;
            NombreMateria = "";
        }
    }
}
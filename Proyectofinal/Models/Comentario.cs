using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyectofinal.Models
{
    public class Comentario
    {
        public int IdComentario { get; set; }
        public string Contenido { get; set; }
        public int FkUsuario { get; set; }
        public int FkResumen { get; set; }
        public DateTime Fecha { get; set; }

        public Comentario()
        {
            IdComentario = -1;
            Contenido = "";
            FkUsuario = -1;
            FkResumen = -1;
            Fecha = new DateTime(0001, 01, 01);

        }

        public Comentario(int id, string cont, int us, int res, DateTime dt)
        {
            IdComentario = id;
            Contenido = cont;
            FkUsuario = us;
            FkResumen = res;
            Fecha = dt;
        }

    }
}
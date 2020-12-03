using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyectofinal.Models
{
    public class Respuesta
    {

        public int IdRespuesta { get; set; }
        public int FkPregunta {  get; set;  }
        public string Contenido { get; set; }
        public Respuesta(int idRespuesta, int fkPregunta, string contenido)
        {
            IdRespuesta = idRespuesta;
            FkPregunta = fkPregunta;
            Contenido = contenido;
        }


        public Respuesta()
        {
            IdRespuesta = -1;
            FkPregunta = -1;
            Contenido = "";
        }

    }
}
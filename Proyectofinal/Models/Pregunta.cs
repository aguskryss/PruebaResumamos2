using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyectofinal.Models
{
    public class Pregunta
    {

        public int IdPregunta { get; set; }
        public string Contenido { get; set; }
        public int FkUsuario { get; set; }

        public Pregunta(int idPregunta, string contenido, int fkUsuario)
        {
            IdPregunta = idPregunta;
            Contenido = contenido;
            FkUsuario = fkUsuario;
        }


        public Pregunta()
        {
            IdPregunta = -1;
            Contenido = "";
            FkUsuario = -1;
        }


    }
}
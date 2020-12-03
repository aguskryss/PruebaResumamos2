using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyectofinal.Models
{
    public class ComentariosYDenuncias
    {
        

        public int IdDenuncia { get; set; }
        public int FkMotivo { get; set; }
        public int IdComentario { get; set; }
        public string Contenido { get; set; }
        public int FkUsuario { get; set; }
        public int FkResumen { get; set; }
        public DateTime Fecha { get; set; }

        public ComentariosYDenuncias(int idDenuncia, int fkMotivo, int idComentario, string contenido, int fkUsuario, int fkResumen, DateTime fecha)
        {
            IdDenuncia = idDenuncia;
            FkMotivo = fkMotivo;
            IdComentario = idComentario;
            Contenido = contenido;
            FkUsuario = fkUsuario;
            FkResumen = fkResumen;
            Fecha = fecha;
        }

        public ComentariosYDenuncias()
        {
            IdDenuncia = -1;
            FkMotivo = -1;
            IdComentario = -1;
            Contenido = "";
            FkUsuario = -1;
            FkResumen = -1;
            Fecha = new DateTime();
        }
    }
}
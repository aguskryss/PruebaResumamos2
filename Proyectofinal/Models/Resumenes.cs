using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyectofinal.Models
{
    public class Resumenes
    {
        public int IdResumen { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int FkMateria { get; set; }
        public int FkUsuario { get; set; }
        public int Puntuacion { get; set; }
        [Required]
        [Range(0, 6, ErrorMessage = "Ingrese un año entre 1 y 5")]
        public int Ano { get; set; }
        [Required]
        public HttpPostedFileBase Archivo { get; set; }
        public string NombreImagen { get; set; }
        [Required]
        public int FkEscuela { get; set; }
        public DateTime Fecha { get; set; }
        public Boolean Aprobado { get; set; }
        public string Categorias { get; set; }
        public string Descripcion { get; set; }

        public Resumenes()
        {
            IdResumen = -1;
            Nombre = "";
            FkMateria = -1;
            FkUsuario = -1;
            Puntuacion = 0;
            Ano = 0;
            NombreImagen = "";
            FkEscuela = 0;
            Aprobado = false;
            Fecha = new DateTime(0001, 01, 01);
            Descripcion = "";

        }
        public Resumenes(int id, string nom, int fkmat, int fkua, int puntu, int ano, string nomimg, int fkesc, Boolean b, DateTime dt,string des)
        {
            IdResumen = id;
            Nombre = nom;
            FkMateria = fkmat;
            FkUsuario = fkua;
            Puntuacion = puntu;
            Ano = ano;
            NombreImagen = nomimg;
            FkEscuela = fkesc;
            Aprobado = b;
            Fecha = dt;
            Descripcion = des;
        }
    }
}
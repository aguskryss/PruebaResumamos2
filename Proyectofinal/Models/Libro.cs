using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyectofinal.Models
{
    public class Libro
    {
        

        public int IdLibro { get; set; }
        public string Nombre { get; set; }
        public Double Precio { get; set; }
        public int FkVendedor { get; set; }
        public int FkMateria { get; set; }
        public string Editorial { get; set; }
        public string Lugar { get; set; }
        public string NombreImagen { get; set; }
        public int FkAno { get; set; }
        public Boolean Aprobado { get; set; }
        public string Division { get; set; }
        public int FkEscuela { get; set; }
        public int FkComprador { get; set; }
        public string Descripcion { get; set; }
        public int Telefono { get; set; }
        public HttpPostedFileBase Imagen { get; set; }
        public string LinkMP { get; set; }

        public Libro(int idLibro, string nombre, Double precio, int fkVendedor, int fkMateria, string editorial, string lugar, string nombreImagen, int fkAno, bool aprobado, string division, int fkEscuela, int fkComprador, string descripcion, int tel, string mp)
        {
            IdLibro = idLibro;
            Nombre = nombre;
            Precio = precio;
            FkVendedor = fkVendedor;
            FkMateria = fkMateria;
            Editorial = editorial;
            Lugar = lugar;
            NombreImagen = nombreImagen;
            FkAno = fkAno;
            Aprobado = aprobado;
            Division = division;
            FkEscuela = fkEscuela;
            FkComprador = fkComprador;
            Descripcion = descripcion;
            Telefono = tel;
            LinkMP = mp;
        }

        public Libro()
        {
            IdLibro = -1;
            Nombre = "";
            Precio = 0;
            FkVendedor = -1;
            FkMateria = -1;
            Editorial = "";
            Lugar = "";
            NombreImagen = "";
            FkAno = -1;
            Aprobado = false;
            Division = "";
            FkEscuela = -1;
            FkComprador = -1;
            Descripcion = "";
            Telefono = -1;
            LinkMP = "";
        }

    }
}
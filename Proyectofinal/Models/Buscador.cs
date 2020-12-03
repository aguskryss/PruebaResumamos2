using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyectofinal.Models
{
    public class Buscador
    {
        public string txt { get; set; }
        public int idEsc { get; set; }
        public int FkEscuela { get; set; }
        public int FkMateria { get; set; }
        public int FkAno { get; set; }
        public Buscador()
        {
            txt = "";
            idEsc = -1;
            FkEscuela = -1;
            FkMateria =-1 ;
            FkAno = -1;
        }

        public Buscador(string txt, int idEsc, int fkEscuela, int fkMateria, int fkAno)
        {
            this.txt = txt;
            this.idEsc = idEsc;
            FkEscuela = fkEscuela;
            FkMateria = fkMateria;
            FkAno = fkAno;
        }
    }
}
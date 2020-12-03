using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyectofinal.Models
{
    public class Año
    {
        public int a { get; set; }
        public string escri { get; set; }

        public Año()
        {
            a = -1;
            escri = "";
        }
        public Año(int i, string s)
        {
            a = i;
            escri = s;
        }
    }
}
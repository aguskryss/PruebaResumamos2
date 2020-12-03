using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyectofinal.Models
{
    public class Tag
    {
        public int IdTag { get; set; }
        public string NombreTag { get; set; }

        public Tag()
        {
            IdTag = -1;
            NombreTag = "";
        }
        public Tag(int id, string nom)
        {
            IdTag = id;
            NombreTag = nom;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyectofinal.Models
{
    public class Codigo
    {


        public int Id { get; set; }
        public string Codi { get; set; }
        public Codigo(int id, string codi)
        {
            Id = id;
            Codi = codi;
        }
        public Codigo()
        {
            Id = -1;
            Codi = "";
        }

    }
}
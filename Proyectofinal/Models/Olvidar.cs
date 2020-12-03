using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyectofinal.Models
{
    public class Olvidar
    {
       
        public string Mail { get; set; }
        public Olvidar(string mail)
        {
            Mail = mail;
        }
        public Olvidar()
        {
            Mail = "";
        }

    }
}
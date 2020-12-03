using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyectofinal.Models
{
    public class Contra
    {
       
        public int idUsuario { get; set; }
        public string ContraVieja { get; set; }


        [Required(ErrorMessage = "Ingrese una contraseña")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "La contraseña debe tener entre 6 y 15 caracteres")]

        public string Contra1 { get; set; }
        [Compare("Contra1", ErrorMessage = "Las contraseñas no coinciden, por favor ingreselas de vuelta")]

        public string Contra2 { get; set; }

        public Contra(int idUsuario, string contraVieja, string contra1, string contra2)
        {
            this.idUsuario = idUsuario;
            ContraVieja = contraVieja;
            Contra1 = contra1;
            Contra2 = contra2;
        }

        public Contra()
        {
            this.idUsuario = -1;
            ContraVieja = "";
            Contra1 = "";
            Contra2 = "";
        }
    }
}
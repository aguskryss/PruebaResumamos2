using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyectofinal.Models
{
    public class Login2
    {
        
        [Required(ErrorMessage = "Nombre de usuario incorrecto")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Ingrese una contraseña")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Contraseña incorrecta")]
        public string Contrasena { get; set; }
        public int FkResumen { get; set; }
        public int FkLibro { get; set; }

        public Login2(string username, string contrasena, int fkResumen, int fklibro)
        {
            Username = username;
            Contrasena = contrasena;
            FkResumen = fkResumen;
            FkLibro = fklibro;
        }


        public Login2()
        {
            Username = "";
            Contrasena = "";
            FkResumen = -1;
            FkLibro = -1;
        }

    }
}
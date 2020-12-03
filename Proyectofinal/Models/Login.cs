using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Proyectofinal.Models
{
    public class Login
    {
        [Required (ErrorMessage = "Nombre de usuario incorrecto")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Ingrese una contraseña")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Contraseña incorrecta")]
        public string Contrasena { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyectofinal.Models
{
    public class MailContacto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required]
        public string Asunto { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Mensaje { get; set; }
    }
}
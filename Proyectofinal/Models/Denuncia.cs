using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyectofinal.Models
{
    public class Denuncia
    {
        public int IdDenuncia { get; set; }
        public int FkUsuario { get; set; }
        public int FkResumen { get; set; }
        public int FkMotivo { get; set; }

        public Denuncia()
        {
            IdDenuncia = -1;
            FkMotivo = -1;
            FkResumen = -1;
            FkUsuario = -1;
        }

        public Denuncia(int id, int usu,int res,int mot)
        {
            IdDenuncia = id;
            FkUsuario = usu;
            FkResumen = res;
            FkMotivo = mot;
        }
    }
}
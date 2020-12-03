using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Proyectofinal.Models;
using System.Data;
using MercadoPago;
using MercadoPago.DataStructures.Payment;
using MercadoPago.Resources;
using System.Text;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using System.Configuration;
using System.Web.Configuration;
using System.Net.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;


namespace Proyectofinal.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Home()
        {
            Usuarios usu = new Usuarios();
            if (Session["id"] != null)
            {
                 usu = BD.TraerUsuario(Int32.Parse(Session["id"].ToString()));
            }
            Usuarios miUsuario = new Usuarios();
            miUsuario = usu;
            return View();
        }
        public ActionResult Index()
        {
            List<Resumenes> l = BD.TraerResumenesXPunt();
            ViewBag.pag = 1;
            ViewBag.lista = l;
            return View("");
        }

        public ActionResult About()
        {
            ViewBag.Message = "page";

            return View();
        }
        [HttpGet]
        public FileResult ImageDownload(int Id)
        {

            Resumenes res = BD.TraerResumen(Id);
            string nombre = res.NombreImagen;
            var imgPath = Server.MapPath("~/Content/Archivos/" + nombre);
            return File(imgPath, "image/jpg", nombre);
        }
        public ActionResult Consulta()
        {
            ViewBag.i = 0;
            return View();
        }
        public ActionResult Cerrar()
        {
            Session["id"] = null;
            return RedirectToAction("Home");
        }
        
        public string ValidarLogin(string username, string pass)
        {
            

            if (ModelState.IsValid)
            {
                Usuarios usu = BD.ValidarLoginUsuario(username, pass);
                if (usu.IdUsuario != -1)
                {
                    Session["id"] = usu.IdUsuario;                  
                    return usu.Nombre +" "+usu.Apellido;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
        public ActionResult ValidarLoginUsuario(string username, string pass)
        {


                Usuarios usu = BD.ValidarLoginUsuario(username, pass);
                if (usu.IdUsuario != -1)
                {
                    Session["id"] = usu.IdUsuario;
                    return View("index");
                }
                else
                {
                    return View ("Login");
                }
            
        }
        public ActionResult QuienesSomos()
        {
            return View("");
        }
        public ActionResult Loguearse()
        {
            return View("Login");
        }

        public ActionResult DespuesDeRegistrarse(Usuarios user)
        {
            if (ModelState.IsValid)
            {
                if (user.Archivo != null)
                {
                    user.NombreImagen = Path.GetFileName(user.Archivo.FileName);   // creo bien
                    user.Archivo.SaveAs(Server.MapPath(@"~/Content/Archivos/" + user.NombreImagen));  // bien hermoso
                }
                bool EstaElUs = BD.ValidarUsuarioExistente(user.Username);
                if (EstaElUs)
                {
                    ViewBag.us = true;
                    ViewBag.ListaAños = BD.TraerAños();
                    ViewBag.ListaEscuelas = BD.TraerEscuelas();
                    Usuarios usu = new Usuarios();
                    user.Creditos = 100;
                    return View("Registrarse", usu);
                }
                else
                {
                    BD.InsertarUsuario(user);
                    Usuarios usu = BD.ValidarLoginUsuario(user.Username, user.Contrasena);
                    Session["id"] = usu.IdUsuario;
                    return RedirectToAction("Home");
                }

            }
            else
            {
                return RedirectToAction("Registrarse");
            }
        }
        public ActionResult Registrarse()
        {
            ViewBag.us = false;
            ViewBag.ListaAños = BD.TraerAños();
            ViewBag.ListaEscuelas = BD.TraerEscuelas();
            Usuarios user = new Usuarios();
            user.Creditos = 100;
            return View("Registrarse", user);
        }
        /*
        public ActionResult SumarMeGusta(int Id)
        {
            if (Session["id"] != null)
            {
                string idUs = Session["id"].ToString();
                int idusuario = Int32.Parse(idUs);
                bool votoAntes = BD.VerSiVoto(Id, idusuario);
                if (votoAntes == true)
                {
                    BD.EliminarVoto(Id, idusuario);
                    BD.DespuntuarResumen(Id);
                }
                else
                {
                    BD.AgregarVoto(Id, idusuario);
                    BD.PuntuarResumen(Id);
                }

                ViewBag.Gusto = BD.VerSiVoto(Id, idusuario);
                Guardado g = BD.TraerResGuardado(Id, idusuario);
                ViewBag.Guardo = g.fkRes;
                ViewBag.id = Id;
                return View("Resumen");
            }else
            {
                Login2 l = new Login2();
                l.FkResumen = Id;
                return View("LoginEspe",l);
            }
            
        }
        */

        public int SumarMeGusta(int Id)
        {

            string idUs = Session["id"].ToString();
            int idusuario = Int32.Parse(idUs);
            bool votoAntes = BD.VerSiVoto(Id, idusuario);
            if (votoAntes == true)
            {
                BD.EliminarVoto(Id, idusuario);
                BD.DespuntuarResumen(Id);
            }
            else
            {
                BD.AgregarVoto(Id, idusuario);
                BD.PuntuarResumen(Id);
            }

            ViewBag.Gusto = BD.VerSiVoto(Id, idusuario);
            Guardado g = BD.TraerResGuardado(Id, idusuario);
            ViewBag.Guardo = g.fkRes;
            ViewBag.id = Id;
            Resumenes r = BD.TraerResumen(Id);
            return r.Puntuacion;
        }



        [HttpPost]
        public ActionResult ValidarCrearUsuario(Usuarios user)
        {
            if (ModelState.IsValid)// falta completar la clase BD cdo este hecha la home
            {
                BD.InsertarUsuario(user);
                return View("Login");
            }
            else
            {
                return View("CrearCuenta");
            }

        }
        public ActionResult InserRes()
        {
            bool l = Login();

            if (l == true)
            {
                ViewBag.ListaAños = BD.TraerAños();
                ViewBag.ListaMaterias = BD.TraerMateria();
                ViewBag.ListaEscuelas = BD.TraerEscuelas();
                return View("SubirResumen");
            }
            else
            {
                return RedirectToAction("Loguearse");
            }
        }
        /* VA A ESTAR EN EL BACKOFFICE
        public ActionResult EliminarRes(int Id)
        {
            BD.EliminarResumen(Id);
            return RedirectToAction("Index");
        }
        */
        [HttpPost]
        public ActionResult DespuesDeModificarResumen(Resumenes res)
        {

            List<string> ListaPalabras = new List<string>();
            if (res.Categorias == "")
            {
                //Manejo de string para los tags
                string BorrarEspacio = res.Categorias;
                string palabraActual = "", tags = "";
                int cantDeComas = 0;

                for (int i = 0; i < BorrarEspacio.Length; i++)
                {
                    if (BorrarEspacio.Substring(i, 1) != " ")
                    {
                        tags += BorrarEspacio.Substring(i, 1);
                    }
                }
                tags += ",";
                for (int i = 0; i < tags.Length; i++)
                {
                    if (tags.Substring(i, 1) != ",")
                    {
                        palabraActual += tags.Substring(i, 1);

                    }
                    else if (tags.Substring(i, 1) == ",")
                    {
                        ListaPalabras.Add(palabraActual);
                        palabraActual = "";
                        cantDeComas++;
                    }

                }
                if (cantDeComas == 0 && tags.Length > 1)
                {
                    ListaPalabras.Add(palabraActual);
                }
            }
            // Hasta aca separe las palabras y las puse en una lista


            //Guardar en la BD e ir al index
            if (res.Archivo != null)
            {
                res.NombreImagen = Path.GetFileName(res.Archivo.FileName);   // creo bien
                res.Archivo.SaveAs(Server.MapPath(@"~/Content/Archivos/" + res.NombreImagen));  // bien hermoso
            }
            BD.ModificarResumen(res);
            int idResumen = res.IdResumen;

            if (res.Categorias == "")
            {
                foreach (string palabra in ListaPalabras)
                {
                    Tag MiTag = new Tag();
                    MiTag = BD.BuscarTag(palabra);
                    if (MiTag.IdTag == -1)
                    {
                        BD.InsertarTag(palabra);
                        MiTag = BD.BuscarTag(palabra);
                    }
                    BD.InsertarTagXRes(MiTag.IdTag, idResumen);

                }
            }
            return RedirectToAction("MisResumenes");
        }

        [HttpPost]
        public ActionResult InsertarResumen(Resumenes res)
        {
            //Manejo de string para los tags
            string BorrarEspacio = res.Categorias;
            string palabraActual = "", tags = "";
            int cantDeComas = 0;
            List<string> ListaPalabras = new List<string>();
            for (int i = 0; i < BorrarEspacio.Length; i++)
            {
                if (BorrarEspacio.Substring(i, 1) != " ")
                {
                    tags += BorrarEspacio.Substring(i, 1);
                }
            }
            tags += ",";
            for (int i = 0; i < tags.Length; i++)
            {
                if (tags.Substring(i, 1) != ",")
                {
                    palabraActual += tags.Substring(i, 1);

                }
                else if (tags.Substring(i, 1) == ",")
                {
                    ListaPalabras.Add(palabraActual);
                    palabraActual = "";
                    cantDeComas++;
                }

            }
            if (cantDeComas == 0 && tags.Length > 1)
            {
                ListaPalabras.Add(palabraActual);
            }

            // Hasta aca separe las palabras y las puse en una lista


            //Guardar en la BD e ir al index
            res.NombreImagen = Path.GetFileName(res.Archivo.FileName);   // creo bien
            res.Archivo.SaveAs(Server.MapPath(@"~/Content/Archivos/" + res.NombreImagen));  // bien hermoso
            BD.InsertarResumen(res);//   creo q bien

            int idResumen = BD.TraerIdResumenXNombre(res.Nombre, res.FkUsuario, res.NombreImagen, res.Ano, res.Fecha);

            foreach (string palabra in ListaPalabras)
            {
                Tag MiTag = new Tag();
                MiTag = BD.BuscarTag(palabra);
                if (MiTag.IdTag == -1)
                {
                    BD.InsertarTag(palabra);
                    MiTag = BD.BuscarTag(palabra);
                }
                BD.InsertarTagXRes(MiTag.IdTag, idResumen);

            }




            return RedirectToAction("index");
        }
        public ActionResult TraerEsc(int id)
        {
            ViewBag.id = id;
            ViewBag.nom = BD.TraerNombreEscuelaxId(id);
            ViewBag.lista = BD.TraerResumenesXEsc(id);
            ViewBag.pag = 1;
            return View("Escuela");
        }

        [HttpPost]
        public ActionResult Buscar(Buscador b)
        {
            if (b.txt != null)
            {
                ViewBag.lista = BD.Buscador(b.txt, b.idEsc);

                if (b.idEsc != -1)
                {
                    ViewBag.b = 1;
                    ViewBag.nom = BD.TraerNombreEscuelaxId(b.idEsc);
                    return View("Escuela");
                }
                else
                {
                    ViewBag.i = 0;
                    ViewBag.TextoBuscado = b.txt;
                    return View("index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        public ActionResult ValidarLoginEspe(Login2 l)
        {
            string username = l.Username;
            string pass = l.Contrasena;

            if (ModelState.IsValid)
            {
                Usuarios usu = BD.ValidarLoginUsuario(username, pass);
                if (usu.IdUsuario != -1)
                {
                    Session["id"] = usu.IdUsuario;
                    string i = Session["id"].ToString();
                    int idus = Int32.Parse(i);
                    ViewBag.id = l.FkResumen;
                    ViewBag.Gusto = BD.VerSiVoto(l.FkResumen, idus);
                    Guardado g = BD.TraerResGuardado(l.FkResumen, idus);
                    ViewBag.Guardo = g.fkRes;
                    ComentariosYDenuncias c = new ComentariosYDenuncias();
                    c.FkMotivo = -1;
                    c.Fecha = DateTime.Now;
                    return View("Resumen", c);

                }
                else
                {
                    Login2 lo = new Login2();
                    l.FkResumen = l.FkResumen;
                    return View("LoginEspe", l);
                }
            }
            else
            {
                Login2 lo = new Login2();
                l.FkResumen = l.FkResumen;
                return View("LoginEspe", l);
            }
        }
        public ActionResult GuardarResumen(int id)
        {
            if (Session["id"] != null)
            {
                string i = Session["id"].ToString();
                int idus = Int32.Parse(i);
                Guardado g = BD.TraerResGuardado(id, idus);
                if (g.fkRes == -1 && g.fkUsu == -1)
                {
                    BD.AgregarGuardado(id, idus);
                }
                else
                {
                    BD.EliminarGuardado(id, idus);
                }
                ViewBag.Gusto = BD.VerSiVoto(id, idus);
                Guardado ga = BD.TraerResGuardado(id, idus);
                ViewBag.Guardo = ga.fkRes;
                ViewBag.id = id;
                return View("Resumen");
            }
            else
            {
                Login2 l = new Login2();
                l.FkResumen = id;
                return View("LoginEspe", l);
            }
        }
        public ActionResult Resumen(int id)
        {
            if (Session["id"] != null)
            {
                string i = Session["id"].ToString();
                int idus = Int32.Parse(i);
                ViewBag.id = id;
                ViewBag.Gusto = BD.VerSiVoto(id, idus);
                Guardado g = BD.TraerResGuardado(id, idus);
                ViewBag.Guardo = g.fkRes;
                ComentariosYDenuncias c = new ComentariosYDenuncias();
                return View("");
            }
            else
            {
                ViewBag.id = id;
                ViewBag.Gusto = false;
                ViewBag.Guardo = -1;
                ComentariosYDenuncias c = new ComentariosYDenuncias();
                return View("");
            }
        }

        public ActionResult InsertarComentario(ComentariosYDenuncias coment)
        {
            Comentario comen = new Comentario();
            comen.IdComentario = coment.IdComentario;
            comen.FkUsuario = Int32.Parse(Session["id"].ToString()); 
            comen.FkResumen = coment.FkResumen;
            comen.Fecha = DateTime.Now;
            comen.Contenido = coment.Contenido;
            BD.AgregarComentario(comen);
            Session["id"] = Session["id"];
            ViewBag.id = comen.FkResumen;
            ViewBag.Gusto = BD.VerSiVoto(comen.FkResumen, comen.FkUsuario); // AGREGAR ESTO
            return View("Resumen");
        }

        public ActionResult Guardados()
        {
            string g = Session["id"].ToString();
            int idus = Int32.Parse(g);
            List<int> idResumenes = BD.TraerIdDeResumenesGuardados(idus);
            List<Resumenes> lista = new List<Resumenes>();
            foreach (int i in idResumenes)
            {
                Resumenes resu = new Resumenes();
                resu = BD.TraerResumen(i);
                lista.Add(resu);
            }
            ViewBag.lista = lista;
            return View();
        }

        public ActionResult EliminarGuardado(int id)
        {
            bool l = Login();
            if (l == true)
            {
                string i = Session["id"].ToString();
                int idus = Int32.Parse(i);
                BD.EliminarGuardado(id, idus);
                ViewBag.id = id;
                ViewBag.Gusto = BD.VerSiVoto(id, idus);
                Guardado g = BD.TraerResGuardado(id, idus);
                ViewBag.Guardo = g.fkRes;
                return View("Resumen");
            }
            else
            {
                return RedirectToAction("Loguearse");
            }
        }
        public ActionResult EliminardeMisGuardados(int id)
        {
            string i = Session["id"].ToString();
            int idus = Int32.Parse(i);
            BD.EliminarGuardado(id, idus);
            return RedirectToAction("Guardados");
        }


        public bool Login()
        {
            bool l;
            if (Session["id"] != null)
            {
                l = true;
            }
            else
            {
                l = false;
            }
            return l;
        }
        public ActionResult MisResumenes()
        {
            string i = Session["id"].ToString();
            int idus = Int32.Parse(i);
            ViewBag.lista = BD.TraerResumenesDelUsuario(idus);
            return View();
        }
        public ActionResult Eliminar(int id)
        {
            BD.EliminarResumen(id);
            return RedirectToAction("MisResumenes");
        }
        public ActionResult DenunciarResumen(int id)
        {
            if (Login() == true)
            {
                ViewBag.id = id;
                return View();
            }
            else
            {
                return RedirectToAction("Loguearse");
            }
        }

        public ActionResult MiPerfil()
        {
            if (Login() == true)
            {
                string i = Session["id"].ToString();
                int idus = Int32.Parse(i);
                ViewBag.id = idus;
                return View();
            }
            else
            {
                return RedirectToAction("Loguearse");
            }
        }

        public ActionResult EditarPerfil()
        {
            if (Login())
            {
                ViewBag.ListaEscuelas = BD.TraerEscuelas();
                string i = Session["id"].ToString();
                int idus = Int32.Parse(i);
                ViewBag.id = idus;
                Usuarios User = new Usuarios();
                User.Contrasena = "";
                User.Contra2 = "";
                User.Admin = false;
                User.Creditos = 0;
                User.NombreImagen = "";
                User.Puntuacion = 0;
                User.IdUsuario = idus;
                return View("EditarPerfil", User);
            }
            else
            {
                return RedirectToAction("Loguearse");
            }
        }
        [HttpPost]
        public ActionResult DespuesDeEditarPerfil(Usuarios usu)
        {
            if (usu.Archivo != null)
            {
                usu.NombreImagen = Path.GetFileName(usu.Archivo.FileName);   // creo bien
                usu.Archivo.SaveAs(Server.MapPath(@"~/Content/Archivos/" + usu.NombreImagen));  // bien hermoso
            }
            else
            {
                usu.NombreImagen = null;
            }
            BD.ModificarPerfil(usu);
            return RedirectToAction("MiPerfil");
        }
        public ActionResult ModificarResumen(int id)
        {
            if (Login())
            {
                ViewBag.id = id;
                ViewBag.ListaAños = BD.TraerAños();
                ViewBag.ListaEscuelas = BD.TraerEscuelas();
                return View();
            }
            else
            {
                return RedirectToAction("Loguearse");
            }
        }

        public ActionResult DespuesDeDenunciarResumen(ComentariosYDenuncias comen)
        {
            string i = Session["id"].ToString();
            int idus = Int32.Parse(i);
            comen.FkUsuario = idus;
            BD.AgregarDenuncia(comen);       
            ViewBag.id = comen.FkResumen;
            ViewBag.Gusto = BD.VerSiVoto(comen.FkResumen, comen.FkUsuario);
            Guardado g = BD.TraerResGuardado(comen.FkResumen, comen.FkUsuario);
            ViewBag.Guardo = g.fkRes;
            return View("Resumen");

        }

        public ActionResult CambiarContra()
        {
            Contra con = new Contra();
            string i = Session["id"].ToString();
            int idus = Int32.Parse(i);
            con.idUsuario = idus;
            return View("CambiarContra");
        }

        public ActionResult DespuesDeCambiar(Contra c)
        {
            bool b = BD.VerContraVieja(c.ContraVieja, c.idUsuario);
            if (b)
            {
                BD.CambiarContra(c);
                return RedirectToAction("home");
            }
            else
            {
                return RedirectToAction("CambiarContra");
            }

        }
        

        public ActionResult ContraDelMail(int i, string s)
        {
            Boolean b = BD.VerSiEstaElCodigo(i, s);
            if (b == true)
            {
                ViewBag.id = i;
                ViewBag.ContraVieja = BD.TraerContra(i);
                Contra c = new Contra();
                c.ContraVieja = BD.TraerContra(i);
                c.idUsuario = i;
                return View("ContraNueva");
            }
            else
            {
                return RedirectToAction("CambiarContra");
            }
        }

        public ActionResult Olvidar()
        {
            ViewBag.i = false;
            return View();
        }

        public ActionResult FiltrarEsc(int id, string BusquedaAnterio)
        {
            ViewBag.lista = BD.BuscadorXEsc(BusquedaAnterio, id);
            ViewBag.i = 0;
            ViewBag.TextoBuscado = BusquedaAnterio;
            return View("index");
        }

        public ActionResult FiltrarAno(int id, string BusquedaAnterio)
        {
            ViewBag.lista = BD.BuscadorXAno(BusquedaAnterio, id);
            ViewBag.i = 0;
            ViewBag.TextoBuscado = BusquedaAnterio;
            return View("index");
        }

        public ActionResult FiltrarMat(int id, string BusquedaAnterio)
        {
            ViewBag.lista = BD.BuscadorXMat(BusquedaAnterio, id);
            ViewBag.i = 0;
            ViewBag.TextoBuscado = BusquedaAnterio;
            return View("index");
        }
        public List<Resumenes> TraerMasResumenes(int cant)
        {
            List<Resumenes> l = BD.MasResumenes(cant);
            return l;
        }
        public ActionResult EnviarMail(Olvidar o)
        {
            Usuarios usu = BD.VerMailSiExiste(o.Mail);
            if (usu.IdUsuario != -1)
            {
                Codigo c = BD.CodigoAlAzar();
                BD.InsertarCodigoYUsuario(c.Id, usu.IdUsuario);

                MailMessage correo = new MailMessage();

                correo.From = new MailAddress("resumamos@gmail.com", "Resumamos!"); //Correo de salida
                correo.To.Add(o.Mail); //Correo destino
                correo.Subject = "Restaurar la contraseña";  //Asunto
                //correo.Body =  "Hola! te hablamos desde el equipo de resumamos para que puedas reestablecer tu contraseña. Ingrese al siguiente link para poder reestablecerla: " + "https://resumamoss.azurewebsites.net/" + "Home/ContraDelMail?i=" + usu.IdUsuario+ "&s="+c.Codi; //Mensaje del correo
                correo.Body= "Hola! te hablamos desde el equipo de resumamos para que puedas reestablecer tu contraseña. Ingrese al siguiente link para poder reestablecerla: " + string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~")) + "Home/ContraDelMail?i=" + usu.IdUsuario+ "&s="+c.Codi;
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;
                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Host = "smtp.gmail.com"; //Host del servidor de correo
                smtp.Port = 587; //Puerto de salida
                smtp.Credentials = new System.Net.NetworkCredential("resumamos@gmail.com", "Resumamos.123"); //Cuenta de correo
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtp.EnableSsl = true;//True si el servidor de correo permite ssl
                smtp.Send(correo);
            }
            return View();
        }

        /*public ActionResult EnviarMail(Olvidar o)
        {
            Usuarios usu = BD.VerMailSiExiste(o.Mail);
            if (usu.IdUsuario != -1)
            {
                 codigo mandar mail
                try
                {

                    var senderEmail = new MailAddress("resumamos@hotmail.com", "Resumamos!");
                    var receiverEmail = new MailAddress(o.Mail, "Receiver");
                    var password = "Resuma123";
                    var sub = "Restaurar la contraseña";
                    //var body = "Hola! te hablamos desde el equipo de resumamos para que puedas reestablecer tu contraseña. Ingrese al siguiente link para poder reestablecerla: http://localhost:50373/Home/ContraDelMail/" + usu.IdUsuario;

                    var body = "Hola! te hablamos desde el equipo de resumamos para que puedas reestablecer tu contraseña. Ingrese al siguiente link para poder reestablecerla: " + string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~")) + "Home/ContraDelMail/" + usu.IdUsuario;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.office365.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = "Restaurar la contraseña",
                        Body = body,
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();

                }
                catch (Exception)
                {
                    return View();
                }
            }
            else
            {
                ViewBag.i = true;
                return View("Olvidar");
            }
            
        }*/
            public ActionResult MandarMailConsulta(MailContacto o)
        {
            MailMessage correo = new MailMessage();
           
            correo.From = new MailAddress("resumamos@gmail.com", "Resumamos!"); //Correo de salida
            correo.To.Add("resumamos@gmail.com"); //Correo destino
            correo.Subject = "Asunto: " + o.Asunto + " de parte de: " + o.Nombre + " con el mail: " + o.Email; //Asunto
            correo.Body = o.Mensaje; //Mensaje del correo
            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.Normal;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com"; //Host del servidor de correo
            smtp.Port = 587; //Puerto de salida
            smtp.Credentials = new System.Net.NetworkCredential("resumamos@gmail.com", "Resumamos.123"); //Cuenta de correo
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.EnableSsl = true;//True si el servidor de correo permite ssl
            smtp.Send(correo);
            return RedirectToAction("Home");
        }



       /*public ActionResult MandarMailConsulta(MailContacto o)
        {
           
            /* codigo mandar mail
            try
                {

                    var senderEmail = new MailAddress("resumamos@hotmail.com", "Resumamos!");
                    var receiverEmail = new MailAddress("resumamos@hotmail.com", "Receiver");
                    var password = "Resum123";
                    var sub = "Asunto: "+o.Asunto+" de parte de: "+ o.Nombre+" con el mail: "+o.Email;
                    var body = o.Mensaje ;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.office365.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = sub,
                        Body = sub+"      "+body,
                    })
                    {
                        smtp.Send(mess);
                    }
                    return RedirectToAction("Home");

                }
                catch (Exception e)
                {
                ViewBag.i = 1;
                ViewBag.error = e.Message;
                return View("Consulta");
                }
            
        }*/

        public ActionResult PaginaSiguiente(int id)
        {
            List<Resumenes> l = BD.MasResumenes(id);
            ViewBag.pag = id + 1;
            ViewBag.lista = l;
            if (l.Count == 0)
            {
                l = BD.MasResumenes(id - 1);
                ViewBag.pag = id;
                ViewBag.lista = l;
            }
            return View("index");
        }
        public ActionResult PaginaAnterior(int id)
        {
            List<Resumenes> l = BD.TraerPaginaAnterior(id);
            ViewBag.pag = id - 1;
            ViewBag.lista = l;
            return View("index");
        }
        public ActionResult PaginaSiguienteEsc(int pag,int id)
        {
            List<Resumenes> l = BD.MasResumenesEsc(pag,id);
            ViewBag.pag = pag + 1;
            ViewBag.lista = l;
            ViewBag.id = id;
            ViewBag.nom = BD.TraerNombreEscuelaxId(id);
            if (l.Count == 0)
            {
                l = BD.MasResumenesEsc(pag - 1,id);
                ViewBag.pag = id;
                ViewBag.lista = l;
            }
            return View("Escuela");
        }
        public ActionResult PaginaAnteriorEsc(int pag,int id)
        {
            List<Resumenes> l = BD.TraerPaginaAnteriorEsc(pag,id);
            ViewBag.pag = pag - 1;
            ViewBag.lista = l;
            ViewBag.id = id;
            ViewBag.nom = BD.TraerNombreEscuelaxId(id);
            return View("Escuela");
        }



        /*-------------------------------------------------------------------------*/
        //PARTE LIBROS

        public ActionResult Libros()
        {
            ViewBag.f = null;
            ViewBag.i = 0;
            ViewBag.pag = 1;
            ViewBag.lista = BD.TraerLibros();
            return View();
        }
        public ActionResult MiLibro(int id)
        {
            if (Session["id"] != null)
            {
                string i = Session["id"].ToString();
                int idus = Int32.Parse(i);
                ViewBag.id = id;
                Guardado g = BD.TraerResGuardado(id, idus);
                ViewBag.Guardo = g.fkRes;
                return View("");
            }
            else
            {
                ViewBag.id = id;
                ViewBag.Gusto = false;
                ViewBag.Guardo = -1;
                return View("");
            }

        }


        public ActionResult SubirLibro()
        {
            string i = Session["id"].ToString();
            int idus = Int32.Parse(i);
            Libro miLibro = new Libro();
            miLibro.FkVendedor = idus;
            return View("InsertarLibro");
        }
        public ActionResult DespuesDeInsertarLibro(Libro miLibro)
        {
            string i = Session["id"].ToString();
            int idus = Int32.Parse(i);
            miLibro.FkVendedor = idus;
            if (miLibro.Imagen != null)
            {
                miLibro.NombreImagen = Path.GetFileName(miLibro.Imagen.FileName);   // creo bien
                miLibro.Imagen.SaveAs(Server.MapPath(@"~/Content/Archivos/" + miLibro.NombreImagen));  // bien hermoso
            }
            BD.InsertarLibro(miLibro);
            return RedirectToAction("Libros");
        }
        public ActionResult Comprar(Libro milibro) { // Agrega credenciales
            MercadoPago.SDK.SetAccessToken("TEST-1795964063673032-042602-f31ef928a7f980f5fa09b3734a8e7189 - 213630883");
            string token = Request["token"];
            string payment_method_id = Request["payment_method_id"];

            string issuer_id = Request["issuer_id"];
            int? installments = null;
            Payment payment = new Payment()
            {

                TransactionAmount = float.Parse(milibro.Precio.ToString()),
                Token = token,
                Installments = installments,
                Description = milibro.Descripcion,
                PaymentMethodId = payment_method_id,
                IssuerId = issuer_id,
                Payer = new Payer()
                {
                    Email = milibro.Telefono.ToString()
                }
            };
            // Guarda y postea el pago
            payment.Save();
            ViewBag.f = payment.Status.ToString();
            ViewBag.i = 0;
            ViewBag.lista = BD.TraerLibros();
            return View("Libros");
        }
        public ActionResult BuscarLibros(BuscadorLibros b)
        {
            ViewBag.f = null;
            ViewBag.i = 1;
            ViewBag.lista = BD.TraerBuscadorLibros(b);
            ViewBag.TextoBuscado = b.Busueda;
            return View("Libros");
        }
        public ActionResult FiltrarEscLibro(int id, string BusquedaAnterio)
        {
            ViewBag.f = null;
            ViewBag.lista = BD.BuscadorXEscLibro(BusquedaAnterio, id);
            ViewBag.i = 1;
            ViewBag.TextoBuscado = BusquedaAnterio;
            return View("Libros");
        }

        public ActionResult FiltrarAnoLibro(int id, string BusquedaAnterio)
        {
            ViewBag.lista = BD.BuscadorXAnoLibro(BusquedaAnterio, id);
            ViewBag.i = 1;
            ViewBag.f = null;
            ViewBag.TextoBuscado = BusquedaAnterio;
            return View("Libros");
        }

        public ActionResult FiltrarMatLibro(int id, string BusquedaAnterio)
        {
            ViewBag.lista = BD.BuscadorXMatLibro(BusquedaAnterio, id);
            ViewBag.i = 1;
            ViewBag.f = null;
            ViewBag.TextoBuscado = BusquedaAnterio;
            return View("Libros");
        }
        public ActionResult MisLibros()
        {
            string i = Session["id"].ToString();
            int idus = Int32.Parse(i);
            ViewBag.lista = BD.TraerLibroDelUsuario(idus);
            return View();
        }
        public ActionResult EliminarLi(int id)
        {
            BD.EliminarLibro(id);
            return RedirectToAction("MisLibros");
        }
        public ActionResult ModificarLibro(int id)
        {
            if (Login())
            {
                ViewBag.id = id;
                ViewBag.ListaMaterias = BD.TraerMateria();
                ViewBag.ListaAños = BD.TraerAños();
                ViewBag.ListaEscuelas = BD.TraerEscuelas();
                return View();
            }
            else
            {
                return RedirectToAction("Loguearse");
            }
        }
        [HttpPost]
        public ActionResult DespuesDeModificarLibro(Libro li)
        {
            //Guardar en la BD e ir al index
            if (li.Imagen != null)
            {
                li.NombreImagen = Path.GetFileName(li.Imagen.FileName);   // creo bien
                li.Imagen.SaveAs(Server.MapPath(@"~/Content/Archivos/" + li.NombreImagen));  // bien hermoso
            }
            BD.ModificarLibro(li);
            return RedirectToAction("MisLibros");
        }
        public ActionResult GuardarLibro(int id)
        {
            if (Session["id"] != null)
            {
                string i = Session["id"].ToString();
                int idus = Int32.Parse(i);
                GuardadoLib g = BD.TraerLibGuardado(id, idus);
                if (g.fkLib == -1 && g.fkUsu == -1)
                {
                    BD.AgregarGuardadoLib(id, idus);
                }
                else
                {
                    BD.EliminarGuardadoLib(id, idus);
                }
                
                GuardadoLib ga = BD.TraerLibGuardado(id, idus);
                ViewBag.Guardo = ga.fkLib;
                ViewBag.id = id;
                return View("MiLibro");
            }
            else
            {
                Login2 l = new Login2();
                l.FkResumen = id;
                return View("LoginEspe", l);
            }
        }
        public ActionResult GuardadosLib()
        {
            string g = Session["id"].ToString();
            int idus = Int32.Parse(g);
            List<int> idlibro = BD.TraerIdDeLibroGuardados(idus);
            List<Libro> lista = new List<Libro>();
            foreach (int i in idlibro)
            {
                Libro resu = new Libro();
                resu = BD.TraerLibro(i);
                lista.Add(resu);
            }
            ViewBag.lista = lista;
            return View();
        }

        public ActionResult EliminarGuardadoLibro(int id)
        {
            bool l = Login();
            if (l == true)
            {
                string i = Session["id"].ToString();
                int idus = Int32.Parse(i);
                BD.EliminarGuardadoLib(id, idus);
                ViewBag.id = id;
                GuardadoLib g = BD.TraerLibGuardado(id, idus);
                ViewBag.Guardo = g.fkLib;
                return View("MiLibro");
            }
            else
            {
                return RedirectToAction("Loguearse");
            }
        }
        public ActionResult EliminardeMisGuardadosLib(int id)
        {
            string i = Session["id"].ToString();
            int idus = Int32.Parse(i);
            BD.EliminarGuardadoLib(id, idus);
            return RedirectToAction("GuardadosLib");
        }
        public ActionResult PaginaSiguienteLibros(int id)
        {
            ViewBag.f = null;
            ViewBag.i = 0;
            ViewBag.pag = id+1;
            List<Libro>l= BD.TraerMasLibros(id);
            ViewBag.lista = l;
            if (l.Count == 0)
            {
                l = BD.TraerMasLibros(id-1);
                ViewBag.pag = id;
                ViewBag.lista = l;
            }
            return View("Libros");
        }
        public ActionResult PaginaAnteriorLibros(int id)
        {
            ViewBag.f = null;
            ViewBag.i = 0;
            ViewBag.pag = id - 1;
            List<Libro> l = BD.TraerPaginaAnteriorLibros(id);
            ViewBag.lista = l;
            return View("Libros");
        }
    }
}
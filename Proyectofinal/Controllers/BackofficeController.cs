using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyectofinal.Models;

namespace Proyectofinal.Controllers
{
    public class BackofficeController : Controller
    {
        // GET: Backoffice
        public ActionResult index()
        {
            if (Session["id"] != null)
            {
                string i = Session["id"].ToString();
                int id = Int32.Parse(i);
                Usuarios usu = BD.TraerUsuario(id);
                if (usu.IdUsuario != -1 && usu.Admin == true)
                {
                    Session["id"] = usu.IdUsuario;
                    Session["Admin"] = "true";
                    return View("Home");
                }
                return View();
            }                   
            else
            {
                return View();
            }
        }
        public ActionResult ValidarLoginAdmin(Login log)
        {
            if (ModelState.IsValid)
            {
                Usuarios usu = BD.ValidarLoginUsuario(log.Username, log.Contrasena);
                if (usu.IdUsuario != -1 && usu.Admin == true)
                {                
                    Session["id"] = usu.IdUsuario;
                    Session["Admin"] = "true";
                    return View("Home");
                }
                else
                {
                    return View("index");
                }
            }else
            {
                return View("index");
            }
        }

        public ActionResult Aprobar()
        {
            ViewBag.lista = BD.TraerResumenesSinAprobar();
            return View("");
        }
        public ActionResult VerDenuncias()
        {
            if (Login())
            {
                List<Denuncia> listaDenuncias = new List<Denuncia>();
                listaDenuncias = BD.TraerDenuncias();
                ViewBag.lista = listaDenuncias;
                return View("");
            }
            else
            {
                return RedirectToAction("index");
            }

        }

        public ActionResult Resumen (int id)
        {
            if (Login())
            {
            
            Denuncia d = BD.TraerDenunciaEspe(id);
            ViewBag.id = d.FkResumen;
            ViewBag.idDenu = id;
            return View("");
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        public ActionResult Descartar(int id)
        {
            if (Login())
            {
                BD.BorrarDenuncia(id);
                return RedirectToAction("VerDenuncias");
            }
            else
            {
                return RedirectToAction("index");
            }
            
        }
        public ActionResult EliminarResumenXDenuncia(int id)
        {
            if (Login())
            {
            Denuncia d = BD.TraerDenunciaEspe(id);
            BD.EliminarResumen(d.FkResumen);
            BD.BorrarDenuncia(id);
            return RedirectToAction("VerDenuncias");
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        public ActionResult MiResumen(int id)
        {
            Resumenes res = BD.TraerResumen(id);
            ViewBag.Nombre=res.Nombre;
            ViewBag.Descripcion = res.Descripcion;
            ViewBag.id = id;
            return View();
        }
        public ActionResult Resum(int id)
        {
            Resumenes res = BD.TraerResumen(id);
            ViewBag.Nombre = res.Nombre;
            ViewBag.Descripcion = res.Descripcion;
            ViewBag.id = id;
            return View();
        }

        public ActionResult AprobarResumen (int id)
        {
            if (Login())
            {
                BD.AprobarResumen(id);
            ViewBag.lista = BD.TraerResumenesSinAprobar();
            return View("Aprobar");
        }
            else
            {
                return RedirectToAction("index");
            }
        }
        public ActionResult RechazarResumen(int id)
        {
            BD.EliminarResumen(id);
            ViewBag.lista = BD.TraerResumenesSinAprobar();
            return View("Aprobar");
        }
        public ActionResult Datos()
        {
            if (Login())
            {
               
                ViewBag.lista = BD.TraerCantidadResumenesAprobados();
                ViewBag.lib = BD.TraerCantidadLibrosAprobados();
                ViewBag.libsin = BD.TraerCantidadLibrosSinAprobar();
                ViewBag.ressin = BD.TraerCantidadResumenesSinAprobar();
                ViewBag.usu = BD.TraerCantidadUsuarios();
                ViewBag.vend = BD.TraerCantidadResumenesLibrosVend();
                return View("");
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        public ActionResult InsertarMateria()
        {
            if (Login())
            {
                return View();
            }
            else
            {
                return RedirectToAction("index");
            }
        }
        public ActionResult DespuesDeInsertarMateria(BuscadorLibros b)
        {
            if (Login())
            {

                BD.InsertarMateria(b.Busueda);
                return RedirectToAction("index");
            }
            else
            {
                return RedirectToAction("index");
            }
        }
        public ActionResult InsertarEscuela()
        {
            if (Login())
            {
                return View();
            }
            else
            {
                return RedirectToAction("index");
            }
        }
        public ActionResult DespuesDeInsertarEscuela(BuscadorLibros b)
        {
           
            if (Login())
            {
                BD.InsertarEscuela(b.Busueda);
                return RedirectToAction("index");
            }
            else
            {
                return RedirectToAction("index");
            }
        }
        public ActionResult BorrarMateria()
        {
            if (Login())
            {
                return View();
            }
            else
            {
                return RedirectToAction("index");
            }
        }
        public ActionResult BorrarEsta(int id)
        {
            if (Login())
            {
                BD.BorrarMateria(id);
                return RedirectToAction("BorrarMateria");
            }
            else
            {
                return RedirectToAction("index");
            }

        }

        public ActionResult BorrarEscuela()
        {
            if (Login())
            {
                return View();
            }
            else
            {
                return RedirectToAction("index");
            }
        }
        public ActionResult BorrarLaOtra(int id)
        {
            
            if (Login())
            {
                BD.BorrarEscuela(id);
                return RedirectToAction("BorrarEscuela");
            }
            else
            {
                return RedirectToAction("index");
            }
        }
        public ActionResult BorrarResumen()
        {

            if (Login())
            {
               
                return View();
            }
            else
            {
                return RedirectToAction("index");
            }
        }
        public ActionResult BorrarR(int id)
        {

            if (Login())
            {
                BD.EliminarResumen(id);
                return RedirectToAction("BorrarResumen");
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        public ActionResult BorrarLibros()
        {

            if (Login())
            {

                return View();
            }
            else
            {
                return RedirectToAction("index");
            }
        }
        public ActionResult BorrarL(int id)
        {

            if (Login())
            {
                BD.EliminarLibro(id);
                return RedirectToAction("BorrarLibros");
            }
            else
            {
                return RedirectToAction("index");
            }
        }
        public bool Login()
        {
            bool l;
            if (Session["id"] != null && Session["Admin"] != null)
            {
                l = true;
            }
            else
            {
                l = false;
            }
            return l;
        }
        public ActionResult AprobarL()
        {
            if (Login())
            {
                ViewBag.lista = BD.TraerLibrosSinAprobar();
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult AprobarLibros(int id)
        {
            if (Login())
            {
                BD.AprobarLibro(id);
                ViewBag.lista = BD.TraerLibrosSinAprobar();
                return View("AprobarL");
            }
            else
            {
                return RedirectToAction("index");
            }
        }
        public ActionResult MiLibros (int id)
        {
            ViewBag.id = id;
            return View("MisLibros");
        }
        public ActionResult RechazarLibro(int id)
        {
            BD.EliminarLibro(id);
            ViewBag.lista = BD.TraerLibrosSinAprobar();
            return View("AprobarL");
        }
        public ActionResult AgregarMP(int id)
        {
            ViewBag.id = id;
            ViewBag.ListaMaterias = BD.TraerMateria();
            ViewBag.ListaAños = BD.TraerAños();
            ViewBag.ListaEscuelas = BD.TraerEscuelas();
            return View("");
        }
        [HttpPost]
        public ActionResult DespuesDeAgregarMP(Libro li)
        {
            //Guardar en la BD e ir al index
            if (li.Imagen != null)
            {
                li.NombreImagen = Path.GetFileName(li.Imagen.FileName);   // creo bien
                li.Imagen.SaveAs(Server.MapPath(@"~/Content/Archivos/" + li.NombreImagen));  // bien hermoso
            }
            BD.ModificarLibroBack(li);
            return RedirectToAction("AprobarL");
        }

        public ActionResult Lib(int id)
        {
            ViewBag.id = id;
            return View();
        }

        public ActionResult AprobarTodos()
        {
            BD.AprobarTodosLosResumenes();
            ViewBag.lista = BD.TraerResumenesSinAprobar();
            return View("Aprobar");
        }
        public ActionResult RechazarTodosLosResumenes()
        {
            BD.EliminarTodosLosResumenesSinAprobar();
            ViewBag.lista = BD.TraerResumenesSinAprobar();
            return View("Aprobar");
        }
        public ActionResult AprobarTodosLibros()
        {
            BD.AprobarTodosLosLibros();
            ViewBag.lista = BD.TraerLibrosSinAprobar();
            return View("AprobarL");
        }
        public ActionResult RechazarTodosLosLibros()
        {
            BD.EliminarTodosLosLibrosSinAprobar();
            ViewBag.lista = BD.TraerLibrosSinAprobar();
            return View("AprobarL");
        }
    }
}
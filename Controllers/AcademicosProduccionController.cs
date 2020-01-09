using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGCFIEE.Models;
using System.Diagnostics;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SGCFIEE.Controllers
{
    public class AcademicosProduccionController : Controller
    {
        // GET: /<controller>/
        public IActionResult IndexLibroEE()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        public IActionResult IndexMaterialDidactico()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        public IActionResult IndexMPractica()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        public IActionResult IndexProyectosE()
        {
            List<TablaProyectosEdu> ListProyectosEdu = new List<TablaProyectosEdu>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListProyectosEdu = (from datos in context.ProyectoEducativos
                               join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                               join perio in context.TipoPeriodo on datos.IdPeriodo equals perio.IdPeriodo
                               select new TablaProyectosEdu
                               {
                                   IdProyectoEdu = datos.IdProyectoEducativos,
                                   NumPersonal = acad.NumeroPersonal,
                                   Nombre = acad.Nombre,
                                   ApellidoPaterno = acad.ApellidoPaterno,
                                   ApellidoMaterno = acad.ApellidoMaterno,
                                   Descripcion = datos.Descripcion,
                                   Archivo = datos.Archivo,
                                   Periodo = perio.Nombre,
                                   Status = acad.Status
                               }
                               ).Where(calif => calif.Status == 1).ToList();
            }
            return View(ListProyectosEdu);
        }
        public IActionResult CrearMaterialDidactico()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        public IActionResult EditarMaterialDidactico()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        public IActionResult CrearMPractica()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        public IActionResult EditarMPractica()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        public IActionResult CrearLibroEE()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        public IActionResult EditarLibroEE()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        public IActionResult CrearProyectosE()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList();
                var perio = context.TipoPeriodo.ToList();
                ViewData["academicos"] = acad;
                ViewData["periodos"] = perio;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult GuardarProyectosE(byte[] file,ProyectoEducativos datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListProyectoEducativo = context.ProyectoEducativos.ToList();
                foreach (ProyectoEducativos item in ListProyectoEducativo)
                {
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo)
                    {
                        return RedirectToAction("IndexProyectosE");
                    }
                }

                context.ProyectoEducativos.Add(datos);
                context.SaveChanges();
            }
            if (file != null)
            {
               

            }
            return RedirectToAction("IndexProyectosE");
        }
        public IActionResult EditarProyectosE()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

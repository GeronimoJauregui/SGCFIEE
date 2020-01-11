using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGCFIEE.Models;
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Fiver.Mvc.FileUpload.Models.Home;

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
        public async Task<IActionResult> GuardarProyectosE(IFormFile file, ProyectoEducativos datos)
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
                var new_name_table = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.ProyectoEducativos.Add(datos);
                context.SaveChanges();
            }
            
            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Produccion/ProyectoEducativoInnovador", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexProyectosE");
        }
        public IActionResult EditarProyectosE(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ProyectoEducativos DatosProyectosEdu = context.ProyectoEducativos.Where(s => s.IdProyectoEducativos == id).Single();
                var perio = context.TipoPeriodo.ToList();
                var acad = context.Academicos.ToList();
                ViewData["periodos"] = perio;
                ViewData["academicos"] = acad;
                return View(DatosProyectosEdu);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarProyectosE(IFormFile file,ProyectoEducativos datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListProyectosE = context.ProyectoEducativos.ToList();

                foreach (ProyectoEducativos item in ListProyectosE)
                {
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo && datos.IdProyectoEducativos != item.IdProyectoEducativos)
                    {
                        return RedirectToAction("IndexProyectosE");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.ProyectoEducativos.Where(w => w.IdProyectoEducativos == datos.IdProyectoEducativos).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    var new_name_table = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename();
                    datos.Archivo = new_name_table;
                }
                
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.ProyectoEducativos.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexProyectosE");
            }
            var new_name_file = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Produccion/ProyectoEducativoInnovador", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexProyectosE");
        }
        public IActionResult EliminarProyectosE(int id)
        {
             using(sgcfieeContext context = new sgcfieeContext())
            {
                ProyectoEducativos eliminar = context.ProyectoEducativos.Where(w => w.IdProyectoEducativos == id).Single();
                context.ProyectoEducativos.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexProyectosE");
            }
        }
        public async Task<IActionResult> DescargarProyectosE(string filename)
        {
            
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Produccion/ProyectoEducativoInnovador", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path),Path.GetFileName(path));
        }


        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"},
                {".pptx","application/vnd.openxmlformats-officedocument.presentationml.presentation"},
                {".rar","application/x-rar-compressed"},
                {".zip","application/zip"}
            };
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

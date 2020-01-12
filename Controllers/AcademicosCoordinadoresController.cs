using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGCFIEE.Models;
using System.Diagnostics;
using Fiver.Mvc.FileUpload.Models.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.IO;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SGCFIEE.Controllers
{
    public class AcademicosCoordinadores : Controller
    {
        // GET: /<controller>/
        [Authorize]
        public IActionResult IndexAcademia()
        {
            List<TablaAcademia> TablaAcademia = new List<TablaAcademia>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                TablaAcademia = (from datos in context.CoordinadorAcademia
                               join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                               join perioIni in context.TipoPeriodo on datos.IdFechaInicial equals perioIni.IdPeriodo
                               join perioTer in context.TipoPeriodo on datos.IdFechaCierre equals perioTer.IdPeriodo
                               join academia in context.Academias on datos.IdAcadademia equals academia.IdAcademias
                                 select new TablaAcademia
                               {
                                   IdCoordinadorAcademia = datos.IdCoordinadorAcademia,
                                   NumPersonal = acad.NumeroPersonal,
                                   Nombre = acad.Nombre,
                                   ApellidoPaterno = acad.ApellidoPaterno,
                                   ApellidoMaterno = acad.ApellidoMaterno,
                                   NombreAcademia = academia.Nombre,
                                   Archivo = datos.ArchivoActaA,
                                   PeriodoInicio = perioIni.Nombre,
                                   PeriodoTermino = perioTer.Nombre,
                                   Status = acad.Status
                               }
                               ).ToList();
            }
            return View(TablaAcademia);
        }
        [Authorize]
        public IActionResult CrearAcademia()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList();
                var perio = context.TipoPeriodo.ToList();
                var academia = context.Academias.Where(s => s.Status == 1).ToList();
                ViewData["academicos"] = acad;
                ViewData["periodos"] = perio;
                ViewData["academias"] = academia;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarAcademia(IFormFile file, CoordinadorAcademia datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListAcademia = context.CoordinadorAcademia.ToList();
                foreach (CoordinadorAcademia item in ListAcademia)
                {
                    if (datos.IdAcademico == item.IdAcademico && datos.IdFechaInicial == item.IdFechaInicial && datos.IdFechaCierre == item.IdFechaCierre)
                    {
                        return RedirectToAction("IndexAcademia");
                    }
                }
                var new_name_table = datos.IdFechaInicial+ "_"+ datos.IdFechaCierre + "_" + datos.IdAcademico + "_" + file.GetFilename();
                datos.ArchivoActaA = new_name_table;
                context.CoordinadorAcademia.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdFechaInicial + "_" + datos.IdFechaCierre + "_" + datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Coordinador/Academia", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexAcademia");
        }
        [Authorize]
        public IActionResult EditarAcademia(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CoordinadorAcademia DatosCoorAcademia = context.CoordinadorAcademia.Where(s => s.IdCoordinadorAcademia == id).Single();
                var perio = context.TipoPeriodo.ToList();
                var acad = context.Academicos.ToList();
                var academia = context.Academias.Where(s => s.Status == 1).ToList();
                ViewData["periodos"] = perio;
                ViewData["academicos"] = acad;
                ViewData["academias"] = academia;
                return View(DatosCoorAcademia);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarAcademia(IFormFile file, CoordinadorAcademia datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListAcademia = context.CoordinadorAcademia.ToList();

                foreach (CoordinadorAcademia item in ListAcademia)
                {
                    if (datos.IdAcademico == item.IdAcademico && datos.IdFechaInicial == item.IdFechaInicial && datos.IdFechaCierre == item.IdFechaCierre && datos.IdCoordinadorAcademia != item.IdCoordinadorAcademia)
                    {
                        return RedirectToAction("IndexAcademia");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.CoordinadorAcademia.Where(w => w.IdCoordinadorAcademia == datos.IdCoordinadorAcademia).Single();
                    datos.ArchivoActaA = nomArchivo.ArchivoActaA;
                }
                else
                {
                    var new_name_table = datos.IdFechaInicial + "_" + datos.IdFechaCierre + "_" + datos.IdAcademico + "_" + file.GetFilename();
                    datos.ArchivoActaA = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CoordinadorAcademia.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexAcademia");
            }
            var new_name_file = datos.IdFechaInicial + "_" + datos.IdFechaCierre + "_" + datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Coordinador/Academia", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexAcademia");
        }
        public IActionResult EliminarAcademia(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CoordinadorAcademia eliminar = context.CoordinadorAcademia.Where(w => w.IdCoordinadorAcademia == id).Single();
                context.CoordinadorAcademia.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexAcademia");
            }
        }
        public async Task<IActionResult> DescargarAcademia(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Coordinador/Academia", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }






        [Authorize]
        public IActionResult IndexProgramaTransversal()
        {
            List<TablaProgramaTransversal> ListProgramaTransversal = new List<TablaProgramaTransversal>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListProgramaTransversal = (from datos in context.CoordinadorProgramaTransversal
                                 join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                 join perioIni in context.TipoPeriodo on datos.IdFechaInicial equals perioIni.IdPeriodo
                                 join perioTer in context.TipoPeriodo on datos.IdFechaCierre equals perioTer.IdPeriodo
                                 join programa in context.ProgramasTrasversales on datos.IdPt equals programa.IdProgramasTrasversales
                                 select new TablaProgramaTransversal
                                 {
                                     IdCoordinadorPrograma = datos.IdCoordinadorProgramaTransversal,
                                     NumPersonal = acad.NumeroPersonal,
                                     Nombre = acad.Nombre,
                                     ApellidoPaterno = acad.ApellidoPaterno,
                                     ApellidoMaterno = acad.ApellidoMaterno,
                                     NombrePrograma = programa.Nombre,
                                     Archivo = datos.Evidencia,
                                     PeriodoInicio = perioIni.Nombre,
                                     PeriodoTermino = perioTer.Nombre,
                                     Status = acad.Status
                                 }
                               ).ToList();
            }
            return View(ListProgramaTransversal);
        }
        [Authorize]
        public IActionResult CrearProgramaTransversal()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList();
                var perio = context.TipoPeriodo.ToList();
                var programa = context.ProgramasTrasversales.Where(s => s.Status == 1).ToList();
                ViewData["academicos"] = acad;
                ViewData["periodos"] = perio;
                ViewData["programas"] = programa;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarProgramaTransversal(IFormFile file, CoordinadorProgramaTransversal datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListPrograma = context.CoordinadorProgramaTransversal.ToList();
                foreach (CoordinadorProgramaTransversal item in ListPrograma)
                {
                    if (datos.IdAcademico == item.IdAcademico && datos.IdFechaInicial == item.IdFechaInicial && datos.IdFechaCierre == item.IdFechaCierre)
                    {
                        return RedirectToAction("IndexProgramaTransversal");
                    }
                }
                var new_name_table = datos.IdFechaInicial + "_" + datos.IdFechaCierre + "_" + datos.IdAcademico + "_" + file.GetFilename();
                datos.Evidencia = new_name_table;
                context.CoordinadorProgramaTransversal.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdFechaInicial + "_" + datos.IdFechaCierre + "_" + datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Coordinador/ProgramaTransversal", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexProgramaTransversal");
        }
        [Authorize]
        public IActionResult EditarProgramaTransversal(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CoordinadorProgramaTransversal DatosCoorPrograma = context.CoordinadorProgramaTransversal.Where(s => s.IdCoordinadorProgramaTransversal == id).Single();
                var perio = context.TipoPeriodo.ToList();
                var acad = context.Academicos.ToList();
                var programa = context.ProgramasTrasversales.Where(s => s.Status == 1).ToList();
                ViewData["periodos"] = perio;
                ViewData["academicos"] = acad;
                ViewData["programas"] = programa;
                return View(DatosCoorPrograma);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarProgramaTransversal(IFormFile file, CoordinadorProgramaTransversal datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListPrograma = context.CoordinadorProgramaTransversal.ToList();

                foreach (CoordinadorProgramaTransversal item in ListPrograma)
                {
                    if (datos.IdAcademico == item.IdAcademico && datos.IdFechaInicial == item.IdFechaInicial && datos.IdFechaCierre == item.IdFechaCierre && datos.IdCoordinadorProgramaTransversal != item.IdCoordinadorProgramaTransversal)
                    {
                        return RedirectToAction("IndexProgramaTransversal");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.CoordinadorProgramaTransversal.Where(w => w.IdCoordinadorProgramaTransversal == datos.IdCoordinadorProgramaTransversal).Single();
                    datos.Evidencia = nomArchivo.Evidencia;
                }
                else
                {
                    var new_name_table = datos.IdFechaInicial + "_" + datos.IdFechaCierre + "_" + datos.IdAcademico + "_" + file.GetFilename();
                    datos.Evidencia = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CoordinadorProgramaTransversal.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexProgramaTransversal");
            }
            var new_name_file = datos.IdFechaInicial + "_" + datos.IdFechaCierre + "_" + datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Coordinador/ProgramaTransversal", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexProgramaTransversal");
        }
        public IActionResult EliminarProgramaTransversal(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CoordinadorProgramaTransversal eliminar = context.CoordinadorProgramaTransversal.Where(w => w.IdCoordinadorProgramaTransversal == id).Single();
                context.CoordinadorProgramaTransversal.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexProgramaTransversal");
            }
        }
        public async Task<IActionResult> DescargarProgramaTransversal(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Coordinador/ProgramaTransversal", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
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

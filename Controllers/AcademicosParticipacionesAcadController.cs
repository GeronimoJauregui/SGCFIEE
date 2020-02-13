using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGCFIEE.Models;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Fiver.Mvc.FileUpload.Models.Home;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SGCFIEE.Controllers
{
    public class AcademicosParticipacionesAcadController : Controller
    {
        // GET: /<controller>/
        /*[Authorize]
        public IActionResult IndexArbitraje()
        {
            List<TablaEvaluadores> ListEvaluadores = new List<TablaEvaluadores>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListEvaluadores = (from datos in context.EvaluadoresAcademicos
                                 join acad in context.Academicos on datos.IdAcademicos equals acad.IdAcademicos
                                 join tipo in context.TipoEvaluador on datos.IdTipoEvaluador equals tipo.IdTipoEvaluador
                                 select new TablaEvaluadores
                                 {
                                     IdEvaluadores = datos.IdEvaluadoresAcademicos,
                                     NumPersonal = acad.NumeroPersonal,
                                     Nombre = acad.Nombre,
                                     ApellidoPaterno = acad.ApellidoPaterno,
                                     ApellidoMaterno = acad.ApellidoMaterno,
                                     Archivo = datos.Archivo,
                                     Tipo = tipo.Nombre,
                                     RevisorEvaluador = datos.RevisorEvaluador,
                                     StatusEvaluador = datos.Status,
                                     Status = acad.Status
                                 }
                               ).ToList();
            }
            return View(ListEvaluadores);
        }
        [Authorize]
        public IActionResult CrearArbitraje()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList();
                var tipo = context.TipoEvaluador.ToList();
                ViewData["academicos"] = acad;
                ViewData["evaluadores"] = tipo;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarArbitraje(IFormFile file, EvaluadoresAcademicos datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = datos.IdAcademicos + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.EvaluadoresAcademicos.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdAcademicos + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/ParticipacionAcad/Arbitraje", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexArbitraje");
        }
        [Authorize]
        public IActionResult EditarArbitraje(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                EvaluadoresAcademicos DatosEvaluadores = context.EvaluadoresAcademicos.Where(s => s.IdEvaluadoresAcademicos == id).Single();

                var acad = context.Academicos.ToList();
                var tipo = context.TipoEvaluador.ToList();
                ViewData["academicos"] = acad;
                ViewData["evaluadores"] = tipo;
                return View(DatosEvaluadores);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarArbitraje(IFormFile file, EvaluadoresAcademicos datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.EvaluadoresAcademicos.Where(w => w.IdEvaluadoresAcademicos == datos.IdEvaluadoresAcademicos).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    var new_name_table = datos.IdAcademicos + "_" + file.GetFilename();
                    datos.Archivo = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.EvaluadoresAcademicos.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexArbitraje");
            }
            var new_name_file = datos.IdAcademicos + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/ParticipacionAcad/Arbitraje", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexArbitraje");
        }
        public IActionResult EliminarArbitraje(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                EvaluadoresAcademicos eliminar = context.EvaluadoresAcademicos.Where(w => w.IdEvaluadoresAcademicos == id).Single();
                context.EvaluadoresAcademicos.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexArbitraje");
            }
        }
        public async Task<IActionResult> DescargarArbitraje(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/ParticipacionAcad/Arbitraje", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }






        [Authorize]
        public IActionResult IndexCursos_Talleres()
        {
            List<TablaCursoTaller> ListCursoTaller = new List<TablaCursoTaller>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListCursoTaller = (from datos in context.CursosTalleresAplicacion
                                   join acad in context.Academicos on datos.IdAcademicos equals acad.IdAcademicos
                                   select new TablaCursoTaller
                                   {
                                       IdCursoTaller = datos.IdCursosTalleres,
                                       NumPersonal = acad.NumeroPersonal,
                                       Nombre = acad.Nombre,
                                       ApellidoPaterno = acad.ApellidoPaterno,
                                       ApellidoMaterno = acad.ApellidoMaterno,
                                       Archivo = datos.Archivo,
                                       Tipo = datos.CT,
                                       Titulo = datos.Titulo,
                                       Fecha = datos.Fecha.ToString(),
                                       Status = acad.Status
                                   }
                               ).ToList();
            }
            return View(ListCursoTaller);
        }
        [Authorize]
        public IActionResult CrearCursos_Talleres()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList();
                ViewData["academicos"] = acad;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarCursos_Talleres(IFormFile file, CursosTalleresAplicacion datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = datos.IdAcademicos + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.CursosTalleresAplicacion.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdAcademicos + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/ParticipacionAcad/CursosTalleres", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexCursos_Talleres");
        }
        [Authorize]
        public IActionResult EditarCursos_Talleres(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CursosTalleresAplicacion DatosCursosTalleres = context.CursosTalleresAplicacion.Where(s => s.IdCursosTalleres == id).Single();
                
                var acad = context.Academicos.ToList();
                ViewData["academicos"] = acad;
                string fecha = DatosCursosTalleres.Fecha.ToString();
                string[] resultado = fecha.Split(' ');
                ViewData["fecha"] = resultado[0];
                return View(DatosCursosTalleres);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarCursos_Talleres(IFormFile file, CursosTalleresAplicacion datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.CursosTalleresAplicacion.Where(w => w.IdCursosTalleres == datos.IdCursosTalleres).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    var new_name_table = datos.IdAcademicos + "_" + file.GetFilename();
                    datos.Archivo = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CursosTalleresAplicacion.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexCursos_Talleres");
            }
            var new_name_file = datos.IdAcademicos + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/ParticipacionAcad/CursosTalleres", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexCursos_Talleres");
        }
        public IActionResult EliminarCursos_Talleres(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CursosTalleresAplicacion eliminar = context.CursosTalleresAplicacion.Where(w => w.IdCursosTalleres == id).Single();
                context.CursosTalleresAplicacion.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexCursos_Talleres");
            }
        }
        public async Task<IActionResult> DescargarCursos_Talleres(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/ParticipacionAcad/CursosTalleres", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }




        [Authorize]
        public IActionResult IndexPartCuerpos()
        {
            List<TablaCA> ListCA = new List<TablaCA>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListCA = (from datos in context.CaAcademicos
                                   join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                   join nivel in context.CanivelJerarquico on datos.IdCanivelJerarquico equals nivel.IdCanivelJerarquico
                                   join cuerpo in context.CuerposAcademicos on datos.IdCuerpoAcademico equals cuerpo.IdCuerpoAcademico
                                   select new TablaCA
                                   {
                                       IdCA = datos.IdCa,
                                       NumPersonal = acad.NumeroPersonal,
                                       Nombre = acad.Nombre,
                                       ApellidoPaterno = acad.ApellidoPaterno,
                                       ApellidoMaterno = acad.ApellidoMaterno,
                                       Archivo = datos.Archivo,
                                       Fecha = datos.FechaRegistro.ToString(),
                                       StatusAcademico = datos.Status,
                                       NombreNivel = nivel.Nombre,
                                       NombreCuerpo = cuerpo.Nombre,
                                       Status = acad.Status
                                   }
                               ).ToList();
            }
            return View(ListCA);
        }
        [Authorize]
        public IActionResult CrearPartCuerpos()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList();
                var nivel = context.CanivelJerarquico.ToList();
                var cuerpo = context.CuerposAcademicos.ToList();
                ViewData["academicos"] = acad;
                ViewData["nivel"] = nivel;
                ViewData["cuerpo"] = cuerpo;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarPartCuerpos(IFormFile file, CaAcademicos datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = datos.IdAcademico + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.CaAcademicos.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/ParticipacionAcad/CuerposAcademicos", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexPartCuerpos");
        }
        [Authorize]
        public IActionResult EditarPartCuerpos(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CaAcademicos DatosCA = context.CaAcademicos.Where(s => s.IdCa == id).Single();
                var nivel = context.CanivelJerarquico.ToList();
                var cuerpo = context.CuerposAcademicos.ToList();
                var acad = context.Academicos.ToList();
                ViewData["academicos"] = acad;
                ViewData["nivel"] = nivel;
                ViewData["cuerpo"] = cuerpo;
                string fecha = DatosCA.FechaRegistro.ToString();
                string[] resultado = fecha.Split(' ');
                ViewData["fecha"] = resultado[0];
                return View(DatosCA);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarPartCuerpos(IFormFile file, CaAcademicos datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.CaAcademicos.Where(w => w.IdCa == datos.IdCa).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    var new_name_table = datos.IdAcademico + "_" + file.GetFilename();
                    datos.Archivo = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CaAcademicos.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexPartCuerpos");
            }
            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/ParticipacionAcad/CuerposAcademicos", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexPartCuerpos");
        }
        public IActionResult EliminarArticulos(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CaAcademicos eliminar = context.CaAcademicos.Where(w => w.IdCa == id).Single();
                context.CaAcademicos.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexPartCuerpos");
            }
        }
        public async Task<IActionResult> DescargarPartCuerpos(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/ParticipacionAcad/CuerposAcademicos", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }




        [Authorize]
        public IActionResult IndexPonencias_Conferencias()
        {
            List<TablaPonenciasConferencias> ListPonenciasConferencias = new List<TablaPonenciasConferencias>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListPonenciasConferencias = (from datos in context.PonenciasConferencias
                          join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                          join tipo in context.TipoLocNacInter on datos.IdTipo equals tipo.IdTipo
                          select new TablaPonenciasConferencias
                          {
                              IdPonenConfer = datos.IdPonencias,
                              NumPersonal = acad.NumeroPersonal,
                              Nombre = acad.Nombre,
                              ApellidoPaterno = acad.ApellidoPaterno,
                              ApellidoMaterno = acad.ApellidoMaterno,
                              Archivo = datos.Archivo,
                              Fecha = datos.Fecha.ToString(),
                              NombrePonConf = datos.Nombre,
                              TipoPonenConfe = datos.PonenciaConferencia,
                              tipo = tipo.Nombre,
                              Status = acad.Status
                          }
                            ).ToList();
            }
            return View(ListPonenciasConferencias);
        }
        [Authorize]
        public IActionResult CrearPonencias_Conferencias()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList();
                var nac = context.TipoLocNacInter.ToList();
                ViewData["academicos"] = acad;
                ViewData["nac"] = nac;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarPonencias_Conferencias(IFormFile file, PonenciasConferencias datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = datos.IdAcademico + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.PonenciasConferencias.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/ParticipacionAcad/PonenciasConferencias", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexPonencias_Conferencias");
        }
        [Authorize]
        public IActionResult EditarPonencias_Conferencias(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                PonenciasConferencias DatosPC = context.PonenciasConferencias.Where(s => s.IdPonencias == id).Single();
                var acad = context.Academicos.ToList();
                var nac = context.TipoLocNacInter.ToList();
                ViewData["academicos"] = acad;
                ViewData["nac"] = nac;
                string fecha = DatosPC.Fecha.ToString();
                string[] resultado = fecha.Split(' ');
                ViewData["fecha"] = resultado[0];
                return View(DatosPC);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarPonencias_Conferencias(IFormFile file, PonenciasConferencias datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.PonenciasConferencias.Where(w => w.IdPonencias == datos.IdPonencias).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    var new_name_table = datos.IdAcademico + "_" + file.GetFilename();
                    datos.Archivo = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.PonenciasConferencias.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexPonencias_Conferencias");
            }
            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/ParticipacionAcad/PonenciasConferencias", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexPonencias_Conferencias");
        }
        public IActionResult EliminarPonencias_Conferencias(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                PonenciasConferencias eliminar = context.PonenciasConferencias.Where(w => w.IdPonencias == id).Single();
                context.PonenciasConferencias.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexPonencias_Conferencias");
            }
        }
        public async Task<IActionResult> DescargarPonencias_Conferencias(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/ParticipacionAcad/PonenciasConferencias", filename);

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
        }*/
    }
}

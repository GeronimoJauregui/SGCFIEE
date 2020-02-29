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
        [Authorize]
        public IActionResult IndexArbitraje()
        {
            List<TablaEvaluadores> ListEvaluadores = new List<TablaEvaluadores>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListEvaluadores = (from datos in context.EvaluadoresAcademicos
                                   join tipo in context.TipoEvaluador on datos.IdTipoEvaluador equals tipo.IdTipoEvaluador
                                   select new TablaEvaluadores
                                   {
                                       IdEvaluadores = datos.IdEvaluadoresAcademicos,
                                       Archivo = datos.Archivo,
                                       Tipo = tipo.Nombre,
                                       RevisorEvaluador = datos.RevisorEvaluador,
                                       StatusEvaluador = datos.Status
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
        public async Task<IActionResult> GuardarArbitraje(IFormFile file, EvaluadoresAcademicos datos, int idAcademico, int Lider)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.EvaluadoresAcademicos.Add(datos);
                context.SaveChanges();
                EvaluadoresAcademicos DatosEval = context.EvaluadoresAcademicos.Last();
                var new_name_table = DatosEval.IdEvaluadoresAcademicos + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.EvaluadoresAcademicos.Update(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdEvaluadoresAcademicos + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/ParticipacionAcad/Arbitraje", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                EvaluadoresAcademicos DatosCT = context.EvaluadoresAcademicos.Last();
                Academicosevaluadores info = new Academicosevaluadores();
                info.IdAcademico = idAcademico;
                info.IdEvaluadores = DatosCT.IdEvaluadoresAcademicos;
                info.Lider = Lider;
                context.Academicosevaluadores.Add(info);
                context.SaveChanges();
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


                var tipo = context.TipoEvaluador.ToList();

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
                    var new_name_table = datos.IdEvaluadoresAcademicos + "_" + file.GetFilename();
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
            var new_name_file = datos.IdEvaluadoresAcademicos + "_" + file.GetFilename();
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
                List<Academicosevaluadores> eliminarAcad = context.Academicosevaluadores.Where(f => f.IdEvaluadores == id).ToList();
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    context.Academicosevaluadores.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }
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
        public IActionResult AcademicosArbitraje(int id)
        {
            List<TablaAcadArbitraje> ListAcadArbitraje = new List<TablaAcadArbitraje>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListAcadArbitraje = (from datos in context.Academicosevaluadores
                                     join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                     where datos.IdEvaluadores == id
                                     select new TablaAcadArbitraje
                                     {
                                         IdAcadEvaluadores = datos.IdAcademicosEvaluadores,
                                         NumPersonal = acad.NumeroPersonal,
                                         Nombre = acad.Nombre,
                                         ApellidoPaterno = acad.ApellidoPaterno,
                                         ApellidoMaterno = acad.ApellidoMaterno,
                                         idEvaluadores = datos.IdEvaluadores
                                     }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                ViewData["academicos"] = acade;
                ViewData["idArbitraje"] = id;
            }
            return View(ListAcadArbitraje);
        }
        [Authorize]
        public IActionResult GuardarAcadArbitraje(int idAcademico, int arbitraje, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicosevaluadores AcadArbitraje = new Academicosevaluadores();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListAcad = context.Academicosevaluadores.ToList();
                foreach (Academicosevaluadores item in ListAcad)
                {
                    if (idAcademico == item.IdAcademico && arbitraje == item.IdEvaluadores)
                    {
                        return RedirectToAction("AcademicosArbitraje", new { id = arbitraje });
                    }
                }
                AcadArbitraje.Lider = Lider;
                AcadArbitraje.IdAcademico = idAcademico;
                AcadArbitraje.IdEvaluadores = arbitraje;
                context.Academicosevaluadores.Add(AcadArbitraje);
                context.SaveChanges();
            }
            return RedirectToAction("AcademicosArbitraje", new { id = AcadArbitraje.IdEvaluadores });
        }
        [Authorize]
        public IActionResult EliminarAcadArbitraje(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicosevaluadores eliminar = context.Academicosevaluadores.Where(w => w.IdAcademicosEvaluadores == id).Single();
                context.Academicosevaluadores.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("AcademicosArbitraje", new { id = id_acad });
            }
        }





        [Authorize]
        public IActionResult IndexCursos_Talleres()
        {
            List<TablaCursoTaller> ListCursoTaller = new List<TablaCursoTaller>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListCursoTaller = (from datos in context.CursosTalleresAplicacion
                                   select new TablaCursoTaller
                                   {
                                       IdCursoTaller = datos.IdCursosTalleres,
                                       Archivo = datos.Archivo,
                                       Tipo = datos.CT,
                                       Titulo = datos.Titulo,
                                       Fecha = datos.Fecha.ToString()
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
        public async Task<IActionResult> GuardarCursos_Talleres(IFormFile file, CursosTalleresAplicacion datos, int idAcademico, int Lider)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.CursosTalleresAplicacion.Add(datos);
                context.SaveChanges();
                CursosTalleresAplicacion DatosCT = context.CursosTalleresAplicacion.Last();
                var new_name_table = DatosCT.IdCursosTalleres + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.CursosTalleresAplicacion.Update(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdCursosTalleres + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/ParticipacionAcad/CursosTalleres", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CursosTalleresAplicacion DatosCT = context.CursosTalleresAplicacion.Last();
                Academicoscursostaller info = new Academicoscursostaller();
                info.IdAcademico = idAcademico;
                info.IdCursosDiplo = DatosCT.IdCursosTalleres;
                info.Lider = Lider;
                context.Academicoscursostaller.Add(info);
                context.SaveChanges();
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
                    var new_name_table = datos.IdCursosTalleres + "_" + file.GetFilename();
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
            var new_name_file = datos.IdCursosTalleres + "_" + file.GetFilename();
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
                List<Academicoscursostaller> eliminarAcad = context.Academicoscursostaller.Where(f => f.IdCursosDiplo == id).ToList();
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    context.Academicoscursostaller.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }
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
        public IActionResult AcademicosCursos_Talleres(int id)
        {
            List<TablaAcadCursoTalleres> ListAcadCursoTaller = new List<TablaAcadCursoTalleres>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListAcadCursoTaller = (from datos in context.Academicoscursostaller
                                       join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                       where datos.IdCursosDiplo == id
                                       select new TablaAcadCursoTalleres
                                       {
                                           IdAcadCursoTalleres = datos.IdAcademicosCursosTaller,
                                           NumPersonal = acad.NumeroPersonal,
                                           Nombre = acad.Nombre,
                                           ApellidoPaterno = acad.ApellidoPaterno,
                                           ApellidoMaterno = acad.ApellidoMaterno,
                                           idCursosTalleres = datos.IdCursosDiplo
                                       }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                ViewData["academicos"] = acade;
                ViewData["idCursoTaller"] = id;
            }
            return View(ListAcadCursoTaller);
        }
        [Authorize]
        public IActionResult GuardarAcadCursos_Talleres(int idAcademico, int cursotaller, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicoscursostaller AcadCursoTaller = new Academicoscursostaller();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListAcad = context.Academicoscursostaller.ToList();
                foreach (Academicoscursostaller item in ListAcad)
                {
                    if (idAcademico == item.IdAcademico && cursotaller == item.IdCursosDiplo)
                    {
                        return RedirectToAction("AcademicosCursos_Talleres", new { id = cursotaller });
                    }
                }
                AcadCursoTaller.Lider = Lider;
                AcadCursoTaller.IdAcademico = idAcademico;
                AcadCursoTaller.IdCursosDiplo = cursotaller;
                context.Academicoscursostaller.Add(AcadCursoTaller);
                context.SaveChanges();
            }
            return RedirectToAction("AcademicosCursos_Talleres", new { id = AcadCursoTaller.IdCursosDiplo });
        }
        [Authorize]
        public IActionResult EliminarAcadCursos_Talleres(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicoscursostaller eliminar = context.Academicoscursostaller.Where(w => w.IdAcademicosCursosTaller == id).Single();
                context.Academicoscursostaller.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("AcademicosCursos_Talleres", new { id = id_acad });
            }
        }



        [Authorize]
        public IActionResult IndexPartCuerpos()
        {
            List<TablaCA> ListCA = new List<TablaCA>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListCA = (from datos in context.CaAcademicos
                          join nivel in context.CanivelJerarquico on datos.IdCanivelJerarquico equals nivel.IdCanivelJerarquico
                          join cuerpo in context.CuerposAcademicos on datos.IdCuerpoAcademico equals cuerpo.IdCuerpoAcademico
                          select new TablaCA
                          {
                              IdCA = datos.IdCa,
                              Archivo = datos.Archivo,
                              Fecha = datos.FechaRegistro.ToString(),
                              StatusAcademico = datos.Status,
                              NombreNivel = nivel.Nombre,
                              NombreCuerpo = cuerpo.Nombre
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
        public async Task<IActionResult> GuardarPartCuerpos(IFormFile file, CaAcademicos datos, int idAcademico, int Lider)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.CaAcademicos.Add(datos);
                context.SaveChanges();
                CaAcademicos DatosCA = context.CaAcademicos.Last();
                var new_name_table = DatosCA.IdCa + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.CaAcademicos.Update(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdCa + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/ParticipacionAcad/CuerposAcademicos", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CaAcademicos DatosCA = context.CaAcademicos.Last();
                Academicoscuerposacad info = new Academicoscuerposacad();
                info.IdAcademico = idAcademico;
                info.IdCuerpoAcad = DatosCA.IdCa;
                info.Lider = Lider;
                context.Academicoscuerposacad.Add(info);
                context.SaveChanges();
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
                    var new_name_table = datos.IdCa + "_" + file.GetFilename();
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
            var new_name_file = datos.IdCa + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/ParticipacionAcad/CuerposAcademicos", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexPartCuerpos");
        }
        public IActionResult EliminarPartCuerpos(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                List<Academicoscuerposacad> eliminarAcad = context.Academicoscuerposacad.Where(f => f.IdCuerpoAcad == id).ToList();
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    context.Academicoscuerposacad.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }

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
        public IActionResult AcademicosPartCuerpos(int id)
        {
            List<TablaAcadPartCuerpos> ListAcadPartCuerpos = new List<TablaAcadPartCuerpos>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListAcadPartCuerpos = (from datos in context.Academicoscuerposacad
                                       join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                       where datos.IdCuerpoAcad == id
                                       select new TablaAcadPartCuerpos
                                       {
                                           IdAcadCuerpoAcad = datos.IdAcademicosCuerposAcad,
                                           NumPersonal = acad.NumeroPersonal,
                                           Nombre = acad.Nombre,
                                           ApellidoPaterno = acad.ApellidoPaterno,
                                           ApellidoMaterno = acad.ApellidoMaterno,
                                           idCuerpo = datos.IdCuerpoAcad
                                       }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                ViewData["academicos"] = acade;
                ViewData["idCuerpoAcad"] = id;
            }
            return View(ListAcadPartCuerpos);
        }
        [Authorize]
        public IActionResult GuardarAcadPartCuerpos(int idAcademico, int cuerpoacademico, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicoscuerposacad AcadCuerpoAcad = new Academicoscuerposacad();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListAcad = context.Academicoscuerposacad.ToList();
                foreach (Academicoscuerposacad item in ListAcad)
                {
                    if (idAcademico == item.IdAcademico && cuerpoacademico == item.IdCuerpoAcad)
                    {
                        return RedirectToAction("AcademicosPartCuerpos", new { id = cuerpoacademico });
                    }
                }
                AcadCuerpoAcad.Lider = Lider;
                AcadCuerpoAcad.IdAcademico = idAcademico;
                AcadCuerpoAcad.IdCuerpoAcad = cuerpoacademico;
                context.Academicoscuerposacad.Add(AcadCuerpoAcad);
                context.SaveChanges();
            }
            return RedirectToAction("AcademicosPartCuerpos", new { id = AcadCuerpoAcad.IdCuerpoAcad });
        }
        [Authorize]
        public IActionResult EliminarAcadPartCuerpos(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicoscuerposacad eliminar = context.Academicoscuerposacad.Where(w => w.IdAcademicosCuerposAcad == id).Single();
                context.Academicoscuerposacad.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("AcademicosPartCuerpos", new { id = id_acad });
            }
        }



        [Authorize]
        public IActionResult IndexPonencias_Conferencias()
        {
            List<TablaPonenciasConferencias> ListPonenciasConferencias = new List<TablaPonenciasConferencias>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListPonenciasConferencias = (from datos in context.PonenciasConferencias
                                             join tipo in context.TipoLocNacInter on datos.IdTipo equals tipo.IdTipo
                                             select new TablaPonenciasConferencias
                                             {
                                                 IdPonenConfer = datos.IdPonencias,
                                                 Archivo = datos.Archivo,
                                                 Fecha = datos.Fecha.ToString(),
                                                 NombrePonConf = datos.Nombre,
                                                 TipoPonenConfe = datos.PonenciaConferencia,
                                                 tipo = tipo.Nombre
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
        public async Task<IActionResult> GuardarPonencias_Conferencias(IFormFile file, PonenciasConferencias datos, int idAcademico, int Lider)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.PonenciasConferencias.Add(datos);
                context.SaveChanges();
                PonenciasConferencias DatosPC = context.PonenciasConferencias.Last();
                var new_name_table = DatosPC.IdPonencias + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.PonenciasConferencias.Update(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdPonencias + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/ParticipacionAcad/PonenciasConferencias", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                PonenciasConferencias DatosPC = context.PonenciasConferencias.Last();
                Academicoponenciasconf info = new Academicoponenciasconf();
                info.IdAcademico = idAcademico;
                info.IdPonenciasConf = DatosPC.IdPonencias;
                info.Lider = Lider;
                context.Academicoponenciasconf.Add(info);
                context.SaveChanges();
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

                var nac = context.TipoLocNacInter.ToList();

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
                    var new_name_table = datos.IdPonencias + "_" + file.GetFilename();
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
            var new_name_file = datos.IdPonencias + "_" + file.GetFilename();
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
                List<Academicoponenciasconf> eliminarAcad = context.Academicoponenciasconf.Where(f => f.IdPonenciasConf == id).ToList();
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    context.Academicoponenciasconf.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }
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
        [Authorize]
        public IActionResult AcademicosPonencias_Conferencias(int id)
        {
            List<TablaAcadPonenciaConf> ListAcadPonenciasConfe = new List<TablaAcadPonenciaConf>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListAcadPonenciasConfe = (from datos in context.Academicoponenciasconf
                                          join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                          where datos.IdPonenciasConf == id
                                          select new TablaAcadPonenciaConf
                                          {
                                              IdAcadPonenciaConfe = datos.IdAcademicoPonenciasConf,
                                              NumPersonal = acad.NumeroPersonal,
                                              Nombre = acad.Nombre,
                                              ApellidoPaterno = acad.ApellidoPaterno,
                                              ApellidoMaterno = acad.ApellidoMaterno,
                                              idPonencia = datos.IdPonenciasConf
                                          }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                ViewData["academicos"] = acade;
                ViewData["idPonencia"] = id;
            }
            return View(ListAcadPonenciasConfe);
        }
        [Authorize]
        public IActionResult GuardarAcadPonencias_Conferencias(int idAcademico, int ponencia, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicoponenciasconf AcadPonenciaConfe = new Academicoponenciasconf();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListAcad = context.Academicoponenciasconf.ToList();
                foreach (Academicoponenciasconf item in ListAcad)
                {
                    if (idAcademico == item.IdAcademico && ponencia == item.IdPonenciasConf)
                    {
                        return RedirectToAction("AcademicosPonencias_Conferencias", new { id = ponencia });
                    }
                }
                AcadPonenciaConfe.Lider = Lider;
                AcadPonenciaConfe.IdAcademico = idAcademico;
                AcadPonenciaConfe.IdPonenciasConf = ponencia;
                context.Academicoponenciasconf.Add(AcadPonenciaConfe);
                context.SaveChanges();
            }
            return RedirectToAction("AcademicosPonencias_Conferencias", new { id = AcadPonenciaConfe.IdPonenciasConf });
        }
        [Authorize]
        public IActionResult EliminarAcadPonencias_Conferencias(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicoponenciasconf eliminar = context.Academicoponenciasconf.Where(w => w.IdAcademicoPonenciasConf == id).Single();
                context.Academicoponenciasconf.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("AcademicosPonencias_Conferencias", new { id = id_acad });
            }
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

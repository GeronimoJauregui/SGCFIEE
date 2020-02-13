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
    public class AcademicosComisionesController : Controller
    {
        // GET: /<controller>/
        /*[Authorize]
        public IActionResult IndexJurExperiencia()
        {
            List<TablaJurExperiencia> ListJurExperiencia = new List<TablaJurExperiencia>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListJurExperiencia = (from datos in context.JuradoExperienciaRecepcional
                                   join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                   join trabajo in context.TrabajosRecepcionales on datos.IdTr equals trabajo.IdTrabajosRecepcionales
                                   join alum in context.Alumnos on trabajo.IdAlumno equals alum.IdAlumnos
                                   join datosG in context.DatosPersonales on alum.RDatosPerson equals datosG.IdDatosPersonales
                                   join modalidad in context.TipoModalidad on trabajo.IdModalidad equals modalidad.IdModalidad
                                   select new TablaJurExperiencia
                                   {
                                       IdJurado = datos.IdJer,
                                       NumPersonal = acad.NumeroPersonal,
                                       Nombre = acad.Nombre,
                                       ApellidoPaterno = acad.ApellidoPaterno,
                                       ApellidoMaterno = acad.ApellidoMaterno,
                                       NombreAlum = datosG.Nombre,
                                       ApellidoPaternoAlum = datosG.ApellidoPaterno,
                                       ApellidoMaternoAlum = datosG.ApellidoMaterno,
                                       Modalidad = modalidad.Nombre,
                                       NombreTrabajo = trabajo.NombreTrabajo,
                                       Fecha = trabajo.FechaPresentacion.ToString(),
                                       Archivo = datos.Archivo,
                                       JuradoPrejurado = datos.JuradoPrejurado,
                                       Status = acad.Status
                                   }
                               ).Where(s => s.JuradoPrejurado == 1).ToList();
            }
            return View(ListJurExperiencia);
        }
        [Authorize]
        public IActionResult CrearJurExperiencia()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                List<TrabajosRecepcionales> datTR = new List<TrabajosRecepcionales>();
                List<Alumnos> datAlum = new List<Alumnos>();
                List<Alumnos> datosfin = new List<Alumnos>();
                List<DatosPersonales> datGene = new List<DatosPersonales>();
                List<DatosPersonales> datosGene = new List<DatosPersonales>();
                var acad = context.Academicos.ToList();
                
                datTR = context.TrabajosRecepcionales.ToList();
                datAlum = context.Alumnos.ToList();
                datGene = context.DatosPersonales.ToList();

                foreach (TrabajosRecepcionales item in datTR)
                {
                    foreach (Alumnos item2 in datAlum)
                    {
                        if(item.IdAlumno == item2.IdAlumnos)
                        {
                            datosfin.Add(item2);
                        }
                    }
                    
                }
                foreach (Alumnos item in datosfin)
                {
                    foreach (DatosPersonales item2 in datGene)
                    {
                        if (item.RDatosPerson == item2.IdDatosPersonales)
                        {
                            datosGene.Add(item2);
                        }
                    }
                }
                ViewData["datosGene"] = datosGene;
                ViewData["academicos"] = acad;
                
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarJurExperiencia(IFormFile file, JuradoExperienciaRecepcional datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var datosAlum = context.Alumnos.Where(s => s.RDatosPerson == datos.IdTr).Single();
                var datosTR = context.TrabajosRecepcionales.Where(a => a.IdAlumno == datosAlum.IdAlumnos).Single();
                datos.IdTr = datosTR.IdTrabajosRecepcionales;
                var new_name_table = datos.IdAcademico + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.JuradoExperienciaRecepcional.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Comisiones/JuradoExperienciaRecepcional", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexJurExperiencia");
        }
        [Authorize]
        public IActionResult EditarJurExperiencia(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                JuradoExperienciaRecepcional DatosJur = context.JuradoExperienciaRecepcional.Where(s => s.IdJer == id).Single();

                /**var idTrabajoRecep = DatosJur.IdTr;
                var idAlumno = context.TrabajosRecepcionales.Where(w => w.IdTrabajosRecepcionales == idTrabajoRecep).Single();
                Alumnos idDatoAlumno = context.Alumnos.Where(x => x.IdAlumnos == idAlumno.IdAlumno).Single();
                var dato = idDatoAlumno.RDatosPerson;
                ViewData["datoComparar"] = dato;**/

                /*var acad = context.Academicos.ToList();
                ViewData["academicos"] = acad;


                List<TrabajosRecepcionales> datTR = new List<TrabajosRecepcionales>();
                List<Alumnos> datAlum = new List<Alumnos>();
                List<Alumnos> datosfin = new List<Alumnos>();
                List<DatosPersonales> datGene = new List<DatosPersonales>();
                List<DatosPersonales> datosGene = new List<DatosPersonales>();

                datTR = context.TrabajosRecepcionales.ToList();
                datAlum = context.Alumnos.ToList();
                datGene = context.DatosPersonales.ToList();

                foreach (TrabajosRecepcionales item in datTR)
                {
                    foreach (Alumnos item2 in datAlum)
                    {
                        if (item.IdAlumno == item2.IdAlumnos)
                        {
                            datosfin.Add(item2);
                        }
                    }

                }
                foreach (Alumnos item in datosfin)
                {
                    foreach (DatosPersonales item2 in datGene)
                    {
                        if (item.RDatosPerson == item2.IdDatosPersonales)
                        {
                            datosGene.Add(item2);
                        }
                    }
                }
                ViewData["datosGene"] = datosGene;

                return View(DatosJur);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarJurExperiencia(IFormFile file,JuradoExperienciaRecepcional datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.JuradoExperienciaRecepcional.Where(w => w.IdJer == datos.IdJer).Single();
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
                var datosAlum2 = context.Alumnos.Where(s => s.RDatosPerson == datos.IdTr).Single();
                var datosTR2 = context.TrabajosRecepcionales.Where(a => a.IdAlumno == datosAlum2.IdAlumnos).Single();
                datos.IdTr = datosTR2.IdTrabajosRecepcionales;
                context.JuradoExperienciaRecepcional.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexJurExperiencia");
            }
            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Comisiones/JuradoExperienciaRecepcional", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexJurExperiencia");
        }
        public IActionResult EliminarJurExperiencia(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                JuradoExperienciaRecepcional eliminar = context.JuradoExperienciaRecepcional.Where(w => w.IdJer == id).Single();
                context.JuradoExperienciaRecepcional.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexJurExperiencia");
            }
        }
        public async Task<IActionResult> DescargarJurExperiencia(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Comisiones/JuradoExperienciaRecepcional", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }





        [Authorize]
        public IActionResult IndexJurOposicion()
        {
            List<TablaJurOposicion> ListJurOposicion = new List<TablaJurOposicion>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListJurOposicion = (from datos in context.JuradoExamenOposicion
                                      join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                      join ee in context.ExperienciaEducativa on datos.IdEe equals ee.IdExperienciaEducativa
                                      select new TablaJurOposicion
                                      {
                                          IdJurado = datos.IdJexposicion,
                                          NumPersonal = acad.NumeroPersonal,
                                          Nombre = acad.Nombre,
                                          ApellidoPaterno = acad.ApellidoPaterno,
                                          ApellidoMaterno = acad.ApellidoMaterno,
                                          Ee = ee.Nombre,
                                          TipoExamen = datos.TipoExamen,
                                          Fecha = datos.Fecha.ToString(),
                                          Archivo = datos.Archivo,
                                          Status = acad.Status
                                      }
                               ).ToList();
            }
            return View(ListJurOposicion);
        }
        [Authorize]
        public IActionResult CrearJurOposicion()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList();
                var Ee = context.ExperienciaEducativa.ToList();
                ViewData["academicos"] = acad;
                ViewData["ExperienciasE"] = Ee;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarJurOposicion(IFormFile file, JuradoExamenOposicion datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = datos.IdAcademico + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.JuradoExamenOposicion.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Comisiones/JuradoOposicion", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexJurOposicion");
        }
        [Authorize]
        public IActionResult EditarJurOposicion(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                JuradoExamenOposicion DatosJur = context.JuradoExamenOposicion.Where(s => s.IdJexposicion == id).Single();

                var acad = context.Academicos.ToList();
                var Ee = context.ExperienciaEducativa.ToList();
                ViewData["academicos"] = acad;
                ViewData["ExperienciasE"] = Ee;
                string fecha = DatosJur.Fecha.ToString();
                string[] resultado = fecha.Split(' ');
                ViewData["fecha"] = resultado[0];
                return View(DatosJur);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarJurOposicion(IFormFile file, JuradoExamenOposicion datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.JuradoExamenOposicion.Where(w => w.IdJexposicion == datos.IdJexposicion).Single();
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
                context.JuradoExamenOposicion.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexJurOposicion");
            }
            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Comisiones/JuradoOposicion", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexJurOposicion");
        }
        public IActionResult EliminarJurOposicion(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                JuradoExamenOposicion eliminar = context.JuradoExamenOposicion.Where(w => w.IdJexposicion == id).Single();
                context.JuradoExamenOposicion.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexJurOposicion");
            }
        }
        public async Task<IActionResult> DescargarJurOposicion(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Comisiones/JuradoOposicion", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }





        [Authorize]
        public IActionResult IndexPartRedisenio()
        {
            List<TablaRedisenio> ListRedisenio = new List<TablaRedisenio>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListRedisenio = (from datos in context.RediseñoPlanEstudios
                                    join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                    join programa in context.ProgramaEducativo on datos.IdPrograma equals programa.IdProgramaEducativo
                                    select new TablaRedisenio
                                    {
                                        IdPlan = datos.IdRediseñoActualizacionEstudios,
                                        NumPersonal = acad.NumeroPersonal,
                                        Nombre = acad.Nombre,
                                        ApellidoPaterno = acad.ApellidoPaterno,
                                        ApellidoMaterno = acad.ApellidoMaterno,
                                        Area = datos.Area,
                                        NombrePrograma = programa.Nombre,
                                        Tipo = datos.CoordinadorColaborador,
                                        Archivo = datos.Archivo,
                                        Status = acad.Status
                                    }
                               ).ToList();
            }
            return View(ListRedisenio);
        }
        [Authorize]
        public IActionResult CrearPartRedisenio()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList();
                var programa = context.ProgramaEducativo.ToList();
                ViewData["academicos"] = acad;
                ViewData["programa"] = programa;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarPartRedisenio(IFormFile file, RediseñoPlanEstudios datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = datos.IdAcademico + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.RediseñoPlanEstudios.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Comisiones/RedesenioPlanEstudio", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexPartRedisenio");
        }
        [Authorize]
        public IActionResult EditarPartRedisenio(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                RediseñoPlanEstudios DatosPlan = context.RediseñoPlanEstudios.Where(s => s.IdRediseñoActualizacionEstudios == id).Single();

                var acad = context.Academicos.ToList();
                var programa = context.ProgramaEducativo.ToList();
                ViewData["academicos"] = acad;
                ViewData["programa"] = programa;
                return View(DatosPlan);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarPartRedisenio(IFormFile file, RediseñoPlanEstudios datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.RediseñoPlanEstudios.Where(w => w.IdRediseñoActualizacionEstudios == datos.IdRediseñoActualizacionEstudios).Single();
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
                context.RediseñoPlanEstudios.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexPartRedisenio");
            }
            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Comisiones/RedesenioPlanEstudio", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexPartRedisenio");
        }
        public IActionResult EliminarPartRedesenio(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                RediseñoPlanEstudios eliminar = context.RediseñoPlanEstudios.Where(w => w.IdRediseñoActualizacionEstudios == id).Single();
                context.RediseñoPlanEstudios.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexPartRedisenio");
            }
        }
        public async Task<IActionResult> DescargarPartRedesenio(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Comisiones/RedesenioPlanEstudio", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }




        [Authorize]
        public IActionResult IndexPLADEA()
        {
            List<TablaPladea> ListPladea = new List<TablaPladea>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListPladea = (from datos in context.ParticipacionPladea
                                    join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                    select new TablaPladea
                                    {
                                        IdJurado = datos.IdPladea,
                                        NumPersonal = acad.NumeroPersonal,
                                        Nombre = acad.Nombre,
                                        ApellidoPaterno = acad.ApellidoPaterno,
                                        ApellidoMaterno = acad.ApellidoMaterno,
                                        Comision = datos.Comision,
                                        Meta = datos.Meta,
                                        Accion = datos.Accion,
                                        Fecha = datos.Fecha.ToString(),
                                        Archivo = datos.Archivo,
                                        Status = acad.Status
                                    }
                               ).ToList();
            }
            return View(ListPladea);
        }
        [Authorize]
        public IActionResult CrearPLADEA()
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
        public async Task<IActionResult> GuardarPLADEA(IFormFile file, ParticipacionPladea datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = datos.IdAcademico + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.ParticipacionPladea.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Comisiones/PLADEA", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexPLADEA");
        }
        [Authorize]
        public IActionResult EditarPLADEA(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ParticipacionPladea DatosPladea = context.ParticipacionPladea.Where(s => s.IdPladea == id).Single();

                var acad = context.Academicos.ToList();
                ViewData["academicos"] = acad;
                string fecha = DatosPladea.Fecha.ToString();
                string[] resultado = fecha.Split(' ');
                ViewData["fecha"] = resultado[0];
                return View(DatosPladea);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarPLADEA(IFormFile file, ParticipacionPladea datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.ParticipacionPladea.Where(w => w.IdPladea == datos.IdPladea).Single();
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
                context.ParticipacionPladea.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexPLADEA");
            }
            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Comisiones/PLADEA", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexPLADEA");
        }
        public IActionResult EliminarPLADEA(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ParticipacionPladea eliminar = context.ParticipacionPladea.Where(w => w.IdPladea == id).Single();
                context.ParticipacionPladea.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexPLADEA");
            }
        }
        public async Task<IActionResult> DescargarPLADEA(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Comisiones/PLADEA", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }




        [Authorize]
        public IActionResult IndexPreJurExperiencia()
        {
            List<TablaPreJurExperiencia> ListPreJurExperiencia = new List<TablaPreJurExperiencia>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListPreJurExperiencia = (from datos in context.JuradoExperienciaRecepcional
                                      join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                      join trabajo in context.TrabajosRecepcionales on datos.IdTr equals trabajo.IdTrabajosRecepcionales
                                      join alum in context.Alumnos on trabajo.IdAlumno equals alum.IdAlumnos
                                      join datosG in context.DatosPersonales on alum.RDatosPerson equals datosG.IdDatosPersonales
                                      join modalidad in context.TipoModalidad on trabajo.IdModalidad equals modalidad.IdModalidad
                                      select new TablaPreJurExperiencia
                                      {
                                          IdJurado = datos.IdJer,
                                          NumPersonal = acad.NumeroPersonal,
                                          Nombre = acad.Nombre,
                                          ApellidoPaterno = acad.ApellidoPaterno,
                                          ApellidoMaterno = acad.ApellidoMaterno,
                                          NombreAlum = datosG.Nombre,
                                          ApellidoPaternoAlum = datosG.ApellidoPaterno,
                                          ApellidoMaternoAlum = datosG.ApellidoMaterno,
                                          Modalidad = modalidad.Nombre,
                                          NombreTrabajo = trabajo.NombreTrabajo,
                                          Archivo = datos.Archivo,
                                          JuradoPrejurado = datos.JuradoPrejurado,
                                          Status = acad.Status
                                      }
                               ).Where(s => s.JuradoPrejurado == 0).ToList();
            }
            return View(ListPreJurExperiencia);
        }
        [Authorize]
        public IActionResult CrearPreJurExperiencia()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                List<TrabajosRecepcionales> datTR = new List<TrabajosRecepcionales>();
                List<Alumnos> datAlum = new List<Alumnos>();
                List<Alumnos> datosfin = new List<Alumnos>();
                List<DatosPersonales> datGene = new List<DatosPersonales>();
                List<DatosPersonales> datosGene = new List<DatosPersonales>();
                var acad = context.Academicos.ToList();

                datTR = context.TrabajosRecepcionales.ToList();
                datAlum = context.Alumnos.ToList();
                datGene = context.DatosPersonales.ToList();

                foreach (TrabajosRecepcionales item in datTR)
                {
                    foreach (Alumnos item2 in datAlum)
                    {
                        if (item.IdAlumno == item2.IdAlumnos)
                        {
                            datosfin.Add(item2);
                        }
                    }

                }
                foreach (Alumnos item in datosfin)
                {
                    foreach (DatosPersonales item2 in datGene)
                    {
                        if (item.RDatosPerson == item2.IdDatosPersonales)
                        {
                            datosGene.Add(item2);
                        }
                    }
                }
                ViewData["datosGene"] = datosGene;
                ViewData["academicos"] = acad;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarPreJurExperiencia(IFormFile file, JuradoExperienciaRecepcional datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var datosAlum = context.Alumnos.Where(s => s.RDatosPerson == datos.IdTr).Single();
                var datosTR = context.TrabajosRecepcionales.Where(a => a.IdAlumno == datosAlum.IdAlumnos).Single();
                datos.IdTr = datosTR.IdTrabajosRecepcionales;
                var new_name_table = datos.IdAcademico + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.JuradoExperienciaRecepcional.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Comisiones/PreJuradoExperienciaRecepcional", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexPreJurExperiencia");
        }
        [Authorize]
        public IActionResult EditarPreJurExperiencia(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                JuradoExperienciaRecepcional DatosJur = context.JuradoExperienciaRecepcional.Where(s => s.IdJer == id).Single();

                var acad = context.Academicos.ToList();
                ViewData["academicos"] = acad;

                List<TrabajosRecepcionales> datTR = new List<TrabajosRecepcionales>();
                List<Alumnos> datAlum = new List<Alumnos>();
                List<Alumnos> datosfin = new List<Alumnos>();
                List<DatosPersonales> datGene = new List<DatosPersonales>();
                List<DatosPersonales> datosGene = new List<DatosPersonales>();

                datTR = context.TrabajosRecepcionales.ToList();
                datAlum = context.Alumnos.ToList();
                datGene = context.DatosPersonales.ToList();

                foreach (TrabajosRecepcionales item in datTR)
                {
                    foreach (Alumnos item2 in datAlum)
                    {
                        if (item.IdAlumno == item2.IdAlumnos)
                        {
                            datosfin.Add(item2);
                        }
                    }

                }
                foreach (Alumnos item in datosfin)
                {
                    foreach (DatosPersonales item2 in datGene)
                    {
                        if (item.RDatosPerson == item2.IdDatosPersonales)
                        {
                            datosGene.Add(item2);
                        }
                    }
                }
                ViewData["datosGene"] = datosGene;

                return View(DatosJur);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarPreJurExperiencia(IFormFile file, JuradoExperienciaRecepcional datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.JuradoExperienciaRecepcional.Where(w => w.IdJer == datos.IdJer).Single();
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
                var datosAlum2 = context.Alumnos.Where(s => s.RDatosPerson == datos.IdTr).Single();
                var datosTR2 = context.TrabajosRecepcionales.Where(a => a.IdAlumno == datosAlum2.IdAlumnos).Single();
                datos.IdTr = datosTR2.IdTrabajosRecepcionales;
                context.JuradoExperienciaRecepcional.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexPreJurExperiencia");
            }
            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Comisiones/PreJuradoExperienciaRecepcional", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexPreJurExperiencia");
        }
        public IActionResult EliminarPreJurExperiencia(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                JuradoExperienciaRecepcional eliminar = context.JuradoExperienciaRecepcional.Where(w => w.IdJer == id).Single();
                context.JuradoExperienciaRecepcional.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexPreJurExperiencia");
            }
        }
        public async Task<IActionResult> DescargarPreJurExperiencia(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Comisiones/PreJuradoExperienciaRecepcional", filename);

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

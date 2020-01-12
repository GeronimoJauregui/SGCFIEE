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
        [Authorize]
        public IActionResult IndexLibroEE()
        {
            List<TablaLibroEE> ListLibroEE = new List<TablaLibroEE>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListLibroEE = (from datos in context.Libroee
                                    join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                    join perio in context.TipoPeriodo on datos.IdPeriodo equals perio.IdPeriodo
                                    select new TablaLibroEE
                                    {
                                        IdLibroEE = datos.IdLibroEe,
                                        NumPersonal = acad.NumeroPersonal,
                                        Nombre = acad.Nombre,
                                        ApellidoPaterno = acad.ApellidoPaterno,
                                        ApellidoMaterno = acad.ApellidoMaterno,
                                        NombreLibro = datos.Nombre,
                                        Archivo = datos.Archivo,
                                        Periodo = perio.Nombre,
                                        Status = acad.Status
                                    }
                               ).Where(calif => calif.Status == 1).ToList();
            }
            return View(ListLibroEE);
        }
        [Authorize]
        public IActionResult IndexMaterialDidactico()
        {
            List<TablaMaterialD> ListMaterialD = new List<TablaMaterialD>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListMaterialD = (from datos in context.MateriaDidactico
                               join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                               join perio in context.TipoPeriodo on datos.IdPeriodo equals perio.IdPeriodo
                               select new TablaMaterialD
                               {
                                   IdMDidactico = datos.IdMateriaDidactico,
                                   NumPersonal = acad.NumeroPersonal,
                                   Nombre = acad.Nombre,
                                   ApellidoPaterno = acad.ApellidoPaterno,
                                   ApellidoMaterno = acad.ApellidoMaterno,
                                   NotasClase = datos.NotasClase,
                                   Acetatos = datos.Acetatos,
                                   Videos = datos.Videos,
                                   Programas = datos.Programas,
                                   Prototipos = datos.Prototipos,
                                   Archivo = datos.Acta,
                                   Periodo = perio.Nombre,
                                   Status = acad.Status
                               }
                               ).Where(calif => calif.Status == 1).ToList();
            }
            return View(ListMaterialD);
        }
        [Authorize]
        public IActionResult IndexMPractica()
        {
            List<TablaMPractica> ListMPractica = new List<TablaMPractica>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListMPractica = (from datos in context.ManualesPractica
                               join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                               join perio in context.TipoPeriodo on datos.IdPeriodo equals perio.IdPeriodo
                               select new TablaMPractica
                               {
                                   IdMPractica = datos.IdMaterialesPractica,
                                   NumPersonal = acad.NumeroPersonal,
                                   Nombre = acad.Nombre,
                                   ApellidoPaterno = acad.ApellidoPaterno,
                                   ApellidoMaterno = acad.ApellidoMaterno,
                                   NombreManual = datos.Nombre,
                                   Archivo = datos.Archivo,
                                   Periodo = perio.Nombre,
                                   Status = acad.Status
                               }
                               ).Where(calif => calif.Status == 1).ToList();
            }
            return View(ListMPractica);
        }
        [Authorize]
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


        [Authorize]
        public IActionResult CrearMaterialDidactico()
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
        public async Task<IActionResult> GuardarMaterialDidactico(IFormFile file, MateriaDidactico datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListMDidactico = context.MateriaDidactico.ToList();
                foreach (MateriaDidactico item in ListMDidactico)
                {
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo)
                    {
                        return RedirectToAction("IndexMaterialDidactico");
                    }
                }
                var new_name_table = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename();
                datos.Acta = new_name_table;
                context.MateriaDidactico.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Produccion/MaterialDidactico", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexMaterialDidactico");
        }
        [Authorize]
        public IActionResult EditarMaterialDidactico(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                MateriaDidactico DatosMDidactico = context.MateriaDidactico.Where(s => s.IdMateriaDidactico == id).Single();
                var perio = context.TipoPeriodo.ToList();
                var acad = context.Academicos.ToList();
                ViewData["periodos"] = perio;
                ViewData["academicos"] = acad;
                return View(DatosMDidactico);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarMaterialDidactico(IFormFile file, MateriaDidactico datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListMaterialDidactico = context.MateriaDidactico.ToList();

                foreach (MateriaDidactico item in ListMaterialDidactico)
                {
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo && datos.IdMateriaDidactico != item.IdMateriaDidactico)
                    {
                        return RedirectToAction("IndexMaterialDidactico");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.MateriaDidactico.Where(w => w.IdMateriaDidactico == datos.IdMateriaDidactico).Single();
                    datos.Acta = nomArchivo.Acta;
                }
                else
                {
                    var new_name_table = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename();
                    datos.Acta = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.MateriaDidactico.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexMaterialDidactico");
            }
            var new_name_file = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Produccion/MaterialDidactico", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexMaterialDidactico");
        }
        public IActionResult EliminarMaterialDidactico(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                MateriaDidactico eliminar = context.MateriaDidactico.Where(w => w.IdMateriaDidactico == id).Single();
                context.MateriaDidactico.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexMaterialDidactico");
            }
        }
        public async Task<IActionResult> DescargarMaterialDidactico(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Produccion/MaterialDidactico", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }


        [Authorize]
        public IActionResult CrearMPractica()
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
        public async Task<IActionResult> GuardarMPractica(IFormFile file, ManualesPractica datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListMPractica = context.ManualesPractica.ToList();
                foreach (ManualesPractica item in ListMPractica)
                {
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo)
                    {
                        return RedirectToAction("IndexMPractica");
                    }
                }
                var new_name_table = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.ManualesPractica.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Produccion/ManualesPractica", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexMPractica");
        }
        [Authorize]
        public IActionResult EditarMPractica(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ManualesPractica DatosMPractica = context.ManualesPractica.Where(s => s.IdMaterialesPractica == id).Single();
                var perio = context.TipoPeriodo.ToList();
                var acad = context.Academicos.ToList();
                ViewData["periodos"] = perio;
                ViewData["academicos"] = acad;
                return View(DatosMPractica);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarMPractica(IFormFile file, ManualesPractica datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListMPractica = context.ManualesPractica.ToList();

                foreach (ManualesPractica item in ListMPractica)
                {
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo && datos.IdMaterialesPractica != item.IdMaterialesPractica)
                    {
                        return RedirectToAction("IndexMPractica");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.ManualesPractica.Where(w => w.IdMaterialesPractica == datos.IdMaterialesPractica).Single();
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
                context.ManualesPractica.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexMPractica");
            }
            var new_name_file = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Produccion/ManualesPractica", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexMPractica");
        }
        public IActionResult EliminarMPractica(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ManualesPractica eliminar = context.ManualesPractica.Where(w => w.IdMaterialesPractica == id).Single();
                context.ManualesPractica.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexMPractica");
            }
        }
        public async Task<IActionResult> DescargarMPractica(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Produccion/ManualesPractica", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }


        [Authorize]
        public IActionResult CrearLibroEE()
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
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarLibroEE(IFormFile file, Libroee datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListLibroEE = context.Libroee.ToList();
                foreach (Libroee item in ListLibroEE)
                {
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo)
                    {
                        return RedirectToAction("IndexLibroEE");
                    }
                }
                var new_name_table = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.Libroee.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Produccion/LibroEE", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexLibroEE");
        }
        [Authorize]
        public IActionResult EditarLibroEE(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Libroee DatosLibroEE = context.Libroee.Where(s => s.IdLibroEe == id).Single();
                var perio = context.TipoPeriodo.ToList();
                var acad = context.Academicos.ToList();
                ViewData["periodos"] = perio;
                ViewData["academicos"] = acad;
                return View(DatosLibroEE);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarLibroEE(IFormFile file, Libroee datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListLibroEE = context.Libroee.ToList();

                foreach (Libroee item in ListLibroEE)
                {
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo && datos.IdLibroEe != item.IdLibroEe)
                    {
                        return RedirectToAction("IndexLibroEE");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.Libroee.Where(w => w.IdLibroEe == datos.IdLibroEe).Single();
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
                context.Libroee.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexLibroEE");
            }
            var new_name_file = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Produccion/LibroEE", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexLibroEE");
        }
        public IActionResult EliminarLibroEE(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Libroee eliminar = context.Libroee.Where(w => w.IdLibroEe == id).Single();
                context.Libroee.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexLibroEE");
            }
        }
        public async Task<IActionResult> DescargarLibroEE(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Produccion/LibroEE", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }


        [Authorize]
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
        [Authorize]
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

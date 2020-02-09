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
using System.Globalization;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SGCFIEE.Controllers
{
    public class AcademicosPublicacionesController : Controller
    {
        // GET: /<controller>/
        [Authorize]
        public IActionResult IndexArticulos()
        {
            List<TablaArticulos> ListArticulos = new List<TablaArticulos>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListArticulos = (from datos in context.Articulos
                          join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                          join tipo in context.TipoLocNacInter on datos.IdTipoNI equals tipo.IdTipo
                          select new TablaArticulos
                          {
                              IdArticulos = datos.IdArticulos,
                              NumPersonal = acad.NumeroPersonal,
                              Nombre = acad.Nombre,
                              ApellidoPaterno = acad.ApellidoPaterno,
                              ApellidoMaterno = acad.ApellidoMaterno,
                              Archivo = datos.Archivo,
                              Tipo = tipo.Nombre,
                              Registro = datos.Registro,
                              Arbitrada = datos.Arbitrada,
                              NombreArticulo = datos.Nombre,
                              Status = acad.Status
                          }
                               ).ToList();
            }
            return View(ListArticulos);
        }
        [Authorize]
        public IActionResult CrearArticulos()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList();
                var lugar = context.TipoLocNacInter.Where(s=> s.Nombre != "Local").ToList();
                ViewData["academicos"] = acad;
                ViewData["lugar"] = lugar;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarArticulos(IFormFile file, Articulos datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = datos.IdAcademico + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.Articulos.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Articulos", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexArticulos");
        }
        [Authorize]
        public IActionResult EditarArticulos(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Articulos DatosArticulo = context.Articulos.Where(s => s.IdArticulos == id).Single();
                var lugar = context.TipoLocNacInter.Where(s => s.Nombre != "Local").ToList();
                var acad = context.Academicos.ToList();
                
                ViewData["lugar"] = lugar;
                ViewData["academicos"] = acad;
                return View(DatosArticulo);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarArticulos(IFormFile file, Articulos datos)
        {
            
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.Articulos.Where(w => w.IdArticulos == datos.IdArticulos).Single();
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
                context.Articulos.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexArticulos");
            }
            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Articulos", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexArticulos");
        }
        public IActionResult EliminarArticulos(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Articulos eliminar = context.Articulos.Where(w => w.IdArticulos == id).Single();
                context.Articulos.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexArticulos");
            }
        }
        public async Task<IActionResult> DescargarArticulos(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Publicaciones/Articulos", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }







        [Authorize]
        public IActionResult IndexCongresos()
        {
            List<TablaCongresos> ListCongreso = new List<TablaCongresos>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListCongreso = (from datos in context.Congresos
                                 join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                 join tipo in context.TipoLocNacInter on datos.IdNacInt equals tipo.IdTipo
                                 select new TablaCongresos
                                 {
                                     IdCongresos = datos.IdCongresos,
                                     NumPersonal = acad.NumeroPersonal,
                                     Nombre = acad.Nombre,
                                     ApellidoPaterno = acad.ApellidoPaterno,
                                     ApellidoMaterno = acad.ApellidoMaterno,
                                     Archivo = datos.Archivo,
                                     Tipo = tipo.Nombre,
                                     NombreCongreso = datos.Nombre,
                                     Status = acad.Status
                                 }
                               ).ToList();
            }
            return View(ListCongreso);
        }
        [Authorize]
        public IActionResult CrearCongresos()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList();
                var lugar = context.TipoLocNacInter.Where(s => s.Nombre != "Local").ToList();
                ViewData["academicos"] = acad;
                ViewData["lugar"] = lugar;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarCongresos(IFormFile file, Congresos datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = datos.IdAcademico + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.Congresos.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Congresos", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexCongresos");
        }
        [Authorize]
        public IActionResult EditarCongresos(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Congresos DatosCongresos = context.Congresos.Where(s => s.IdCongresos == id).Single();
                var lugar = context.TipoLocNacInter.Where(s => s.Nombre != "Local").ToList();
                var acad = context.Academicos.ToList();
                ViewData["lugar"] = lugar;
                ViewData["academicos"] = acad;
                return View(DatosCongresos);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarCongresos(IFormFile file, Congresos datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.Congresos.Where(w => w.IdCongresos == datos.IdCongresos).Single();
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
                context.Congresos.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexCongresos");
            }
            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Congresos", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexCongresos");
        }
        public IActionResult EliminarCongresos(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Congresos eliminar = context.Congresos.Where(w => w.IdCongresos == id).Single();
                context.Congresos.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexCongresos");
            }
        }
        public async Task<IActionResult> DescargarCongresos(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Publicaciones/Congresos", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }






        [Authorize]
        public IActionResult IndexRevistas()
        {
            List<TablaRevistas> ListRevistas = new List<TablaRevistas>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListRevistas = (from datos in context.Revistas
                                join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                join tipo in context.TipoLocNacInter on datos.IdNI equals tipo.IdTipo
                                select new TablaRevistas
                                {
                                    IdRevistas = datos.IdRevistas,
                                    NumPersonal = acad.NumeroPersonal,
                                    Nombre = acad.Nombre,
                                    ApellidoPaterno = acad.ApellidoPaterno,
                                    ApellidoMaterno = acad.ApellidoMaterno,
                                    Archivo = datos.Archivo,
                                    Tipo = tipo.Nombre,
                                    NombreRevista = datos.Nombre,
                                    Registro = datos.Registro,
                                    Arbitrada = datos.Arbitrada,
                                    Status = acad.Status
                                }
                               ).ToList();
            }
            return View(ListRevistas);
        }
        [Authorize]
        public IActionResult CrearRevistas()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList();
                var lugar = context.TipoLocNacInter.Where(s => s.Nombre != "Local").ToList();
                ViewData["academicos"] = acad;
                ViewData["lugar"] = lugar;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarRevistas(IFormFile file, Revistas datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = datos.IdAcademico + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.Revistas.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Revistas", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexRevistas");
        }
        [Authorize]
        public IActionResult EditarRevistas(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Revistas DatosRevistas = context.Revistas.Where(s => s.IdRevistas == id).Single();
                var lugar = context.TipoLocNacInter.Where(s => s.Nombre != "Local").ToList();
                var acad = context.Academicos.ToList();
                ViewData["lugar"] = lugar;
                ViewData["academicos"] = acad;
                return View(DatosRevistas);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarRevistas(IFormFile file, Revistas datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.Revistas.Where(w => w.IdRevistas == datos.IdRevistas).Single();
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
                context.Revistas.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexRevistas");
            }
            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Revistas", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexRevistas");
        }
        public IActionResult EliminarRevistas(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Revistas eliminar = context.Revistas.Where(w => w.IdRevistas == id).Single();
                context.Revistas.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexRevistas");
            }
        }
        public async Task<IActionResult> DescargarRevistas(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Publicaciones/Revistas", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }




        [Authorize]
        public IActionResult IndexReportesTecnicos()
        {
            List<TablaReportesTecnicos> ListReportes = new List<TablaReportesTecnicos>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListReportes = (from datos in context.ReportesTecnicos
                                join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                select new TablaReportesTecnicos
                                {
                                    IdReporteTecnico = datos.IdReportesTecnicos,
                                    NumPersonal = acad.NumeroPersonal,
                                    Nombre = acad.Nombre,
                                    ApellidoPaterno = acad.ApellidoPaterno,
                                    ApellidoMaterno = acad.ApellidoMaterno,
                                    Archivo = datos.Archivo,
                                    NombreReporte = datos.Nombre,
                                    Empresa_Sector = datos.LugarEmpresaSector,
                                    Status = acad.Status
                                }
                               ).ToList();
            }
            return View(ListReportes);
        }
        [Authorize]
        public IActionResult CrearReportes()
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
        public async Task<IActionResult> GuardarReportes(IFormFile file, ReportesTecnicos datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = datos.IdAcademico + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.ReportesTecnicos.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/ReportesTecnicos", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexReportesTecnicos");
        }
        [Authorize]
        public IActionResult EditarReportes(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ReportesTecnicos DatosReporte = context.ReportesTecnicos.Where(s => s.IdReportesTecnicos == id).Single();
                var acad = context.Academicos.ToList();
                ViewData["academicos"] = acad;
                return View(DatosReporte);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarReportes(IFormFile file, ReportesTecnicos datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.ReportesTecnicos.Where(w => w.IdReportesTecnicos == datos.IdReportesTecnicos).Single();
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
                context.ReportesTecnicos.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexReportesTecnicos");
            }
            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/ReportesTecnicos", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexReportesTecnicos");
        }
        public IActionResult EliminarReportes(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ReportesTecnicos eliminar = context.ReportesTecnicos.Where(w => w.IdReportesTecnicos == id).Single();
                context.ReportesTecnicos.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexReportesTecnicos");
            }
        }
        public async Task<IActionResult> DescargarReportes(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Publicaciones/ReportesTecnicos", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }




        [Authorize]
        public IActionResult IndexLibros()
        {
            List<TablaLibros> ListLibros = new List<TablaLibros>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListLibros = (from datos in context.LibrosAcademicos
                                join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                join edi in context.Editorial on datos.IdEditorial equals edi.IdEditorial
                                select new TablaLibros
                                {
                                    IdLibro = datos.IdLibrosAcademicos,
                                    NumPersonal = acad.NumeroPersonal,
                                    Nombre = acad.Nombre,
                                    ApellidoPaterno = acad.ApellidoPaterno,
                                    ApellidoMaterno = acad.ApellidoMaterno,
                                    Archivo = datos.Archivo,
                                    Titulo = datos.Titulo,
                                    ISBN = datos.Isbn,
                                    Anio = datos.Anio,
                                    Tiraje = datos.Tiraje,
                                    Editorial = edi.Nombre,
                                    Status = acad.Status
                                }
                               ).ToList();
            }
            return View(ListLibros);
        }
        [Authorize]
        public IActionResult CrearLibros()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList();
                var edit = context.Editorial.ToList();
                ViewData["academicos"] = acad;
                ViewData["editorial"] = edit;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarLibros(IFormFile file, LibrosAcademicos datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = datos.IdAcademico + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.LibrosAcademicos.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Libros", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexLibros");
        }
        [Authorize]
        public IActionResult EditarLibros(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                LibrosAcademicos DatosLibros = context.LibrosAcademicos.Where(s => s.IdLibrosAcademicos == id).Single();
                var acad = context.Academicos.ToList();
                var edit = context.Editorial.ToList();
                ViewData["academicos"] = acad;
                ViewData["editorial"] = edit;
                return View(DatosLibros);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarLibros(IFormFile file, LibrosAcademicos datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.LibrosAcademicos.Where(w => w.IdLibrosAcademicos == datos.IdLibrosAcademicos).Single();
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
                context.LibrosAcademicos.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexLibros");
            }
            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Libros", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexLibros");
        }
        public IActionResult EliminarLibros(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                LibrosAcademicos eliminar = context.LibrosAcademicos.Where(w => w.IdLibrosAcademicos == id).Single();
                context.LibrosAcademicos.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexLibros");
            }
        }
        public async Task<IActionResult> DescargarLibros(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Publicaciones/Libros", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }



        [Authorize]
        public IActionResult IndexCapitulos()
        {
            List<TablaCapitulos> ListCapitulos = new List<TablaCapitulos>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListCapitulos = (from datos in context.CapLibro
                              join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                              join edi in context.Editorial on datos.IdEditorial equals edi.IdEditorial
                              select new TablaCapitulos
                              {
                                  IdCapitulo = datos.IdCapLibro,
                                  NumPersonal = acad.NumeroPersonal,
                                  Nombre = acad.Nombre,
                                  ApellidoPaterno = acad.ApellidoPaterno,
                                  ApellidoMaterno = acad.ApellidoMaterno,
                                  Archivo = datos.Archivo,
                                  Titulo = datos.Titulo,
                                  ISBN = datos.Isbn,
                                  Anio = datos.Anio,
                                  Editorial = edi.Nombre,
                                  Status = acad.Status
                              }
                               ).ToList();
            }
            return View(ListCapitulos);
        }
        [Authorize]
        public IActionResult CrearCapitulosLibros()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList();
                var edit = context.Editorial.ToList();
                ViewData["academicos"] = acad;
                ViewData["editorial"] = edit;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarCapitulos(IFormFile file, CapLibro datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = datos.IdAcademico + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.CapLibro.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/CapitulosLibros", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexCapitulos");
        }
        [Authorize]
        public IActionResult EditarCapitulosLibros(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CapLibro DatosCap = context.CapLibro.Where(s => s.IdCapLibro == id).Single();
                var acad = context.Academicos.ToList();
                var edit = context.Editorial.ToList();
                ViewData["academicos"] = acad;
                ViewData["editorial"] = edit;
                return View(DatosCap);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarCapitulos(IFormFile file, CapLibro datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.CapLibro.Where(w => w.IdCapLibro == datos.IdCapLibro).Single();
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
                context.CapLibro.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexCapitulos");
            }
            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/CapitulosLibros", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexCapitulos");
        }
        public IActionResult EliminarCapitulos(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CapLibro eliminar = context.CapLibro.Where(w => w.IdCapLibro == id).Single();
                context.CapLibro.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexCapitulos");
            }
        }
        public async Task<IActionResult> DescargarCapitulos(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Publicaciones/CapitulosLibros", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }





        [Authorize]
        public IActionResult IndexPatentes()
        {
            List<TablaPatentes> ListPatentes = new List<TablaPatentes>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListPatentes = (from datos in context.PatentesAcademicos
                                 join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                 join tipo in context.TipoLocNacInter on datos.IdNacI equals tipo.IdTipo
                                 select new TablaPatentes
                                 {
                                     IdPatentes = datos.IdPatentesAcademicos,
                                     NumPersonal = acad.NumeroPersonal,
                                     Nombre = acad.Nombre,
                                     ApellidoPaterno = acad.ApellidoPaterno,
                                     ApellidoMaterno = acad.ApellidoMaterno,
                                     Archivo = datos.Archivo,
                                     NombrePatente = datos.Nombre,
                                     Tipo = tipo.Nombre,
                                     Status = acad.Status
                                 }
                               ).ToList();
            }
            return View(ListPatentes);
        }
        [Authorize]
        public IActionResult CrearPatentes()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList();
                var lugar = context.TipoLocNacInter.Where(s => s.Nombre != "Local").ToList();
                ViewData["academicos"] = acad;
                ViewData["lugar"] = lugar;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarPatentes(IFormFile file, PatentesAcademicos datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = datos.IdAcademico + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.PatentesAcademicos.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Patentes", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexPatentes");
        }
        [Authorize]
        public IActionResult EditarPatentes(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                PatentesAcademicos DatosPatentes = context.PatentesAcademicos.Where(s => s.IdPatentesAcademicos == id).Single();
                var lugar = context.TipoLocNacInter.Where(s => s.Nombre != "Local").ToList();
                var acad = context.Academicos.ToList();
                ViewData["lugar"] = lugar;
                ViewData["academicos"] = acad;
                return View(DatosPatentes);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarPatentes(IFormFile file, PatentesAcademicos datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.PatentesAcademicos.Where(w => w.IdPatentesAcademicos == datos.IdPatentesAcademicos).Single();
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
                context.PatentesAcademicos.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexPatentes");
            }
            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Patentes", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexPatentes");
        }
        public IActionResult EliminarPatentes(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                PatentesAcademicos eliminar = context.PatentesAcademicos.Where(w => w.IdPatentesAcademicos == id).Single();
                context.PatentesAcademicos.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexPatentes");
            }
        }
        public async Task<IActionResult> DescargarPatentes(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Publicaciones/Patentes", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }




        [Authorize]
        public IActionResult IndexTrabajoRecep()
        {
            List<TablaTrabajosRecep> ListTrabajosRecep = new List<TablaTrabajosRecep>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListTrabajosRecep = (from datos in context.TrabajosRecepcionales
                                join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                join academia in context.Academias on datos.IdAcademia equals academia.IdAcademias
                                join alum in context.Alumnos on datos.IdAlumno equals alum.IdAlumnos
                                join datosalum in context.DatosPersonales on alum.RDatosPerson equals datosalum.IdDatosPersonales
                                join grado in context.GradoTitulo on datos.IdGrado equals grado.IdGradoTitulo
                                join mod in context.TipoModalidad on datos.IdModalidad equals mod.IdModalidad
                                select new TablaTrabajosRecep
                                {
                                    IdTrabajos = datos.IdTrabajosRecepcionales,
                                    NumPersonal = acad.NumeroPersonal,
                                    Nombre = acad.Nombre,
                                    ApellidoPaterno = acad.ApellidoPaterno,
                                    ApellidoMaterno = acad.ApellidoMaterno,
                                    NombreAlum = datosalum.Nombre,
                                    ApellidoPaternoAlum = datosalum.ApellidoPaterno,
                                    ApellidoMaternoAlum = datosalum.ApellidoMaterno,
                                    Proceso = datos.Proceso,
                                    Modalidad = mod.Nombre,
                                    Grado = grado.Nombre,
                                    Academia = academia.Nombre,
                                    Fecha = datos.FechaPresentacion.ToString(),
                                    NumCT = datos.NumeroConsejoT,
                                    Archivo = datos.Archivo,
                                    NombreTrabajo = datos.NombreTrabajo,
                                    Status = acad.Status
                                }
                               ).ToList();
                

            }
            return View(ListTrabajosRecep);
        }
        
        [Authorize]
        public IActionResult CrearTrabajosRecep()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList();
                var academia = context.Academias.Where(s => s.Status == 1).ToList();
                var alum = context.DatosPersonales.ToList();
                var grados = context.GradoTitulo.ToList();
                var modalidad = context.TipoModalidad.ToList();
                ViewData["academicos"] = acad;
                ViewData["academia"] = academia;
                ViewData["alumnos"] = alum;
                ViewData["grados"] = grados;
                ViewData["modalidad"] = modalidad;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarTrabajosRecep(IFormFile file, TrabajosRecepcionales datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = datos.IdAcademico + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.TrabajosRecepcionales.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/TrabajosRecepcionales", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexTrabajoRecep");
        }
        [Authorize]
        public IActionResult EditarTrabajosRecep(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                TrabajosRecepcionales DatosTrabajos = context.TrabajosRecepcionales.Where(s => s.IdTrabajosRecepcionales == id).Single();
                var acad = context.Academicos.ToList();
                var academia = context.Academias.Where(s => s.Status == 1).ToList();
                var alum = context.DatosPersonales.ToList();
                var grados = context.GradoTitulo.ToList();
                var modalidad = context.TipoModalidad.ToList();
                
                ViewData["academicos"] = acad;
                ViewData["academia"] = academia;
                ViewData["alumnos"] = alum;
                ViewData["grados"] = grados;
                ViewData["modalidad"] = modalidad;
                string fecha = DatosTrabajos.FechaPresentacion.ToString();
                string[] resultado = fecha.Split(' ');
                ViewData["fecha"] = resultado[0];

                return View(DatosTrabajos);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarTrabajosRecep(IFormFile file, TrabajosRecepcionales datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.TrabajosRecepcionales.Where(w => w.IdTrabajosRecepcionales == datos.IdTrabajosRecepcionales).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    var new_name_table = datos.IdAcademico + "_" + file.GetFilename();
                    datos.Archivo = new_name_table;
                }

            }
            if (datos.Proceso == 0) datos.FechaPresentacion = null;
            using (sgcfieeContext context = new sgcfieeContext())
            {
                
                context.TrabajosRecepcionales.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexTrabajoRecep");
            }
            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/TrabajosRecepcionales", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexTrabajoRecep");
        }
        public IActionResult EliminarTrabajosRecep(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                TrabajosRecepcionales eliminar = context.TrabajosRecepcionales.Where(w => w.IdTrabajosRecepcionales == id).Single();
                context.TrabajosRecepcionales.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexTrabajoRecep");
            }
        }
        public async Task<IActionResult> DescargarTrabajosRecep(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Publicaciones/TrabajosRecepcionales", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }







        [Authorize]
        public IActionResult IndexConcursos()
        {
            List<TablaConcursos> ListConcursos = new List<TablaConcursos>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListConcursos = (from datos in context.Concursos
                                 join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                 join tipo in context.TipoLocNacInter on datos.IdNacInter equals tipo.IdTipo
                                 select new TablaConcursos
                                 {
                                     IdConcursos = datos.IdConcursos,
                                     NumPersonal = acad.NumeroPersonal,
                                     Nombre = acad.Nombre,
                                     ApellidoPaterno = acad.ApellidoPaterno,
                                     ApellidoMaterno = acad.ApellidoMaterno,
                                     Archivo = datos.Archivo,
                                     Tipo = tipo.Nombre,
                                     NombreConcurso = datos.Nombre,
                                     Status = acad.Status
                                 }
                               ).ToList();
            }
            return View(ListConcursos);
        }
        [Authorize]
        public IActionResult CrearConcursos()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList();
                var lugar = context.TipoLocNacInter.Where(s => s.Nombre != "Local").ToList();
                ViewData["academicos"] = acad;
                ViewData["lugar"] = lugar;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarConcursos(IFormFile file, Concursos datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = datos.IdAcademico + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.Concursos.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Concursos", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexConcursos");
        }
        [Authorize]
        public IActionResult EditarConcursos(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Concursos DatosConcursos = context.Concursos.Where(s => s.IdConcursos == id).Single();
                var lugar = context.TipoLocNacInter.Where(s => s.Nombre != "Local").ToList();
                var acad = context.Academicos.ToList();
                ViewData["lugar"] = lugar;
                ViewData["academicos"] = acad;
                return View(DatosConcursos);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarConcursos(IFormFile file, Concursos datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.Concursos.Where(w => w.IdConcursos == datos.IdConcursos).Single();
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
                context.Concursos.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexConcursos");
            }
            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Concursos", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexConcursos");
        }
        public IActionResult EliminarConcursos(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Concursos eliminar = context.Concursos.Where(w => w.IdConcursos == id).Single();
                context.Concursos.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexConcursos");
            }
        }
        public async Task<IActionResult> DescargarConcursos(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Publicaciones/Concursos", filename);

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

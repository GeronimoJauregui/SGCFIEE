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
                                 join tipo in context.TipoLocNacInter on datos.IdTipoNI equals tipo.IdTipo
                                 select new TablaArticulos
                                 {
                                     IdArticulos = datos.IdArticulos,
                                     Archivo = datos.Archivo,
                                     Tipo = tipo.Nombre,
                                     Registro = datos.Registro,
                                     Arbitrada = datos.Arbitrada,
                                     NombreArticulo = datos.Nombre,
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
                var lugar = context.TipoLocNacInter.Where(s => s.Nombre != "Local").ToList();
                ViewData["academicos"] = acad;
                ViewData["lugar"] = lugar;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarArticulos(IFormFile file, Articulos datos, int idAcademico, int Lider)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.Articulos.Add(datos);
                context.SaveChanges();
                Articulos DatosArticulo = context.Articulos.Last();
                var new_name_table = DatosArticulo.IdArticulos + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.Articulos.Update(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdArticulos + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Articulos", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            using (sgcfieeContext context = new sgcfieeContext())
            {
                Articulos DatosArticulo = context.Articulos.Last();
                Academicoarticulos info = new Academicoarticulos();
                info.IdAcademico = idAcademico;
                info.IdArticulo = DatosArticulo.IdArticulos;
                info.Lider = Lider;
                context.Academicoarticulos.Add(info);
                context.SaveChanges();
            }
            return RedirectToAction("IndexArticulos");
        }
        [Authorize]
        public IActionResult AcademicosArticulos(int id)
        {
            List<TablaAcadArticulos> ListAcadArticulos = new List<TablaAcadArticulos>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListAcadArticulos = (from datos in context.Academicoarticulos
                                     join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                     where datos.IdArticulo == id
                                     select new TablaAcadArticulos
                                     {
                                         IdAcadArticulos = datos.IdAcademicoArticulos,
                                         NumPersonal = acad.NumeroPersonal,
                                         Nombre = acad.Nombre,
                                         ApellidoPaterno = acad.ApellidoPaterno,
                                         ApellidoMaterno = acad.ApellidoMaterno,
                                         idArticulo = datos.IdArticulo
                                     }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                ViewData["academicos"] = acade;
                ViewData["idArticulo"] = id;
            }
            return View(ListAcadArticulos);
        }
        [Authorize]
        public IActionResult GuardarAcadArticulos(int idAcademico, int articulo, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicoarticulos AcadArticulos = new Academicoarticulos();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListAcad = context.Academicoarticulos.ToList();
                foreach (Academicoarticulos item in ListAcad)
                {
                    if (idAcademico == item.IdAcademico && articulo == item.IdArticulo)
                    {
                        return RedirectToAction("AcademicosArticulos", new { id = articulo });
                    }
                }
                AcadArticulos.IdAcademico = idAcademico;
                AcadArticulos.IdArticulo = articulo;
                AcadArticulos.Lider = Lider;
                context.Academicoarticulos.Add(AcadArticulos);
                context.SaveChanges();
            }
            return RedirectToAction("AcademicosArticulos", new { id = AcadArticulos.IdArticulo });
        }
        [Authorize]
        public IActionResult EliminarAcadArticulos(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicoarticulos eliminar = context.Academicoarticulos.Where(w => w.IdAcademicoArticulos == id).Single();
                context.Academicoarticulos.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("AcademicosArticulos", new { id = id_acad });
            }
        }
        [Authorize]
        public IActionResult EditarArticulos(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Articulos DatosArticulo = context.Articulos.Where(s => s.IdArticulos == id).Single();
                var lugar = context.TipoLocNacInter.Where(s => s.Nombre != "Local").ToList();

                ViewData["lugar"] = lugar;
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
                    var new_name_table = datos.IdArticulos + "_" + file.GetFilename();
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
            var new_name_file = datos.IdArticulos + "_" + file.GetFilename();
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
                List<Academicoarticulos> eliminarAcad = context.Academicoarticulos.Where(f => f.IdArticulo == id).ToList();
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    context.Academicoarticulos.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }

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
                                join tipo in context.TipoLocNacInter on datos.IdNacInt equals tipo.IdTipo
                                select new TablaCongresos
                                {
                                    IdCongresos = datos.IdCongresos,
                                    Archivo = datos.Archivo,
                                    Tipo = tipo.Nombre,
                                    NombreCongreso = datos.Nombre
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
        public async Task<IActionResult> GuardarCongresos(IFormFile file, Congresos datos, int idAcademico, int Lider)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.Congresos.Add(datos);
                context.SaveChanges();
                Congresos DatosCongreso = context.Congresos.Last();
                var new_name_table = DatosCongreso.IdCongresos + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.Congresos.Update(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdCongresos + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Congresos", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Congresos DatosCongresos = context.Congresos.Last();
                Academicocongresos info = new Academicocongresos();
                info.IdAcademico = idAcademico;
                info.IdCongreso = DatosCongresos.IdCongresos;
                info.Lider = Lider;
                context.Academicocongresos.Add(info);
                context.SaveChanges();
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
                ViewData["lugar"] = lugar;
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
                    var new_name_table = datos.IdCongresos + "_" + file.GetFilename();
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
            var new_name_file = datos.IdCongresos + "_" + file.GetFilename();
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
                List<Academicocongresos> eliminarAcad = context.Academicocongresos.Where(f => f.IdCongreso == id).ToList();
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    context.Academicocongresos.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }

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
        public IActionResult AcademicosCongresos(int id)
        {
            List<TablaAcadCongresos> ListAcadCongresos = new List<TablaAcadCongresos>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListAcadCongresos = (from datos in context.Academicocongresos
                                     join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                     where datos.IdCongreso == id
                                     select new TablaAcadCongresos
                                     {
                                         IdAcadCongreso = datos.IdAcademicoCongresos,
                                         NumPersonal = acad.NumeroPersonal,
                                         Nombre = acad.Nombre,
                                         ApellidoPaterno = acad.ApellidoPaterno,
                                         ApellidoMaterno = acad.ApellidoMaterno,
                                         idCongreso = datos.IdCongreso
                                     }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                ViewData["academicos"] = acade;
                ViewData["idCongreso"] = id;
            }
            return View(ListAcadCongresos);
        }
        [Authorize]
        public IActionResult GuardarAcadCongresos(int idAcademico, int congreso, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicocongresos AcadCongresos = new Academicocongresos();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListAcad = context.Academicocongresos.ToList();
                foreach (Academicocongresos item in ListAcad)
                {
                    if (idAcademico == item.IdAcademico && congreso == item.IdCongreso)
                    {
                        return RedirectToAction("AcademicosCongresos", new { id = congreso });
                    }
                }
                AcadCongresos.IdAcademico = idAcademico;
                AcadCongresos.IdCongreso = congreso;
                AcadCongresos.Lider = Lider;
                context.Academicocongresos.Add(AcadCongresos);
                context.SaveChanges();
            }
            return RedirectToAction("AcademicosCongresos", new { id = AcadCongresos.IdCongreso });
        }
        [Authorize]
        public IActionResult EliminarAcadCongresos(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicocongresos eliminar = context.Academicocongresos.Where(w => w.IdAcademicoCongresos == id).Single();
                context.Academicocongresos.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("AcademicosCongresos", new { id = id_acad });
            }
        }




        [Authorize]
        public IActionResult IndexRevistas()
        {
            List<TablaRevistas> ListRevistas = new List<TablaRevistas>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListRevistas = (from datos in context.Revistas
                                join tipo in context.TipoLocNacInter on datos.IdNI equals tipo.IdTipo
                                select new TablaRevistas
                                {
                                    IdRevistas = datos.IdRevistas,
                                    Archivo = datos.Archivo,
                                    Tipo = tipo.Nombre,
                                    NombreRevista = datos.Nombre,
                                    Registro = datos.Registro,
                                    Arbitrada = datos.Arbitrada
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
        public async Task<IActionResult> GuardarRevistas(IFormFile file, Revistas datos, int idAcademico, int Lider)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.Revistas.Add(datos);
                context.SaveChanges();
                Revistas DatosRevistas = context.Revistas.Last();
                var new_name_table = DatosRevistas.IdRevistas + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.Revistas.Update(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdRevistas + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Revistas", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Revistas DatosRevistas = context.Revistas.Last();
                Academicorevistas info = new Academicorevistas();
                info.IdAcademico = idAcademico;
                info.IdRevista = DatosRevistas.IdRevistas;
                info.Lider = Lider;
                context.Academicorevistas.Add(info);
                context.SaveChanges();
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
                ViewData["lugar"] = lugar;
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
                    var new_name_table = datos.IdRevistas + "_" + file.GetFilename();
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
            var new_name_file = datos.IdRevistas + "_" + file.GetFilename();
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
                List<Academicorevistas> eliminarAcad = context.Academicorevistas.Where(f => f.IdRevista == id).ToList();
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    context.Academicorevistas.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }

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
        public IActionResult AcademicosRevistas(int id)
        {
            List<TablaAcadRevistas> ListAcadRevistas = new List<TablaAcadRevistas>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListAcadRevistas = (from datos in context.Academicorevistas
                                    join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                    where datos.IdRevista == id
                                    select new TablaAcadRevistas
                                    {
                                        IdAcadRevistas = datos.IdAcademicorevistas,
                                        NumPersonal = acad.NumeroPersonal,
                                        Nombre = acad.Nombre,
                                        ApellidoPaterno = acad.ApellidoPaterno,
                                        ApellidoMaterno = acad.ApellidoMaterno,
                                        IdRevistas = datos.IdRevista
                                    }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                ViewData["academicos"] = acade;
                ViewData["idRevistas"] = id;
            }
            return View(ListAcadRevistas);
        }
        [Authorize]
        public IActionResult GuardarAcadRevistas(int idAcademico, int revistas, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicorevistas AcadRevistas = new Academicorevistas();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListAcad = context.Academicorevistas.ToList();
                foreach (Academicorevistas item in ListAcad)
                {
                    if (idAcademico == item.IdAcademico && revistas == item.IdRevista)
                    {
                        return RedirectToAction("AcademicosRevistas", new { id = revistas });
                    }
                }
                AcadRevistas.IdAcademico = idAcademico;
                AcadRevistas.IdRevista = revistas;
                AcadRevistas.Lider = Lider;
                context.Academicorevistas.Add(AcadRevistas);
                context.SaveChanges();
            }
            return RedirectToAction("AcademicosRevistas", new { id = AcadRevistas.IdRevista });
        }
        [Authorize]
        public IActionResult EliminarAcadRevistas(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicorevistas eliminar = context.Academicorevistas.Where(w => w.IdAcademicorevistas == id).Single();
                context.Academicorevistas.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("AcademicosRevistas", new { id = id_acad });
            }
        }



        [Authorize]
        public IActionResult IndexReportesTecnicos()
        {
            List<TablaReportesTecnicos> ListReportes = new List<TablaReportesTecnicos>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListReportes = (from datos in context.ReportesTecnicos
                                select new TablaReportesTecnicos
                                {
                                    IdReporteTecnico = datos.IdReportesTecnicos,
                                    Archivo = datos.Archivo,
                                    NombreReporte = datos.Nombre,
                                    Empresa_Sector = datos.LugarEmpresaSector
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
        public async Task<IActionResult> GuardarReportes(IFormFile file, ReportesTecnicos datos, int idAcademico, int Lider)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.ReportesTecnicos.Add(datos);
                context.SaveChanges();
                var new_name_table = datos.IdReportesTecnicos + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.ReportesTecnicos.Update(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdReportesTecnicos + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/ReportesTecnicos", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ReportesTecnicos DatosReportesTecnicos = context.ReportesTecnicos.Last();
                Academicoreportest info = new Academicoreportest();
                info.IdAcademico = idAcademico;
                info.IdReportesTec = DatosReportesTecnicos.IdReportesTecnicos;
                info.Lider = Lider;
                context.Academicoreportest.Add(info);
                context.SaveChanges();
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
                    var new_name_table = datos.IdReportesTecnicos + "_" + file.GetFilename();
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
            var new_name_file = datos.IdReportesTecnicos + "_" + file.GetFilename();
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
                List<Academicoreportest> eliminarAcad = context.Academicoreportest.Where(f => f.IdReportesTec == id).ToList();
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    context.Academicoreportest.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }

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
        public IActionResult AcademicosReportes(int id)
        {
            List<TablaAcadReportes> ListAcadReportes = new List<TablaAcadReportes>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListAcadReportes = (from datos in context.Academicoreportest
                                    join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                    where datos.IdReportesTec == id
                                    select new TablaAcadReportes
                                    {
                                        IdAcadReportes = datos.IdAcademicoReportesT,
                                        NumPersonal = acad.NumeroPersonal,
                                        Nombre = acad.Nombre,
                                        ApellidoPaterno = acad.ApellidoPaterno,
                                        ApellidoMaterno = acad.ApellidoMaterno,
                                        IdReporte = datos.IdReportesTec
                                    }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                ViewData["academicos"] = acade;
                ViewData["idReportes"] = id;
            }
            return View(ListAcadReportes);
        }
        [Authorize]
        public IActionResult GuardarAcadReportes(int idAcademico, int reportes, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicoreportest AcadReportes = new Academicoreportest();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListAcad = context.Academicoreportest.ToList();
                foreach (Academicoreportest item in ListAcad)
                {
                    if (idAcademico == item.IdAcademico && reportes == item.IdReportesTec)
                    {
                        return RedirectToAction("AcademicosReportes", new { id = reportes });
                    }
                }

                AcadReportes.IdAcademico = idAcademico;
                AcadReportes.IdReportesTec = reportes;
                AcadReportes.Lider = Lider;
                context.Academicoreportest.Add(AcadReportes);
                context.SaveChanges();
            }
            return RedirectToAction("AcademicosReportes", new { id = AcadReportes.IdReportesTec });
        }
        [Authorize]
        public IActionResult EliminarAcadReportes(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicoreportest eliminar = context.Academicoreportest.Where(w => w.IdAcademicoReportesT == id).Single();
                context.Academicoreportest.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("AcademicosReportes", new { id = id_acad });
            }
        }



        [Authorize]
        public IActionResult IndexLibros()
        {
            List<TablaLibros> ListLibros = new List<TablaLibros>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListLibros = (from datos in context.LibrosAcademicos
                              join edi in context.Editorial on datos.IdEditorial equals edi.IdEditorial
                              select new TablaLibros
                              {
                                  IdLibro = datos.IdLibrosAcademicos,
                                  Archivo = datos.Archivo,
                                  Titulo = datos.Titulo,
                                  ISBN = datos.Isbn,
                                  Anio = datos.Anio,
                                  Tiraje = datos.Tiraje,
                                  Editorial = edi.Nombre
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
        public async Task<IActionResult> GuardarLibros(IFormFile file, LibrosAcademicos datos, int idAcademico, int Lider)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.LibrosAcademicos.Add(datos);
                context.SaveChanges();
                var new_name_table = datos.IdLibrosAcademicos + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.LibrosAcademicos.Update(datos);
                context.SaveChanges();

            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdLibrosAcademicos + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Libros", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                LibrosAcademicos DatosLibro = context.LibrosAcademicos.Last();
                Academicolibro info = new Academicolibro();
                info.IdAcademico = idAcademico;
                info.IdLibroAcad = DatosLibro.IdLibrosAcademicos;
                info.Lider = Lider;
                context.Academicolibro.Add(info);
                context.SaveChanges();
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
                var edit = context.Editorial.ToList();
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
                    var new_name_table = datos.IdLibrosAcademicos + "_" + file.GetFilename();
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
            var new_name_file = datos.IdLibrosAcademicos + "_" + file.GetFilename();
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
                List<Academicolibro> eliminarAcad = context.Academicolibro.Where(f => f.IdLibroAcad == id).ToList();
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    context.Academicolibro.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }

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
        public IActionResult AcademicosLibros(int id)
        {
            List<TablaAcadLibros> ListAcadLibros = new List<TablaAcadLibros>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListAcadLibros = (from datos in context.Academicolibro
                                  join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                  where datos.IdLibroAcad == id
                                  select new TablaAcadLibros
                                  {
                                      IdAcadLibros = datos.IdAcademicoLibro,
                                      NumPersonal = acad.NumeroPersonal,
                                      Nombre = acad.Nombre,
                                      ApellidoPaterno = acad.ApellidoPaterno,
                                      ApellidoMaterno = acad.ApellidoMaterno,
                                      IdLibros = datos.IdLibroAcad
                                  }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                ViewData["academicos"] = acade;
                ViewData["idLibros"] = id;
            }
            return View(ListAcadLibros);
        }
        [Authorize]
        public IActionResult GuardarAcadLibros(int idAcademico, int libros, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicolibro AcadLibros = new Academicolibro();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListAcad = context.Academicolibro.ToList();
                foreach (Academicolibro item in ListAcad)
                {
                    if (idAcademico == item.IdAcademico && libros == item.IdLibroAcad)
                    {
                        return RedirectToAction("AcademicosLibros", new { id = libros });
                    }
                }
                AcadLibros.IdAcademico = idAcademico;
                AcadLibros.IdLibroAcad = libros;
                AcadLibros.Lider = Lider;
                context.Academicolibro.Add(AcadLibros);
                context.SaveChanges();
            }
            return RedirectToAction("AcademicosLibros", new { id = AcadLibros.IdLibroAcad });
        }
        [Authorize]
        public IActionResult EliminarAcadLibros(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicolibro eliminar = context.Academicolibro.Where(w => w.IdAcademicoLibro == id).Single();
                context.Academicolibro.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("AcademicosLibros", new { id = id_acad });
            }
        }


        [Authorize]
        public IActionResult IndexCapitulos()
        {
            List<TablaCapitulos> ListCapitulos = new List<TablaCapitulos>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListCapitulos = (from datos in context.CapLibro
                                 join edi in context.Editorial on datos.IdEditorial equals edi.IdEditorial
                                 select new TablaCapitulos
                                 {
                                     IdCapitulo = datos.IdCapLibro,
                                     Archivo = datos.Archivo,
                                     Titulo = datos.Titulo,
                                     ISBN = datos.Isbn,
                                     Anio = datos.Anio,
                                     Editorial = edi.Nombre
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
        public async Task<IActionResult> GuardarCapitulos(IFormFile file, CapLibro datos, int idAcademico, int Lider)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.CapLibro.Add(datos);
                context.SaveChanges();
                var new_name_table = datos.IdCapLibro + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.CapLibro.Update(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdCapLibro + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/CapitulosLibros", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CapLibro DatosLibro = context.CapLibro.Last();
                Academicocaplibro info = new Academicocaplibro();
                info.IdAcademico = idAcademico;
                info.IdCapLibro = DatosLibro.IdCapLibro;
                info.Lider = Lider;
                context.Academicocaplibro.Add(info);
                context.SaveChanges();
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
                var edit = context.Editorial.ToList();
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
                    var new_name_table = datos.IdCapLibro + "_" + file.GetFilename();
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
            var new_name_file = datos.IdCapLibro + "_" + file.GetFilename();
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
                List<Academicocaplibro> eliminarAcad = context.Academicocaplibro.Where(f => f.IdCapLibro == id).ToList();
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    context.Academicocaplibro.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }
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
        public IActionResult AcademicosCapituloLibros(int id)
        {
            List<TablaAcadCapLibros> ListAcadCapLibros = new List<TablaAcadCapLibros>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListAcadCapLibros = (from datos in context.Academicocaplibro
                                     join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                     where datos.IdCapLibro == id
                                     select new TablaAcadCapLibros
                                     {
                                         IdAcadCapLibros = datos.IdAcademicoCapLibro,
                                         NumPersonal = acad.NumeroPersonal,
                                         Nombre = acad.Nombre,
                                         ApellidoPaterno = acad.ApellidoPaterno,
                                         ApellidoMaterno = acad.ApellidoMaterno,
                                         IdCapLibros = datos.IdCapLibro
                                     }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                ViewData["academicos"] = acade;
                ViewData["idCapLibros"] = id;
            }
            return View(ListAcadCapLibros);
        }
        [Authorize]
        public IActionResult GuardarAcadCapLibros(int idAcademico, int Caplibros, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicocaplibro AcadCapLibros = new Academicocaplibro();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListAcad = context.Academicocaplibro.ToList();
                foreach (Academicocaplibro item in ListAcad)
                {
                    if (idAcademico == item.IdAcademico && Caplibros == item.IdCapLibro)
                    {
                        return RedirectToAction("AcademicosCapituloLibros", new { id = Caplibros });
                    }
                }
                AcadCapLibros.Lider = Lider;
                AcadCapLibros.IdAcademico = idAcademico;
                AcadCapLibros.IdCapLibro = Caplibros;
                context.Academicocaplibro.Add(AcadCapLibros);
                context.SaveChanges();
            }
            return RedirectToAction("AcademicosCapituloLibros", new { id = AcadCapLibros.IdCapLibro });
        }
        [Authorize]
        public IActionResult EliminarAcadCapLibros(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicocaplibro eliminar = context.Academicocaplibro.Where(w => w.IdAcademicoCapLibro == id).Single();
                context.Academicocaplibro.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("AcademicosCapituloLibros", new { id = id_acad });
            }
        }





        [Authorize]
        public IActionResult IndexPatentes()
        {
            List<TablaPatentes> ListPatentes = new List<TablaPatentes>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListPatentes = (from datos in context.PatentesAcademicos
                                join tipo in context.TipoLocNacInter on datos.IdNacI equals tipo.IdTipo
                                select new TablaPatentes
                                {
                                    IdPatentes = datos.IdPatentesAcademicos,
                                    Archivo = datos.Archivo,
                                    NombrePatente = datos.Nombre,
                                    Tipo = tipo.Nombre
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
        public async Task<IActionResult> GuardarPatentes(IFormFile file, PatentesAcademicos datos, int idAcademico, int Lider)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.PatentesAcademicos.Add(datos);
                context.SaveChanges();
                var new_name_table = datos.IdPatentesAcademicos + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.PatentesAcademicos.Update(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdPatentesAcademicos + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Patentes", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                PatentesAcademicos DatosPatentes = context.PatentesAcademicos.Last();
                Academicospatentes info = new Academicospatentes();
                info.IdAcademicos = idAcademico;
                info.IdPatentes = DatosPatentes.IdPatentesAcademicos;
                info.Lider = Lider;
                context.Academicospatentes.Add(info);
                context.SaveChanges();
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
                ViewData["lugar"] = lugar;
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
                    var new_name_table = datos.IdPatentesAcademicos + "_" + file.GetFilename();
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
            var new_name_file = datos.IdPatentesAcademicos + "_" + file.GetFilename();
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
                List<Academicospatentes> eliminarAcad = context.Academicospatentes.Where(f => f.IdPatentes == id).ToList();
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    context.Academicospatentes.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }
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
        public IActionResult AcademicosPatentes(int id)
        {
            List<TablaAcadPatentes> ListAcadPatentes = new List<TablaAcadPatentes>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListAcadPatentes = (from datos in context.Academicospatentes
                                    join acad in context.Academicos on datos.IdAcademicos equals acad.IdAcademicos
                                    where datos.IdPatentes == id
                                    select new TablaAcadPatentes
                                    {
                                        IdAcadPatentes = datos.IdAcademicosPatentes,
                                        NumPersonal = acad.NumeroPersonal,
                                        Nombre = acad.Nombre,
                                        ApellidoPaterno = acad.ApellidoPaterno,
                                        ApellidoMaterno = acad.ApellidoMaterno,
                                        IdPatentes = datos.IdPatentes
                                    }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                ViewData["academicos"] = acade;
                ViewData["idPatentes"] = id;
            }
            return View(ListAcadPatentes);
        }
        [Authorize]
        public IActionResult GuardarAcadPatentes(int idAcademico, int patentes, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicospatentes AcadPatentes = new Academicospatentes();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListAcad = context.Academicospatentes.ToList();
                foreach (Academicospatentes item in ListAcad)
                {
                    if (idAcademico == item.IdAcademicos && patentes == item.IdPatentes)
                    {
                        return RedirectToAction("AcademicosPatentes", new { id = patentes });
                    }
                }
                AcadPatentes.Lider = Lider;
                AcadPatentes.IdAcademicos = idAcademico;
                AcadPatentes.IdPatentes = patentes;
                context.Academicospatentes.Add(AcadPatentes);
                context.SaveChanges();
            }
            return RedirectToAction("AcademicosPatentes", new { id = AcadPatentes.IdPatentes });
        }
        [Authorize]
        public IActionResult EliminarAcadPatentes(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicospatentes eliminar = context.Academicospatentes.Where(w => w.IdAcademicosPatentes == id).Single();
                context.Academicospatentes.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("AcademicosPatentes", new { id = id_acad });
            }
        }



        [Authorize]
        public IActionResult IndexTrabajoRecep()
        {
            List<TablaTrabajosRecep> ListTrabajosRecep = new List<TablaTrabajosRecep>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListTrabajosRecep = (from datos in context.TrabajosRecepcionales
                                     join academia in context.Academias on datos.IdAcademia equals academia.IdAcademias
                                     join alum in context.Alumnos on datos.IdAlumno equals alum.IdAlumnos
                                     join datosalum in context.DatosPersonales on alum.RDatosPerson equals datosalum.IdDatosPersonales
                                     join grado in context.GradoTitulo on datos.IdGrado equals grado.IdGradoTitulo
                                     join mod in context.TipoModalidad on datos.IdModalidad equals mod.IdModalidad
                                     select new TablaTrabajosRecep
                                     {
                                         IdTrabajos = datos.IdTrabajosRecepcionales,
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
        public async Task<IActionResult> GuardarTrabajosRecep(IFormFile file, TrabajosRecepcionales datos, int idAcademico, int Lider)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.TrabajosRecepcionales.Add(datos);
                context.SaveChanges();
                var new_name_table = datos.IdTrabajosRecepcionales + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.TrabajosRecepcionales.Update(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdTrabajosRecepcionales + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/TrabajosRecepcionales", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                TrabajosRecepcionales DatosTrabajosR = context.TrabajosRecepcionales.Last();
                Academicotrabajosrecep info = new Academicotrabajosrecep();
                info.IdAcademico = idAcademico;
                info.IdTrabajosRecep = DatosTrabajosR.IdTrabajosRecepcionales;
                info.Lider = Lider;
                context.Academicotrabajosrecep.Add(info);
                context.SaveChanges();
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

                var academia = context.Academias.Where(s => s.Status == 1).ToList();
                var alum = context.DatosPersonales.ToList();
                var grados = context.GradoTitulo.ToList();
                var modalidad = context.TipoModalidad.ToList();


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
                    var new_name_table = datos.IdTrabajosRecepcionales + "_" + file.GetFilename();
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
            var new_name_file = datos.IdTrabajosRecepcionales + "_" + file.GetFilename();
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
                List<Academicotrabajosrecep> eliminarAcad = context.Academicotrabajosrecep.Where(f => f.IdTrabajosRecep == id).ToList();
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    context.Academicotrabajosrecep.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }
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
        public IActionResult AcademicosTrabajosRecep(int id)
        {
            List<TablaAcadTrabajosRecep> ListAcadTrabajosRecep = new List<TablaAcadTrabajosRecep>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListAcadTrabajosRecep = (from datos in context.Academicotrabajosrecep
                                         join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                         where datos.IdTrabajosRecep == id
                                         select new TablaAcadTrabajosRecep
                                         {
                                             IdAcadTrabajos = datos.IdAcademicoTrabajosRecep,
                                             NumPersonal = acad.NumeroPersonal,
                                             Nombre = acad.Nombre,
                                             ApellidoPaterno = acad.ApellidoPaterno,
                                             ApellidoMaterno = acad.ApellidoMaterno,
                                             IdTrabajos = datos.IdTrabajosRecep
                                         }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                ViewData["academicos"] = acade;
                ViewData["idTrabajos"] = id;
            }
            return View(ListAcadTrabajosRecep);
        }
        [Authorize]
        public IActionResult GuardarAcadTrabajosRecep(int idAcademico, int trabajos, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicotrabajosrecep AcadTrabajos = new Academicotrabajosrecep();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListAcad = context.Academicotrabajosrecep.ToList();
                foreach (Academicotrabajosrecep item in ListAcad)
                {
                    if (idAcademico == item.IdAcademico && trabajos == item.IdTrabajosRecep)
                    {
                        return RedirectToAction("AcademicosTrabajosRecep", new { id = trabajos });
                    }
                }
                AcadTrabajos.Lider = Lider;
                AcadTrabajos.IdAcademico = idAcademico;
                AcadTrabajos.IdTrabajosRecep = trabajos;
                context.Academicotrabajosrecep.Add(AcadTrabajos);
                context.SaveChanges();
            }
            return RedirectToAction("AcademicosTrabajosRecep", new { id = AcadTrabajos.IdTrabajosRecep });
        }
        [Authorize]
        public IActionResult EliminarAcadTrabajosRecep(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicotrabajosrecep eliminar = context.Academicotrabajosrecep.Where(w => w.IdAcademicoTrabajosRecep == id).Single();
                context.Academicotrabajosrecep.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("AcademicosTrabajosRecep", new { id = id_acad });
            }
        }






        [Authorize]
        public IActionResult IndexConcursos()
        {
            List<TablaConcursos> ListConcursos = new List<TablaConcursos>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListConcursos = (from datos in context.Concursos
                                 join tipo in context.TipoLocNacInter on datos.IdNacInter equals tipo.IdTipo
                                 select new TablaConcursos
                                 {
                                     IdConcursos = datos.IdConcursos,
                                     Archivo = datos.Archivo,
                                     Tipo = tipo.Nombre,
                                     NombreConcurso = datos.Nombre,
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
        public async Task<IActionResult> GuardarConcursos(IFormFile file, Concursos datos, int idAcademico, int Lider)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.Concursos.Add(datos);
                context.SaveChanges();
                var new_name_table = datos.IdConcursos + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.Concursos.Update(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdConcursos + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Concursos", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Concursos DatosTrabajosR = context.Concursos.Last();
                Academicoconcursos info = new Academicoconcursos();
                info.IdAcademico = idAcademico;
                info.IdConcursos = DatosTrabajosR.IdConcursos;
                info.Lider = Lider;
                context.Academicoconcursos.Add(info);
                context.SaveChanges();
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

                ViewData["lugar"] = lugar;

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
                    var new_name_table = datos.IdConcursos + "_" + file.GetFilename();
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
            var new_name_file = datos.IdConcursos + "_" + file.GetFilename();
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
                List<Academicoconcursos> eliminarAcad = context.Academicoconcursos.Where(f => f.IdConcursos == id).ToList();
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    context.Academicoconcursos.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }
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
        [Authorize]
        public IActionResult AcademicosConcursos(int id)
        {
            List<TablaAcadConcursos> ListAcadConcursos = new List<TablaAcadConcursos>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListAcadConcursos = (from datos in context.Academicoconcursos
                                     join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                     where datos.IdConcursos == id
                                     select new TablaAcadConcursos
                                     {
                                         IdAcadConcursos = datos.IdAcademicoConcursos,
                                         NumPersonal = acad.NumeroPersonal,
                                         Nombre = acad.Nombre,
                                         ApellidoPaterno = acad.ApellidoPaterno,
                                         ApellidoMaterno = acad.ApellidoMaterno,
                                         IdConcursos = datos.IdConcursos
                                     }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                ViewData["academicos"] = acade;
                ViewData["idConcursos"] = id;
            }
            return View(ListAcadConcursos);
        }
        [Authorize]
        public IActionResult GuardarAcadConcursos(int idAcademico, int concursos, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicoconcursos AcadConcursos = new Academicoconcursos();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListAcad = context.Academicoconcursos.ToList();
                foreach (Academicoconcursos item in ListAcad)
                {
                    if (idAcademico == item.IdAcademico && concursos == item.IdConcursos)
                    {
                        return RedirectToAction("AcademicosConcursos", new { id = concursos });
                    }
                }
                AcadConcursos.Lider = Lider;
                AcadConcursos.IdAcademico = idAcademico;
                AcadConcursos.IdConcursos = concursos;
                context.Academicoconcursos.Add(AcadConcursos);
                context.SaveChanges();
            }
            return RedirectToAction("AcademicosConcursos", new { id = AcadConcursos.IdConcursos });
        }
        [Authorize]
        public IActionResult EliminarAcadConcursos(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicoconcursos eliminar = context.Academicoconcursos.Where(w => w.IdAcademicoConcursos == id).Single();
                context.Academicoconcursos.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("AcademicosConcursos", new { id = id_acad });
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

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
    public class AcademicosConsejoTecnicoController : Controller
    {

        // GET: /<controller>/
        // en este submodulo se encuentran todos los academicos que pertenecen o han pertenecido al consejo técnico
        [Authorize]
        public IActionResult Index()
        {
            List<TablaCT> ListCT = new List<TablaCT>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            { // obtenemos los datos de la tabla asi como sus relaciones y guardamos cada registro en una lista
                ListCT = (from datos in context.ConsejoTecnico
                                 join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                 join perioIni in context.TipoPeriodo on datos.IdFechaInicial equals perioIni.IdPeriodo
                                 join perioTer in context.TipoPeriodo on datos.IdFechaCierre equals perioTer.IdPeriodo
                                 select new TablaCT
                                 {
                                     IdCT = datos.IdConsejoTecnico,
                                     NumPersonal = acad.NumeroPersonal,
                                     Nombre = acad.Nombre,
                                     ApellidoPaterno = acad.ApellidoPaterno,
                                     ApellidoMaterno = acad.ApellidoMaterno,
                                     Archivo = datos.ArchivoActaA,
                                     PeriodoInicio = perioIni.Nombre,
                                     PeriodoTermino = perioTer.Nombre,
                                     Status = acad.Status
                                 }
                               ).ToList();
            }
            
            return View(ListCT);
        }
        [Authorize]
        // formulario para crear un integrante del consejo
        public IActionResult Crear()
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
        public async Task<IActionResult> Guardar(IFormFile file, ConsejoTecnico datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListCT= context.ConsejoTecnico.ToList();
                foreach (ConsejoTecnico item in ListCT)
                {   // verificamos que los datos no sean repetidos
                    if (datos.IdAcademico == item.IdAcademico && datos.IdFechaInicial == item.IdFechaInicial && datos.IdFechaCierre == item.IdFechaCierre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("Index");
                    }
                } // guardamos la url del archivo
                var new_name_table = datos.IdFechaInicial + "_" + datos.IdFechaCierre + "_" + datos.IdAcademico + "_" + file.GetFilename();
                datos.ArchivoActaA = new_name_table;
                context.ConsejoTecnico.Add(datos);
                context.SaveChanges();
            }
            // verificamos que haya un archivo sino regresa un mensaje
            if (file == null || file.Length == 0)
                return Content("file not selected");

            // guardamos los datos
            var new_name_file = datos.IdFechaInicial + "_" + datos.IdFechaCierre + "_" + datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/ConsejoTecnico", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '"+ "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("Index");
        }
        [Authorize]
        // el método recibe el id del registro a modificar
        public IActionResult Editar(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ConsejoTecnico DatosCT = context.ConsejoTecnico.Where(s => s.IdConsejoTecnico == id).Single();
                var perio = context.TipoPeriodo.ToList();
                var acad = context.Academicos.ToList();
                ViewData["periodos"] = perio;
                ViewData["academicos"] = acad;
                return View(DatosCT);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Actualizar(IFormFile file, ConsejoTecnico datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {  // verificamos que los datos no sean repetidos
                var ListCT = context.ConsejoTecnico.Where(x => x.IdConsejoTecnico != datos.IdConsejoTecnico).ToList();

                foreach (ConsejoTecnico item in ListCT)
                {
                    if (datos.IdAcademico == item.IdAcademico && datos.IdFechaInicial == item.IdFechaInicial && datos.IdFechaCierre == item.IdFechaCierre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("Index");
                    }
                }
            } // si no hay archivo asignamos el que tenia previamente
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.ConsejoTecnico.Where(w => w.IdConsejoTecnico == datos.IdConsejoTecnico).Single();
                    datos.ArchivoActaA = nomArchivo.ArchivoActaA;
                }
                else
                {
                    var new_name_table = datos.IdFechaInicial + "_" + datos.IdFechaCierre + "_" + datos.IdAcademico + "_" + file.GetFilename();
                    datos.ArchivoActaA = new_name_table;
                }

            } // guardamos en la db
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.ConsejoTecnico.Update(datos);
                context.SaveChanges();
            } // si no hay que guardar archivo retornamos
            if (file == null || file.Length == 0)
            {
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("Index");
            }
            // guardamos el nuevo archivo
            var new_name_file = datos.IdFechaInicial + "_" + datos.IdFechaCierre + "_" + datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/ConsejoTecnico", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("Index");
        }
        public IActionResult Eliminar(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ConsejoTecnico eliminar = context.ConsejoTecnico.Where(w => w.IdConsejoTecnico == id).Single();
                context.ConsejoTecnico.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> Descargar(string filename)
        {

            if (filename == null)
                return Content("filename not present");
            // obtenemos la ruta del archivo
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/ConsejoTecnico", filename);

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
        {   // tipos de archivo que pueden bajar
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

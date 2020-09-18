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

namespace SGCFIEE.Controllers
{
    public class AcademicosPafisController : Controller
    {
        [Authorize]
        public IActionResult Index()
        { // modelo personalizado de pafi
            // la vista muestra dos tablas
            // 1.- pafis en curso y finalizados
            List<pPafisAcademicos> ListPafis = new List<pPafisAcademicos>();
            // 2.- pafis que solicitan los alumnos
            List<ListPafisSolic> ListPafisSolic = new List<ListPafisSolic>();
            // siempre es necesario saber el tipo de usuario
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            ViewData["tipo"] = tipo;
            using (sgcfieeContext context = new sgcfieeContext())
            {   // si se trata del director, se muestran todos  los pafis
                if (tipo == 1) {
                    ListPafis = (from pafis in context.PafisAcademicos
                                 join per in context.TipoPeriodo on pafis.IdPeriodo equals per.IdPeriodo
                                 join aca in context.Academicos on pafis.IdAcademico equals aca.IdAcademicos
                                 join salon in context.TbSalones on pafis.IdSalon equals salon.IdTbSalones
                                 join PE in context.ProgramaEducativo on pafis.IdProgramaImpacta equals PE.IdProgramaEducativo

                                 select new pPafisAcademicos
                                 {
                                     IdPafis = pafis.IdPafis,
                                     IdPeriodo = pafis.IdPeriodo,
                                     Periodo = per.Nombre,
                                     IdAcademico = pafis.IdAcademico,
                                     Npersonal = aca.NumeroPersonal,
                                     Nombre_academico = aca.Nombre + " " + aca.ApellidoPaterno + " " + aca.ApellidoMaterno,
                                     Tipopafi = pafis.Tipopafi,
                                     Solicitud = pafis.Solicitud,
                                     Nombre_pafi = pafis.Nombre,
                                     IdSalon = salon.IdTbSalones,
                                     Salon = salon.ClaveSalon,
                                     Edificio = salon.Edificio,
                                     Estado = pafis.Estado,
                                     NumeroCt = pafis.NumeroCt,
                                     Horario = pafis.Horario,
                                     PE = PE.Nombre,
                                     IdProgramaImpacta = pafis.IdProgramaImpacta,
                                     NumHoras = pafis.NumHoras
                                 }
                            ).ToList();
                    ViewData["pafis"] = ListPafis;

                    ListPafisSolic = (from pa in context.PafisSolicitados
                                 join per in context.TipoPeriodo on pa.IdPeriodo equals per.IdPeriodo
                                 join aca in context.Academicos on pa.IdAcademico equals aca.IdAcademicos
                                 join alum in context.Alumnos on pa.IdAlumno equals alum.IdAlumnos
                                 join dg in context.DatosPersonales  on alum.RDatosPerson equals dg.IdDatosPersonales

                                 select new ListPafisSolic
                                 {
                                     idPafiSolic = pa.IdpafisSolicitados,
                                     NombrePafi = pa.NombreSolicitados,
                                     Horario = pa.HorarioPosible,
                                     Nombre_academico = aca.Nombre + " " + aca.ApellidoPaterno + " " + aca.ApellidoMaterno,
                                     Periodo = per.Nombre,
                                     matricula = alum.Matricula,
                                     alumno = dg.Nombre + " " + dg.ApellidoPaterno + " " + dg.ApellidoMaterno
                                     
                                 }
                                ).ToList();
                    ViewData["pafisSolic"] = ListPafisSolic;
                }
                // si se trata de un académico solo se muestran los pafis donde esta involucrado
                if (tipo == 2)
                {
                    ListPafis = (from pafis in context.PafisAcademicos
                                 join per in context.TipoPeriodo on pafis.IdPeriodo equals per.IdPeriodo
                                 join aca in context.Academicos on pafis.IdAcademico equals aca.IdAcademicos
                                 join salon in context.TbSalones on pafis.IdSalon equals salon.IdTbSalones
                                 join PE in context.ProgramaEducativo on pafis.IdProgramaImpacta equals PE.IdProgramaEducativo
                                 where pafis.IdAcademico == (int)HttpContext.Session.GetInt32("IdUsu")
                    select new pPafisAcademicos
                                 {
                                     IdPafis = pafis.IdPafis,
                                     IdPeriodo = pafis.IdPeriodo,
                                     Periodo = per.Nombre,
                                     IdAcademico = pafis.IdAcademico,
                                     Npersonal = aca.NumeroPersonal,
                                     Nombre_academico = aca.Nombre + " " + aca.ApellidoPaterno + " " + aca.ApellidoMaterno,
                                     Tipopafi = pafis.Tipopafi,
                                     Solicitud = pafis.Solicitud,
                                     Nombre_pafi = pafis.Nombre,
                                     IdSalon = salon.IdTbSalones,
                                     Salon = salon.ClaveSalon,
                                     Edificio = salon.Edificio,
                                     Estado = pafis.Estado,
                                     NumeroCt = pafis.NumeroCt,
                                     Horario = pafis.Horario,
                                     PE = PE.Nombre,
                                     IdProgramaImpacta = pafis.IdProgramaImpacta,
                                     NumHoras = pafis.NumHoras
                                 }
                            ).ToList();
                    ViewData["pafis"] = ListPafis;
                }
                
            }
            return View();
        }

        [Authorize]
        // crear un pafi
        public IActionResult Crear()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList();
                var perio = context.TipoPeriodo.ToList();
                var pe = context.ProgramaEducativo.ToList();
                var salones = context.TbSalones.ToList();


                ViewData["academicos"] = acad;
                ViewData["periodos"] = perio;
                ViewData["pe"] = pe;
                ViewData["salones"] = salones;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        // guardar un pafi
        public async Task<IActionResult> Guardar(List<IFormFile> file, PafisAcademicos datos)
        {

            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            { // si se trata de un academico no se pide el id, se asigna aquí
                if (tipo == 2)
                {
                    datos.IdAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
                }
                var pa = context.PafisAcademicos.ToList();
                // verificamos que los datos no sean repetidos
                foreach (PafisAcademicos item in pa)
                {
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo && datos.IdSalon == item.IdSalon && datos.Horario == item.Horario)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("Index");
                    }
                } // guardamos los datos en la DB
                var new_name_table = "Pafi" + "_" + datos.IdAcademico + "_" + file[0].GetFilename();
                var new_name_table2 = "Acta" + "_" + datos.IdAcademico + "_" + file[1].GetFilename();
                datos.ArchivoPafi = new_name_table;
                datos.ArchivoActaA = new_name_table2;
                context.PafisAcademicos.Add(datos);
                context.SaveChanges();
            }
            // si no hay archivo, regresa este mensaje
            if (file[0] == null || file[0].Length == 0)
                return Content("file not selected");
            // guardamos el archivo en el servidor
            var new_name_file = "Pafi" + "_" + datos.IdAcademico + "_" + file[0].GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/PafisAcademicos", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file[0].CopyToAsync(stream);
            }
            // si no hay archivo, regresa este mensaje
            if (file[1] == null || file[1].Length == 0)
                return Content("file not selected");
            // guardamos los archivos en el servidor
            var new_name_file2 = "Acta" + "_" + datos.IdAcademico + "_" + file[1].GetFilename();
            var path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/PafisAcademicos", new_name_file2);

            using (var stream = new FileStream(path2, FileMode.Create))
            {
                await file[1].CopyToAsync(stream);
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("Index");
        }

        [Authorize]
        // recibe el id del registro
        public IActionResult Detalles(int id)
        {
            pPafisAcademicos Pafis = new pPafisAcademicos();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Pafis = (from pafis in context.PafisAcademicos
                             join per in context.TipoPeriodo on pafis.IdPeriodo equals per.IdPeriodo
                             join aca in context.Academicos on pafis.IdAcademico equals aca.IdAcademicos
                             join salon in context.TbSalones on pafis.IdSalon equals salon.IdTbSalones
                             join PE in context.ProgramaEducativo on pafis.IdProgramaImpacta equals PE.IdProgramaEducativo

                             select new pPafisAcademicos
                             {
                                 IdPafis = pafis.IdPafis,
                                 IdPeriodo = pafis.IdPeriodo,
                                 Periodo = per.Nombre,
                                 IdAcademico = pafis.IdAcademico,
                                 Npersonal = aca.NumeroPersonal,
                                 Nombre_academico = aca.Nombre + " " + aca.ApellidoPaterno + " " + aca.ApellidoMaterno,
                                 Tipopafi = pafis.Tipopafi,
                                 Solicitud = pafis.Solicitud,
                                 Nombre_pafi = pafis.Nombre,
                                 IdSalon = salon.IdTbSalones,
                                 Salon = salon.ClaveSalon,
                                 Edificio = salon.Edificio,
                                 Estado = pafis.Estado,
                                 NumeroCt = pafis.NumeroCt,
                                 Horario = pafis.Horario,
                                 PE = PE.Nombre,
                                 IdProgramaImpacta = pafis.IdProgramaImpacta,
                                 NumHoras = pafis.NumHoras,
                                 ArchivoPafi = pafis.ArchivoPafi,
                                 ArchivoActaA = pafis.ArchivoActaA
                                 
                             }
                            ).Single();
                return View(Pafis);
            }
            
        }

        [Authorize]
        // recibe el id del registro a editar
        public IActionResult Editar(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {

                PafisAcademicos pafi = context.PafisAcademicos.Where(s => s.IdPafis == id).Single();

                var acad = context.Academicos.ToList();
                var perio = context.TipoPeriodo.ToList();
                var pe = context.ProgramaEducativo.ToList();
                var salones = context.TbSalones.ToList();


                ViewData["academicos"] = acad;
                ViewData["periodos"] = perio;
                ViewData["pe"] = pe;
                ViewData["salones"] = salones;

                return View(pafi);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Actualizar(List<IFormFile> file, PafisAcademicos datos)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // si es un académico no se pide el id en el formulario, se busca aquí
                if (tipo == 2)
                {
                    datos.IdAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
                }
                //var pa = context.PafisAcademicos.ToList();
                //foreach (PafisAcademicos item in pa)
                //{
                //    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo && datos.IdSalon == item.IdSalon && datos.Horario == item.Horario)
                //    {
                //        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                //        return RedirectToAction("Index");

                //    }
                //}
            }
            using (sgcfieeContext context = new sgcfieeContext())
            { // si hay archivo, se modifica la ruta
                if (file.Count() > 0)
                {
                    var new_name_table = "Pafi" + "_" + datos.IdAcademico + "_" + file[0].GetFilename();
                    datos.ArchivoPafi = new_name_table;

                    var new_name_table2 = "Acta" + "_" + datos.IdAcademico + "_" + file[1].GetFilename();
                    datos.ArchivoActaA = new_name_table2;
                } // en caso contrario se guardan los mismas rutas
                else
                {
                    var nomArchivo = context.PafisAcademicos.Where(w => w.IdPafis == datos.IdPafis).Single();
                    datos.ArchivoPafi = nomArchivo.ArchivoPafi;
                    datos.ArchivoActaA = nomArchivo.ArchivoActaA;
                }

            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            // se guardan los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.PafisAcademicos.Update(datos);
                context.SaveChanges();
                
            }
            // si no hay archivos, acabamos y regresamos
            if (file.Count() == 0)
            {
                return RedirectToAction("Index");
            }
            // si hay archivo, lo guardamos primero en el servidor
            var new_name_file = "Pafi" + "_" + datos.IdAcademico + "_" + file[0].GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/PafisAcademicos", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file[0].CopyToAsync(stream);
            }

            var new_name_file2 = "Acta" + "_" + datos.IdAcademico + "_" + file[1].GetFilename();
            var path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/PafisAcademicos", new_name_file2);

            using (var stream = new FileStream(path2, FileMode.Create))
            {
                await file[1].CopyToAsync(stream);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                PafisAcademicos eliminar = context.PafisAcademicos.Where(w => w.IdPafis == id).Single();
                context.PafisAcademicos.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public IActionResult EliminarPafiSolic(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                PafisSolicitados eliminar = context.PafisSolicitados.Where(w => w.IdpafisSolicitados == id).Single();
                context.PafisSolicitados.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Descargar(string filename)
        {
            // si no hay url regresa el siguiente mensaje
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/PafisAcademicos", filename);

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
        // formatos que son compatibles
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
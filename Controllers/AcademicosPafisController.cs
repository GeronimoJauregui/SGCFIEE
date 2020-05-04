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
        {
            List<pPafisAcademicos> ListPafis = new List<pPafisAcademicos>();
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            ViewData["tipo"] = tipo;
            using (sgcfieeContext context = new sgcfieeContext())
            {
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
                }
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
        public async Task<IActionResult> Guardar(List<IFormFile> file, PafisAcademicos datos)
        {

            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 2)
                {
                    datos.IdAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
                }
                var pa = context.PafisAcademicos.ToList();
                foreach (PafisAcademicos item in pa)
                {
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo && datos.IdSalon == item.IdSalon && datos.Horario == item.Horario)
                    {
                        return RedirectToAction("Index");
                    }
                }
                var new_name_table = "Pafi" + "_" + datos.IdAcademico + "_" + file[0].GetFilename();
                var new_name_table2 = "Acta" + "_" + datos.IdAcademico + "_" + file[1].GetFilename();
                datos.ArchivoPafi = new_name_table;
                datos.ArchivoActaA = new_name_table2;
                context.PafisAcademicos.Add(datos);
                context.SaveChanges();
            }

            if (file[0] == null || file[0].Length == 0)
                return Content("file not selected");

            var new_name_file = "Pafi" + "_" + datos.IdAcademico + "_" + file[0].GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/PafisAcademicos", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file[0].CopyToAsync(stream);
            }

            if (file[1] == null || file[1].Length == 0)
                return Content("file not selected");

            var new_name_file2 = "Acta" + "_" + datos.IdAcademico + "_" + file[1].GetFilename();
            var path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/PafisAcademicos", new_name_file2);

            using (var stream = new FileStream(path2, FileMode.Create))
            {
                await file[1].CopyToAsync(stream);
            }

            return RedirectToAction("Index");
        }

        [Authorize]
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
                if (tipo == 2)
                {
                    datos.IdAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
                }
                var pa = context.PafisAcademicos.ToList();
                foreach (PafisAcademicos item in pa)
                {
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo && datos.IdSalon == item.IdSalon && datos.Horario == item.Horario)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file.Count() > 0)
                {
                    var new_name_table = "Pafi" + "_" + datos.IdAcademico + "_" + file[0].GetFilename();
                    datos.ArchivoPafi = new_name_table;

                    var new_name_table2 = "Acta" + "_" + datos.IdAcademico + "_" + file[1].GetFilename();
                    datos.ArchivoActaA = new_name_table2;
                }
                else
                {
                    var nomArchivo = context.PafisAcademicos.Where(w => w.IdPafis == datos.IdPafis).Single();
                    datos.ArchivoPafi = nomArchivo.ArchivoPafi;
                    datos.ArchivoActaA = nomArchivo.ArchivoActaA;
                }

            }

            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.PafisAcademicos.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }

            if (file.Count() == 0)
            {
                return RedirectToAction("Index");
            }

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

        public async Task<IActionResult> Descargar(string filename)
        {

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
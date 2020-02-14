using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGCFIEE.Models;
using System.Diagnostics;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SGCFIEE.Controllers
{
    public class AcademicosEvaluacionesController : Controller
    {
        // GET: /<controller>/
        
        [Authorize]
        public IActionResult IndexEvalEstudiantes()
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu");
            List<TablaCalifEstudiantes> ListCalifEstudiantes = new List<TablaCalifEstudiantes>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 1)
                {
                    ListCalifEstudiantes = (from calif in context.EvaluacionEstudiantes
                                            join acad in context.Academicos on calif.IdAcademico equals acad.IdAcademicos
                                            join perio in context.TipoPeriodo on calif.IdPeriodo equals perio.IdPeriodo
                                            select new TablaCalifEstudiantes
                                            {
                                                IdCalifEstudiantes = calif.IdEvaluacionEstudiantes,
                                                NumPersonal = acad.NumeroPersonal,
                                                Nombre = acad.Nombre,
                                                ApellidoPaterno = acad.ApellidoPaterno,
                                                ApellidoMaterno = acad.ApellidoMaterno,
                                                Calificacion = calif.Calificacion,
                                                Periodo = perio.Nombre,
                                                Status = acad.Status
                                            }
                                   ).ToList();
                }
                if (tipo == 2)
                {
                    ListCalifEstudiantes = (from calif in context.EvaluacionEstudiantes
                                            join acad in context.Academicos on calif.IdAcademico equals acad.IdAcademicos
                                            join perio in context.TipoPeriodo on calif.IdPeriodo equals perio.IdPeriodo
                                            where calif.IdAcademico == idUsu
                                            select new TablaCalifEstudiantes
                                            {
                                                IdCalifEstudiantes = calif.IdEvaluacionEstudiantes,
                                                NumPersonal = acad.NumeroPersonal,
                                                Nombre = acad.Nombre,
                                                ApellidoPaterno = acad.ApellidoPaterno,
                                                ApellidoMaterno = acad.ApellidoMaterno,
                                                Calificacion = calif.Calificacion,
                                                Periodo = perio.Nombre,
                                                Status = acad.Status
                                            }
                                   ).ToList();
                }
            }
            return View(ListCalifEstudiantes);
        }
        [Authorize]
        public IActionResult IndexEvalCT()
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu");
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<TablaCalifCT> ListCalifCT = new List<TablaCalifCT>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 1)
                {
                    ListCalifCT = (from calif in context.EvaluacionConsejoTecnico
                                   join acad in context.Academicos on calif.IdAcademico equals acad.IdAcademicos
                                   join perio in context.TipoPeriodo on calif.IdPeriodo equals perio.IdPeriodo
                                   select new TablaCalifCT
                                   {
                                       IdCalifCT = calif.IdConsejoTecnico,
                                       NumPersonal = acad.NumeroPersonal,
                                       Nombre = acad.Nombre,
                                       ApellidoPaterno = acad.ApellidoPaterno,
                                       ApellidoMaterno = acad.ApellidoMaterno,
                                       CalifDesempenio = calif.CalificacionDesempenio,
                                       CalifGestion = calif.CalificacionGestion,
                                       Periodo = perio.Nombre,
                                       Status = acad.Status
                                   }
                               ).ToList();
                }
                if (tipo == 2)
                {
                    ListCalifCT = (from calif in context.EvaluacionConsejoTecnico
                                   join acad in context.Academicos on calif.IdAcademico equals acad.IdAcademicos
                                   join perio in context.TipoPeriodo on calif.IdPeriodo equals perio.IdPeriodo
                                   where calif.IdAcademico == idUsu
                                   select new TablaCalifCT
                                   {
                                       IdCalifCT = calif.IdConsejoTecnico,
                                       NumPersonal = acad.NumeroPersonal,
                                       Nombre = acad.Nombre,
                                       ApellidoPaterno = acad.ApellidoPaterno,
                                       ApellidoMaterno = acad.ApellidoMaterno,
                                       CalifDesempenio = calif.CalificacionDesempenio,
                                       CalifGestion = calif.CalificacionGestion,
                                       Periodo = perio.Nombre,
                                       Status = acad.Status
                                   }
                               ).ToList();
                }
            }
            return View(ListCalifCT);
        }
        [Authorize]
        public IActionResult IndexEvalTutor()
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu");
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<TablaCalifTutor> ListCalifTutor = new List<TablaCalifTutor>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 1)
                {
                    ListCalifTutor = (from calif in context.TbCalificacionTutor
                                      join
                                      acad in context.Academicos on calif.RAcademicos equals acad.IdAcademicos
                                      join
                                      perio in context.TipoPeriodo on calif.RPeriodo equals perio.IdPeriodo
                                      select
                                      new TablaCalifTutor
                                      {
                                          IdCalifTutor = calif.IdTbCalificacionTutor,
                                          NumPersonal = acad.NumeroPersonal,
                                          Nombre = acad.Nombre,
                                          ApellidoPaterno = acad.ApellidoPaterno,
                                          ApellidoMaterno = acad.ApellidoMaterno,
                                          Calificacion = calif.Calificacion,
                                          Periodo = perio.Nombre,
                                          Status = acad.Status
                                      }
                                ).ToList();
                }
                if (tipo == 2)
                {
                    ListCalifTutor = (from calif in context.TbCalificacionTutor
                                      join
                                      acad in context.Academicos on calif.RAcademicos equals acad.IdAcademicos
                                      join
                                      perio in context.TipoPeriodo on calif.RPeriodo equals perio.IdPeriodo
                                      where calif.RAcademicos == idUsu
                                      select
                                      new TablaCalifTutor
                                      {
                                          IdCalifTutor = calif.IdTbCalificacionTutor,
                                          NumPersonal = acad.NumeroPersonal,
                                          Nombre = acad.Nombre,
                                          ApellidoPaterno = acad.ApellidoPaterno,
                                          ApellidoMaterno = acad.ApellidoMaterno,
                                          Calificacion = calif.Calificacion,
                                          Periodo = perio.Nombre,
                                          Status = acad.Status
                                      }
                                ).ToList();
                }
            }
            return View(ListCalifTutor);
        }

        [Authorize]
        public IActionResult CrearEvalCT()
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
        public IActionResult GuardarEvalCT(EvaluacionConsejoTecnico datos)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 2)
                {
                    datos.IdAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
                }
                var ListCalifCT = context.EvaluacionConsejoTecnico.ToList();
                foreach (EvaluacionConsejoTecnico item in ListCalifCT)
                {
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo)
                    {
                        return RedirectToAction("IndexEvalCT");
                    }
                }
           
                context.EvaluacionConsejoTecnico.Add(datos);
                context.SaveChanges();
            }
            return RedirectToAction("IndexEvalCT");
        }
        [Authorize]
        public IActionResult CrearEvalEstudiantes()
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
        public IActionResult GuardarEvalEstudiantes(EvaluacionEstudiantes datos)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 2)
                {
                    datos.IdAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
                }
                var ListCalifEstudiantes = context.EvaluacionEstudiantes.ToList();
                foreach (EvaluacionEstudiantes item in ListCalifEstudiantes)
                {
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo)
                    {
                        return RedirectToAction("IndexEvalEstudiantes");
                    }
                }
           
                context.EvaluacionEstudiantes.Add(datos);
                context.SaveChanges();
            }
            return RedirectToAction("IndexEvalEstudiantes");
        }
        [Authorize]
        public IActionResult CrearEvalTutor()
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
        public IActionResult GuardarEvalTutor(TbCalificacionTutor datos)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 2)
                {
                    datos.RAcademicos = (int)HttpContext.Session.GetInt32("IdUsu");
                }
                var ListCalifTutor = context.TbCalificacionTutor.ToList();
                foreach (TbCalificacionTutor item in ListCalifTutor)
                {
                    if(datos.RAcademicos == item.RAcademicos && datos.RPeriodo == item.RPeriodo)
                    {
                        return RedirectToAction("IndexEvalTutor");
                    }
                }
                context.TbCalificacionTutor.Add(datos);
                context.SaveChanges();
            }
            return RedirectToAction("IndexEvalTutor");
        }
        [Authorize]
        public IActionResult DatosEvalEstudiantes(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<CalifAcademicoEE> ListCalifEE = new List<CalifAcademicoEE>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                EvaluacionEstudiantes DatosCalifEstudiantes = context.EvaluacionEstudiantes.Where(s => s.IdEvaluacionEstudiantes == id).Single();
                ListCalifEE = (from calif in context.ExperienciaEducativaPeriodo
                               join acad in context.Academicos on calif.IdAcademico equals acad.IdAcademicos
                               join perio in context.TipoPeriodo on calif.IdPeriodo equals perio.IdPeriodo
                               join mapa in context.MapaCurricular on calif.IdMapaCurricular equals mapa.IdMapaCurricular
                               join EE in context.ExperienciaEducativa on mapa.IdExperienciaEducativa equals EE.IdExperienciaEducativa
                               join Institucion in context.InstitucionesEmpresas on calif.IdInstitucionSuperior equals Institucion.IdIE
                               select new CalifAcademicoEE
                               {
                                   IdAcademico = calif.IdAcademico,
                                   Institucion = Institucion.Nombre,
                                   IdCalifEE = calif.IdExperienciaEducativaPeriodo,
                                   IdPeriodo = calif.IdPeriodo,
                                   NumPersonal = acad.NumeroPersonal,
                                   Nombre = acad.Nombre,
                                   ApellidoPaterno = acad.ApellidoPaterno,
                                   ApellidoMaterno = acad.ApellidoMaterno,
                                   Nrc = calif.Nrc,
                                   Calificacion= calif.CalificacionAcademico,
                                   ExperienciaE = EE.Nombre,
                                   Periodo = perio.Nombre
                               }
                               ).Where(calif => calif.IdAcademico == DatosCalifEstudiantes.IdAcademico && calif.IdPeriodo == DatosCalifEstudiantes.IdPeriodo && calif.Institucion=="Universidad Veracruzana").ToList();
                
            }

                return View(ListCalifEE);
        }


        [Authorize]
        public IActionResult EditarEvalCT(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                EvaluacionConsejoTecnico DatosCalifCT = context.EvaluacionConsejoTecnico.Where(s => s.IdConsejoTecnico == id).Single();
                var perio = context.TipoPeriodo.ToList();
                var acad = context.Academicos.ToList();
                ViewData["periodos"] = perio;
                ViewData["academicos"] = acad;
                return View(DatosCalifCT);
            }
        }
        [Authorize]
        public IActionResult EditarEvalEstudiantes(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                EvaluacionEstudiantes DatosCalifEstudiantes = context.EvaluacionEstudiantes.Where(s => s.IdEvaluacionEstudiantes == id).Single();
                var perio = context.TipoPeriodo.ToList();
                var acad = context.Academicos.ToList();
                ViewData["periodos"] = perio;
                ViewData["academicos"] = acad;
                return View(DatosCalifEstudiantes);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult ActualizarEvalEstudiantes(EvaluacionEstudiantes datos)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu");
            if(tipo == 2)
            {
                datos.IdAcademico = idUsu;
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListCalifEstudiantes = context.EvaluacionEstudiantes.ToList();

                foreach (EvaluacionEstudiantes item in ListCalifEstudiantes)
                {
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo && datos.IdEvaluacionEstudiantes != item.IdEvaluacionEstudiantes)
                    {
                        return RedirectToAction("IndexEvalEstudiantes");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.EvaluacionEstudiantes.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            return RedirectToAction("IndexEvalEstudiantes");
        }
        [Authorize]
        public IActionResult EditarEvalTutor(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                TbCalificacionTutor DatosCalifTutor= context.TbCalificacionTutor.Where(s => s.IdTbCalificacionTutor == id).Single();
                var perio = context.TipoPeriodo.ToList();
                var acad = context.Academicos.ToList();
                ViewData["periodos"] = perio;
                ViewData["academicos"] = acad;
                return View(DatosCalifTutor);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult ActualizarEvalTutor(TbCalificacionTutor datos)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu");
            if (tipo == 2)
            {
                datos.RAcademicos = idUsu;
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListCalifTutor = context.TbCalificacionTutor.ToList();

                foreach (TbCalificacionTutor item in ListCalifTutor)
                {
                    if (datos.RAcademicos == item.RAcademicos && datos.RPeriodo == item.RPeriodo && datos.IdTbCalificacionTutor != item.IdTbCalificacionTutor)
                    {
                        return RedirectToAction("IndexEvalTutor");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                
                
                context.TbCalificacionTutor.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            return RedirectToAction("IndexEvalTutor");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult ActualizarEvalCT(EvaluacionConsejoTecnico datos)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu");
            if (tipo == 2)
            {
                datos.IdAcademico = idUsu;
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListCalifCT = context.EvaluacionConsejoTecnico.ToList();

                foreach (EvaluacionConsejoTecnico item in ListCalifCT)
                {
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo && datos.IdConsejoTecnico != item.IdConsejoTecnico)
                    {
                        return RedirectToAction("IndexEvalCT");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {


                context.EvaluacionConsejoTecnico.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            return RedirectToAction("IndexEvalCT");
        }

        public IActionResult EliminarEvalTutor(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                TbCalificacionTutor eliminar = context.TbCalificacionTutor.Where(w => w.IdTbCalificacionTutor == id).Single();
                context.TbCalificacionTutor.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexEvalTutor");
            }
        }
        public IActionResult EliminarEvalCT(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                EvaluacionConsejoTecnico eliminar = context.EvaluacionConsejoTecnico.Where(w => w.IdConsejoTecnico == id).Single();
                context.EvaluacionConsejoTecnico.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexEvalCT");
            }
        }
        public IActionResult EliminarEvalEstudiantes(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                EvaluacionEstudiantes eliminar = context.EvaluacionEstudiantes.Where(w => w.IdEvaluacionEstudiantes == id).Single();
                context.EvaluacionEstudiantes.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexEvalEstudiantes");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using SGCFIEE.Models;

namespace SGCFIEE.Controllers
{
    public class AcademicosExperienciaEducativaController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            List<pExperienciaEduPeriodo> ListEEP = new List<pExperienciaEduPeriodo>();
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu");
            ViewData["tipo"] = tipo;
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 1) {
                    ListEEP = (from EEP in context.ExperienciaEducativaPeriodo
                               join per in context.TipoPeriodo on EEP.IdPeriodo equals per.IdPeriodo
                               join aca in context.Academicos on EEP.IdAcademico equals aca.IdAcademicos
                               join ies in context.InstitucionesEmpresas on EEP.IdInstitucionSuperior equals ies.IdIE
                               join contra in context.TipoContratacionee on EEP.IdContratacionEe equals contra.IdTipoContratacion
                               join salon in context.TbSalones on EEP.IdSalon equals salon.IdTbSalones
                               join MC in context.MapaCurricular on EEP.IdMapaCurricular equals MC.IdMapaCurricular
                               join EE in context.ExperienciaEducativa on MC.IdExperienciaEducativa equals EE.IdExperienciaEducativa
                               join PE in context.ProgramaEducativo on MC.IdProgramaEducativo equals PE.IdProgramaEducativo
                               join are in context.AreaExperienciaEducativa on EE.IdArea equals are.IdAreaExperienciaEducativa
                               where ies.Nombre == "Universidad Veracruzana"

                               select new pExperienciaEduPeriodo
                               {
                                   IdExperienciaEducativaPeriodo = EEP.IdExperienciaEducativaPeriodo,
                                   Nrc = EEP.Nrc,
                                   IdPeriodo = EEP.IdPeriodo,
                                   periodo = per.Nombre,
                                   IdAcademico = EEP.IdAcademico,
                                   Npersonal = aca.NumeroPersonal,
                                   academico = aca.Nombre + " " + aca.ApellidoPaterno + " " + aca.ApellidoMaterno,
                                   IdInstitucionSuperior = EEP.IdInstitucionSuperior,
                                   institucion = ies.Nombre,
                                   IdContratacionEe = EEP.IdContratacionEe,
                                   tipo_contratacion = contra.Nombre,
                                   IdSalon = EEP.IdSalon,
                                   salon = salon.ClaveSalon,
                                   CalificacionAcademico = EEP.CalificacionAcademico,
                                   Status = EEP.Status,
                                   IdMapaCurricular = EEP.IdMapaCurricular,
                                   EE = EE.Nombre,
                                   PE = PE.Nombre,
                                   creditos = EE.Creditos,
                                   area = are.Nombre,
                                   horas = EE.Horas
                               }
                        ).ToList();
                }
                if (tipo == 2)
                {
                    ListEEP = (from EEP in context.ExperienciaEducativaPeriodo
                               join per in context.TipoPeriodo on EEP.IdPeriodo equals per.IdPeriodo
                               join aca in context.Academicos on EEP.IdAcademico equals aca.IdAcademicos
                               join ies in context.InstitucionesEmpresas on EEP.IdInstitucionSuperior equals ies.IdIE
                               join contra in context.TipoContratacionee on EEP.IdContratacionEe equals contra.IdTipoContratacion
                               join salon in context.TbSalones on EEP.IdSalon equals salon.IdTbSalones
                               join MC in context.MapaCurricular on EEP.IdMapaCurricular equals MC.IdMapaCurricular
                               join EE in context.ExperienciaEducativa on MC.IdExperienciaEducativa equals EE.IdExperienciaEducativa
                               join PE in context.ProgramaEducativo on MC.IdProgramaEducativo equals PE.IdProgramaEducativo
                               join are in context.AreaExperienciaEducativa on EE.IdArea equals are.IdAreaExperienciaEducativa
                               where ies.Nombre == "Universidad Veracruzana" && aca.IdAcademicos == idUsu

                               select new pExperienciaEduPeriodo
                               {
                                   IdExperienciaEducativaPeriodo = EEP.IdExperienciaEducativaPeriodo,
                                   Nrc = EEP.Nrc,
                                   IdPeriodo = EEP.IdPeriodo,
                                   periodo = per.Nombre,
                                   IdAcademico = EEP.IdAcademico,
                                   Npersonal = aca.NumeroPersonal,
                                   academico = aca.Nombre + " " + aca.ApellidoPaterno + " " + aca.ApellidoMaterno,
                                   IdInstitucionSuperior = EEP.IdInstitucionSuperior,
                                   institucion = ies.Nombre,
                                   IdContratacionEe = EEP.IdContratacionEe,
                                   tipo_contratacion = contra.Nombre,
                                   IdSalon = EEP.IdSalon,
                                   salon = salon.ClaveSalon,
                                   CalificacionAcademico = EEP.CalificacionAcademico,
                                   Status = EEP.Status,
                                   IdMapaCurricular = EEP.IdMapaCurricular,
                                   EE = EE.Nombre,
                                   PE = PE.Nombre,
                                   creditos = EE.Creditos,
                                   area = are.Nombre,
                                   horas = EE.Horas
                               }
                        ).ToList();
                }

                    ViewData["EEP"] = ListEEP;
            }
            return View();
        }

        [Authorize]
        public IActionResult CrearEEUV()
        {
            List<MCEE> ListMCEE = new List<MCEE>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList();
                var perio = context.TipoPeriodo.ToList();
                var expEdu = context.ExperienciaEducativa.ToList();
                var salones = context.TbSalones.ToList();
                var tipo_contratacionee = context.TipoContratacionee.ToList();

                ListMCEE = (from MC in context.MapaCurricular
                                        join EE in context.ExperienciaEducativa on MC.IdExperienciaEducativa equals EE.IdExperienciaEducativa
                                        join PE in context.ProgramaEducativo on MC.IdProgramaEducativo equals PE.IdProgramaEducativo
                                        where  PE.Nombre != "Externo"
                                        select new MCEE
                                        {
                                            IdMapaCurricular = MC.IdMapaCurricular,
                                            IdExperienciaEducativa = MC.IdExperienciaEducativa,
                                            NombreEE = EE.Nombre,
                                            IdProgramaEducativo = MC.IdProgramaEducativo,
                                            NombrePE = PE.Nombre,
                                            Estado = MC.Estado
                                            
                                        }
                               ).ToList();


                ViewData["academicos"] = acad;
                ViewData["periodos"] = perio;
                ViewData["ExpEdu"] = ListMCEE;
                ViewData["salones"] = salones;
                ViewData["tipo_contratacionee"] = tipo_contratacionee;
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult GuardarEEUV(ExperienciaEducativaPeriodo datos)
        {
            
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 2) {
                    datos.IdAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
                }
                InstitucionesEmpresas uv = context.InstitucionesEmpresas.Where(w => w.Nombre == "Universidad Veracruzana").Single();
                
                datos.IdInstitucionSuperior = uv.IdIE;
                datos.Status = 1;
                context.ExperienciaEducativaPeriodo.Add(datos);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult DetallesEEUV( int id)
        {
            List<pExperienciaEduPeriodo> ListEEP = new List<pExperienciaEduPeriodo>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListEEP = (from EEP in context.ExperienciaEducativaPeriodo
                           join per in context.TipoPeriodo on EEP.IdPeriodo equals per.IdPeriodo
                           join aca in context.Academicos on EEP.IdAcademico equals aca.IdAcademicos
                           join ies in context.InstitucionesEmpresas on EEP.IdInstitucionSuperior equals ies.IdIE
                           join contra in context.TipoContratacionee on EEP.IdContratacionEe equals contra.IdTipoContratacion
                           join salon in context.TbSalones on EEP.IdSalon equals salon.IdTbSalones
                           join MC in context.MapaCurricular on EEP.IdMapaCurricular equals MC.IdMapaCurricular
                           join EE in context.ExperienciaEducativa on MC.IdExperienciaEducativa equals EE.IdExperienciaEducativa
                           join PE in context.ProgramaEducativo on MC.IdProgramaEducativo equals PE.IdProgramaEducativo
                           join are in context.AreaExperienciaEducativa on EE.IdArea equals are.IdAreaExperienciaEducativa
                           where ies.Nombre == "Universidad Veracruzana"

                           select new pExperienciaEduPeriodo
                           {
                               IdExperienciaEducativaPeriodo = EEP.IdExperienciaEducativaPeriodo,
                               Nrc = EEP.Nrc,
                               IdPeriodo = EEP.IdPeriodo,
                               periodo = per.Nombre,
                               IdAcademico = EEP.IdAcademico,
                               Npersonal = aca.NumeroPersonal,
                               academico = aca.Nombre + " " + aca.ApellidoPaterno + " " + aca.ApellidoMaterno,
                               IdInstitucionSuperior = EEP.IdInstitucionSuperior,
                               institucion = ies.Nombre,
                               IdContratacionEe = EEP.IdContratacionEe,
                               tipo_contratacion = contra.Nombre,
                               IdSalon = EEP.IdSalon,
                               salon = salon.ClaveSalon,
                               CalificacionAcademico = EEP.CalificacionAcademico,
                               Status = EEP.Status,
                               IdMapaCurricular = EEP.IdMapaCurricular,
                               EE = EE.Nombre,
                               PE = PE.Nombre,
                               creditos = EE.Creditos,
                               area = are.Nombre,
                               horas = EE.Horas
                           }
                            ).Where(EEP => EEP.IdExperienciaEducativaPeriodo == id).ToList();
                ViewData["EEP"] = ListEEP;
            }
            return View();
        }

        [Authorize]
        public IActionResult EditarEEUV(int id)
        {
            List<MCEE> ListMCEE = new List<MCEE>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {

                ExperienciaEducativaPeriodo Datoseep = context.ExperienciaEducativaPeriodo.Where(s => s.IdExperienciaEducativaPeriodo == id).Single();


                var acad = context.Academicos.ToList();
                var perio = context.TipoPeriodo.ToList();
                var expEdu = context.ExperienciaEducativa.ToList();
                var salones = context.TbSalones.ToList();
                var tipo_contratacionee = context.TipoContratacionee.ToList();

                ListMCEE = (from MC in context.MapaCurricular
                            join EE in context.ExperienciaEducativa on MC.IdExperienciaEducativa equals EE.IdExperienciaEducativa
                            join PE in context.ProgramaEducativo on MC.IdProgramaEducativo equals PE.IdProgramaEducativo
                            where PE.Nombre != "Externo"
                            select new MCEE
                            {
                                IdMapaCurricular = MC.IdMapaCurricular,
                                IdExperienciaEducativa = MC.IdExperienciaEducativa,
                                NombreEE = EE.Nombre,
                                IdProgramaEducativo = MC.IdProgramaEducativo,
                                NombrePE = PE.Nombre,
                                Estado = MC.Estado

                            }
                               ).ToList();


                ViewData["academicos"] = acad;
                ViewData["periodos"] = perio;
                ViewData["ExpEdu"] = ListMCEE;
                ViewData["salones"] = salones;
                ViewData["tipo_contratacionee"] = tipo_contratacionee;

                return View(Datoseep);
            }

        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ActualizarEEUV(ExperienciaEducativaPeriodo datos)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 2)
                {
                    datos.IdAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
                }


                context.ExperienciaEducativaPeriodo.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            return RedirectToAction("Index");
        }

        public IActionResult EliminarEEUV(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ExperienciaEducativaPeriodo eliminar = context.ExperienciaEducativaPeriodo.Where(w => w.IdExperienciaEducativaPeriodo == id).Single();
                context.ExperienciaEducativaPeriodo.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [Authorize]
        public IActionResult IndexEEEUV()
        {
            List<pExperienciaEduPeriodo> ListEEP = new List<pExperienciaEduPeriodo>();
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu");
            ViewData["tipo"] = tipo;
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 1) {
                    ListEEP = (from EEP in context.ExperienciaEducativaPeriodo
                               join per in context.TipoPeriodo on EEP.IdPeriodo equals per.IdPeriodo
                               join aca in context.Academicos on EEP.IdAcademico equals aca.IdAcademicos
                               join ies in context.InstitucionesEmpresas on EEP.IdInstitucionSuperior equals ies.IdIE
                               join MC in context.MapaCurricular on EEP.IdMapaCurricular equals MC.IdMapaCurricular
                               join EE in context.ExperienciaEducativa on MC.IdExperienciaEducativa equals EE.IdExperienciaEducativa
                               where ies.Nombre != "Universidad Veracruzana"

                               select new pExperienciaEduPeriodo
                               {
                                   IdExperienciaEducativaPeriodo = EEP.IdExperienciaEducativaPeriodo,
                                   IdPeriodo = EEP.IdPeriodo,
                                   periodo = per.Nombre,
                                   IdAcademico = EEP.IdAcademico,
                                   Npersonal = aca.NumeroPersonal,
                                   academico = aca.Nombre + " " + aca.ApellidoPaterno + " " + aca.ApellidoMaterno,
                                   IdInstitucionSuperior = EEP.IdInstitucionSuperior,
                                   institucion = ies.Nombre,
                                   Status = EEP.Status,
                                   IdMapaCurricular = EEP.IdMapaCurricular,
                                   EE = EE.Nombre,
                               }
                            ).ToList();
                }
                if (tipo == 2)
                {
                    ListEEP = (from EEP in context.ExperienciaEducativaPeriodo
                               join per in context.TipoPeriodo on EEP.IdPeriodo equals per.IdPeriodo
                               join aca in context.Academicos on EEP.IdAcademico equals aca.IdAcademicos
                               join ies in context.InstitucionesEmpresas on EEP.IdInstitucionSuperior equals ies.IdIE
                               join MC in context.MapaCurricular on EEP.IdMapaCurricular equals MC.IdMapaCurricular
                               join EE in context.ExperienciaEducativa on MC.IdExperienciaEducativa equals EE.IdExperienciaEducativa
                               where ies.Nombre != "Universidad Veracruzana" && EEP.IdAcademico == idUsu

                               select new pExperienciaEduPeriodo
                               {
                                   IdExperienciaEducativaPeriodo = EEP.IdExperienciaEducativaPeriodo,
                                   IdPeriodo = EEP.IdPeriodo,
                                   periodo = per.Nombre,
                                   IdAcademico = EEP.IdAcademico,
                                   Npersonal = aca.NumeroPersonal,
                                   academico = aca.Nombre + " " + aca.ApellidoPaterno + " " + aca.ApellidoMaterno,
                                   IdInstitucionSuperior = EEP.IdInstitucionSuperior,
                                   institucion = ies.Nombre,
                                   Status = EEP.Status,
                                   IdMapaCurricular = EEP.IdMapaCurricular,
                                   EE = EE.Nombre,
                               }
                            ).ToList();
                }
                
                ViewData["EEP"] = ListEEP;
            }
            return View();
        }


        [Authorize]
        public IActionResult CrearEEEUV()
        {
            List<MCEE> ListMCEE = new List<MCEE>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList();
                var perio = context.TipoPeriodo.ToList();
                var salones = context.TbSalones.ToList();
                var ies = context.InstitucionesEmpresas.Where(w => w.Nombre != "Universidad Veracruzana" && w.IesEmpresa == 2).ToList();

                var mc = (from MC in context.MapaCurricular
                            join EE in context.ExperienciaEducativa on MC.IdExperienciaEducativa equals EE.IdExperienciaEducativa
                            join PE in context.ProgramaEducativo on MC.IdProgramaEducativo equals PE.IdProgramaEducativo
                            where PE.Nombre == "Externo"
                            select new MCEE
                            {
                                IdMapaCurricular = MC.IdMapaCurricular,
                                IdExperienciaEducativa = MC.IdExperienciaEducativa,
                                NombreEE = EE.Nombre,
                                Estado = MC.Estado
                            }
                               ).ToList();

                ViewData["academicos"] = acad;
                ViewData["periodos"] = perio;
                ViewData["ee"] = mc;
                ViewData["ies"] = ies;
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult GuardarEEEUV(ExperienciaEducativaPeriodo datos, string nuevaInstitucion, string nuevaEEE)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 2)
                {
                    datos.IdAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
                }

                if (nuevaInstitucion != null)
                {
                    InstitucionesEmpresas nuevo = new InstitucionesEmpresas();
                    nuevo.Nombre = nuevaInstitucion;
                    nuevo.IesEmpresa = 2;
                    context.InstitucionesEmpresas.Add(nuevo);
                    context.SaveChanges();
                    InstitucionesEmpresas ultima = context.InstitucionesEmpresas.Last();
                    datos.IdInstitucionSuperior = ultima.IdIE;
                }
                if (nuevaEEE != null)
                {
                    var ListAEE = context.AreaExperienciaEducativa.ToList();
                    AreaExperienciaEducativa datoAEE = new AreaExperienciaEducativa();
                    foreach (AreaExperienciaEducativa item in ListAEE)
                    { 
                        if (item.Nombre == "Externo")
                        {
                            datoAEE = item;
                            break;
                        }
                    }
                    ExperienciaEducativa nuevo = new ExperienciaEducativa();
                    nuevo.Nombre = nuevaEEE;
                    nuevo.Creditos = 0;
                    nuevo.Horas = 0;
                    nuevo.IdArea = datoAEE.IdAreaExperienciaEducativa;
                    nuevo.Status = 1;
                    context.ExperienciaEducativa.Add(nuevo);
                    context.SaveChanges();
                    ExperienciaEducativa ultima = context.ExperienciaEducativa.Last();

                    var ListPE = context.ProgramaEducativo.ToList();
                    ProgramaEducativo datoPE = new ProgramaEducativo();
                    foreach (ProgramaEducativo item in ListPE)
                    {
                        if (item.Nombre == "Externo")
                        {
                            datoPE = item;
                            break;
                        }
                    }
                    MapaCurricular nuevainfo = new MapaCurricular();
                    nuevainfo.IdProgramaEducativo = datoPE.IdProgramaEducativo;
                    nuevainfo.IdExperienciaEducativa = ultima.IdExperienciaEducativa;
                    nuevainfo.Estado = 1;
                    context.MapaCurricular.Add(nuevainfo);
                    context.SaveChanges();
                    MapaCurricular ultimo = context.MapaCurricular.Last();
                    datos.IdMapaCurricular = ultimo.IdMapaCurricular;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                datos.Status = 1;
                context.ExperienciaEducativaPeriodo.Add(datos);
                context.SaveChanges();
            }
            return RedirectToAction("IndexEEEUV");
        }

        [Authorize]
        public IActionResult EditarEEEUV(int id)
        {
            List<MCEE> ListMCEE = new List<MCEE>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ExperienciaEducativaPeriodo Datoseep = context.ExperienciaEducativaPeriodo.Where(s => s.IdExperienciaEducativaPeriodo == id).Single();

                var acad = context.Academicos.ToList();
                var perio = context.TipoPeriodo.ToList();
                var salones = context.TbSalones.ToList();
                var ies = context.InstitucionesEmpresas.Where(w => w.Nombre != "Universidad Veracruzana" && w.IesEmpresa == 2).ToList();

                var mc = (from MC in context.MapaCurricular
                          join EE in context.ExperienciaEducativa on MC.IdExperienciaEducativa equals EE.IdExperienciaEducativa
                          join PE in context.ProgramaEducativo on MC.IdProgramaEducativo equals PE.IdProgramaEducativo
                          where PE.Nombre == "Externo"
                          select new MCEE
                          {
                              IdMapaCurricular = MC.IdMapaCurricular,
                              IdExperienciaEducativa = MC.IdExperienciaEducativa,
                              NombreEE = EE.Nombre,
                              Estado = MC.Estado
                          }
                               ).ToList();

                ViewData["academicos"] = acad;
                ViewData["periodos"] = perio;
                ViewData["ee"] = mc;
                ViewData["ies"] = ies;
                return View(Datoseep);
            }
            
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ActualizarEEEUV(ExperienciaEducativaPeriodo datos, string nuevaInstitucion)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 2)
                {
                    datos.IdAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
                }

                if (nuevaInstitucion != null)
                {
                    InstitucionesEmpresas nuevo = new InstitucionesEmpresas();
                    nuevo.Nombre = nuevaInstitucion;
                    nuevo.IesEmpresa = 2;
                    context.InstitucionesEmpresas.Add(nuevo);
                    context.SaveChanges();
                    InstitucionesEmpresas ultima = context.InstitucionesEmpresas.Last();
                    datos.IdInstitucionSuperior = ultima.IdIE;
                }

                context.ExperienciaEducativaPeriodo.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            return RedirectToAction("IndexEEEUV");
        }

        public IActionResult EliminarEEEUV(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ExperienciaEducativaPeriodo eliminar = context.ExperienciaEducativaPeriodo.Where(w => w.IdExperienciaEducativaPeriodo == id).Single();
                context.ExperienciaEducativaPeriodo.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexEEEUV");
            }
        }
    }

   
}
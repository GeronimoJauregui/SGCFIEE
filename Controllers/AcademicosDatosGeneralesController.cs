﻿using System;
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
    public class AcademicosDatosGeneralesController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var dg = (from aca in context.Academicos
                          join pe in context.ProgramaEducativo on aca.IdProgramaEducativo equals pe.IdProgramaEducativo
                          join tp in context.TipoPersonal on aca.RTipoPersonal equals tp.IdTipoPersonal
                          select new pAcademicos
                          {
                              IdAcademicos = aca.IdAcademicos,
                              Nombre = aca.Nombre,
                              ApellidoPaterno = aca.ApellidoPaterno,
                              ApellidoMaterno = aca.ApellidoMaterno,
                              FechaNacimiento = aca.FechaNacimiento,
                              Curp = aca.Curp,
                              CorreoInstitucional = aca.CorreoInstitucional,
                              CorreoAlternativo = aca.CorreoAlternativo,
                              Celular = aca.Celular,
                              Sexo = aca.Sexo,
                              ProgramaEducativo = pe.Nombre,
                              NumeroPersonal = aca.NumeroPersonal,
                              FechaIngresoUv = aca.FechaIngresoUv,
                              Status = aca.Status,
                              RTipoPersonal = aca.RTipoPersonal,
                              tipoPersonal = tp.Nombre

                          }
                               ).ToList();

                foreach (var item in dg)
                {
                    if (item.Sexo == 0)
                        item.Nombre_Sexo = "Femenino";
                    if (item.Sexo == 1)
                        item.Nombre_Sexo = "Masculino";
                    if (item.Status == 1)
                        item.NombreStatus = "Activo";
                    if (item.Status == 2)
                        item.NombreStatus = "Inactivo";
                    if (item.Status == 3)
                        item.NombreStatus = "Incapacitado";
                }

                ViewData["academicos"] = dg;
            }
            return View();
        }

        [Authorize]
        public IActionResult CrearDG()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var pe = context.ProgramaEducativo.ToList();
                ViewData["pe"] = pe;
            }
            return View();
        }

        public IActionResult EditarDG(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var aca = context.Academicos.Where(w => w.IdAcademicos==id).Single();
                var pe = context.ProgramaEducativo.ToList();
                ViewData["pe"] = pe;
                ViewData["aca"] = aca;
                ViewData["academico"] = id;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult GuardarDG(Academicos datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                datos.RTipoPersonal = 2;
                context.Academicos.Add(datos);
                context.SaveChanges();
            }

            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicos aca = context.Academicos.Last();
                return RedirectToAction("TablaGA", new { id = aca.IdAcademicos});
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult ActualizarDG(Academicos datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.Academicos.Update(datos);
                context.SaveChanges();
            }

            using (sgcfieeContext context = new sgcfieeContext())
            {
                return RedirectToAction("EditarDG", new { id = datos.IdAcademicos });
            }

        }

        [Authorize]
        public IActionResult TablaGA(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pEstudios> estudios = new List<pEstudios>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var NombreTitulo = context.NombreTitulo.ToList();
                var ies = context.InstitucionesEmpresas.Where(w => w.IesEmpresa == 2).ToList();
                var GradoTitulo = context.GradoTitulo.ToList();

                estudios = (from es in context.Estudios
                            join nt in context.NombreTitulo on es.IdNombreTitulo equals nt.IdNombreTitulo
                            join ie in context.InstitucionesEmpresas on es.IdInstitucion equals ie.IdIE
                            join gt in context.GradoTitulo on es.IdGradoTitulo equals gt.IdGradoTitulo
                            where es.IdAcademico == id
                            select new pEstudios
                            {
                                IdEstudios = es.IdEstudios,
                                IdAcademico = es.IdAcademico,
                                NombreTitulo = nt.Nombre,
                                Institucion = ie.Nombre,
                                GradoTitulo = gt.Nombre,
                                AcrePnpc = es.AcrePnpc,
                                FechaDeEgreso = es.FechaDeEgreso,
                                FechaDeTitulacion = es.FechaDeTitulacion
                            }
                               ).ToList();

                foreach (pEstudios item in estudios) {
                    if (item.AcrePnpc == 0)
                        item.Reconocimiento = "Ninguno";
                    if (item.AcrePnpc == 1)
                        item.Reconocimiento = "Acreditado";
                    if (item.AcrePnpc == 0)
                        item.Reconocimiento = "PNPC";
                }
                ViewData["nt"] = NombreTitulo;
                ViewData["gt"] = GradoTitulo;
                ViewData["ies"] = ies;
                ViewData["academico"] = id;
                ViewData["estudios"] = estudios;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarTablaGA(List<IFormFile> file, Estudios datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = "Titulo" + "_" + datos.IdAcademico + "_" + datos.IdNombreTitulo + "_" + file[0].GetFilename();
                var new_name_table2 = "Cedula" + "_" + datos.IdAcademico + "_" + datos.IdNombreTitulo + "_" + file[1].GetFilename();
                datos.ArchivoTitulo = new_name_table;
                datos.ArchivoCedula = new_name_table2;
                context.Estudios.Add(datos);
                context.SaveChanges();
            }

            if (file[0] == null || file[0].Length == 0)
                return Content("file not selected");

            var new_name_file = "Titulo" + "_" + datos.IdAcademico + "_" + datos.IdNombreTitulo + "_" + file[0].GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Estudios", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file[0].CopyToAsync(stream);
            }

            if (file[1] == null || file[1].Length == 0)
                return Content("file not selected");

            var new_name_file2 = "Cedula" + "_" + datos.IdAcademico + "_" + datos.IdNombreTitulo + "_" + file[1].GetFilename();
            var path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Estudios", new_name_file2);

            using (var stream = new FileStream(path2, FileMode.Create))
            {
                await file[1].CopyToAsync(stream);
            }

            return RedirectToAction("TablaGA",new { id = datos.IdAcademico});
        }

        [Authorize]
        public IActionResult EditarGA(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pEstudios> estudios = new List<pEstudios>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                estudios = (from es in context.Estudios
                            join nt in context.NombreTitulo on es.IdNombreTitulo equals nt.IdNombreTitulo
                            join ie in context.InstitucionesEmpresas on es.IdInstitucion equals ie.IdIE
                            join gt in context.GradoTitulo on es.IdGradoTitulo equals gt.IdGradoTitulo
                            where es.IdAcademico == id
                            select new pEstudios
                            {
                                IdEstudios = es.IdEstudios,
                                IdAcademico = es.IdAcademico,
                                NombreTitulo = nt.Nombre,
                                Institucion = ie.Nombre,
                                GradoTitulo = gt.Nombre,
                                AcrePnpc = es.AcrePnpc,
                                FechaDeEgreso = es.FechaDeEgreso,
                                FechaDeTitulacion = es.FechaDeTitulacion
                            }
                               ).ToList();

                foreach (pEstudios item in estudios)
                {
                    if (item.AcrePnpc == 0)
                        item.Reconocimiento = "Ninguno";
                    if (item.AcrePnpc == 1)
                        item.Reconocimiento = "Acreditado";
                    if (item.AcrePnpc == 0)
                        item.Reconocimiento = "PNPC";
                }
                ViewData["academico"] = id;
                ViewData["estudios"] = estudios;
            }
            return View();
        }

        [Authorize]
        public IActionResult FormCrearGA(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var NombreTitulo = context.NombreTitulo.ToList();
                var ies = context.InstitucionesEmpresas.Where(w => w.IesEmpresa == 2).ToList();
                var GradoTitulo = context.GradoTitulo.ToList();

                ViewData["nt"] = NombreTitulo;
                ViewData["gt"] = GradoTitulo;
                ViewData["ies"] = ies;
                ViewData["academico"] = id;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarFormTablaGA(List<IFormFile> file, Estudios datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = "Titulo" + "_" + datos.IdAcademico + "_" + datos.IdNombreTitulo + "_" + file[0].GetFilename();
                var new_name_table2 = "Cedula" + "_" + datos.IdAcademico + "_" + datos.IdNombreTitulo + "_" + file[1].GetFilename();
                datos.ArchivoTitulo = new_name_table;
                datos.ArchivoCedula = new_name_table2;
                context.Estudios.Add(datos);
                context.SaveChanges();
            }

            if (file[0] == null || file[0].Length == 0)
                return Content("file not selected");

            var new_name_file = "Titulo" + "_" + datos.IdAcademico + "_" + datos.IdNombreTitulo + "_" + file[0].GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Estudios", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file[0].CopyToAsync(stream);
            }

            if (file[1] == null || file[1].Length == 0)
                return Content("file not selected");

            var new_name_file2 = "Cedula" + "_" + datos.IdAcademico + "_" + datos.IdNombreTitulo + "_" + file[1].GetFilename();
            var path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Estudios", new_name_file2);

            using (var stream = new FileStream(path2, FileMode.Create))
            {
                await file[1].CopyToAsync(stream);
            }

            return RedirectToAction("EditarGA", new { id = datos.IdAcademico });
        }

        [Authorize]
        public IActionResult FormEditarGA(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var NombreTitulo = context.NombreTitulo.ToList();
                var ies = context.InstitucionesEmpresas.Where(w => w.IesEmpresa == 2).ToList();
                var GradoTitulo = context.GradoTitulo.ToList();
                var ga = context.Estudios.Where(w => w.IdEstudios == id).Single();

                ViewData["nt"] = NombreTitulo;
                ViewData["gt"] = GradoTitulo;
                ViewData["ies"] = ies;
                ViewData["academico"] = id;
                return View(ga);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> FormActualizarTablaGA(IFormFile file, IFormFile file2, Estudios datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = "Titulo" + "_" + datos.IdAcademico + "_" + datos.IdNombreTitulo + "_" + file.GetFilename();
                var new_name_table2 = "Cedula" + "_" + datos.IdAcademico + "_" + datos.IdNombreTitulo + "_" + file2.GetFilename();
                datos.ArchivoTitulo = new_name_table;
                datos.ArchivoCedula = new_name_table2;
                context.Estudios.Update(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = "Titulo" + "_" + datos.IdAcademico + "_" + datos.IdNombreTitulo + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Estudios", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            if (file2 == null || file2.Length == 0)
                return Content("file not selected");

            var new_name_file2 = "Cedula" + "_" + datos.IdAcademico + "_" + datos.IdNombreTitulo + "_" + file2.GetFilename();
            var path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Estudios", new_name_file2);

            using (var stream = new FileStream(path2, FileMode.Create))
            {
                await file2.CopyToAsync(stream);
            }

            return RedirectToAction("EditarGA", new { id = datos.IdAcademico });
        }

        public IActionResult TablaCertificaciones(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pCertificaciones> certificaciones = new List<pCertificaciones>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var tc = context.TipoCertificacion.ToList();

                certificaciones = (from cer in context.Certificaciones
                                join tcer in context.TipoCertificacion on cer.IdTipoCertificacion equals tcer.IdCertificacion
                                where cer.IdAcademico == id
                                select new pCertificaciones
                                {
                                    IdCertificaciones = cer.IdCertificaciones,
                                    Nombre = cer.Nombre,
                                    IdTipoCertificacion = cer.IdTipoCertificacion,
                                    TipoCertificacion = tcer.Nombre,
                                    IdAcademico = cer.IdAcademico,
                                }
                                   ).ToList();

                ViewData["tc"] = tc;
                ViewData["cer"] = certificaciones;
                ViewData["academico"] = id;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarTablaCertificaciones(IFormFile file, Certificaciones datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = "Certificacion" + "_" + datos.IdAcademico + "_" + datos.Nombre + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.Certificaciones.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = "Certificacion" + "_" + datos.IdAcademico + "_" + datos.Nombre + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Certificaciones", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("TablaCertificaciones", new { id = datos.IdAcademico });
        }

        public IActionResult EditarCertificaciones(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pCertificaciones> certificaciones = new List<pCertificaciones>();
            using (sgcfieeContext context = new sgcfieeContext())
            {

                certificaciones = (from cer in context.Certificaciones
                                   join tcer in context.TipoCertificacion on cer.IdTipoCertificacion equals tcer.IdCertificacion
                                   where cer.IdAcademico == id
                                   select new pCertificaciones
                                   {
                                       IdCertificaciones = cer.IdCertificaciones,
                                       Nombre = cer.Nombre,
                                       IdTipoCertificacion = cer.IdTipoCertificacion,
                                       TipoCertificacion = tcer.Nombre,
                                       IdAcademico = cer.IdAcademico,
                                       Archivo = cer.Archivo
                                   }
                                   ).ToList();

                ViewData["cer"] = certificaciones;
                ViewData["academico"] = id;
            }
            return View();
        }

        public IActionResult TablaCD(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pCursosDiplomadoFormacion> CD = new List<pCursosDiplomadoFormacion>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ies = context.InstitucionesEmpresas.ToList();

                CD = (from cd in context.CursosDiplomadoFormacion
                                   join ins in context.InstitucionesEmpresas on cd.IdIesEmpresa equals ins.IdIE
                                   where cd.IdAcademico == id
                                   select new pCursosDiplomadoFormacion
                                   {
                                       IdCD = cd.IdCD,
                                       IdAcademico = cd.IdAcademico,
                                       Nombre = cd.Nombre,
                                       CursoDiplomado = cd.CursoDiplomado,
                                       PD = cd.PD,
                                       Horas = cd.Horas,
                                       IdIesEmpresa = cd.IdIesEmpresa,
                                       institucion = ins.Nombre,
                                       Lugar = cd.Lugar,
                                       Fecha = cd.Fecha,
                                       Archivo = cd.Archivo
                                       
                                   }
                                   ).ToList();

                ViewData["ies"] = ies;
                ViewData["cd"] = CD;
                ViewData["academico"] = id;
            }
            return View();
        }

        [Authorize]
        public IActionResult EditarCD(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pCursosDiplomadoFormacion> CD = new List<pCursosDiplomadoFormacion>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CD = (from cd in context.CursosDiplomadoFormacion
                      join ins in context.InstitucionesEmpresas on cd.IdIesEmpresa equals ins.IdIE
                      where cd.IdAcademico == id
                      select new pCursosDiplomadoFormacion
                      {
                          IdCD = cd.IdCD,
                          IdAcademico = cd.IdAcademico,
                          Nombre = cd.Nombre,
                          CursoDiplomado = cd.CursoDiplomado,
                          PD = cd.PD,
                          Horas = cd.Horas,
                          IdIesEmpresa = cd.IdIesEmpresa,
                          institucion = ins.Nombre,
                          Lugar = cd.Lugar,
                          Fecha = cd.Fecha,
                          Archivo = cd.Archivo

                      }
                                   ).ToList();
                ViewData["cd"] = CD;
                ViewData["academico"] = id;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarTablaCD(IFormFile file, CursosDiplomadoFormacion datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = "CD" + "_" + datos.IdAcademico + "_" + datos.Nombre + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.CursosDiplomadoFormacion.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = "CD" + "_" + datos.IdAcademico + "_" + datos.Nombre + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Cursos_Diplomados", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("TablaCD", new { id = datos.IdAcademico });
        }


        [Authorize]
        public IActionResult TablaEP(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pExperienciaProfesional> EP = new List<pExperienciaProfesional>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ies = context.InstitucionesEmpresas.Where(w => w.IesEmpresa == 1).ToList();
                var tp = context.TipoPuesto.ToList();

                EP = (from ep in context.ExperienciaProfesional
                      join ins in context.InstitucionesEmpresas on ep.IdEmpresa equals ins.IdIE
                      join tip in context.TipoPuesto on ep.IdTipoPuesto equals tip.IdPuesto
                      where ep.IdAcademico == id
                      select new pExperienciaProfesional
                      {
                          IdEp = ep.IdEp,
                          IdAcademico = ep.IdAcademico,
                          IdEmpresa = ep.IdEmpresa,
                          empresa = ins.Nombre,
                          IdTipoPuesto = tip.IdPuesto,
                          TipoPuesto = tip.Nombre,
                          FechaInicio = ep.FechaInicio,
                          FechaFin = ep.FechaFin,
                          AreaDesarrollo = ep.AreaDesarrollo

                      }
                                   ).ToList();


                ViewData["ies"] = ies;
                ViewData["tp"] = tp;
                ViewData["ep"] = EP;
                ViewData["academico"] = id;
            }
            return View();
        }

        [Authorize]
        public IActionResult EditarEP(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pExperienciaProfesional> EP = new List<pExperienciaProfesional>();
            using (sgcfieeContext context = new sgcfieeContext())
            {

                EP = (from ep in context.ExperienciaProfesional
                      join ins in context.InstitucionesEmpresas on ep.IdEmpresa equals ins.IdIE
                      join tip in context.TipoPuesto on ep.IdTipoPuesto equals tip.IdPuesto
                      where ep.IdAcademico == id
                      select new pExperienciaProfesional
                      {
                          IdEp = ep.IdEp,
                          IdAcademico = ep.IdAcademico,
                          IdEmpresa = ep.IdEmpresa,
                          empresa = ins.Nombre,
                          IdTipoPuesto = tip.IdPuesto,
                          TipoPuesto = tip.Nombre,
                          FechaInicio = ep.FechaInicio,
                          FechaFin = ep.FechaFin,
                          AreaDesarrollo = ep.AreaDesarrollo,
                          Archivo = ep.Archivo

                      }
                                   ).ToList();

                ViewData["ep"] = EP;
                ViewData["academico"] = id;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarTablaEP(IFormFile file, ExperienciaProfesional datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = "EP" + "_" + datos.IdAcademico + "_" + datos.IdEp + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.ExperienciaProfesional.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = "EP" + "_" + datos.IdAcademico + "_" + datos.IdEp + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Exp_Profesional", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("TablaEP", new { id = datos.IdAcademico });
        }

        [Authorize]
        public IActionResult TablaTC(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            //List<pExperienciaProfesional> EP = new List<pExperienciaProfesional>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var tl = context.TipoLaboratorio.ToList();
                var tp = context.TipoPersonal.ToList();
                ViewData["tl"] = tl;
                ViewData["tp"] = tp;
                ViewData["academico"] = id;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarTablaTC(IFormFile file, pTipoContratacion datos)
        {
            if (datos.tipopersonal == 1) {
                using (sgcfieeContext context = new sgcfieeContext())
                {
                    var new_name_table = "PTC" + "_" + datos.IdAcademico + "_" + file.GetFilename();
                    datos.Archivo = new_name_table;
                    ContratacionPtc ptc = new ContratacionPtc();
                    ptc.IdAcademico = datos.IdAcademico;
                    ptc.FechaNombramiento = datos.FechaNombramiento;
                    ptc.Archivo = datos.Archivo;
                    ptc.Status = 1;
                    context.ContratacionPtc.Add(ptc);
                    context.SaveChanges();
                }

                if (file == null || file.Length == 0)
                    return Content("file not selected");

                var new_name_file = "PTC" + "_" + datos.IdAcademico + "_" + file.GetFilename();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/ptc", new_name_file);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            if (datos.tipopersonal == 3) {
                using (sgcfieeContext context = new sgcfieeContext())
                {
                    Laboratorio lab = new Laboratorio();
                    lab.IdTipoLaboratorio = datos.IdTipoLaboratorio;
                    lab.IdAcademico = datos.IdAcademico;
                    lab.Status = 1;
                    context.Laboratorio.Add(lab);
                    context.SaveChanges();
                }
                
            }
            return RedirectToAction("TablaDistinciones", new { id = datos.IdAcademico });
        }

        [Authorize]
        public IActionResult TablaDistinciones(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var td = context.TipoDistincionTa.ToList();
                ViewData["td"] = td;
                ViewData["academico"] = id;
            }
            return View();
        }

        [Authorize]
        public IActionResult EditarDistinciones(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var td = context.TipoDistincionTa.ToList();
                var dista = context.DistincionesTa.ToList();
                var dis = new DistincionesTa();
                foreach (DistincionesTa val in dista)
                {
                    if (val.IdAcademico == id)
                    {
                        dis = val;
                    }
                }
                ViewData["td"] = td;
                ViewData["academico"] = id;
                return View(dis);
            }

            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarDistinciones(IFormFile file, DistincionesTa datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = "Dist" + "_" + datos.IdAcademico + "_" + datos.IdDistincion + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                datos.Status = 1;
                context.DistincionesTa.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = "Dist" + "_" + datos.IdAcademico + "_" + datos.IdDistincion + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Distinciones", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarDistinciones(IFormFile file, DistincionesTa datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file != null) {
                    var new_name_table = "Dist" + "_" + datos.IdAcademico + "_" + datos.IdDistincion + "_" + file.GetFilename();
                    datos.Archivo = new_name_table;
                }
                else {
                    var dis = context.DistincionesTa.Where(w => w.IdAcademico == datos.IdAcademico).Single();
                    datos.Archivo = dis.Archivo;
                }
                
                datos.Status = 1;
                context.DistincionesTa.Update(datos);
                context.SaveChanges();
            }

            if (file != null) {
                var new_name_file = "Dist" + "_" + datos.IdAcademico + "_" + datos.IdDistincion + "_" + file.GetFilename();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Distinciones", new_name_file);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            return RedirectToAction("EditarDistinciones", new { id = datos.IdAcademico});
        }

        [Authorize]
        public IActionResult DetallesDG(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");

            using (sgcfieeContext context = new sgcfieeContext()) {
                var dg = (from aca in context.Academicos
                      join pe in context.ProgramaEducativo on aca.IdProgramaEducativo equals pe.IdProgramaEducativo
                      join tp in context.TipoPersonal on aca.RTipoPersonal equals tp.IdTipoPersonal
                      where aca.IdAcademicos == id
                      select new pAcademicos
                      {
                          IdAcademicos = aca.IdAcademicos,
                          Nombre = aca.Nombre,
                          ApellidoPaterno = aca.ApellidoPaterno,
                          ApellidoMaterno = aca.ApellidoMaterno,
                          FechaNacimiento = aca.FechaNacimiento,
                          Curp = aca.Curp,
                          CorreoInstitucional = aca.CorreoInstitucional,
                          CorreoAlternativo = aca.CorreoAlternativo,
                          Celular = aca.Celular,
                          Sexo = aca.Sexo,
                          ProgramaEducativo = pe.Nombre,
                          NumeroPersonal = aca.NumeroPersonal,
                          FechaIngresoUv = aca.FechaIngresoUv,
                          Status = aca.Status,
                          RTipoPersonal = aca.RTipoPersonal,
                          tipoPersonal = tp.Nombre

                      }
                               ).Single();
                    if (dg.Sexo == 0)
                        dg.Nombre_Sexo = "Femenino";
                    if (dg.Sexo == 1)
                        dg.Nombre_Sexo = "Masculino";
                if (dg.Status == 1)
                    dg.NombreStatus = "Activo";
                if (dg.Status == 2)
                    dg.NombreStatus = "Inactivo";
                if (dg.Status == 3)
                    dg.NombreStatus = "Incapacitado";

                ViewData["academicos"] = dg;
                ViewData["academico"] = id;
            }
            return View();
        }

        [Authorize]
        public IActionResult DetallesGA(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pEstudios> estudios = new List<pEstudios>();
            using (sgcfieeContext context = new sgcfieeContext())
            {

                estudios = (from es in context.Estudios
                            join nt in context.NombreTitulo on es.IdNombreTitulo equals nt.IdNombreTitulo
                            join ie in context.InstitucionesEmpresas on es.IdInstitucion equals ie.IdIE
                            join gt in context.GradoTitulo on es.IdGradoTitulo equals gt.IdGradoTitulo
                            where es.IdAcademico == id
                            select new pEstudios
                            {
                                IdEstudios = es.IdEstudios,
                                IdAcademico = es.IdAcademico,
                                NombreTitulo = nt.Nombre,
                                Institucion = ie.Nombre,
                                GradoTitulo = gt.Nombre,
                                AcrePnpc = es.AcrePnpc,
                                FechaDeEgreso = es.FechaDeEgreso,
                                FechaDeTitulacion = es.FechaDeTitulacion,
                                ArchivoCedula = es.ArchivoCedula,
                                ArchivoTitulo = es.ArchivoTitulo
                                
                            }
                               ).ToList();

                foreach (pEstudios item in estudios)
                {
                    if (item.AcrePnpc == 0)
                        item.Reconocimiento = "Ninguno";
                    if (item.AcrePnpc == 1)
                        item.Reconocimiento = "Acreditado";
                    if (item.AcrePnpc == 0)
                        item.Reconocimiento = "PNPC";
                }
                ViewData["academico"] = id;
                ViewData["estudios"] = estudios;
            }
            return View();
        }

        public IActionResult DetallesCertificaciones(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pCertificaciones> certificaciones = new List<pCertificaciones>();
            using (sgcfieeContext context = new sgcfieeContext())
            {

                certificaciones = (from cer in context.Certificaciones
                                   join tcer in context.TipoCertificacion on cer.IdTipoCertificacion equals tcer.IdCertificacion
                                   where cer.IdAcademico == id
                                   select new pCertificaciones
                                   {
                                       IdCertificaciones = cer.IdCertificaciones,
                                       Nombre = cer.Nombre,
                                       IdTipoCertificacion = cer.IdTipoCertificacion,
                                       TipoCertificacion = tcer.Nombre,
                                       IdAcademico = cer.IdAcademico,
                                       Archivo = cer.Archivo
                                   }
                                   ).ToList();

                ViewData["cer"] = certificaciones;
                ViewData["academico"] = id;
            }
            return View();
        }

        public IActionResult DetallesCD(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pCursosDiplomadoFormacion> CD = new List<pCursosDiplomadoFormacion>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CD = (from cd in context.CursosDiplomadoFormacion
                      join ins in context.InstitucionesEmpresas on cd.IdIesEmpresa equals ins.IdIE
                      where cd.IdAcademico == id
                      select new pCursosDiplomadoFormacion
                      {
                          IdCD = cd.IdCD,
                          IdAcademico = cd.IdAcademico,
                          Nombre = cd.Nombre,
                          CursoDiplomado = cd.CursoDiplomado,
                          PD = cd.PD,
                          Horas = cd.Horas,
                          IdIesEmpresa = cd.IdIesEmpresa,
                          institucion = ins.Nombre,
                          Lugar = cd.Lugar,
                          Fecha = cd.Fecha,
                          Archivo = cd.Archivo

                      }
                                   ).ToList();
                ViewData["cd"] = CD;
                ViewData["academico"] = id;
            }
            return View();
        }

        [Authorize]
        public IActionResult DetallesEP(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pExperienciaProfesional> EP = new List<pExperienciaProfesional>();
            using (sgcfieeContext context = new sgcfieeContext())
            {

                EP = (from ep in context.ExperienciaProfesional
                      join ins in context.InstitucionesEmpresas on ep.IdEmpresa equals ins.IdIE
                      join tip in context.TipoPuesto on ep.IdTipoPuesto equals tip.IdPuesto
                      where ep.IdAcademico == id
                      select new pExperienciaProfesional
                      {
                          IdEp = ep.IdEp,
                          IdAcademico = ep.IdAcademico,
                          IdEmpresa = ep.IdEmpresa,
                          empresa = ins.Nombre,
                          IdTipoPuesto = tip.IdPuesto,
                          TipoPuesto = tip.Nombre,
                          FechaInicio = ep.FechaInicio,
                          FechaFin = ep.FechaFin,
                          AreaDesarrollo = ep.AreaDesarrollo,
                          Archivo = ep.Archivo

                      }
                                   ).ToList();

                ViewData["ep"] = EP;
                ViewData["academico"] = id;
            }
            return View();
        }

        [Authorize]
        public IActionResult DetallesTC(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var aca = context.Academicos.Where(w => w.IdAcademicos == id).Single();
                var tl = context.TipoLaboratorio.ToList();
                var tp = context.TipoPersonal.ToList();
                ViewData["idtp"] = aca.RTipoPersonal;

                foreach (TipoPersonal item in tp)
                {
                    if (item.IdTipoPersonal == aca.RTipoPersonal)
                        ViewData["tp"] = item.Nombre;
                }

                if (aca.RTipoPersonal == 1) {
                    ViewData["tc"] = context.ContratacionPtc.Where(w => w.IdAcademico == id).Single();
                }
                if (aca.RTipoPersonal == 3)
                {
                    var lab = context.Laboratorio.Where(w => w.IdAcademico == id).Single();
                    foreach (TipoLaboratorio item in tl)
                    {
                        if (item.IdTipoLaboratorio == lab.IdTipoLaboratorio)
                            ViewData["tc"] = item.Nombre;
                    }
                }

                ViewData["academico"] = id;
            }
            return View();
        }

        [Authorize]
        public IActionResult DetallesDistinciones(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var td = context.TipoDistincionTa.ToList();
                var dista = context.DistincionesTa.ToList();
                ViewData["dis"] = new DistincionesTa();
                foreach (DistincionesTa val in dista)
                {
                    if (val.IdAcademico == id)
                    {
                        ViewData["dis"] = val;
                        foreach (TipoDistincionTa item in td)
                        {
                            if (item.IdDistincion == val.IdDistincion)
                                ViewData["distincion"] = item.Nombre;
                        }
                    }
                }
            }
            ViewData["academico"] = id;
            return View();

        }
    
            












        public IActionResult EliminarAcademico(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicos eliminar = context.Academicos.Where(w => w.IdAcademicos == id).Single();
                context.Academicos.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public IActionResult EliminarGA(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Estudios eliminar = context.Estudios.Where(w => w.IdEstudios == id).Single();
                context.Estudios.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }








        public async Task<IActionResult> DescargarGA(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/DatosGenerales/Estudios", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        public async Task<IActionResult> DescargarCer(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/DatosGenerales/Certificaciones", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        public async Task<IActionResult> DescargarEP(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/DatosGenerales/Exp_Profesional", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        public async Task<IActionResult> DescargarCD(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/DatosGenerales/Cursos_Diplomados", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        public async Task<IActionResult> DescargarTC(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/DatosGenerales/ptc", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        public async Task<IActionResult> DescargarDistincion(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/DatosGenerales/Distinciones", filename);

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
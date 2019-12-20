using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGCFIEE.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace SGCFIEE.Controllers
{
    public class EstudiantesBuzonController : Controller
    {
        private string from = "pruebasgcfiee@gmail.com";
        private string to = "jonathan9623@hotmail.es";
        private string pass = "Qwerty.12";
        MailMessage m = new MailMessage();
        SmtpClient smtp = new SmtpClient();

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            if(tipo == 1)
            {
                return RedirectToAction("SeleccionarQueja");
            }
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {

                var x = context.CtProblemas.ToList();
                ViewData["problema"] = x;
                var y = context.TipoPeriodo.ToList();
                ViewData["periodo"] = y;
                var z = context.Academicos.ToList();
                ViewData["academico"] = z;
                return View();
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearSugerencia(BuzonSugerencias suge)
        {
            TbBuzonDeQuejas buzon = new TbBuzonDeQuejas();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                buzon.RPeriodo = suge.RPeriodo;
                buzon.RProblema = suge.RProblema;
                buzon.RAlumno = (int)HttpContext.Session.GetInt32("IdUsu");
                buzon.Sugerencia = suge.Sugerencia;
                buzon.Propuesta = suge.Propuesta;
                context.TbBuzonDeQuejas.Add(buzon);
                context.SaveChanges();
                TempData["mensaje"] = "Dato guardadado";
                var problem = context.CtProblemas.Where(s => s.IdCtProblemas == buzon.RProblema).Single();
                string problema = problem.NombreProblemas;
                try
                {
                    m.From = new MailAddress(from, "Jonathan Trujillo");
                    m.To.Add(new MailAddress(to));
                    m.Subject = "PROBLEMA CON: " + problema;
                    m.BodyEncoding = System.Text.Encoding.UTF8;
                    m.Body = "SITUACION: " + suge.Propuesta + "\r\nPROPUESTA: " + suge.Sugerencia;
                    m.IsBodyHtml = true;
                    smtp.Host = "smtp.gmail.com";
                    smtp.UseDefaultCredentials = true;
                    smtp.Port = 587;
                    smtp.Credentials = new NetworkCredential(from, pass);
                    smtp.EnableSsl = true;
                    smtp.Send(m);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearSugerenciaAca(BuzonSugerencias sugere)
        {

            TbBuzonAcademicos buzon = new TbBuzonAcademicos();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                buzon.RAcademicos = sugere.RAcademicos;
                buzon.RPeriodo = sugere.RPeriodo.Value;
                buzon.Propuesta = sugere.Propuesta;
                buzon.RAlumno = (int)HttpContext.Session.GetInt32("IdUsu");
                buzon.Sugerencia = sugere.Sugerencia;
                context.TbBuzonAcademicos.Add(buzon);
                context.SaveChanges();
                TempData["mensaje"] = "Dato guardado";
                var aca = context.Academicos.Where(s => s.IdAcademicos == sugere.RAcademicos).Single();
                string academico = aca.Nombre;
                try
                {
                    m.From = new MailAddress(from);
                    m.To.Add(new MailAddress(to));
                    m.Subject = "PROBLEMA CON:" + academico;
                    m.Body = "SITUACION: " + sugere.Propuesta + "\r\nPROPUESTA: " + sugere.Sugerencia;
                    smtp.Host = "smtp.gmail.com";
                    smtp.UseDefaultCredentials = true;
                    smtp.Port = 587;
                    smtp.Credentials = new NetworkCredential(from, pass);
                    smtp.EnableSsl = true;
                    smtp.Send(m);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        [Authorize]
        public IActionResult CrearProblema()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearProblema(CtProblemas problema)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CtProblemas.Add(problema);
                context.SaveChanges();
                TempData["mensaje"] = "Dato guardado";
                return RedirectToAction("Index");
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult SeleccionarQueja()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }

        [Authorize]
        public IActionResult CargarTabla(CtMovilidades queja)
        {
            int x = queja.TipoMovilidades.Value;
            if(x == 0)
            {
                return RedirectToAction("SeleccionarQueja");
            }
            if(x == 1)
            {
                return RedirectToAction("TablaInfrestructura");
            }
            else
            {
                return RedirectToAction("TablaAcademicos");
            }
        }

        [Authorize]
        public IActionResult TablaInfrestructura()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<TablaSugerenciasBuzon> suge = new List<TablaSugerenciasBuzon>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                suge = (from t in context.TbBuzonDeQuejas
                           join
                            p in context.CtProblemas on t.RProblema equals p.IdCtProblemas
                           join
                           a in context.Alumnos on t.RAlumno equals a.IdAlumnos
                           join
                           d in context.DatosPersonales on a.RDatosPerson equals d.IdDatosPersonales
                           join
                           o in context.TipoPeriodo on t.RPeriodo equals o.IdPeriodo
                           select
                           new TablaSugerenciasBuzon
                           {
                               idtb = t.IdTbBuzonDeQuejas,
                               nombrePro = p.NombreProblemas,
                               nombreAlu = d.Nombre,
                               apeAluP = d.ApellidoPaterno,
                               apeAluM = d.ApellidoMaterno,
                               nomPeri = o.Nombre,
                               sugerencia = t.Sugerencia,
                               propuesta = t.Propuesta
                           }
                          ).ToList();
                ViewData["lista"] = suge;
            }
            return View();
        }

        [Authorize]
        public IActionResult TablaAcademicos()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<TablaSugerenciasBuzon> suge = new List<TablaSugerenciasBuzon>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                suge = (from t in context.TbBuzonAcademicos
                        join
                         p in context.Academicos on t.RAcademicos equals p.IdAcademicos
                        join
                        a in context.Alumnos on t.RAlumno equals a.IdAlumnos
                        join
                        d in context.DatosPersonales on a.RDatosPerson equals d.IdDatosPersonales
                        join
                        o in context.TipoPeriodo on t.RPeriodo equals o.IdPeriodo
                        select
                        new TablaSugerenciasBuzon
                        {
                            idtb = t.IdBuzonAcademicos,
                            nombreAlu = d.Nombre,
                            apeAluP = d.ApellidoPaterno,
                            apeAluM = d.ApellidoMaterno,
                            nomPeri = o.Nombre,
                            sugerencia = t.Sugerencia,
                            propuesta = t.Propuesta,
                            nombreMaestro = p.Nombre,
                            apePat = p.ApellidoPaterno,
                            apeMaP = p.ApellidoMaterno
                        }
                          ).ToList();
                ViewData["lista"] = suge;
            }
            return View();
        }
    }
}

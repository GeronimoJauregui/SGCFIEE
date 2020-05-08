using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGCFIEE.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace SGCFIEE.Controllers
{
    public class EstudiantesPafisController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<TablaPafi> tb_pafi = new List<TablaPafi>();
            List<TbPafisAlumno> pafi_alum = new List<TbPafisAlumno>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                tb_pafi = (from d in context.PafisAcademicos
                           join
                            p in context.ProgramaEducativo on d.IdProgramaImpacta equals p.IdProgramaEducativo
                           join
                           a in context.Academicos on d.IdAcademico equals a.IdAcademicos
                           join
                           s in context.TbSalones on d.IdSalon equals s.IdTbSalones
                           select
                           new TablaPafi
                           {
                               idPafi = d.IdPafis,
                               NombrePafi = d.Nombre,
                               Horario = d.Horario,
                               NombreMaestro = a.Nombre,
                               ApePaterno = a.ApellidoPaterno,
                               ApeMaterno = a.ApellidoMaterno,
                               ClvSalon = s.ClaveSalon,
                               ProgrmaEdu = p.Nombre,
                               ocupado = 0,
                               estado = d.Estado.Value
                           }
                          ).Where(s => s.estado == 0).ToList();
                pafi_alum = context.TbPafisAlumno.ToList();
            }
            foreach (TablaPafi item1 in tb_pafi)
            {
                int cont = 0;
                foreach (TbPafisAlumno item2 in pafi_alum)
                {
                    if(item1.idPafi == item2.RInfopafi)
                    {
                        cont++;
                    }

                }
                item1.TotalAlum = cont;
            }

            return View(tb_pafi);

        }

        [Authorize]
        public IActionResult DetallesPafi(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<InformacionPafiCompleta> tb_pafi = new List<InformacionPafiCompleta>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                tb_pafi = (from p in context.TbPafisAlumno
                           join pa in context.PafisAcademicos on p.RInfopafi equals pa.IdPafis
                           join a in context.Academicos on pa.IdAcademico equals a.IdAcademicos
                           join pe in context.TipoPeriodo on pa.IdPeriodo equals pe.IdPeriodo
                           join s in context.TbSalones on pa.IdSalon equals s.IdTbSalones
                           join pi in context.ProgramaEducativo on pa.IdProgramaImpacta equals pi.IdProgramaEducativo

                           join al in context.Alumnos on p.RAlumno equals al.IdAlumnos
                           join dp in context.DatosPersonales on al.RDatosPerson equals dp.IdDatosPersonales
                           select
                           new InformacionPafiCompleta
                           {
                               idpafi = p.RInfopafi,
                               alumno = dp.Nombre + " " + dp.ApellidoPaterno + " " + dp.ApellidoMaterno,
                               academico = a.Nombre + " " + a.ApellidoPaterno + " " + a.ApellidoMaterno,
                               matricula = al.Matricula,
                               nombrePafi = pa.Nombre,
                               Horas = pa.NumHoras,
                               salon = s.Edificio + " " + s.ClaveSalon,
                               programa = pi.Nombre,
                               horario = pa.Horario,
                               tipoPafi = pa.Tipopafi

                           }).Where(p => p.idpafi == id).ToList(); 
            }
            
            return View(tb_pafi);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult SolicitudPafi()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var x = context.Academicos.ToList();
                var y = context.TbSalones.ToList();
                var z = context.TipoPeriodo.ToList();
                ViewData["academicos"] = x;
                ViewData["salones"] = y;
                ViewData["periodos"] = z;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Crear(PafisAcademicos pafis)
        {
            TbPafisAlumno tbpafi = new TbPafisAlumno();
            tbpafi.RAlumno = (int)HttpContext.Session.GetInt32("IdUsu");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.PafisAcademicos.Add(pafis);
                context.SaveChanges();
                TempData["Mensaje"] = "Datos registrados";
                var x = context.PafisAcademicos.Last();
                int idpafinuevo = x.IdPafis;
                tbpafi.RInfopafi = idpafinuevo;
                context.TbPafisAlumno.Add(tbpafi);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult Inscribir(int id)
        {
            TbPafisAlumno pafis = null;
            TbPafisAlumno nuevo = new TbPafisAlumno();
            int alum = (int)HttpContext.Session.GetInt32("IdUsu");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                pafis = context.TbPafisAlumno.Where(a => a.RAlumno == alum && a.RInfopafi == id).FirstOrDefault();
                if (pafis == null)
                {
                    nuevo.RAlumno = alum;
                    nuevo.RInfopafi = id;
                    context.TbPafisAlumno.Add(nuevo);
                    context.SaveChanges();
                    TempData["Mensaje"] = "Datos registrados";
                }
            }
            return RedirectToAction("Index");
        }
        
        public IActionResult Desenlistar(int id)
        {
            int alum = (int)HttpContext.Session.GetInt32("IdUsu");
            TbPafisAlumno tbpafi = null;
            using (sgcfieeContext context = new sgcfieeContext())
            {
                tbpafi = context.TbPafisAlumno.Where(s => s.RAlumno == alum && s.RInfopafi.Value == id).SingleOrDefault();
                if (tbpafi != null)
                {
                    context.TbPafisAlumno.Remove(tbpafi);
                    context.SaveChanges();
                    int x = 0;
                    x = context.TbPafisAlumno.Where(a => a.RInfopafi.Value == id).Count();
                    if (x < 1)
                    {
                        PafisAcademicos pafi = context.PafisAcademicos.Where(b => b.IdPafis == id).Single();
                        context.PafisAcademicos.Remove(pafi);
                        context.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index");
        }

        
    }
}
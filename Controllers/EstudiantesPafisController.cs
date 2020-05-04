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
            //List<TablaPafi> tb_paficito = new List<TablaPafi>();
            List<TablaPafi> tb_pafi = new List<TablaPafi>();
            List<TablaPafi> correcto = new List<TablaPafi>();
            TablaPafi aux = new TablaPafi();
            List<TbPafisAlumno> pafi_alum = new List<TbPafisAlumno>();
            int idAlu = (int)HttpContext.Session.GetInt32("IdUsu");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                tb_pafi = (from d in context.TbPafisAlumno
                           join
                            p in context.PafisAcademicos on d.RInfopafi equals p.IdPafis
                           join
                           a in context.Academicos on p.IdAcademico equals a.IdAcademicos
                           join
                           s in context.TbSalones on p.IdSalon equals s.IdTbSalones
                           select
                           new TablaPafi
                           {
                               idPafi = p.IdPafis,
                               NombrePafi = p.Nombre,
                               Horario = p.Horario,
                               NombreMaestro = a.Nombre,
                               ApePaterno = a.ApellidoPaterno,
                               ApeMaterno = a.ApellidoMaterno,
                               ClvSalon = s.ClaveSalon,
                               ocupado = 0,
                               estado = p.Estado.Value
                           }
                          ).Where(s => s.estado == 0).ToList();
                pafi_alum = context.TbPafisAlumno.Where(s => s.RAlumno.Equals(idAlu)).ToList();
            }

            foreach (TablaPafi t in tb_pafi)
            {
                foreach (TbPafisAlumno pa in pafi_alum)
                {
                    if (t.idPafi == pa.RInfopafi)
                    {
                        t.ocupado = 1;
                    }
                }
            }
            if (tb_pafi.Count > 0)
            {
                foreach (TablaPafi tp in tb_pafi)
                {
                    int contador = 0;
                    foreach (TablaPafi dato in tb_pafi)
                    {
                        if (tp.idPafi == dato.idPafi)
                        {
                            contador++;
                        }
                    }
                    tp.TotalAlum = contador;
                }
                foreach (TablaPafi tb in tb_pafi)
                {
                    if (correcto.Count == 0)
                    {
                        correcto.Add(tb);
                    }
                    else
                    {
                        int bandera = 0;
                        foreach (TablaPafi c in correcto)
                        {
                            if (c.idPafi == tb.idPafi)
                            {
                                bandera = 1;
                            }
                        }
                        if (bandera == 0)
                        {
                            correcto.Add(tb);
                        }
                    }
                }
                foreach (TablaPafi table in correcto)
                {
                    String nom = table.NombreMaestro;
                    nom = nom + " " + table.ApePaterno;
                    nom = nom + " " + table.ApeMaterno;
                    table.NombreMaestro = nom;
                }
            }

            if (correcto.Count > 0)
            {
                return View(correcto);
            }
            else
            {
                return View(tb_pafi);
            }

        }
        [Authorize]
        public IActionResult FormEditar(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            PafisAcademicos pafi;
            using (sgcfieeContext context = new sgcfieeContext())
            {
                pafi = context.PafisAcademicos.Where(s => s.IdPafis == id).Single();
                var x = context.TbSalones.ToList();
                var y = context.Academicos.ToList();
                ViewData["salones"] = x;
                ViewData["academicos"] = y;
            }
            return View(pafi);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Editar(PafisAcademicos pafis)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.PafisAcademicos.Update(pafis);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            return RedirectToAction("Index");
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
                ViewData["academicos"] = x;
                ViewData["salones"] = y;
            }
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize]
        //public IActionResult Crear(PafisAcademicos pafis)
        //{
        //    DateTime fech = DateTime.Today.Date;
        //    int mes, ano;
        //    mes = fech.Month;
        //    ano = fech.Year;
        //    pafis.Estado = 0;
        //    pafis.NumHoras = 20;
        //    pafis.Tipopafi = 0;
        //    pafis.Solicitud = 0;
        //    TbPafisAlumno tbpafi = new TbPafisAlumno();
        //    int idPa = 0;
        //    tbpafi.RAlumno = (int)HttpContext.Session.GetInt32("IdUsu");
        //    List<TipoPeriodo> tp = new List<TipoPeriodo>();
        //    using (sgcfieeContext context = new sgcfieeContext())
        //    {
        //        tp = context.TipoPeriodo.ToList();
        //        foreach (TipoPeriodo periodo in tp)
        //        {
        //            int mes2, ano2;
        //            DateTime dt = periodo.FechaInicio.Value;
        //            mes2 = dt.Month;
        //            ano2 = dt.Year;
        //            if (mes2 <= mes && ano2 <= ano)
        //            {
        //                DateTime dt2 = periodo.FechaFin.Value;
        //                mes2 = dt2.Month;
        //                ano2 = dt2.Year;
        //                if (ano2 == ano)
        //                {
        //                    if (mes2 >= mes)
        //                    {
        //                        idPa = periodo.IdPeriodo;
        //                        break;
        //                    }
        //                }
        //                else
        //                {
        //                    if (ano2 > ano)
        //                    {
        //                        idPa = periodo.IdPeriodo;
        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //        if (idPa == 0)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        pafis.IdPeriodo = idPa;
        //        context.PafisAcademicos.Add(pafis);
        //        context.SaveChanges();
        //        TempData["Mensaje"] = "Datos registrados";
        //        var x = context.PafisAcademicos.Last();
        //        int idpafinuevo = x.IdPafis;
        //        tbpafi.RInfopafi = idpafinuevo;
        //        context.TbPafisAlumno.Add(tbpafi);
        //        context.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}
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
        [Authorize]
        public IActionResult DetallesPafi(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<InformacionPafiCompleta> tb_pafi = new List<InformacionPafiCompleta>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                tb_pafi = (from p in context.PafisAcademicos
                           join a in context.Academicos on p.IdAcademico equals a.IdAcademicos
                           join s in context.TbSalones on p.IdSalon equals s.IdTbSalones
                           select
                           new InformacionPafiCompleta
                           {
                               idPafi = p.IdPafis,
                               nombrePafi = p.Nombre,
                               Horario = p.Horario,
                               nombreMaestro = a.Nombre,
                               ApePaterno = a.ApellidoPaterno,
                               ApeMaterno = a.ApellidoMaterno,
                               clave_salon = s.ClaveSalon,
                               estado = p.Estado.Value,
                               totHoras = p.NumHoras
                           }).ToList();
            }
            InformacionPafiCompleta correcto = new InformacionPafiCompleta();
            foreach (InformacionPafiCompleta item in tb_pafi)
            {
                if (item.idPafi == id)
                {
                    if (item.estado == 0)
                    {
                        item.edo = "Solicitud";
                    }
                    correcto = item;
                    break;
                }
            }
            return View(correcto);
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

        public IActionResult Eliminar(int id)
        {
            PafisAcademicos pafi;
            List<TbPafisAlumno> pafis = new List<TbPafisAlumno>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                pafis = context.TbPafisAlumno.Where(w => w.RInfopafi.Value == id).ToList();
                foreach (TbPafisAlumno item in pafis)
                {
                    context.TbPafisAlumno.Remove(item);
                    context.SaveChanges();
                }
                pafi = context.PafisAcademicos.Where(s => s.IdPafis == id).Single();
                context.PafisAcademicos.Remove(pafi);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            //return RedirectToAction("Index");
        }
    }
}
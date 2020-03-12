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
    public class EstudiantesComplementariaController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        [HttpGet]
        [Authorize]
        public IActionResult CrearPrograma()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearPrograma(ProgramaEducativo programa)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.ProgramaEducativo.Add(programa);
                context.SaveChanges();
                TempData["Mensaje"] = "Programa agregado correctamente";
                return RedirectToAction("MostrarProgramas");
            }
        }
        [Authorize]
        public IActionResult MostrarProgramas()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var lista = context.ProgramaEducativo.ToList();
                return View(lista);
            }

        }
        [Authorize]
        public IActionResult DetallesPrograma(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var lista = context.ProgramaEducativo.Where(s => s.IdProgramaEducativo == id).Single();
                return View(lista);
            }
        }
        [HttpGet]
        [Authorize]
        public IActionResult EditarPrograma(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var objeto = context.ProgramaEducativo.Where(o => o.IdProgramaEducativo == id).Single();
                return View(objeto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarPrograma(ProgramaEducativo programa)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.ProgramaEducativo.Update(programa);
                context.SaveChanges();
                TempData["mensaje"] = "Datos actualizados correctamente";
                return RedirectToAction("MostrarProgramas");
            }
        }
        [HttpGet]
        public IActionResult EliminarPrograma(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var programa = context.ProgramaEducativo.Where<ProgramaEducativo>(p => p.IdProgramaEducativo == id).Single<ProgramaEducativo>();
                if (programa == null) return NotFound();
                context.ProgramaEducativo.Remove(programa);
                context.SaveChanges();
                TempData["Mensaje"] = "Dato eliminado";
                return RedirectToAction("MostrarProgramas");
            }
        }
        [HttpGet]
        [Authorize]
        public IActionResult CrearRubro()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearRubro(TbRubrosexamenes rubro)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TbRubrosexamenes.Add(rubro);
                context.SaveChanges();
                TempData["Mensaje"] = "Rubro guardado correctamente";
                return RedirectToAction("MostrarRubro");
            }
        }
        [Authorize]
        public IActionResult MostrarRubro()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var lista = context.TbRubrosexamenes.ToList();
                return View(lista);
            }
        }
        [HttpGet]
        [Authorize]
        public IActionResult EditarRubro(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var objeto = context.TbRubrosexamenes.Where(o => o.IdTbRubrosExamenes == id).First();
                return View(objeto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarRubro(TbRubrosexamenes rubro)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TbRubrosexamenes.Update(rubro);
                context.SaveChanges();
                TempData["mensaje"] = "datos actualziados correctamente";
                return RedirectToAction("MostrarRubro");
            }
        }
        
        [HttpGet]
        public IActionResult EliminarRubro(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var rubro = context.TbRubrosexamenes.Where<TbRubrosexamenes>(r => r.IdTbRubrosExamenes == id).Single<TbRubrosexamenes>();
                if (rubro == null) return NotFound();
                context.TbRubrosexamenes.Remove(rubro);
                context.SaveChanges();
                TempData["Mensaje"] = "Eelemento elimindado";
                return RedirectToAction("MostrarRubro");
            }

        }
        [HttpGet]
        [Authorize]
        public IActionResult CrearSalon()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearSalon(TbSalones salon)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TbSalones.Add(salon);
                context.SaveChanges();
                TempData["Mensaje"] = "Salon agregado correctamente";
                return RedirectToAction("MostrarSalon");
            }
        }
        [Authorize]
        public IActionResult MostrarSalon()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var lista = context.TbSalones.ToList();
                return View(lista);
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult EditarSalon(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var objeto = context.TbSalones.Where(o => o.IdTbSalones == id).Single();
                return View(objeto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarSalon(TbSalones salon)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TbSalones.Update(salon);
                context.SaveChanges();
                TempData["mensaje"] = "datos actualziados correctamente";
                return RedirectToAction("MostrarSalon");
            }
        }
        [HttpGet]
        public IActionResult EliminarSalon(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var salon = context.TbSalones.Where<TbSalones>(p => p.IdTbSalones == id).Single<TbSalones>();
                if (salon == null) return NotFound();
                context.TbSalones.Remove(salon);
                context.SaveChanges();
                TempData["Mensaje"] = "Dato eliminado";
                return RedirectToAction("MostrarSalon");
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult CrearArea()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearArea(AreaExperienciaEducativa area)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.AreaExperienciaEducativa.Add(area);
                context.SaveChanges();
                TempData["mensaje"] = "El area se guardo correctamente";
                return RedirectToAction("MostrarArea");
            }
        }
        [Authorize]
        public IActionResult MostrarArea()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var lista = context.AreaExperienciaEducativa.ToList();
                return View(lista);
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult EditarArea(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var objeto = context.AreaExperienciaEducativa.Where(o => o.IdAreaExperienciaEducativa == id).Single();
                return View(objeto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarArea(AreaExperienciaEducativa area)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.AreaExperienciaEducativa.Update(area);
                context.SaveChanges();
                TempData["mensaje"] = "datos acrualizados correctamente";
                return RedirectToAction("MostrarArea");
            }
        }
        [HttpGet]
        public IActionResult EliminarArea(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var area = context.AreaExperienciaEducativa.Where<AreaExperienciaEducativa>(p => p.IdAreaExperienciaEducativa == id).Single<AreaExperienciaEducativa>();
                if (area == null) return NotFound();
                context.AreaExperienciaEducativa.Remove(area);
                context.SaveChanges();
                TempData["Mensaje"] = "Dato eliminado";
                return RedirectToAction("MostrarSalon");
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult CrearExperiencia()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var x = context.AreaExperienciaEducativa.ToList();
                ViewData["area"] = x;
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearExperiencia(ExperienciaEducativa expe)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.ExperienciaEducativa.Add(expe);
                context.SaveChanges();
                TempData["Mensaje"] = "Experiencia agregada correctamente";
                return RedirectToAction("MostrarExperiencia");
            }
        }
        [Authorize]
        public IActionResult MostrarExperiencia()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<TablaExperiencia> list = new List<TablaExperiencia>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                list = (from a in context.AreaExperienciaEducativa
                        join
                        e in context.ExperienciaEducativa on a.IdAreaExperienciaEducativa equals e.IdArea
                        select
                        new TablaExperiencia
                        {
                            IdExperienciaEducativa = e.IdExperienciaEducativa,
                            Nombre = e.Nombre,
                            Creditos = e.Creditos,
                            Horas = e.Horas,
                            Nombrearea = a.Nombre
                        }).ToList();
                return View(list);
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult EditarExperiencia(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var x = context.AreaExperienciaEducativa.ToList();
                ViewData["areae"] = x;
                var objeto = context.ExperienciaEducativa.Where(o => o.IdExperienciaEducativa == id).Single();
                return View(objeto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarExperiencia(ExperienciaEducativa expe)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {

                context.ExperienciaEducativa.Update(expe);
                context.SaveChanges();
                TempData["Mensjae"] = "datos actualziados correctamente";
                return RedirectToAction("MostrarExperiencia");
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult CrearMovilidad()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearMovilidad(CtMovilidades movi)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CtMovilidades.Add(movi);
                context.SaveChanges();
                TempData["Mensaje"] = "Movildiad guardada correctamente";
                return RedirectToAction("MostrarMovilidad");
            }
        }
        [Authorize]
        public IActionResult MostrarMovilidad()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var lista = context.CtMovilidades.ToList();
                return View(lista);
            }
        }
        [Authorize]
        public IActionResult DetallesMovilidad(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var detalle = context.CtMovilidades.Where(s => s.IdCtMovilidades == id).Single();
                return View(detalle);
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult EditarMovilidad(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var objeto = context.CtMovilidades.Where(o => o.IdCtMovilidades == id).Single();
                return View(objeto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarMovilidad(CtMovilidades movi)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CtMovilidades.Update(movi);
                context.SaveChanges();
                TempData["Mensaje"] = "Datos actualizados correctamente";
                return RedirectToAction("MostrarMovilidad");
            }
        }
        [HttpGet]
        public IActionResult EliminarMovilidad(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var movi = context.CtMovilidades.Where<CtMovilidades>(p => p.IdCtMovilidades == id).Single<CtMovilidades>();
                if (movi == null) return NotFound();
                context.CtMovilidades.Remove(movi);
                context.SaveChanges();
                TempData["Mensaje"] = "Dato eliminado";
                return RedirectToAction("MostrarSalon");
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult CrearTipo()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearTipo(CtTipoCalificacion tip)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CtTipoCalificacion.Add(tip);
                context.SaveChanges();
                TempData["Mensaje"] = "El tipo se ha guardado correctamente";
                return RedirectToAction("MostrarTipo");
            }
        }
        [Authorize]
        public IActionResult MostrarTipo()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var lista = context.CtTipoCalificacion.ToList();
                return View(lista);
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult EditarTipo(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var objeto = context.CtTipoCalificacion.Where(o => o.IdCtTipoCalificacion == id).Single();
                return View(objeto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarTipo(CtTipoCalificacion cali)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CtTipoCalificacion.Update(cali);
                context.SaveChanges();
                TempData["Menssaje"] = "Datos actualizados correctamente";
                return RedirectToAction("MostrarTipo");
            }
        }
        [HttpGet]
        public IActionResult EliminarTipo(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var tipo = context.CtTipoCalificacion.Where<CtTipoCalificacion>(p => p.IdCtTipoCalificacion == id).Single<CtTipoCalificacion>();
                if (tipo == null) return NotFound();
                context.CtTipoCalificacion.Remove(tipo);
                context.SaveChanges();
                TempData["Mensaje"] = "Dato eliminado";
                return RedirectToAction("MostrarTipo");
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult CrearTipoe()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearTipoe(TipoEventos tipoe)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoEventos.Add(tipoe);
                context.SaveChanges();
                TempData["Mensaje"] = "El tipo de evento ha sido guardado";
                return RedirectToAction("MostrarTipoe");
            }
        }
        [Authorize]
        public IActionResult MostrarTipoe()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var lista = context.TipoEventos.ToList();
                return View(lista);
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult EditarTipoe(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var objeto = context.TipoEventos.Where(o => o.IdEventos == id).Single();
                return View(objeto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarTipoe(TipoEventos tipoe)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoEventos.Update(tipoe);
                context.SaveChanges();
                TempData["Mensaje"] = "Datos actualziados correctamente";
                return RedirectToAction("MostrarTipoe");
            }
        }
        [HttpGet]
        public IActionResult EliminarTipoe(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var tipoe = context.TipoEventos.Where<TipoEventos>(p => p.IdEventos == id).Single<TipoEventos>();
                if (tipoe == null) return NotFound();
                context.TipoEventos.Remove(tipoe);
                context.SaveChanges();
                TempData["Mensaje"] = "Dato eliminado";
                return RedirectToAction("MostrarTipoe");
            }
        }
        [HttpGet]
        [Authorize]
        public IActionResult CrearEvento()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var x = context.TipoEventos.ToList();
                ViewData["e"] = x;
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearEvento(TbEventos evento)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TbEventos.Add(evento);
                context.SaveChanges();
                TempData["Mensaje"] = "Evento guardado correctamente";
                return RedirectToAction("MostrarEvento");
            }
        }
        [Authorize]
        public IActionResult MostrarEvento()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<TablaEvento> list = new List<TablaEvento>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                list = (from t in context.TbEventos
                        join e in context.TipoEventos on t.RTioEvento equals e.IdEventos
                        select
                        new TablaEvento
                        {
                            IdEventos = t.IdEventos,
                            Nombre = e.Nombre,
                            NombreEvento = t.Nombre
                        }).ToList();
                return View(list);
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult EditarEvento(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var x = context.TipoEventos.ToList();
                ViewData["evento"] = x;
                var objeto = context.TbEventos.Where(o => o.IdEventos == id).Single();
                return View(objeto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarEvento(TbEventos eve)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TbEventos.Update(eve);
                context.SaveChanges();
                TempData["mensaje"] = "Datos actualizados correctamente";
                return RedirectToAction("MostrarEvento");
            }
        }
        [HttpGet]
        public IActionResult EliminarEventoe(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var evento = context.TbEventos.Where<TbEventos>(p => p.IdEventos == id).Single<TbEventos>();
                if (evento == null) return NotFound();
                context.TbEventos.Remove(evento);
                context.SaveChanges();
                TempData["Mensaje"] = "Dato eliminado";
                return RedirectToAction("MostrarEvento");
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}